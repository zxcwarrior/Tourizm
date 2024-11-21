using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using dem_exam_Tourizm_Fedchenko.Model;

namespace dem_exam_Tourizm_Fedchenko.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelEditPage.xaml
    /// </summary>
    public partial class HotelEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();
        public HotelEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                _currentHotel = selectedHotel;

            DataContext = _currentHotel;
            CBxCountry.ItemsSource = DataBaseEntities.GetContext().Country.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentHotel.Name))
                errors.AppendLine("Укажите название отеля");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errors.AppendLine("Количество звёзд - число от 1 до 5");
            if (_currentHotel.Country == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentHotel.Id == 0)
                DataBaseEntities.GetContext().Hotel.Add(_currentHotel);

                try
                {
                    DataBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }          
        }
    }

