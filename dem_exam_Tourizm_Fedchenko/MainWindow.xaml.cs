using dem_exam_Tourizm_Fedchenko.Pages;
using dem_exam_Tourizm_Fedchenko.Utils;
using System.Windows;

namespace dem_exam_Tourizm_Fedchenko
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new StartPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, System.EventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
