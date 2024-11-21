using System.Linq;
using System.Windows.Controls;
using dem_exam_Tourizm_Fedchenko.Model;

namespace dem_exam_Tourizm_Fedchenko.Pages
{
    public partial class TourListPage : Page
    {
        public TourListPage()
        {
            InitializeComponent();
            LVTour.ItemsSource = DataBaseEntities.GetContext().Tour.ToList();

            var allTypes = DataBaseEntities.GetContext().Type.ToList(); 
            
            allTypes.Insert(0, new Model.Type
            {
                Name = "Все типы"
            });

            CBxTypes.ItemsSource = allTypes;
            CBxTypes.SelectedIndex = 0;
        }

        private void UpdateTours() 
        {
            var currentTours = DataBaseEntities.GetContext().Tour.ToList();

            if (CBxTypes.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.Type.Contains(CBxTypes.SelectedItem as dem_exam_Tourizm_Fedchenko.Model.Type)).ToList();

            currentTours = currentTours.Where(x => x.Name.ToLower().Contains(TBxSearch.Text.ToLower())).ToList();

            if (CBxIsActual.IsChecked == true)
                currentTours = currentTours.Where(x => x.IsActual).ToList();

            LVTour.ItemsSource = currentTours;
        }

        private void TBxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CBxTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CBxIsActual_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void CBxIsActual_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
