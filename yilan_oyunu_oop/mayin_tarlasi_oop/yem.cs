using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yilan_oyunu_oop
{
    public class Yem
    {
        public int yemX, yemY;

        public void yemUret()
        {
            Random r = new Random();
            yemX = r.Next(1, 25);
            yemY = r.Next(1, 25);

        }
        public void yemciz()
        {
            Console.SetCursorPosition(yemX, yemY);
            Console.WriteLine("O");
           
        }
       
    }
}
