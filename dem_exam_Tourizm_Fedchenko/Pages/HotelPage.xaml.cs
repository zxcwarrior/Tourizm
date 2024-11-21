using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using dem_exam_Tourizm_Fedchenko.Model;
using dem_exam_Tourizm_Fedchenko.Utils;

namespace dem_exam_Tourizm_Fedchenko.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        public HotelPage()
        {
            InitializeComponent();
            DtGridHotels.ItemsSource = DataBaseEntities.GetContext().Hotel.ToList();
        }

        private void AddHotelBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelEditPage(null));
        }

        private void DelHotelBtn_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DtGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DataBaseEntities.GetContext().Hotel.RemoveRange(hotelsForRemoving);
                    DataBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    DtGridHotels.ItemsSource = DataBaseEntities.GetContext().Hotel.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelEditPage((sender as Button).DataContext as Hotel));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DtGridHotels.ItemsSource = DataBaseEntities.GetContext().Hotel.ToList();
            }
        }
    }
}
