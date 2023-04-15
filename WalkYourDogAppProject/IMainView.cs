using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkYourDogApp
{

    /// <summary>
    ///  Interfejs ten zawiera dwa eventy "ShowPetView" i "ShowOwnerView".
    ///  Te eventy służą do powiadamiania o tym, że widok zwierzęcia lub widok właściciela powinien być wyświetlony.
    ///  Aplikacja, która implementuje ten interfejs, będzie reagować na te zdarzenia i wykonywać odpowiednie działania.
    /// </summary>
    internal interface IMainView
    {
        event EventHandler ShowPetView;
        event EventHandler ShowOwnerView;
    }
}
