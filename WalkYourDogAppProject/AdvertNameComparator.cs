using System.Collections.Generic;

namespace WalkYourDogApp
{
    internal class AdvertNameComparator : IComparer<AdvertModel>
    {

        /// <summary>
        ///  Metoda Compare przyjmującą dwa parametry "x" i "y" typu "AdvertModel", która porównuje nazwy ogłoszeń za pomocą metody "string.Compare".
        ///  Metoda ta jest używana przez metodę "SortByAdvertName" w klasie "AppAdvertsModel" do sortowania ogłoszeń po nazwie.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Zwraca int oznaczający kolejność porównywanych ogłoszeń</returns>
        public int Compare(AdvertModel x, AdvertModel y)
        {
            return string.Compare(x.AdvertName, y.AdvertName);
        }
    }
}