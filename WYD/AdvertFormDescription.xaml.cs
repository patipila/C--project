using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WalkYourDogApp;

namespace WYD
{
    /// <summary>
    /// Logika interakcji dla klasy AdvertFormDescription.xaml
    /// </summary>
    public partial class AdvertFormDescription : Window
    {
        /// <summary>
        /// Wyświetlanie szczegółów ogłoszenia, które zostało wybrane przez użytkownika z listy ogłoszeń.
        /// </summary>

        
        public AdvertFormDescription()
        {
            InitializeComponent();
            txtTitleAdvertFormDescription.Content = AdvertModel.SelectedAdvert.AdvertName;
            txtOwnerAdvertFormDescription.Content = AdvertModel.SelectedAdvert.Dog.Owner;
            btnDogAdvertForm.Content = AdvertModel.SelectedAdvert.Dog.DogName;
            txtOwnerTelAdvertFormDescription.Content = AdvertModel.SelectedAdvert.Dog.Owner.OwnerPhone;
            txtPrizeAdvertFormDescription.Content = AdvertModel.SelectedAdvert.AdvertPrize;
            txtDateAdvertFormDescription.Content = AdvertModel.SelectedAdvert.AdvertDate;
            txtDescriptionAdvertFormDescription.Content = AdvertModel.SelectedAdvert.AdvertContent;
            AddDateAdvertFormDescription.Content = AdvertModel.SelectedAdvert.WhenDate;
        }

        /// <summary>
        /// Otwieranie okna AdvertsForm i zamknięcie bieżącego okienka.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            AdvertsForm advertsForm = new AdvertsForm();

            advertsForm.Show();
            Close();
        }

        /// <summary>
        /// Otwieranie okna DogInformation i zamknięcie bieżącego okna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDogAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            DogInformation information= new DogInformation();
            information.Show(); 
            Close();
        }
    }
}
