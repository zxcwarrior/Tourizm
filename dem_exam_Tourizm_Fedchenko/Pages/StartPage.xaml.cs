using System.Windows;
using System.Windows.Controls;
using dem_exam_Tourizm_Fedchenko.Utils;

namespace dem_exam_Tourizm_Fedchenko.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void TourBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TourListPage());
        }

        private void HotelsBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelPage());
        }
    }
}
