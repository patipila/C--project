using System;
using System.Collections.Generic;

namespace WalkYourDogApp
{
    /// <summary>
    ///  Klasa ta implementuje interfejs IComparer<WalkerModel>, co oznacza, że jest to
    ///  komparator dla typu "WalkerModel"
    /// </summary>
    public class WalkerNameComparator : IComparer<WalkerModel>
    {

        /// <summary>
        /// Klasa ta zawiera metodę Compare, która porównuje dwie instancje klasy "WalkerModel.
        /// Porównanie jest dokonywane na podstawie nazwiska wyprowadzającego.
        /// </summary>
        /// <param name="x">Nazwisko jednego wyprowadzającego</param>
        /// <param name="y">Nazwisko drugiego wyprowadzająceggo</param>
        /// <returns> Zwraca liczbę całkowitą, która wskazuje,
        /// czy pierwszy argument jest mniejszy, większy lub równy drugiemu argumentowi</returns>
        public int Compare(WalkerModel x, WalkerModel y)
        {
            return string.Compare(x.WalkerSurname, y.WalkerSurname);
        }
    }
}