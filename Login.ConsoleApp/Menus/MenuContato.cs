using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.ConsoleApp.Menus
{
    public class MenuContato : SubMenu
    {
        public override void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu Contato");

            Console.ReadLine();
        }
    }
}
