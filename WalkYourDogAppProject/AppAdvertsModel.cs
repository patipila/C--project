using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{
    [Serializable]
    public class AppAdvertsModel : Model1, IListable, IXml,ICloneable
    {

       
        List<AdvertModel> appAdverts = new List<AdvertModel>();
        

        public List<AdvertModel> AppAdverts { get => appAdverts; set => appAdverts = value; }



        public void addAdvertToList()
        {
            
                foreach (var advert in AdvertModels.ToList())
                {
                    AppAdverts.Add(advert);
                }
            
        }



        /// <summary>
        /// Usuwanie ogłoszeń po numerze ID.
        /// </summary>
        /// <param name="ID">ID ogłoszenia</param>

        public void DelateAdvertByID(int ID)
        {
            if (this.AppAdverts.FirstOrDefault(advert => advert.AdvertId == ID) == null)
                return;

            this.AppAdverts.Remove(this.AppAdverts.FirstOrDefault(advert => advert.AdvertId == ID));
        }



        /// <summary>
        /// Sortowanie ogłoszeń po nazwie.
        /// </summary>
        public void SortByAdvertName()
        {
            this.appAdverts.Sort(new AdvertNameComparator());
        }


        /// <summary>
        /// Metoda nadpisuje metodę ToString(); tworzona jest
        /// reprezentacja tekstową wszystkich obiektów AdvertModel znajdujących się na liście appAdverts
        /// </summary>
        /// <returns>Zwracany jest tekst</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (AdvertModel advert in appAdverts)
                sb.AppendLine(advert.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Metoda "ReadXml" służy do odczytywania danych z pliku XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public object ReadXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppAdvertsModel));
            FileStream fs = new FileStream($"{filePath}.xml", FileMode.Open);
            return (AppAdvertsModel)serializer.Deserialize(fs);

        }

        /// <summary>
        /// Metoda "WriteXml" służy do zapisywania danych do pliku XML .
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public void WriteXml(string filePath, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppAdvertsModel));
            TextWriter writer = new StreamWriter($"{filePath}.xml");
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        /// <summary>
        /// Metoda "AddToList" służy do dodawania obiektów typu "AdvertModel" do listy "AppAdverts".
        /// </summary>
        /// <param name="obj"></param>

        public void AddToList(object obj)
        {
            AppAdverts.Add((AdvertModel)obj);
        }

        /// <summary>
        /// Metoda "RemoveFromList" służy do usuwania obiektów typu "AdvertModel" z listy "AppAdverts"
        /// (jeśli taki obiekt istnieje na liście).
        /// </summary>
        /// <param name="obj"></param>

        public void RemoveFromList(object obj)
        {
            if (this.AppAdverts.Contains((AdvertModel)obj))
                this.AppAdverts.Remove((AdvertModel)obj);
        }

        /// <summary>
        /// Metoda "Clone" służy do tworzenia kopii obiektu "AppAdvertsModel".
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();


        /// <summary>
        /// Metoda "DeepClone" służy do tworzenia głębokiej kopii obiektu "AppAdvertsModel" 
        /// wraz z wszystkimi obiektami zawartymi w liście "AppAdverts".
        /// </summary>
        /// <returns></returns>
        public object DeepClone()
        {
            AppAdvertsModel adverts = new AppAdvertsModel();
            adverts = (AppAdvertsModel)this.MemberwiseClone();
            adverts.AppAdverts = new List<AdvertModel>();
            foreach (AdvertModel advert in this.AppAdverts)
                adverts.AddToList((DogModel)advert.Clone());
            return adverts;

        }
    }
}
