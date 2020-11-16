using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    class ListaPosortowana
    {
        Wezel glowa = null; // element poczatkowy listy

        public void Wstaw(int num)
        {
            if(glowa == null)
            {
                Wezel tmp = new Wezel();

                tmp.dane = num;
                tmp.nastepny = null;

                glowa = tmp;
            }
            else
            {
                Wezel tmp = glowa;
                Wezel doPrzestawienia = null;

                if(num < glowa.dane)
                {
                    glowa = new Wezel();
                    glowa.dane = num;
                    glowa.nastepny = tmp;
                    return;
                }
                else
                {
                    while (tmp.nastepny != null)
                    {
                        if(num >= tmp.nastepny.dane)
                        {
                            tmp = tmp.nastepny;
                        }
                        else
                        {
                            break;
                        }
                    }

                    doPrzestawienia = tmp.nastepny;

                    tmp.nastepny = new Wezel();

                    tmp.nastepny.dane = num;
                    tmp.nastepny.nastepny = doPrzestawienia;
                   
                }
            } 
        }

        public override string ToString() //metoda testowa do sprawdzenia poprawnosci wstawiania
        {
            string result = "[";
            Wezel aktualny = glowa;

            while (aktualny != null)
            {
                result += aktualny.dane + ", ";
                aktualny = aktualny.nastepny;
            }

            result += "]";

            return result;
        }

        class Wezel
        {
            public int dane;
            public Wezel nastepny = null;
        }
    }

    static void Main(string[] args)
    {
        ListaPosortowana lista = new ListaPosortowana();

        lista.Wstaw(2);
        lista.Wstaw(9);
        lista.Wstaw(6);
        lista.Wstaw(1);
        lista.Wstaw(3);
        lista.Wstaw(7);
        Console.WriteLine(lista);

        Console.ReadLine();
    }
}

