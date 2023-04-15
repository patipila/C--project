using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{
    public class OwnerModel : Model1,ICloneable
    {
        protected static int ownerId;
        protected string ownerName;
        protected string ownerSurname;
        protected DateTime ownerDateOfBirth;
        protected string ownerEmail;
        protected string ownerPhone;
        protected EnumOwnerGender ownerGender;
        public static OwnerModel SelectedOwner;
        public virtual List<DogModel> OwnerDogs { get; set; }
        [DisplayName("Owner ID")]
        [Key]
        public int OwnerId
        { get => ownerId; set => ownerId = value; }

        [DisplayName("Owner Name")]
        public string OwnerName
        { get => ownerName; set => ownerName = value; }

        [DisplayName("Owner Surname")]
        public string OwnerSurname { get => ownerSurname; set => ownerSurname = value; }

        [DisplayName("Owner Birthdate")]
        public DateTime OwnerDateOfBirth { get => ownerDateOfBirth; set => ownerDateOfBirth = value; }

        [DisplayName("Owner Email")]

        public string OwnerEmail { get => ownerEmail; set => ownerEmail = value; }

        [DisplayName("Owner Phone Number")]
        public string OwnerPhone { get => ownerPhone; set => ownerPhone = value; }
        public EnumOwnerGender OwnerGender { get => ownerGender; set => ownerGender = value; }

        /// <summary>
        /// Konstruktor klasy "OwnerModel" inicjalizuje wartość pola "Id" na 0, a następnie zwiększa ją o 1.
        /// </summary>
        public OwnerModel()
        {
            OwnerId = 1;

        }

        public OwnerModel(string ownerName, string ownerSurname, DateTime ownerDateOfBirth, string ownerEmail, string ownerPhone, EnumOwnerGender ownerGender) : this()
        {
            OwnerName = ownerName;
            OwnerSurname = ownerSurname;
            OwnerDateOfBirth = ownerDateOfBirth;
            OwnerEmail = ownerEmail;
            OwnerPhone = ownerPhone;
            OwnerGender = ownerGender;
            OwnerId++;
        }
        public OwnerModel(string ownerName, string ownerSurname)
        {
            OwnerName = ownerName;
            OwnerSurname = ownerSurname;
        }

        /// <summary>
        /// Metoda, która pozwala na połączenie imienia i nazwiska właściciela
        /// </summary>
        /// <returns>Zwraca mię i Naziwsko właściciela psa</returns>
        public override string ToString()
        {
            return $"{ownerName} {ownerSurname} ";
        }

        /// <summary>
        /// Metoda "SaveOwnerToBase" służy do zapisywania obiektu klasy "OwnerModel" do bazy danych.
        /// </summary>
        public void SaveOwnerToBase()
        {
            
                OwnerModels.Add(this);
                SaveChanges();
            
        }

        /// <summary>
        /// Metoda "Clone" pozwala na klonowanie obiektu "OwnerModel".
        /// </summary>
        /// <returns></returns>

        public object Clone() => this.MemberwiseClone();
    }

    /// <summary>
    /// Enumeracja "EnumOwnerGender" zawierająca trzy elementy "male", "female" i "other" reprezentujące płeć właściciela.
    /// </summary>
    public enum EnumOwnerGender { male, female, other }

}
