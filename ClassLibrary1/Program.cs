using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            GraphicInterface graphicInterface = new GraphicInterface();
            graphicInterface.StartsInterface();
        }
    }
}