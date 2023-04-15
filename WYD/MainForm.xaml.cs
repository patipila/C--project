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

namespace WYD
{
    /// <summary>
    /// Logika interakcji dla klasy MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda tworzy nowy obiekt klasy OwnerForm
        /// i otwiera okno tej klasy, a następnie zamyka aktualne okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAdvert_btn_Click(object sender, RoutedEventArgs e)
        {
            OwnerForm ownerForm = new OwnerForm();

            ownerForm.Show();
            Close();
        }

        /// <summary>
        /// Metoda tworzy nowy obiekt klasy AdvertsForm 
        /// i otwiera okno tej klasy, a następnie zamyka aktualne okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BrowseAdvert_btn_Click(object sender, RoutedEventArgs e)
        {
            AdvertsForm advertsForm = new AdvertsForm();

            advertsForm.Show();
            Close();
        }

        /// <summary>
        ///  Metoda tworzy nowy obiekt klasy AppWalkersForm 
        ///  i otwiera okno tej klasy, a następnie zamyka aktualne okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BrowseWalkers_btn_Click(object sender, RoutedEventArgs e)
        {
            AppWalkersForm appWalkerForm = new AppWalkersForm();

            appWalkerForm.Show();
            Close();
        }

        /// <summary>
        ///  Metoda tworzy nowy obiekt klasy WalkerForm
        ///  i otwiera okno tej klasy, a następnie zamyka aktualne okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AddWalker_btn_Click(object sender, RoutedEventArgs e)
        {
            WalkerForm walkerForm = new WalkerForm();

            walkerForm.Show();
            Close();
        }
    }
}
