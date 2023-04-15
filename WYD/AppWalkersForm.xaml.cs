using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using WalkYourDogAppProject;

namespace WYD
{
    /// <summary>
    /// View of all current dog walkers.
    /// </summary>
    public partial class AppWalkersForm : Window
    {

        AppWalkerModel AppWalkerModelapp = new AppWalkerModel();
        WalkerModel walker = new WalkerModel(); 
       public static WalkerModel SavedWalkerModel;
        public AppWalkersForm()
        {
            InitializeComponent();
            AppWalkerModelapp.addWalkerToList();
            lsbAppWalkersForm.ItemsSource = AppWalkerModelapp.WalkerList;


            cbxAppWalkersFormSortBy.ItemsSource = new string[] { "WalkerId", "WalkerName", "WalkerSurname", "DateOfBirth" };
            cbxAppWalkersFormSortDiraction.ItemsSource = Enum.GetNames(typeof(ListSortDirection));

            lsbAppWalkersForm.Items.SortDescriptions.Add(new SortDescription("WalkerId", ListSortDirection.Ascending));

        }
        /// <summary>
        /// Metoda WalkerFormUser() dodaje nowego wyprowadzającego do listy osób wyprowadzających, 
        /// ustawia źródło danych dla listy, ustawia filtrowanie listy 
        /// i sortowanie oraz konfiguruje zmiany w sortowaniu i filtrowaniu.
        /// </summary>
        /// <param name="model"></param>
        public void WalkerFormUser(WalkerModel model)

        {
            AppWalkerModelapp.AddToList(model);
            lsbAppWalkersForm.ItemsSource = AppWalkerModelapp.WalkerList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsbAppWalkersForm.ItemsSource);
            view.Filter = WalkerFilter;

           
            cbxAppWalkersFormSortBy.SelectionChanged += SelectionChanged;
            cbxAppWalkersFormSortDiraction.SelectionChanged += SelectionChanged;

        }

        /// <summary>
        /// Sortowanie listy wyprowadzających na podstawie wybranego parametru sortowania i opcji sortowania.
        /// </summary>
        public void SortList()
        {
            var SortProperty = cbxAppWalkersFormSortBy.SelectedItem.ToString();
            var SortDirection = cbxAppWalkersFormSortDiraction.SelectedItem.ToString() == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending;

            lsbAppWalkersForm.Items.SortDescriptions[0] = new SortDescription(SortProperty, SortDirection);


        }


        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortList();
        }

        /// <summary>
        ///  Filtrowanie listy wyprowadzających na podstawie tekstu wpisanego w polu do filtrowania.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool WalkerFilter(object item)
        {
            if (String.IsNullOrEmpty(txtAppWalkersFormFilter.Text))
                return true;
            else
                return ((AdvertModel)item).AdvertName.IndexOf(txtAppWalkersFormFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Odświezenie widoku listy wyprowadzająych po zmianie tekstu w filtrowaniu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtAdvertFormFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            lblSearchAppWalkerForm.Visibility= Visibility.Hidden;
                      CollectionViewSource.GetDefaultView(lsbAppWalkersForm.ItemsSource).Refresh();
        }

        /// <summary>
        /// Wyczyszczenie pola filtrowania po klinięciu na to pole.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        /// <summary>
        /// Zapisywanie wybranego wyprowadzającego do
        /// zmiennej statycznej SavedWalkerModel i otwarcie okno z detalami wyprowadzającego psy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void listAppWalkersForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SavedWalkerModel = (WalkerModel)lsbAppWalkersForm.SelectedItem;
            AppWalkerViewForm appWalkerViewForm = new AppWalkerViewForm();
            appWalkerViewForm.Show();
            Close();

        }

        /// <summary>
        /// Metoda zamyka bieżące okno i otwiera okno głównego formularza aplikacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExitAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Close();
        }

        private void lblSearchAppWalkerForm_GotFocus(object sender, RoutedEventArgs e)
        {
            lblSearchAppWalkerForm.Visibility = Visibility.Hidden;

        }

        private void txtAppWalkersFormFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            lblSearchAppWalkerForm.Visibility = Visibility.Hidden;
        }

        private void btnSortAppWalkerForm_Click(object sender, RoutedEventArgs e)
        {
            cbxAppWalkersFormSortBy.Visibility = Visibility.Visible;
            cbxAppWalkersFormSortDiraction.Visibility = Visibility.Visible;
        }


        private void DeleteWalker(int walkerId)
        {
            using (var context = new Model1())
            {
                WalkerModel walkerToDelete = context.WalkersModels.Find(walkerId);
                if (walkerToDelete != null)
                {

                    context.WalkersModels.Remove(walkerToDelete);
                    context.SaveChanges();
                }

            }
        }

        private void btnDeleteAppWalkerForm_Click(object sender, RoutedEventArgs e)
        {
            var selectedWalker = (WalkerModel)lsbAppWalkersForm.SelectedItem;
            if (selectedWalker != null)
            {
                DeleteWalker(selectedWalker.Id);
                AppWalkerModelapp.RemoveFromList(selectedWalker);
                lsbAppWalkersForm.ItemsSource = new ObservableCollection<WalkerModel>(AppWalkerModelapp.WalkerList);

            }
        }



            private void lsbAppWalkersForm_Double_Clik(object sender, MouseButtonEventArgs e)
        {
            SavedWalkerModel = (WalkerModel)lsbAppWalkersForm.SelectedItem;
            AppWalkerViewForm appWalkerViewForm = new AppWalkerViewForm();
            appWalkerViewForm.Show();
            Close();
        }
    }
}
