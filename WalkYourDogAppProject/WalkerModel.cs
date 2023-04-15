using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Net.Cache;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{
    public class WalkerModel:ICloneable
    {
        protected int id;
        protected string walkerName;
        protected string walkerSurname;
        protected DateTime walkerDateOfBirth;
        protected string walkerEmail;
        protected string walkerPhone;
        protected string descriptionW;
        protected EnumWalkerGender walkerGender;
       

        [DisplayName("Owner ID")]
        [Key]
        public int Id { get => id; set => id = value; }

        [DisplayName("Walker Name")]
        public string WalkerName { get => walkerName; set => walkerName = value; }

        [DisplayName("Walker Surname")]
        public string WalkerSurname { get => walkerSurname; set => walkerSurname = value; }

        [DisplayName("Walker Birthdate")]
         public DateTime WalkerDateOfBirth { get => walkerDateOfBirth; set => walkerDateOfBirth = value; }

        [DisplayName("Walker Email")]
         public string WalkerEmail { get => walkerEmail; set => walkerEmail = value; }

        [DisplayName("Walker Phone Number")]
        public string WalkerPhone {
            get
            {
                return walkerPhone;
            }
            set
            {
                walkerPhone = value;
            }
        }

        [DisplayName("Walker Description")]
        public string DescriptionW { get => descriptionW; set => descriptionW = value; }
        public EnumWalkerGender WalkerGender { get => walkerGender; set => walkerGender = value; }


        /// <summary>
        /// Konstruktor bezparametrowy klasy "WalkerModel" inicjalizuje wartość pola "Id" na 0, a następnie zwiększa ją o 1.
        /// </summary>

        public WalkerModel()
        {
            Id = 0;
            Id++;
        }

        public WalkerModel( string walkerName, string walkerSurname, string walkerDateOfBirth, string walkerEmail, string walkerPhone, EnumWalkerGender walkerGender) : this()
        {
           
            WalkerName = walkerName;
            WalkerSurname = walkerSurname;
            DateTime date;
            DateTime.TryParseExact(walkerDateOfBirth, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            WalkerDateOfBirth = date;
            WalkerEmail = walkerEmail;
            WalkerPhone = walkerPhone;
            WalkerGender= walkerGender;
            
        }

        public WalkerModel(string walkerName, string walkerSurname, string walkerDateOfBirth, string walkerEmail, string walkerPhone, EnumWalkerGender walkerGender, string descriptionW) : this(walkerName, walkerSurname, walkerDateOfBirth, walkerEmail, walkerPhone, walkerGender)
        {
            DescriptionW = descriptionW;
        }

        /// <summary>
        /// Metoda "Age", która oblicza wiek wyprowadzającego na podstawie daty urodzenia
        /// </summary>
        /// <returns>Zwraca wiek wyprowadzającego</returns>
        public int Age()
        {
            return DateTime.Now.Year - walkerDateOfBirth.Date.Year;
        }

        /// <summary>
        ///  Przesłonięta metoda "ToString"
        /// </summary>
        /// <returns>Zwraca imię i nazwisko wyprowadzającegoo</returns>
        public override string ToString()
        {
            return $"{walkerName} {walkerSurname} ";
        }

        /// <summary>
        /// Metoda "SaveWalkerToBase" służy do zapisywania obiektu klasy "WalkerModel" do bazy danych. 
        /// </summary>

        public void SaveWalkerToBase()
        {
            using (Model1 db = new Model1())
            {
                db.WalkersModels.Add(this);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metoda "Clone"  pozwala na klonowanie obiektu "WalkerModel".
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();

    }

    /// <summary>
    /// Enumeracja "EnumWalkerGender", która określa płeć wyprowadzającego
    /// </summary>
    public enum EnumWalkerGender { male, female, other }
}