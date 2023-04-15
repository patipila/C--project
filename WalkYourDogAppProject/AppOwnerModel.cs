using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WalkYourDogAppProject;

namespace  WalkYourDogApp
{
    [Serializable]
    public class AppOwnerModel : Model1 ,IListable,ICloneable,IXml

    {
       
        List<OwnerModel> ownerList = new List<OwnerModel>();

      

        public List<OwnerModel> OwnerList { get => ownerList; set => ownerList = value; }
       

        
        public AppOwnerModel()
        {
            
            OwnerModel owner = new OwnerModel();
            List<OwnerModel> ownerList = new List<OwnerModel>();
        }

        /// <summary>
        /// Metoda "addOwnerToList" służy do dodawania właścicieli do listy "OwnerList". 
        /// </summary>

        public void addOwnerToList()
        {

                foreach (var owner in OwnerModels.ToList())
                {
                    OwnerList.Add(owner);
                }
            
        }


        /// <summary>
        /// Metoda "ReadXml" służy do odczytywania danych z pliku XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public object ReadXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppOwnerModel));
            FileStream fs = new FileStream($"{filePath}.xml", FileMode.Open);
            return (AppOwnerModel)serializer.Deserialize(fs);
        }

        /// <summary>
        /// Metoda "WriteXml" służy do zapisywania danych do pliku XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public void WriteXml(string filePath, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppOwnerModel));
            TextWriter writer = new StreamWriter($"{filePath}.xml");
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        /// <summary>
        /// Metoda "AddToList" służy do dodawania obiektów typu "OwnerModel" do listy "OwnerList".
        /// </summary>
        /// <param name="obj"></param>
        public void AddToList(object obj)
        {
            OwnerList.Add((OwnerModel)obj);
        }

        /// <summary>
        /// Metoda "RemoveFromList" służy do usuwania obiektów typu "OwnerModel" z listy "OwnerList" 
        /// (jeśli taki obiekt istnieje na liście).
        /// </summary>
        /// <param name="obj"></param>
        public void RemoveFromList(object obj)
        {
            if (this.OwnerList.Contains((OwnerModel)obj))
                this.OwnerList.Remove((OwnerModel)obj);
        }

        /// <summary>
        /// Metoda "Clone" służy do tworzenia kopii obiektu "AppOwnerModel".
        /// </summary>
        /// <returns></returns>
        public object Clone() => this.MemberwiseClone();

        /// <summary>
        /// Metoda "DeepClone" służy do tworzenia głębokiej kopii obiektu "AppOwnerModel" 
        /// wraz z wszystkimi obiektami zawartymi w jego liście "OwnerList".
        /// </summary>
        /// <returns></returns>
        public object DeepClone()
        {
            AppOwnerModel owners = new AppOwnerModel();
            owners = (AppOwnerModel)this.MemberwiseClone();
            owners.OwnerList = new List<OwnerModel>();
            foreach (OwnerModel owner in this.OwnerList)
                owners.AddToList((OwnerModel)owner.Clone());
            return owners;

        }
    }
}
