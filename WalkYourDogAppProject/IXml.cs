using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkYourDogAppProject
{

    /// <summary>
    /// Metoda "ReadXml"  służy do odczytywania danych z pliku XML i deserializacji ich do obiektu.
    /// Metoda "WriteXml" służy do zapisywania danych do pliku XML i serializacji ich z obiektu "obj".
    /// </summary>
    public interface IXml
    {

          object ReadXml(string filePath);

          void WriteXml(string filePath, object obj);
    }
}
