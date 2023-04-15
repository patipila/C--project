using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{
    [Serializable]
    public class AppDogModel : Model1, IListable, ICloneable,IXml
    {
        public List<DogModel> dogList = new List<DogModel>();


        public List<DogModel> DogList { get => dogList; set => dogList = value; }

        /// <summary>
        /// Metoda "addDogToList" służy do dodawania psów do listy "dogList".
        /// </summary>
        public void addDogToList()
        {

            foreach (DogModel dog in DogModels.Where(x => x.OwnerId == OwnerModel.SelectedOwner.OwnerId).ToList())
            {

                dogList.Add(dog);

            }

        }

        /// <summary>
        /// Metoda "ReadXml" służy do odczytywania danych z pliku XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public object ReadXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppDogModel));
            FileStream fs = new FileStream($"{filePath}.xml", FileMode.Open);
            return (AppDogModel)serializer.Deserialize(fs);

        }

        /// <summary>
        /// Metoda "WriteXml" służy do zapisywania danych do pliku XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>

        public void WriteXml(string filePath, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppDogModel));
            TextWriter writer = new StreamWriter($"{filePath}.xml");
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        /// <summary>
        /// Metoda "AddToList" służy do dodawania obiektów typu "DogModel" do listy "DogList".
        /// </summary>
        /// <param name="obj"></param>
        public void AddToList(object obj)
        {
            DogList.Add((DogModel)obj);
        }

        /// <summary>
        /// Metoda "RemoveFromList" służy do usuwania obiektów typu "DogModel" z listy "DogList"
        /// (jeśli taki obiekt istnieje na liście).
        /// </summary>
        /// <param name="obj"></param>

        public void RemoveFromList(object obj)
        {
            if (this.DogList.Contains((DogModel)obj))
                this.DogList.Remove((DogModel)obj);
        }

        /// <summary>
        /// Metoda "Clone" służy do tworzenia kopii obiektu "AppDogModel".
        /// </summary>
        /// <returns></returns>

        public object Clone() => this.MemberwiseClone();

        /// <summary>
        /// Metoda "DeepClone" służy do tworzenia głębokiej kopii obiektu "AppDogModel" 
        /// wraz z wszystkimi obiektami zawartymi w jego liście "DogList".
        /// </summary>
        /// <returns></returns>
        public object DeepClone()
        {
            AppDogModel dogs = new AppDogModel();
            dogs = (AppDogModel)this.MemberwiseClone();
            dogs.DogList = new List<DogModel>();
            foreach (DogModel dog in this.DogList)
                dogs.AddToList((DogModel)dog.Clone());
            return dogs;

        }

    }

}
