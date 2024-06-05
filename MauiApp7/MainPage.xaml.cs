using MauiApp7.Models;

namespace MauiApp7
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
        }

        public void OnNewButtonClicked(Object sender, EventArgs e)
        {
           
            statusMessage.Text = "";
           

            App.StudentRepo.AddNewStudent(newStudent.Text);
            statusMessage.Text = App.StudentRepo.StatusMessage;

            newStudent.Text = "";
        }

        public void OnGetButtonClicked(Object sender, EventArgs e)
        {
            statusMessage.Text = "";

            List<Student> section = App.StudentRepo.GetSection();
            sectionList.ItemsSource = section; 
        }
    }

}
