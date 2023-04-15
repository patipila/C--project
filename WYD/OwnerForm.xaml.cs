using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Logika interakcji dla klasy OwnerForm.xaml
    /// </summary>
    public partial class OwnerForm : Window
    {
        public static OwnerModel SavedOwner;
        AppOwnerModel owners = new AppOwnerModel();



        public OwnerForm()
        {
            InitializeComponent();
            owners.addOwnerToList();
            listOwnerForm.ItemsSource = owners.OwnerList;

            cbxSortDirectionOwnerForm.SelectedIndex = 0;
            cbxSortByWhatOwnerForm.SelectedIndex = 0;
            cbxSortByWhatOwnerForm.ItemsSource = new string[] { "OwnerId", "OwnerName", "OwnerSurname" };
            cbxSortDirectionOwnerForm.ItemsSource = Enum.GetNames(typeof(ListSortDirection));

            listOwnerForm.Items.SortDescriptions.Add(new SortDescription("OwnerId", ListSortDirection.Ascending));


            cbxSortByWhatOwnerForm.SelectionChanged += SelectionChanged;
            cbxSortDirectionOwnerForm.SelectionChanged += SelectionChanged;



        }
        public void SortList()
        {
            var SortProperty = cbxSortByWhatOwnerForm.SelectedItem.ToString();
            var SortDirection = cbxSortDirectionOwnerForm.SelectedItem.ToString() == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending;

            listOwnerForm.Items.SortDescriptions[0] = new SortDescription(SortProperty, SortDirection);


        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortList();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainForm mainForm = new MainForm();

            mainForm.Show();
            Close();
        }


        public void btnNextOwnerForm_Click(object sender, RoutedEventArgs e)
        {
            DogList dogList = new DogList();


            dogList.Show();
            Close();
        }

        private void btnAddOwnerForm_Click(object sender, RoutedEventArgs e)
        {
            NewOwnerForm newOwnerForm = new NewOwnerForm();
            newOwnerForm.Show();
            Close();
        }

        private void btnSortOwnerForm_Click(object sender, RoutedEventArgs e)
        {
            cbxSortByWhatOwnerForm.Visibility = Visibility.Visible;
            cbxSortDirectionOwnerForm.Visibility = Visibility.Visible;
        }


        public void listOwnerForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listOwnerForm.SelectedItem != null)
                btnNextOwnerForm.IsEnabled = true;
            SavedOwner = (OwnerModel)listOwnerForm.SelectedItem;
            OwnerModel.SelectedOwner = SavedOwner;

        }
        //private void DeleteOwner(int ownerId)
        //{
        //    using (var context = new Model1())
        //    {
        //        OwnerModel ownerToDelete = context.OwnerModels.Find(ownerId);
        //        if (ownerToDelete != null)
        //        {

        //            context.OwnerModels.Remove(ownerToDelete);
        //            context.SaveChanges();
        //        }

        //    }
        //}

        private void btnDeleteOwnerForm_Click(object sender, RoutedEventArgs e)
        {
            var selectedOwner = (OwnerModel)listOwnerForm.SelectedItem;
            if (selectedOwner != null)
            {
                DeleteOwner(selectedOwner.OwnerId);
                owners.RemoveFromList(selectedOwner);
                listOwnerForm.ItemsSource = new ObservableCollection<OwnerModel>(owners.OwnerList);

            }

            btnNextOwnerForm.IsEnabled = false;
        }

        private void DeleteOwner(int ownerId)
        {
            using (var context = new Model1())
            {
                OwnerModel ownerToDelete = context.OwnerModels.Find(ownerId);
                if (ownerToDelete != null)
                { 
                    var selectedOwner = (OwnerModel)listOwnerForm.SelectedItem;
                    if (selectedOwner != null && ownerToDelete.OwnerId != selectedOwner.OwnerId)
                    {
                        selectedOwner = ownerToDelete;
                    }
                    context.OwnerModels.Remove(ownerToDelete);
                    context.SaveChanges();
                    owners.RemoveFromList(selectedOwner);
                    listOwnerForm.ItemsSource = new ObservableCollection<OwnerModel>(owners.OwnerList);

                }
            }
        }
    }
}
