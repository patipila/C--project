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
    /// Logika interakcji dla klasy DogInformation.xaml
    /// </summary>
    public partial class DogInformation : Window
    {
        
        public DogInformation()
        {
            InitializeComponent();
            txtActivityDemandDogInformation.Content = AdvertModel.SelectedAdvert.Dog.ActivityDemand;
            txtAgeDogInformation.Content = AdvertModel.SelectedAdvert.Dog.DogAge;
            txtDescriptionDogInformation.Content = AdvertModel.SelectedAdvert.Dog.DescriptionD;
            txtGenderDogInformation.Content = AdvertModel.SelectedAdvert.Dog.DogGender;
            txtNameDogInformation.Content = AdvertModel.SelectedAdvert.Dog.DogName;
            txtSizeDogInformation.Content = AdvertModel.SelectedAdvert.Dog.DogSize;
        }

        private void btnExitAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            AdvertFormDescription advertFormDescription = new AdvertFormDescription();
            advertFormDescription.Show();
            Close();
        }
    }
}
