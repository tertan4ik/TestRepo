using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_DataBinding_Ver2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AppointmentPage.xaml
    /// </summary>
    /// 
    public partial class AppointmentPage : Page
    {
        Pacient pacient;
        AppointmentStory Appointment;
        public AppointmentPage(Pacient p)
        {
            InitializeComponent();
            pacient = p;
            DataContext = pacient;
            Age.Content = "Age: " + CalculateAge(pacient.Birthday)+ ", " + AgeChecker(CalculateAge(pacient.Birthday));
            LastAppointment.Content ="Last appointment info: " + LastAppointmentDays();


        }

        public void EndReception(object sender, RoutedEventArgs e)
        {
            var newAppointment = new AppointmentStory
            {
                Date= DateTime.Now,
                DoctorId = pacient.ID,
                Diagnosis = nDiagnosis.Text,
                Recommendations =nRecomendations.Text
            };

            if (pacient.Appointmentstories == null)
                pacient.Appointmentstories = new List<AppointmentStory>();

            pacient.Appointmentstories.Add(newAppointment);
            pacient.UpdatePacient();

            NavigationService.GoBack();
        }

        public void Back(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            // Если день рождения еще не наступил в этом году, вычитаем 1 год
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public string AgeChecker(int age)
        {
            if(age>=18)
            {
                return "Совершеннолетний";
            }
            else
            {
                return "Несовершеннолетний";
            }
        }

        public string LastAppointmentDays()
        {
            if(pacient.Appointmentstories != null)
            {
                DateTime today = DateTime.Today;
                TimeSpan difference = today - pacient.Appointmentstories[pacient.Appointmentstories.Count - 1].Date;
                return $"Дней с последнего приема: {(int)difference.TotalDays}" ;
            }
            else
            {
                return "Первый прием в клинике";
            }

        }
         
    }
}
