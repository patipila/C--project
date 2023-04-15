using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// All information about the dog.
    /// </summary>
    public partial class DogForm : Window
    {
        DogModel dog = new DogModel();
        AppDogModel appDog = new AppDogModel();
        DogList dogList = new DogList();
        OwnerForm owner;


        public DogForm()
        {
            InitializeComponent();
            txtAdditionalDescriptionDogForm.IsEnabled = false;
        }


        /// <summary>
        /// Metoda Button_Click() otwiera okno z listą psów i zamyka bieżące okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DogList dogList = new DogList();
            dogList.Show();

            Close();
        }

        /// <summary>
        /// Metoda ta umożliwia edycję pola tekstowego
        /// po zaznaczeniu checkboxa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbAdditionalDescriptionDogForm_Checked(object sender, RoutedEventArgs e)
        {
            txtAdditionalDescriptionDogForm.IsEnabled = true;
        }


        /// <summary>
        /// Metoda uniemożliwia edycję pola tekstowego
        /// po odznaczeniu odpowiedniego checkboxa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbAdditionalDescriptionDogForm_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAdditionalDescriptionDogForm.IsEnabled = false;
        }

        /// <summary>
        ///  Metoda dodaje nowego psa do listy psów i wyświetla komunikat "Dog has been added".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDogDogForm_Click(object sender, RoutedEventArgs e)
        {
            if (txtNameDogForm.Text.Length > 0 || txtAgeDogForm.Text.Length > 0)
            {
                dog.DogName = txtNameDogForm.Text;

                dog.DogAge = txtAgeDogForm.Text;

                using (var db = new Model1())
                {
                    dog.Owner = db.OwnerModels.Where(x => x.OwnerId == OwnerForm.SavedOwner.OwnerId).FirstOrDefault();

                }


                if (cmbGenderDogForm.Text == "Male")
                {
                    dog.DogGender = EnumGender.male;
                }
                else if (cmbGenderDogForm.Text == "Female")
                {
                    dog.DogGender = EnumGender.female;
                }
                else
                {
                    dog.DogGender = EnumGender.castrated;
                }

                if (cmbActivityDogForm.Text == "Small")
                {
                    dog.ActivityDemand = EnumActivity.small;
                }
                else if (cmbActivityDogForm.Text == "Medium")
                {
                    dog.ActivityDemand = EnumActivity.medium;
                }
                else
                {
                    dog.ActivityDemand = EnumActivity.large;
                }
            }

            dog.SaveDogToBase();

            MessageBox.Show("Dog has been added.");

        }

        private void btnCleanDogForm_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in DogForm1.Children)
            {
                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
                if (ctl.GetType() == typeof(ComboBox))
                    ((ComboBox)ctl).SelectedIndex = -1;
            }
        }

        private void txtNameDogForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Name")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtAgeDogForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Age")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtAdditionalDescriptionDogForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Additional description")
            {
                textBox.Text = string.Empty;
            }
        }
    }


}
