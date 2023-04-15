using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkYourDogAppProject
{
    /// <summary>
    /// Klasa abstrakcyjna posiadająca dwie metody.
    /// </summary>
    public abstract class XmlSerializable
    {

        /// <summary>
        /// Obie metody ("ReadXml" i "Write Xml") służą do odczytu i zapisu danych w formacie XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract object ReadXml(string filePath);

        public abstract  void WriteXml(string filePath,object obj);
    }
}
