using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yilan_oyunu_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            int donguDurum = 1, skor = 0;
            ConsoleKeyInfo basilanTus;

            Yem yem = new Yem();
            yem.yemUret();          
            yilan yilan = new yilan();
            yilan.Skor();
            Console.SetCursorPosition(1,29);
            Console.WriteLine(skor);
            do
            {                
                basilanTus = Console.ReadKey();
                yilan.tusAl(basilanTus);
                yilan.ciz();
                yem.yemciz();
                if(yilan.yemYendimi(yem) == true)
                {                    
                    yilan.ciz();                 
                    yem.yemUret();
                    yem.yemciz();                   
                }
                yilan.Skor();
            } while(donguDurum == 1);

            Console.ReadLine();
        }
    }
}
