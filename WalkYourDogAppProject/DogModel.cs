using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{
    public class DogModel : Model1, ICloneable
    {
        protected int dogId;
        protected string dogName;
        protected string dogAge;
        protected EnumSize dogSize;
        protected EnumActivity activityDemand;
        protected string descriptionD;
        
        protected EnumGender dogGender;
        public static DogModel SelectedDog;


        [DisplayName("Dog ID")]
        [Key]
        public int DogId { get => dogId; set => dogId = value; }



        [DisplayName("Dog Name")]
        public string DogName { get => dogName; set => dogName = value; }

        [DisplayName("Dog Age")]
        public string DogAge { get => dogAge; set => dogAge = value; }

        [DisplayName("Dog Size")]
        public EnumSize DogSize { get => dogSize; set => dogSize = value; }

        [DisplayName("Dog Activity")]
        public EnumActivity ActivityDemand { get => activityDemand; set => activityDemand = value; }



        public string DescriptionD { get => descriptionD; set => descriptionD = value; }
        public EnumGender DogGender { get => dogGender; set => dogGender = value; }

        [Required]
        public virtual OwnerModel Owner { get; set; }
        [Required]
        public int OwnerId { get; set; }


        public virtual List<AdvertModel> advert { get; set; }

        /// <summary>
        /// Konstruktor, który inicjalizuje wartość pola "Id" na 1, a następnie zwiększa ją o 1.
        /// </summary>


        public DogModel()
        {
            DogId = 1;
            
            
        }

        /// <summary>
        ///  Konstruktor przyjmuje parametry takie jak nazwa psa, wiek, rozmiar, poziom aktywności, właściciela, płeć psa.
        /// </summary>
        /// <param name="dogName">imię psa</param>
        /// <param name="dogAge">wiek psa</param>
        /// <param name="dogSize">wielkość psa</param>
        /// <param name="activityDemand">pziom aktywności psa</param>
        /// <param name="owner">właściciel psa</param>
        /// <param name="dogGender">płeć psa</param>
        public DogModel(string dogName, string dogAge, EnumSize dogSize, EnumActivity activityDemand, OwnerModel owner, EnumGender dogGender) : this()
        {
            DogName = dogName;
            DogAge = dogAge;
            DogSize = dogSize;
            ActivityDemand = activityDemand;
            Owner= owner;
            
            this.dogGender = dogGender;
            
            DescriptionD = descriptionD;
            DogGender = dogGender;
            DogId++;
        }

        /// <summary>
        /// Konstruktor przyjmuje parametry takie jak nazwa psa, wiek, rozmiar, poziom aktywności, właściciela, płeć psa oraz jego opis.
        /// </summary>
        /// <param name="dogName">imię psa</param>
        /// <param name="dogAge">wiek psa</param>
        /// <param name="dogSize">wielkość psa</param>
        /// <param name="activityDemand">pziom aktywności psa</param>
        /// <param name="owner">właściciel psa</param>
        /// <param name="dogGender">płeć psa</param>
        /// <param name="descriptionD">opis psa</param>

        public DogModel(string dogName, string dogAge, EnumSize dogSize, EnumActivity activityDemand, OwnerModel owner,  EnumGender dogGender, string descriptionD) : this(dogName, dogAge, dogSize, activityDemand, owner,  dogGender)
        {
            DescriptionD = descriptionD;
        }

        /// <summary>
        /// Metoda, która zwraca informacje o psie (imię, wiek)
        /// </summary>
        /// <returns>Zwraca imię i wiek psa</returns>
        public override string ToString()
        {
            return $"{dogName} {dogAge} ";
        }

        /// <summary>
        /// Ta metoda dodaje obiekt OwnerModel do pola Owner.
        /// </summary>
        /// <param name="owner"></param>

        public void AddOwner(OwnerModel owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Metoda "SaveDogToBase" służy do zapisywania obiektu "DogModel" do bazy danych. 
        /// </summary>

        public void SaveDogToBase()
        {
            
            Owner = OwnerModels.Where(x => x.OwnerId == OwnerModel.SelectedOwner.OwnerId).FirstOrDefault();

            DogModels.Add(this);
                SaveChanges();

        }

        /// <summary>
        /// Metoda "Clone" służy do tworzenia kopii obiektu "DogModel".
        /// </summary>
        /// <returns></returns>

        public object Clone() => this.MemberwiseClone();
    }

    /// <summary>
    /// Enumeracja: "EnumSize" (mały, średni, duży) określająca rozmiar psa.
    /// </summary>
    public enum EnumSize { small, medium, large }

    /// <summary>
    /// Enumeracja: "EnumActivity" (mała, średnia, duża) określająca poziom aktywności psa. 
    /// </summary>
    public enum EnumActivity { small, medium, large }

    /// <summary>
    /// Enumeracja: "EnumGender" (męska, żeńska) określająca płeć psa.
    /// </summary>
    public enum EnumGender { male, female, castrated }

}