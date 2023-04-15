 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{


    public class AdvertModel : Model1,ICloneable
    {
        protected int advertId;
        protected string advertName;
        protected OwnerModel ownerInf;
        protected int advertPrice;
        protected int advertTime;
        protected DateTime advertDate;
        protected DateTime whenDate;
        protected string advertContent;
        public static AdvertModel SelectedAdvert;
        


        [Key]
        public int AdvertId { get => advertId; set => advertId = value; }
        public string AdvertName { get => advertName; set => advertName = value; }
        public OwnerModel OwnerInf { get => ownerInf; set => ownerInf = value; }
        public int AdvertPrize{get => advertPrice; set=> advertPrice = value; }
        public DateTime AdvertDate { get => advertDate; set => advertDate = value; }
        public DateTime WhenDate { get => whenDate; set => whenDate = value; }
        public int AdvertTime { get => advertTime; set => advertTime = value; }
        public string AdvertContent { get => advertContent; set => advertContent = value; }
        public  virtual  DogModel Dog { get; set; }
        public int DogId { get; set; }
        
        


        /// <summary>
        /// Konstruktor klasy AdvertModel, który inicjalizuje wartość pola "Id" na 1, a następnie zwiększa ją o 1.
        /// </summary>
        public AdvertModel()
        {
            AdvertId = 1;
            
        }

        public AdvertModel(string advertName, DogModel dogInf, OwnerModel ownerInf, int advertPrize, string advertDate, DateTime whenDate, int advertTime, string advertContent): this()
        {
            DateTime date;
            DateTime.TryParseExact(advertDate, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            AdvertDate = date;

            //DateTime date1;
            //DateTime.TryParseExact(whenDate, new[] {  "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date1);
            WhenDate = whenDate;

            AdvertName = advertName;
            Dog = dogInf;
            OwnerInf = ownerInf;
            AdvertPrize = advertPrize;
            AdvertTime = advertTime;
            AdvertContent= advertContent;
            AdvertId++;

        }

        /// <summary>
        /// Metoda "SaveAdvertToBase" służy do zapisywania ogłoszenia do bazy danych. 
        /// </summary>
        public void SaveAdvertToBase()
        {

            Dog = DogModels.Where(x => x.DogId == DogModel.SelectedDog.DogId).FirstOrDefault();
            OwnerInf = OwnerModels.Where(x => x.OwnerId == DogModel.SelectedDog.OwnerId).FirstOrDefault();

            AdvertModels.Add(this);
            SaveChanges();
            
        }



        /// <summary>
        /// Metoda "LoadAdvert" służy do ładowania ogłoszenia z bazy danych. 
        /// Pobiera ona ogłoszenie o określonym ID (AdvertId) z kolekcji "AdvertModels" 
        /// i przypisuje go do właściwości "SelectedAdvert".
        /// </summary>
        public void LoadAdvert()
        {
            SelectedAdvert = AdvertModels.Where(x => x.AdvertId == SelectedAdvert.AdvertId).FirstOrDefault();
        }

        /// <summary>
        /// Metoda "Clone" służy do tworzenia kopii obiektu ogłoszenia. Metoda ta jest implementacją interfejsu "ICloneable"
        /// Używa metody "MemberwiseClone" aby utworzyć nowy obiekt z takimi samymi wartościami jak oryginalny.
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();
    }
}
