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
using System.ComponentModel;
using WalkYourDogApp;
using System.Collections.ObjectModel;
using WalkYourDogAppProject;

namespace WYD
{
    /// <summary>
    /// View all dog walking ads.
    /// </summary>
    public partial class AdvertsForm : Window
    {
         AppAdvertsModel AppAdvertsModelapp = new AppAdvertsModel();
        AdvertModel advert = new AdvertModel();
        public static AdvertModel SavedAdvertModel;
        public AdvertsForm()
        {
            InitializeComponent();
            AppAdvertsModelapp.addAdvertToList();
            lsbAdvertFormView.ItemsSource = AppAdvertsModelapp.AppAdverts;

            cbxAdvertFormSortBy.ItemsSource = new string[] { "ID", "AvertName", "Dog", "AdvertDate", "OwnerInf", "AdvertPrize", "AdvertDate", "WhenDate",  "AdvertTime" };
            cbxAdvertFormSortDiraction.ItemsSource = Enum.GetNames(typeof(ListSortDirection));

            lsbAdvertFormView.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));

        }

        /// <summary>
        ///  Metoda ta jest odpowiedzialna za dodanie nowego ogłoszenia do listy, aktualizacji źrodła danych
        /// dla kontrolki, zapis danych do pliku XML, ustawienie filtrowania, ustawienia opcji do posortowania,
        /// dodanie zdarzenia.
        /// </summary>
        /// <param name="model"></param>
        public void AdvertsFormUser(AdvertModel model)
        {
            AppAdvertsModelapp.AddToList(model);
            lsbAdvertFormView.ItemsSource = AppAdvertsModelapp.AppAdverts;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lsbAdvertFormView.ItemsSource);
            view.Filter = AdvertFilter;

            cbxAdvertFormSortBy.SelectionChanged += SelectionChanged;
            cbxAdvertFormSortDiraction.SelectionChanged += SelectionChanged;

        }

        /// <summary>
        /// Metoda SortList() służy do sortowania listy ogłoszeń na podstawie wybranego pola i kolejności sortowania.
        /// </summary>


        public void SortList()
        {
            var SortProperty = cbxAdvertFormSortBy.SelectedItem.ToString();
            var SortDirection = cbxAdvertFormSortDiraction.SelectedItem.ToString() == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending;

            lsbAdvertFormView.Items.SortDescriptions[0] = new SortDescription(SortProperty, SortDirection);


        }

        /// <summary>
        /// Sortowanie ogłoszeń.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortList();
        }

        /// <summary>
        /// Metoda służy do filtrowania ogłoszeń na podstawie tekstu wprowadzonego przez użytkownika.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool AdvertFilter(object item)
        {

            if (String.IsNullOrEmpty(txtAdvertFormFilter.Text))
                return true;
            else
                return ((AdvertModel)item).AdvertName.IndexOf(txtAdvertFormFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

       /// <summary>
       /// Metoda służy do odświeżania listy ogłoszeń.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        public void txtAdvertFormFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            lblSearchAdvertForm.Visibility = Visibility.Hidden;
            CollectionViewSource.GetDefaultView(lsbAdvertFormView.ItemsSource).Refresh();
        }

       
      

        /// <summary>
        /// Metoda otwiera okienko MainForm i zamyka bieżące okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            MainForm mainForm = new MainForm();

            mainForm.Show();
            Close();
        }

        /// <summary>
        /// Metoda jest wywoływana przy wyborze ogłoszenia z listy. Otwiera okno AdvertFormDescription.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void txtAdvertFormFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            lblSearchAdvertForm.Visibility = Visibility.Hidden;
        }

        private void lblSearchAdvertForm_GotFocus(object sender, RoutedEventArgs e)
        {
            lblSearchAdvertForm.Visibility = Visibility.Hidden;
        }

        private void btnSortAdvertForm_Click(object sender, RoutedEventArgs e)
        {
            cbxAdvertFormSortBy.Visibility= Visibility.Visible;
            cbxAdvertFormSortDiraction.Visibility= Visibility.Visible;  
        }

        private void DeleteAdvert(int advertId)
        {
            using (var context = new Model1())
            {
                AdvertModel avertToDelete = context.AdvertModels.Find(advertId);
                if (avertToDelete != null)
                {

                    context.AdvertModels.Remove(avertToDelete);
                    context.SaveChanges();
                }

            }
        }

        private void btnDeleteAdvertForm_Click(object sender, RoutedEventArgs e)
        {
            var selectedAdvert = (AdvertModel)lsbAdvertFormView.SelectedItem;
            if (selectedAdvert != null)
            {
                DeleteAdvert(selectedAdvert.AdvertId);
                AppAdvertsModelapp.RemoveFromList(selectedAdvert);
                lsbAdvertFormView.ItemsSource = new ObservableCollection<AdvertModel>(AppAdvertsModelapp.AppAdverts);

            }
        }
            private void lsbAdvertFormView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            SavedAdvertModel = (AdvertModel)lsbAdvertFormView.SelectedItem;
            AdvertModel.SelectedAdvert = SavedAdvertModel;
            advert.LoadAdvert();
            AdvertFormDescription advertFormDescription = new AdvertFormDescription();
            advertFormDescription.Show();
            Close();
        }

    }

}

