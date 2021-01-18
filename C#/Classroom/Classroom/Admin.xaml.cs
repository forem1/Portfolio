
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using System.Collections.ObjectModel;
using System.Data;
using Windows.Storage;
using System.IO;
using Microsoft.Data.Sqlite;
using Windows.UI.Xaml.Navigation;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using Windows.Storage.Pickers;
using Windows.UI.Notifications;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Classroom
{

    public sealed partial class Admin : Windows.UI.Xaml.Controls.Page
    {
        ObservableCollection<User> users = new ObservableCollection<User>();
        ObservableCollection<Discipline> Disciplines = new ObservableCollection<Discipline>();
        ObservableCollection<Mark> marks = new ObservableCollection<Mark>();
        private ObservableCollection<string> roles = new ObservableCollection<string> { "Admin", "Teacher", "Student" };

        public Admin()
        {
            this.InitializeComponent();

            DataAccessClass.InitializeDatabase();
            users = DataAccessClass.GetUsers("");
            Disciplines = DataAccessClass.GetDisciplines();


            UpdateGroups();
        }

        private void DeleteSelectedUser_Click(object sender, RoutedEventArgs e)
        {
            if(UsersGrid.SelectedIndex != -1)
            {
                DataAccessClass.DeleteUser(users[UsersGrid.SelectedIndex].Id);
                users = DataAccessClass.GetUsers("");
                UsersGrid.ItemsSource = users;
            }
        }

        private void AddNewUserBtn_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void AddUserConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string role = "";
            string group = "";
            switch (AddNewUserRoleCBox.SelectedIndex)
            {
                case 0:
                    role = "Admin";
                    break;
                case 1:
                    role = "Teacher";
                    break;
                case 2:
                    role = "Student";
                    group = AddNewUserGroupBox.Text;
                    break;
            }
            if (AddNewUserRoleCBox.SelectedIndex != -1)
            {
                DataAccessClass.AddUser(AddUserLoginBox.Text, AddUSerPasswordBox.Password, role, group);
                users = DataAccessClass.GetUsers("");
                UsersGrid.ItemsSource = users;

                AddUserLoginBox.Text = "";
                AddUSerPasswordBox.Password = "";
                AddNewUserRoleCBox.SelectedIndex = -1;
                AddNewUserGroupBox.Text = "";
                AddNewUserFlyout.Hide();
            }
        }

        private void EditUserData(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            try
            {
                DataAccessClass.ChangeUserData(users[UsersGrid.SelectedIndex].Id, users[UsersGrid.SelectedIndex].Login, users[UsersGrid.SelectedIndex].Password, users[UsersGrid.SelectedIndex].Role, users[UsersGrid.SelectedIndex].Group);
            }
            catch { MainPage.Popup("Error!", "Cannot update user"); }

            users = DataAccessClass.GetUsers("");
            UsersGrid.ItemsSource = users;
        }

        private void AddNewUserRoleCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AddNewUserRoleCBox.SelectedIndex == 2)
            {
                AddNewUserGroupBox.IsEnabled = true;
            }
            else
            {
                AddNewUserGroupBox.IsEnabled = false;
            }
        }
        //----------------------------------------Disciplines-----------------------------------

        private void AddNewDisciplineBtn_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void AddDisciplineConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddDisciplineNameBox.Text != "")
            {
                DataAccessClass.AddDiscipline(AddDisciplineNameBox.Text, AddDisciplineDescriptionBox.Text);
                Disciplines = DataAccessClass.GetDisciplines();
                DisciplinesGrid.ItemsSource = Disciplines;

                AddDisciplineNameBox.Text = "";
                AddDisciplineDescriptionBox.Text = "";
                AddNewDisciplineFlyout.Hide();
                UpdateGroups();
            }
        }

        private void DeactivateSelectedDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccessClass.DeactivateDiscipline(Disciplines[DisciplinesGrid.SelectedIndex].IdDisc);
            }
            catch { MainPage.Popup("Error!", "Cannot deactivate discipline"); }
            
            Disciplines = DataAccessClass.GetDisciplines();
            DisciplinesGrid.ItemsSource = Disciplines;
        }

        private void EditDisciplineData(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            try
            {
                DataAccessClass.ChangeDisciplineData(Disciplines[DisciplinesGrid.SelectedIndex].IdDisc, Disciplines[DisciplinesGrid.SelectedIndex].NameDisc, Disciplines[DisciplinesGrid.SelectedIndex].DescriptionDisc, Disciplines[DisciplinesGrid.SelectedIndex].ActiveDisc);
            }
            catch { MainPage.Popup("Error!", "Cannot update user"); }

            Disciplines = DataAccessClass.GetDisciplines();
            DisciplinesGrid.ItemsSource = Disciplines;
            UpdateGroups();
        }

        private async void CreateReport_Click(object sender, RoutedEventArgs e)
        {

            if (GroupReportSelector.SelectedItem != null) {
                marks = DataAccessClass.GetMarks("", GroupReportSelector.SelectedItem.ToString());

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    //Add a new worksheet to the empty workbook
                    var worksheet = package.Workbook.Worksheets.Add("Журнал");
                    //Add the headers
                    worksheet.Cells[1, 1].Value = "Id занятия";
                    worksheet.Cells[1, 2].Value = "Студент";
                    worksheet.Cells[1, 3].Value = "Учитель";
                    worksheet.Cells[1, 4].Value = "Дисциплина";
                    worksheet.Cells[1, 5].Value = "Оценка";
                    worksheet.Cells[1, 6].Value = "Дата";

                    var row = 2;
                    foreach (Mark mark in marks)
                    {
                        worksheet.Cells[row, 1].Value = mark.IdMark;
                        worksheet.Cells[row, 2].Value = mark.StudentMark;
                        worksheet.Cells[row, 3].Value = mark.TeacherMark;
                        worksheet.Cells[row, 4].Value = mark.DisciplineMark;
                        worksheet.Cells[row, 5].Value = mark.MarkMark;
                        worksheet.Cells[row, 6].Value = mark.DateMark;
                        row++;
                    }

                    worksheet.View.PageLayoutView = false;
                    var savePicker = new FileSavePicker();
                    savePicker.FileTypeChoices.Add("Microsoft Excel", new List<string>() { ".xlsx" });
                    savePicker.SuggestedFileName = "Журнал";
                    var file = await savePicker.PickSaveFileAsync();
                    if (file == null)
                    {
                        Toast("Error!", "Document did not saved");
                        return;
                    }
                    CachedFileManager.DeferUpdates(file);
                    var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                    package.SaveAs(stream.AsStreamForWrite());
                    stream.Dispose();
                    Toast("Done!", "Document created successfully");
                }
            }
        }

        private void Toast(string header, string body)
        {
            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(header));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(body));
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);
            ToastNotifier.Show(toast); //Показываем уведомление
        }

        private void UpdateGroups()
        {
            users = DataAccessClass.GetUsers("");
            List<string> groups = new List<string>();


            foreach (User user in users)
            {
                groups.Add(user.Group);
            }

            groups.Sort();
            int index = 0;
            while (index < groups.Count - 1)
            {
                if (groups[index] == groups[index + 1] || groups[index] == "")
                    groups.RemoveAt(index);
                else
                    index++;
            }

            GroupsList.ItemsSource = groups;
            GroupReportSelector.ItemsSource = groups;
        }
    }
}
