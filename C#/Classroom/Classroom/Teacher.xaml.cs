using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Classroom
{
    public sealed partial class Teacher : Page
    {
        string LOGIN = null;
        ObservableCollection<Mark> teacher = new ObservableCollection<Mark>();
        ObservableCollection<Discipline> disciplines = new ObservableCollection<Discipline>();
        ObservableCollection<User> users = new ObservableCollection<User>();
        ObservableCollection<User> usersStud = new ObservableCollection<User>();


        public Teacher()
        {
            this.InitializeComponent();

            DataAccessClass.InitializeDatabase();

            teacher = DataAccessClass.GetMarks("", "");
            TeacherGrid.ItemsSource = teacher;

            users = DataAccessClass.GetUsers("");
            usersStud = DataAccessClass.GetUsers("Student");


            disciplines = DataAccessClass.GetDisciplines();
            List<string> names = new List<string>();
            foreach (Discipline name in disciplines)
            {
                if (name.ActiveDisc != 0) names.Add(name.NameDisc);
            }

            names.Sort();
            int index = 0;
            while (index < names.Count - 1)
            {
                if (names[index] == names[index + 1] || names[index] == "")
                    names.RemoveAt(index);
                else
                    index++;
            }

            AddMarkDisciplineCBox.ItemsSource = names;



            List<string> groups = new List<string>();
            foreach (User user in users)
            {

                groups.Add(user.Group);
            }

            groups.Sort();
            int index1 = 0;
            while (index1 < groups.Count - 1)
            {
                if (groups[index1] == groups[index1 + 1] || groups[index1] == "")
                    groups.RemoveAt(index1);
                else
                    index1++;
            }

            AddMarkGroupCBox.ItemsSource = groups;



            List<string> stud = new List<string>();
            foreach (User user in usersStud)
            {

                stud.Add(user.Login);
            }

            stud.Sort();
            int index2 = 0;
            while (index2 < stud.Count - 1)
            {
                if (stud[index2] == stud[index2 + 1] || stud[index2] == "")
                    stud.RemoveAt(index2);
                else
                    index2++;
            }

            AddMarkStudentCBox.ItemsSource = stud;
        }

        private void AddNewMarkBtn_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void DeleteSelectedMark_Click(object sender, RoutedEventArgs e)
        {
            DataAccessClass.DeleteMark(teacher[TeacherGrid.SelectedIndex].IdMark);
            teacher = DataAccessClass.GetMarks("", "");
            TeacherGrid.ItemsSource = teacher;
        }

        private void AddMarkConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("d");

            if (AddMarkMarkCBox.SelectedIndex != -1 && AddMarkDisciplineCBox.SelectedIndex != -1 && AddMarkGroupCBox.SelectedIndex != -1 && AddMarkStudentCBox.SelectedIndex != -1)
            {
                DataAccessClass.AddMark(AddMarkStudentCBox.SelectedValue.ToString(), LOGIN, AddMarkDisciplineCBox.SelectedValue.ToString(), Convert.ToInt32(AddMarkMarkCBox.SelectedValue), date, AddMarkGroupCBox.SelectedValue.ToString());
                teacher = DataAccessClass.GetMarks("", "");
                TeacherGrid.ItemsSource = teacher;

                AddMarkStudentCBox.SelectedIndex = -1;
                AddMarkDisciplineCBox.SelectedIndex = -1;
                AddMarkMarkCBox.SelectedIndex = -1;
                AddMarkGroupCBox.SelectedIndex = -1;
                AddNewMarkFlyout.Hide();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LOGIN = e.Parameter.ToString();
            //LOGIN = "dsa";
        }
    }
}
