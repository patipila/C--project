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
    /// Logika interakcji dla klasy AppWalkerViewForm.xaml
    /// </summary>
    public partial class AppWalkerViewForm : Window
    {
        AppWalkersForm appWalkersForm = new AppWalkersForm();
        public AppWalkerViewForm()
        {
            InitializeComponent();
            txtBirthAppWalkerViewForm.Content = AppWalkersForm.SavedWalkerModel.WalkerDateOfBirth;
            txtTelAppWalkerViewForm.Content = AppWalkersForm.SavedWalkerModel.WalkerPhone;
            txtEmailAppWalkerViewForm.Content = AppWalkersForm.SavedWalkerModel.WalkerEmail;
            txtDescriptionAppWalkerViewForm.Content = AppWalkersForm.SavedWalkerModel.DescriptionW;
            txtNameAppWalkerViewForm.Content = AppWalkersForm.SavedWalkerModel;
                
        }

        /// <summary>
        /// Metoda zamyka bieżące okno i otwiera okno z listą wyprowdzających.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExitAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            appWalkersForm.Show();
            Close();
        }
    }
}
