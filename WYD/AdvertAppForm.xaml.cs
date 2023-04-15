using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Logika interakcji dla klasy AdvertAppForm.xaml
    /// </summary>
    public partial class AdvertAppForm : Window
    {
        AdvertModel advert = new AdvertModel();
        AppAdvertsModel appAdverts = new AppAdvertsModel();
        AdvertsForm adverts = new AdvertsForm();
        List<AdvertModel> advertlist = new List<AdvertModel>();
       

        //public static string SavedTitle;
        //public static int SavedPrice;
        //public static int SavedWalkingTime;
        //public static DateTime SavedDate;
        public AdvertAppForm()
        {
            InitializeComponent();
            txtOwnerAdvertAppForm.Content = $"{OwnerForm.SavedOwner}";
            txtDogAdvertAppForm.Content = $"{DogList.SavedDog}";
        }


        /// <summary>
        /// Metoda ta tworzy nowy obiekt klasy DogList i wyświetla go na ekranie, a następnie zamyka bieżące okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitAdvertAppForm_Copy_Click(object sender, RoutedEventArgs e)
        {
            DogList dogList = new DogList();
            dogList.Show();

            Close();
        }

        /// <summary>
        /// Metoda wyświetla obiekt adverts na ekranie i zamyka bieżące okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllAdvertsAdvertAppForm_Copy1_Click(object sender, RoutedEventArgs e)
        {
            AdvertsForm adverts = new AdvertsForm();
            adverts.Show();

            Close();
        }


        /// <summary>
        /// Metoda  służy do dodawania nowego ogłoszenia. Pobiera dane z pól tekstowych.
        /// Sprawdza czy wprowadzona cena jest liczbą całkowitą, jeśli nie to  wyświetla komunikat o błędzie.
        /// Tworzy nowy obiekt AdvertModel i ustawia jego pola na podstawie pobranych danych.
        /// Ostatecznie wywołuje metodę AdvertsFormUser z obiektem advert i wyswietla komunikat o powodzeniu działania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAdvertAdvertAppForm_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitleAdvertAppForm.Text.Length > 0)
            {
                advert.OwnerInf = DogModel.SelectedDog.Owner;
                advert.Dog = DogModel.SelectedDog;
                advert.DogId = DogModel.SelectedDog.DogId;
                advert.AdvertName = txtTitleAdvertAppForm.Text;
                // SavedTitle = txtTitleAdvertAppForm.Text;
                advert.AdvertContent = txtContentAdvertAppForm.Text;
                advert.WhenDate= DateTime.Now.Date;
                int returnValue;
                if (Int32.TryParse(txtAdvertPrizeAdvertAppForm.Text, out returnValue))
                {

                    advert.AdvertPrize = returnValue;
                    //SavedPrice = returnValue;
                }
                else
                {
                    MessageBox.Show("Please enter the price as an integer without commas and dots.");
                }

                //advert.WhenDate = SavedDate;
                
                int returnTime;
                if (Int32.TryParse(txtWalkingTimeAdvertAppForm.Text, out returnTime))
                {

                    advert.AdvertTime = returnTime;
                    //SavedWalkingTime = returnTime;
                }
            }
            else
            {
                MessageBox.Show("Please enter the time as an integer without commas and dots in minutes.");
            }

            if (calemdar.SelectedDate != null)
            {
                adverts.AdvertsFormUser(advert);
                advert.SaveAdvertToBase();
                MessageBox.Show("Advert has been added.");
            }
            else
            {
                MessageBox.Show("Please select the date from calendar.");
            }

            

        }

        /// <summary>
        /// Ta metoda służy do zapisywania daty wybranej przez użytkownika z kalendarza do pola.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calemdar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            advert.AdvertDate = (DateTime)calemdar.SelectedDate.Value;
           // SavedDate = calemdar.DisplayDate;
        }

      

        private void btnCleanAdvertAppForm_Click(object sender, RoutedEventArgs e)
        {
            foreach(Control ctl in AdvertAppForm1.Children)
            {
                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
                if (ctl.GetType() == typeof(ComboBox))
                    ((ComboBox)ctl).SelectedIndex = -1;
            }
        }

        private void txtTitleAdvertAppForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Title")
            {
                textBox.Text = string.Empty;
            }
        }

       

        private void txtWalkingTimeAdvertAppForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "0")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtAdvertPrizeAdvertAppForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "0")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtContentAdvertAppForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Content")
            {
                textBox.Text = string.Empty;
            }
        }

        private void btnExitAdvertAppForm(object sender, RoutedEventArgs e)
        {
            DogList dogList = new DogList();
            dogList.Show();
            Close();    
        }
    }
}
