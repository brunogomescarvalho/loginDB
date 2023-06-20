using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.ConsoleApp.Menus
{
    public class MenuProduto : SubMenu
    {
        public override void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu Produto");

            Console.ReadLine();
        }
    }
}
