using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WalkYourDogApp;

namespace WYD
{
    /// <summary>
    /// All information about the owner.
    /// </summary>
    public partial class NewOwnerForm : Window
    {
        OwnerModel owner = new OwnerModel();
        AppOwnerModel appOwner = new AppOwnerModel();
        OwnerForm ownerForm = new OwnerForm();


        /// <summary>
        ///  Służy do inicjalizacji wszystkich składników w formularzu oraz ich konfiguracji.
        /// </summary>
        public NewOwnerForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Metoda służy do dodania nowego właściciela psa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOwnerNewOwnerForm_Click(object sender, RoutedEventArgs e)
        {

            if (txtNameNewOwnerForm.Text.Length > 0 || txtSurnameNewOwnerForm.Text.Length > 0 || txtDateNewOwnerForm.Text.Length > 0 || txtEmailNewOwnerForm.Text.Length > 0 || txtPhoneNewOwnerForm.Text.Length > 0)
            {
                owner.OwnerName = txtNameNewOwnerForm.Text;
                owner.OwnerSurname = txtSurnameNewOwnerForm.Text;
                owner.OwnerPhone = txtPhoneNewOwnerForm.Text;
                owner.OwnerEmail = txtEmailNewOwnerForm.Text;

                if (cmbGenderNewOwnerForm.Text == "Male")
                {
                    owner.OwnerGender = EnumOwnerGender.male;
                }
                else if (cmbGenderNewOwnerForm.Text == "Female")
                {
                    owner.OwnerGender = EnumOwnerGender.female;
                }
                else
                {
                    owner.OwnerGender = EnumOwnerGender.other;
                }
            }

            string dateText = txtDateNewOwnerForm.Text;
            DateTime date;
            if (DateTime.TryParseExact(dateText, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                owner.OwnerDateOfBirth = date;

                appOwner.AddToList(owner);
                owner.SaveOwnerToBase();
                MessageBox.Show("Owner has been added.");
            }

            else
            {
                MessageBox.Show("Wrong date format. Correct format: yyyy-MM-dd");
                txtDateNewOwnerForm.Focus();
            }

        }

        /// <summary>
        /// Metoda ta jest odpowiedzialna za zamknięcie okna "NewOwnerForm" i
        /// przywrócenie okna "ownerForm".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnExitNewOwnerForm_Click(object sender, RoutedEventArgs e)
        {
            OwnerForm ownerForm = new OwnerForm();
            ownerForm.Show();

            Close();
        }

        private void btnClearNewOwnerForm_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in NewOwnerForm1.Children)
            {
                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
                if (ctl.GetType() == typeof(ComboBox))
                    ((ComboBox)ctl).SelectedIndex = -1;
            }
        }

        private void txtNameNewOwnerForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Name")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtSurnameNewOwnerForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Surname")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtDateNewOwnerForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Date of birth")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtEmailNewOwnerForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Email")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtPhoneNewOwnerForm_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Phone")
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
