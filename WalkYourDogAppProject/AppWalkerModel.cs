using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WalkYourDogAppProject;

namespace WalkYourDogApp
{
    [Serializable]
    public class AppWalkerModel : XmlSerializable,IListable,ICloneable
    {

        List<WalkerModel> walkerList = new List<WalkerModel>();

        public List<WalkerModel> WalkerList { get => walkerList; set => walkerList = value; }

        /// <summary>
        /// Metoda "addWalkerToList" służy do dodawania wyprowadzających do listy "WalkerList". 
        /// Pobiera ona dane z bazy danych i dodaje je do listy.
        /// </summary>
        public void addWalkerToList()
        {

            using (var db = new Model1())
            {


                //long countStart = System.Convert.ToInt32(myCommand.ExecuteScalar());

                foreach (var walker in db.WalkersModels.ToList())
                {

                    WalkerList.Add(walker);

                }
            }

        }


        /// <summary>
        /// Metoda "DelateWalkertByID" służy do usuwania wyprowadzającego o danym ID z listy "WalkerList". 
        /// Sprawdza czy wyprowadzający o danym ID jest na liście i jeśli tak to go usuwa.
        /// </summary>
        /// <param name="ID"></param>
        public void DelateWalkertByID(int ID)
        {
            if (this.WalkerList.FirstOrDefault(walker => walker.Id == ID) == null)
                return;

            this.WalkerList.Remove(this.WalkerList.FirstOrDefault(walker => walker.Id == ID));
        }

        /// <summary>
        /// Metoda "AddToList" służy do dodawania obiektów typu "WalkerModel" do listy "WalkerList".
        /// </summary>
        /// <param name="obj"></param>

        public void AddToList(object obj)
        {
            WalkerList.Add((WalkerModel)obj);
        }

        /// <summary>
        /// Metoda "RemoveFromList" służy do usuwania obiektów typu "WalkerModel" z listy "WalkerList", jeśli taki obiekt istnieje na liście.
        /// </summary>
        /// <param name="obj"></param>
        public void RemoveFromList(object obj)
        {
            if (this.WalkerList.Contains((WalkerModel)obj))
                this.WalkerList.Remove((WalkerModel)obj);
        }

       
  
        /// <summary>
        /// Metoda do sortowania wyprowadzających.
        /// </summary>
        public void SortByWalkerName()
        {
            this.WalkerList.Sort(new WalkerNameComparator());
        }

        /// <summary>
        /// Przesłonięta metoda "ToString" 
        /// </summary>
        /// <returns>Zwracaja ciąg tekstowy zawierający informacje o wszystkich wyprowadzających w liście.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (WalkerModel walker in WalkerList)
                sb.AppendLine(walker.ToString());

            return sb.ToString();
        }


        /// <summary>
        /// Metoda "ReadXml" służy do odczytywania danych z pliku XML i deserializacji ich do obiektu "AppWalkerModel".
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override object ReadXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppWalkerModel));
            FileStream fs = new FileStream($"{filePath}.xml", FileMode.Open);
            return (AppWalkerModel)serializer.Deserialize(fs);

        }

        /// <summary>
        /// Metoda "WriteXml" służy do zapisywania danych do pliku XML i serializacji ich z obiektu "AppWalkerModel".
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public override void WriteXml(string filePath, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppWalkerModel));
            TextWriter writer = new StreamWriter($"{filePath}.xml");
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        /// <summary>
        /// Metoda "Clone" służy do tworzenia kopii obiektu "AppWalkerModel".
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();

        /// <summary>
        /// Metoda "DeepClone" służy do tworzenia głębokiej kopii obiektu "AppWalkerModel"
        /// wraz z wszystkimi obiektami zawartymi w jego liście "WalkerList".
        /// </summary>
        /// <returns></returns>
        public object DeepClone()
        {
            AppWalkerModel walkers = new AppWalkerModel();
            walkers = (AppWalkerModel)this.MemberwiseClone();
            walkers.WalkerList = new List<WalkerModel>();
            foreach (WalkerModel walker in this.WalkerList)
                walkers.AddToList((WalkerModel)walker.Clone());
            return walkers;

        }
    }
}

