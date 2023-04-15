using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkYourDogAppProject
{

    /// <summary>
    /// Metoda "AddToList" służy do dodawania obiektów do listy.
    /// Metoda "RemoveFromList" służy do usuwania obiektów z listy (jeśli taki obiekt już na niej istnieje).
    /// </summary>
    public interface IListable
    {
         void AddToList(object obj);
         void RemoveFromList(object obj);
    }
}
