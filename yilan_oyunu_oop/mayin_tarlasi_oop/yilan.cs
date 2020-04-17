using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yilan_oyunu_oop
{
    public class yilan
    {



        public int X = 1, Y = 1,skor = 0;
        public void ciz()
        {
            Console.Clear();
            Console.SetCursorPosition(X,Y);
            Console.Write("*");
        }
        public void tusAl(ConsoleKeyInfo tus)
        {
            if (tus.Key == ConsoleKey.RightArrow)
            {
                X++;
                ciz();
            }
            else if(tus.Key == ConsoleKey.LeftArrow)
            {
                X--;
                ciz();
            }
            else if (tus.Key == ConsoleKey.UpArrow)
            {
                Y--;
                ciz();
            }
            else if (tus.Key == ConsoleKey.DownArrow)
            {
                Y++;
                ciz();
            }
            if (X == 25)
                X = 1;
            if (X == 0)
                X = 25;
            if (Y == 25)
                Y = 1;
            if (Y == 0)
                Y = 25;
        }
        public bool yemYendimi(Yem yem)
        {
            bool yemDurum = false;
            if((yem.yemX == X) && (yem.yemY == Y))
            {
                skor++;
               yemDurum = true;
            }
            return yemDurum;
        }
        public void Skor()
        {
            Console.SetCursorPosition(1, 29);
            Console.WriteLine(" Skorunuz : " + skor);
        }
    }
}
