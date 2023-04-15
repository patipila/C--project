using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
using WalkYourDogAppProject;

namespace WYD
{
    /// <summary>
    /// All dogs of the owner.
    /// </summary>
    public partial class DogList : Window
    {

        /// <summary>
        /// Zmienna statyczna.
        /// </summary>
        public static DogModel SavedDog;
        AppDogModel dogs = new AppDogModel();



        /// <summary>
        /// Inicjalizacja elementów interfejsu użytkownika okna.
        /// </summary>
        public DogList()
        {

            InitializeComponent();
            dogs.addDogToList();
            listDogList.ItemsSource = dogs.DogList;


            //cbxSortDirectionDogList.SelectedIndex = 0;
            //cbxSortByWhatDogList.SelectedIndex = 0;
            //cbxSortByWhatDogList.ItemsSource = new string[] { "ID", "DogName", "DogAge" };
            //cbxSortDirectionDogList.ItemsSource = Enum.GetNames(typeof(ListSortDirection));

            //listDogList.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));


            //cbxSortByWhatDogList.SelectionChanged += SelectionChanged;
            //cbxSortDirectionDogList.SelectionChanged += SelectionChanged;

        }

        public void SortList()
        {
            var SortProperty = cbxSortByWhatDogList.SelectedItem.ToString();
            var SortDirection = cbxSortDirectionDogList.SelectedItem.ToString() == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending;

            listDogList.Items.SortDescriptions[0] = new SortDescription(SortProperty, SortDirection);


        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortList();
        }


        private void btnSortDogList_Click(object sender, RoutedEventArgs e)
        {
            cbxSortByWhatDogList.Visibility = Visibility.Visible;
            cbxSortDirectionDogList.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Otwierania okna formularza do tworzenia nowego psa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCreateNewDogDogList_Click(object sender, RoutedEventArgs e)
        {
            DogForm dogForm = new DogForm();
            dogForm.Show();

            Close();
        }

        /// <summary>
        /// Zamykanie okna i otwieranie okno głównego formularza właściciela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitDogList_Click(object sender, RoutedEventArgs e)
        {
            OwnerForm ownerForm = new OwnerForm();
            ownerForm.Show();

            Close();
        }

        /// <summary>
        /// Zamknięcia okna i otwarcie okna ogłoszenia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnNextDogList_Click(object sender, RoutedEventArgs e)
        {
            AdvertAppForm advertAppForm = new AdvertAppForm();
            advertAppForm.Show();

            Close();
        }

        /// <summary>
        ///  Zapisywanie wybranego psa do zmiennej statycznej SavedDog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void listDogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listDogList.SelectedItem != null)
                btnNextDogList.IsEnabled = true;
            SavedDog = (DogModel)listDogList.SelectedItem;
            DogModel.SelectedDog = SavedDog;
        }

        private void DeleteDog(int dogId)
        {
            using (var context = new Model1())
            {
                DogModel dogToDelete = context.DogModels.Find(SavedDog.DogId);
                if (dogToDelete != null)
                {

                    context.DogModels.Remove(dogToDelete);
                    context.SaveChanges();
                }

            }
        }

        private void btnDeleteDogList_Click(object sender, RoutedEventArgs e)
        {
            var selectedDog = (DogModel)listDogList.SelectedItem;
            if (selectedDog != null)
            {
                DeleteDog(selectedDog.DogId);
                dogs.RemoveFromList(selectedDog);
                listDogList.ItemsSource = new ObservableCollection<DogModel>(dogs.DogList);
                btnNextDogList.IsEnabled = false;
            }

        }

    }
}
