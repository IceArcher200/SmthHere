using System.ComponentModel;
using System.IO;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Library;
using Library.MyEntities;
using LibraryInterface.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext dbForUser = new ApplicationContext();
        public List<Library.MyEntities.UserInfo> userInfo = new List<Library.MyEntities.UserInfo>();
        public ApplicationContext DbForUser { get { return dbForUser; } set { dbForUser = value; } }
        ApplicationContext db = new ApplicationContext();

        List<MenuInfo> menuInfos = new List<MenuInfo>();

        bool strangeEvent = false;
        bool edit = false;
        bool editCurrentMenu = false;
        bool antiLoop = false;
        public MainWindow()
        {
            new Authorization().ShowDialog();
            InitializeComponent();

            menuInfos = db.MenuInfo.OrderBy(o => o.ParentId).ToList();
            List<MenuItem> mainMenuItems = new List<MenuItem>();
            List<MenuInfo> mainMenuInfos = new List<MenuInfo>();
            for (int i = 0; i < menuInfos.Count; i++)
            {
                MyMenuItem item = new MyMenuItem();
                item.Id = menuInfos[i].Id;
                for (int k = 0; k < userInfo.Count; k++)
                {
                    if (item.Id == userInfo[k].MenuInfoId)
                    {
                        if (userInfo[k].Read == false)
                        {
                            item.Visibility = Visibility.Collapsed;
                            break;
                        }
                    }
                }

                item.Header = menuInfos[i].Title;
                RoutedEventHandler? handler = null;
                if (menuInfos[i].NameOfFunc != "")
                {
                    handler = (RoutedEventHandler)Delegate.CreateDelegate(typeof(RoutedEventHandler), this, menuInfos[i].NameOfFunc);
                    item.Click += handler;
                }
                if (menuInfos[i].ParentId == 0)
                {
                    mainMenuInfos.Add(menuInfos[i]);
                    mainMenuItems.Add(item);
                    continue;
                }

                for (int j = 0; j < mainMenuItems.Count; j++)
                {
                    if (mainMenuInfos[j].Id == menuInfos[i].ParentId)
                    {
                        mainMenuItems[j].Items.Add(item);
                    }
                }
            }
            for (int i = 0; i < mainMenuItems.Count; i++)
            {
                menu.Items.Add(mainMenuItems[i]);
            }



            firstGrid.InitializingNewItem += FirstGrid_InitializingNewItem;
            firstGrid.PreviewKeyDown += FirstGrid_PreviewKeyDown;
            firstGrid.CanUserAddRows = false;
            firstGrid.CanUserDeleteRows = false;
            firstGrid.IsReadOnly = true;
            firstGrid.IsLocked = false;

        }



        private void FirstGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Delete == e.Key)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    foreach (var row in grid.SelectedItems)
                    {
                        if (row is UserInfo)
                        {
                            db.UserInfo.Remove((UserInfo)row);
                            return;
                        }
                        db.Remove(row);
                    }

                }
            }
        }

        private void FirstGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {

            if (e.NewItem is UserInfo)
            {
                db.UserInfo.Add((UserInfo)e.NewItem);
                return;
            }

            if (e.NewItem is User)
            {
                db.Users.Add((User)e.NewItem);
                return;
            }

            db.Add(e.NewItem);

        }

        private void DataGridChanged(object sender, SelectionChangedEventArgs e)
        {
            var source = e.RemovedItems;
            if (source.Count > 0 && antiLoop == false)
            {
                if (firstGrid.IsLocked == false && e.RemovedItems[0] is DateTime)
                {

                    antiLoop = true;
                    var datePicker = sender as DatePicker;
                    datePicker!.SelectedDate = (DateTime)source[0]!;

                }
                antiLoop = false;
            }

        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;

            Granting_Rights(info);
            DataGridTextColumn col1 = new DataGridTextColumn();
            col1.Header = "Имя";
            col1.Binding = new Binding("Name");
            firstGrid.Columns.Add(col1);


            DataGridTextColumn col2 = new DataGridTextColumn();
            col2.Header = "Фамилия";
            col2.Binding = new Binding("Surname");
            firstGrid.Columns.Add(col2);


            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Отчество";
            col3.Binding = new Binding("Patronymic");
            firstGrid.Columns.Add(col3);

            DataGridTextColumn col4 = new DataGridTextColumn();
            col4.Header = "Дата рождения";
            col4.Binding = new Binding("Birthday");
            col4.Binding.StringFormat = "dd/MM/yyyy";
            firstGrid.Columns.Add(col4);

            DataGridComboBoxColumn comboColumn2 = new DataGridComboBoxColumn();
            comboColumn2.Header = "Специальность";
            comboColumn2.ItemsSource = db.Specialty.ToList();
            comboColumn2.SelectedValueBinding = new Binding("SpecialtyID");
            comboColumn2.SelectedValuePath = "ID";
            comboColumn2.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn2);

            DataGridNumericColumn col6 = new DataGridNumericColumn();
            col6.Header = "Опыт работы";
            col6.Binding = new Binding("Experience");
            firstGrid.Columns.Add(col6);

            DataGridNumericColumn col7 = new DataGridNumericColumn();
            col7.Header = "Серия и номер паспорта";
            col7.Binding = new Binding("Passport_Number");
            firstGrid.Columns.Add(col7);

            DataGridTextColumn col8 = new DataGridTextColumn();
            col8.Header = "Дата выдачи паспорта";
            col8.Binding = new Binding("Passport_Receipt_Date");
            col8.Binding.StringFormat = "dd/MM/yyyy";
            firstGrid.Columns.Add(col8);

            DataGridTextColumn col9 = new DataGridTextColumn();
            col9.Header = "Кем выдан паспорт";
            col9.Binding = new Binding("Passport_Given_By");
            firstGrid.Columns.Add(col9);

            DataGridTextColumn col10 = new DataGridTextColumn();
            col10.Header = "Дата регистрации";
            col10.Binding = new Binding("Register_Date");
            col10.Binding.StringFormat = "dd/MM/yyyy";
            firstGrid.Columns.Add(col10);

            DataGridTextColumn col13 = new DataGridTextColumn();
            col13.Header = "Название уч.заведения";
            col13.Binding = new Binding("Institutuion_Name");
            firstGrid.Columns.Add(col13);

            DataGridTextColumn col14 = new DataGridTextColumn();
            col14.Header = "Номер документа";
            col14.Binding = new Binding("EducationIndex");
            firstGrid.Columns.Add(col14);

            DataGridComboBoxColumn comboColumn3 = new DataGridComboBoxColumn();
            comboColumn3.Header = "Уровень образования";
            comboColumn3.ItemsSource = db.EducationLevel.ToList();
            comboColumn3.SelectedValueBinding = new Binding("EducationLevelID");
            comboColumn3.SelectedValuePath = "ID";
            comboColumn3.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn3);

            DataGridComboBoxColumn comboColumn4 = new DataGridComboBoxColumn();
            comboColumn4.Header = "Улица";
            comboColumn4.ItemsSource = db.Street.ToList();
            comboColumn4.SelectedValueBinding = new Binding("StreetID");
            comboColumn4.SelectedValuePath = "ID";
            comboColumn4.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn4);

            DataGridTextColumn col11 = new DataGridTextColumn();
            col11.Header = "Дом";
            col11.Binding = new Binding("House");
            firstGrid.Columns.Add(col11);

            DataGridTextColumn col12 = new DataGridTextColumn();
            col12.Header = "Пособие";
            col12.Binding = new Binding("Payment");
            firstGrid.Columns.Add(col12);




            firstGrid.ItemsSource = db.Client.ToList();
            firstGrid.Visibility = Visibility.Visible;

        }

        private void Archival_Vacancy_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;

            Granting_Rights(info);

            DataGridComboBoxColumn comboColumn3 = new DataGridComboBoxColumn();
            comboColumn3.Header = "Вакансия";
            comboColumn3.ItemsSource = db.Vacancy.ToList();
            comboColumn3.SelectedValueBinding = new Binding("VacancyID");
            comboColumn3.SelectedValuePath = "ID";
            comboColumn3.DisplayMemberPath = "ID";
            firstGrid.Columns.Add(comboColumn3);
            DataGridComboBoxColumn comboColumn1 = new DataGridComboBoxColumn();
            comboColumn1.Header = "Клиент";
            comboColumn1.ItemsSource = db.Client.ToList();
            comboColumn1.SelectedValueBinding = new Binding("ClientID");
            comboColumn1.SelectedValuePath = "ID";
            comboColumn1.DisplayMemberPath = "FullName";
            firstGrid.Columns.Add(comboColumn1);

            DataGridComboBoxColumn comboColumn2 = new DataGridComboBoxColumn();
            comboColumn2.Header = "Сотрудник";
            comboColumn2.ItemsSource = db.Worker.ToList();
            comboColumn2.SelectedValueBinding = new Binding("WorkerID");
            comboColumn2.SelectedValuePath = "ID";
            comboColumn2.DisplayMemberPath = "FullName";
            firstGrid.Columns.Add(comboColumn2);



            DataGridTextColumn col10 = new DataGridTextColumn();
            col10.Header = "Дата";
            col10.Binding = new Binding("Date");
            col10.Binding.StringFormat = "dd/MM/yyyy";
            firstGrid.Columns.Add(col10);


            firstGrid.ItemsSource = db.Archival_Vacancy.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void EducationLevel_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);



            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Название";
            col3.Binding = new Binding("Name");
            firstGrid.Columns.Add(col3);

            firstGrid.ItemsSource = db.EducationLevel.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void VacancyType_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Название";
            col3.Binding = new Binding("Name");
            firstGrid.Columns.Add(col3);

            firstGrid.ItemsSource = db.VacancyType.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void Employer_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Название";
            col3.Binding = new Binding("Name");
            firstGrid.Columns.Add(col3);

            DataGridComboBoxColumn comboColumn2 = new DataGridComboBoxColumn();
            comboColumn2.Header = "Улица";
            comboColumn2.ItemsSource = db.Street.ToList();
            comboColumn2.SelectedValueBinding = new Binding("StreetID");
            comboColumn2.SelectedValuePath = "ID";
            comboColumn2.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn2);

            DataGridNumericColumn col2 = new DataGridNumericColumn();
            col2.Header = "Дом";
            col2.Binding = new Binding("House");
            firstGrid.Columns.Add(col2);

            DataGridNumericColumn col1 = new DataGridNumericColumn();
            col1.Header = "Телефон";
            col1.Binding = new Binding("Phone");
            firstGrid.Columns.Add(col1);




            firstGrid.ItemsSource = db.Employer.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void Positions_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Название";
            col3.Binding = new Binding("Name");
            firstGrid.Columns.Add(col3);

            firstGrid.ItemsSource = db.Positions.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }
        private void Specialty_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Название";
            col3.Binding = new Binding("Name");
            firstGrid.Columns.Add(col3);

            firstGrid.ItemsSource = db.Specialty.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void Street_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Название";
            col3.Binding = new Binding("Name");
            firstGrid.Columns.Add(col3);

            firstGrid.ItemsSource = db.Street.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void Vacancy_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridNumericColumn col1 = new DataGridNumericColumn();
            col1.Header = "Номер";
            col1.Binding = new Binding("ID");
            firstGrid.Columns.Add(col1);

            DataGridComboBoxColumn comboColumn1 = new DataGridComboBoxColumn();
            comboColumn1.Header = "Тип вакансии";
            comboColumn1.ItemsSource = db.VacancyType.ToList();
            comboColumn1.SelectedValueBinding = new Binding("TypeID");
            comboColumn1.SelectedValuePath = "ID";
            comboColumn1.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn1);

            DataGridComboBoxColumn comboColumn2 = new DataGridComboBoxColumn();
            comboColumn2.Header = "Должность";
            comboColumn2.ItemsSource = db.Positions.ToList();
            comboColumn2.SelectedValueBinding = new Binding("PositionID");
            comboColumn2.SelectedValuePath = "ID";
            comboColumn2.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn2);

            DataGridComboBoxColumn comboColumn3 = new DataGridComboBoxColumn();
            comboColumn3.Header = "Работодатель";
            comboColumn3.ItemsSource = db.Employer.ToList();
            comboColumn3.SelectedValueBinding = new Binding("EmployerID");
            comboColumn3.SelectedValuePath = "ID";
            comboColumn3.DisplayMemberPath = "Name";
            firstGrid.Columns.Add(comboColumn3);

            DataGridNumericColumn col2 = new DataGridNumericColumn();
            col2.Header = "Зарплата";
            col2.Binding = new Binding("Salary");
            firstGrid.Columns.Add(col2);

            DataGridNumericColumn col3 = new DataGridNumericColumn();
            col3.Header = "Мин. возраст";
            col3.Binding = new Binding("MinAge");
            firstGrid.Columns.Add(col3);

            DataGridNumericColumn col4 = new DataGridNumericColumn();
            col4.Header = "Макс. возраст";
            col4.Binding = new Binding("MaxAge");
            firstGrid.Columns.Add(col4);

            DataGridComboBoxColumn comboColumn4 = new DataGridComboBoxColumn();
            comboColumn4.Header = "Ограничение по полу";
            comboColumn4.ItemsSource = new List<string>() { "Любой","Только мужской","Только женский"};
            comboColumn4.SelectedValueBinding = new Binding("PreferGender");
            firstGrid.Columns.Add(comboColumn4);

            firstGrid.ItemsSource = db.Vacancy.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void Worker_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);


            DataGridTextColumn col1 = new DataGridTextColumn();
            col1.Header = "Имя";
            col1.Binding = new Binding("Name");
            firstGrid.Columns.Add(col1);

            DataGridTextColumn col2 = new DataGridTextColumn();
            col2.Header = "Фамилия";
            col2.Binding = new Binding("Surname");
            firstGrid.Columns.Add(col2);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Header = "Отчество";
            col3.Binding = new Binding("Patronymic");
            firstGrid.Columns.Add(col3);

            firstGrid.ItemsSource = db.Worker.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }


        private void UserInfo_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            firstGrid.CanUserAddRows = false;
            editCurrentMenu = true;
            if (strangeEvent == true)
            {
                firstGrid.RowEditEnding -= FirstGrid_SourceUpdated;
                strangeEvent = false;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            DataGridComboBoxColumn comboColumn2 = new DataGridComboBoxColumn();
            comboColumn2.Header = "Логин";
            comboColumn2.ItemsSource = db.Users.ToList();
            comboColumn2.SelectedValueBinding = new Binding("UserId");
            comboColumn2.SelectedValuePath = "Id";
            comboColumn2.DisplayMemberPath = "Name";
            comboColumn2.IsReadOnly = true;
            firstGrid.Columns.Add(comboColumn2);

            DataGridComboBoxColumn comboColumn1 = new DataGridComboBoxColumn();
            comboColumn1.Header = "Меню";
            comboColumn1.ItemsSource = menuInfos;
            comboColumn1.SelectedValueBinding = new Binding("MenuInfoId");
            comboColumn1.SelectedValuePath = "Id";
            comboColumn1.DisplayMemberPath = "Title";
            comboColumn1.IsReadOnly = true;
            firstGrid.Columns.Add(comboColumn1);

            DataGridCheckBoxColumn checkboxColumn1 = new DataGridCheckBoxColumn();
            checkboxColumn1.Header = "Чтение";
            checkboxColumn1.Binding = new Binding("Read") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            firstGrid.Columns.Add(checkboxColumn1);

            DataGridCheckBoxColumn checkboxColumn2 = new DataGridCheckBoxColumn();
            checkboxColumn2.Header = "Запись";
            checkboxColumn2.Binding = new Binding("Write") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            firstGrid.Columns.Add(checkboxColumn2);

            DataGridCheckBoxColumn checkboxColumn3 = new DataGridCheckBoxColumn();
            checkboxColumn3.Header = "Редактирование";
            checkboxColumn3.Binding = new Binding("Edit") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            firstGrid.Columns.Add(checkboxColumn3);

            DataGridCheckBoxColumn checkboxColumn4 = new DataGridCheckBoxColumn();
            checkboxColumn4.Header = "Удаление";
            checkboxColumn4.Binding = new Binding("Delete") { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            firstGrid.Columns.Add(checkboxColumn4);



            firstGrid.ItemsSource = db.UserInfo.ToList();

            firstGrid.Visibility = Visibility.Visible;
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            firstGrid.Visibility = Visibility.Hidden;
            firstGrid.ItemsSource = null;
            firstGrid.Columns.Clear();
            if (strangeEvent == false)
            {
                firstGrid.RowEditEnding += FirstGrid_SourceUpdated;
                strangeEvent = true;
            }
            UserInfo info = userInfo.Find(x => x.MenuInfoId == (sender as MyMenuItem)!.Id)!;
            Granting_Rights(info);

            Binding bind = new Binding("Name");
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            DataGridTextColumn col1 = new DataGridTextColumn();
            col1.Header = "Логин";
            col1.Binding = bind;
            firstGrid.Columns.Add(col1);
            DataGridTextColumn col2 = new DataGridTextColumn();
            col2.Header = "Пароль";
            col2.Binding = new Binding("Password");
            firstGrid.Columns.Add(col2);


            firstGrid.ItemsSource = db.Users.ToList();
            firstGrid.Visibility = Visibility.Visible;
        }

        private void FirstGrid_SourceUpdated(object? sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                using (ApplicationContext someDb = new ApplicationContext())
                {
                    var grid = (DataGrid)sender!;
                    User user2 = (e.Row.Item as User)!;
                    someDb.Add(user2);
                    someDb.SaveChanges();
                    someDb.Remove(user2);
                    someDb.SaveChanges();
                    if (grid.SelectedItems.Count > 0)
                    {

                        foreach (var row in grid.SelectedItems)
                        {
                            User user = (row as User)!;
                            for (int i = 0; i < menuInfos.Count; i++)
                            {
                                UserInfo userInfo = new UserInfo() { UserId = user!.Id, MenuInfoId = menuInfos[i].Id };
                                db.UserInfo.Add(userInfo);
                            }

                        }
                    }
                }
            }
        }


        private void ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordRecovery passwordRecovery = new PasswordRecovery();
            passwordRecovery.Owner = this;
            passwordRecovery.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            db.Dispose();
            dbForUser.Dispose();
        }
        private void Granting_Rights(UserInfo info)
        {
            if (info.Write == false)
            { firstGrid.CanUserAddRows = false; }
            else
            { firstGrid.CanUserAddRows = true; }

            if (info.Edit == false)
            { editCurrentMenu = false; }
            else
            { editCurrentMenu = true; }

            if (info.Delete == false)
            { firstGrid.CanUserDeleteRows = false; }
            else { firstGrid.CanUserDeleteRows = true; }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (editCurrentMenu == false)
            {
                firstGrid.IsReadOnly = true;
                MessageBox.Show("У вас нет прав на редактирование данных в этой таблице");
                return;
            }

            if (edit == false)
            {
                edit = true;
                var button = (Button)sender!;
                firstGrid.IsReadOnly = false;
                firstGrid.IsLocked = true;

                button.Content = "Завершить редактирование";
            }
            else
            {
                edit = false;
                var button = (Button)sender!;
                firstGrid.IsReadOnly = true;
                firstGrid.IsLocked = false;

                button.Content = "Редактировать";
            }
        }
        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать в информационную систему биржи труда. После того как вы зашли в систему под вашим логином и паролем, вы можете выбрать один из пунктов меню, которые находятся выше. Далее у вас появится таблица с данными, чтобы редактировать или добавлять данные нужно нажать кнопку \"Редактировать\", после завершения редактирования нажмите кнопку \"Завершить редактирование\" и \"Сохранить\". После этого все внесенные изменения сохраняться.");
        }
        private void UserHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Редактирование таблицы:\r\n1. Внесение новой записи, например: добавлять данные о новом студенте в таблицу студентов\r\n2. Редактирование записи, например: изменение фамилии или должности профессора в таблице\r\n3. Удаление записи, например: удалить запись из таблицы\r\nАвторизация:\r\n1. Авторизация пользователя путём ввода логина и пароля, по логину определяется роль пользователя в системе\r\n2. Смена пароля: позволяет сменить пароль пользователя. Для этого нужно внести используемый пароль на данный момент и подтвердить новый\r\n");
        }
    }
}

