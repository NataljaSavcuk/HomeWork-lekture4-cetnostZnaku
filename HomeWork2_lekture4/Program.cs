using System.Collections.Generic;
namespace HomeWork2_lekture4

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte text: "); //v pripade kopirovani textu - nekopirovat s prazdnymi radky!
            string inputText = Console.ReadLine();
            char[] text = inputText.ToCharArray();

            List<MyLibrary> statistika = new List<MyLibrary>();//pro celkovou statistiku
            List<MyLibrary> statistika2 = new List<MyLibrary>();//pro statistiku velkych a malych znaku

            //nevim jestli zadani predpokladalo toto. Je to prace spis s Array nez s List. 
            int pocetVelkychZnaku = 0;
            int pocetMalychZnaku = 0;
            int pocetBilychZnaku = 0;

            for (int i = 0; i < text.Length; i++)
            {
                int pocet = 0;
                
                for (int j = 0; j<text.Length;j++)//porovnavame kazdy znak textu s kazdym v celem textu
                {
                    if (text[i] == text[j])
                    {
                        pocet++;
                    }
                }
               MyLibrary zaznam = new MyLibrary() { Znak = text[i], Pocet = pocet};

               if (!statistika.Contains(zaznam)) //vytvarime zaznam pro kazdy novy znak
                {
                    statistika.Add(zaznam);
                }
               //delame statistiku velkych a malych pismen a mezer 
               if (char.IsUpper(text[i]))
                {
                    pocetVelkychZnaku++;
                }
               else if (char.IsLower(text[i]))
                {
                    pocetMalychZnaku++;
                }
               else if (char.IsWhiteSpace(text[i]))
                {
                    pocetBilychZnaku++;
                }
            }
            statistika2.Add(new MyLibrary() { Znak = 'V', Pocet = pocetVelkychZnaku });
            statistika2.Add(new MyLibrary() { Znak = 'm', Pocet = pocetMalychZnaku });
            statistika2.Add(new MyLibrary() { Znak = ' ', Pocet = pocetBilychZnaku });


            Console.WriteLine("Statistika textu:");
            for (int i = 0; i < statistika.Count; i++)
            {
                Console.WriteLine(statistika[i]);               
            }
            //neni to uplne sofistikovane, mela bych jit pres Content nebo Find,
            //ale pro List ktery ma pouze 3 cleny - je to OK 
            Console.WriteLine("Celkovy pocet velkych pismen je " + statistika2[0].Pocet);
            Console.WriteLine("Celkovy pocet malych pismen je " + statistika2[1].Pocet);
            Console.WriteLine("Celkovy pocet mezer je " + statistika2[2].Pocet);

            //Bonus: Jestli chceme statistiku konkretniho znaku:
            while (true)
            {
                Console.WriteLine("Chcete zobrazit statistiku pro konkretní znak? Stiskněte 'A' jestli Ano");
                string odpoved = Console.ReadLine().ToUpper();
                if (odpoved == "A")
                {
                    Console.WriteLine("Napište znak, statistiku kterého chcete zobrazit:");
                    char inputZnak = Console.ReadLine()[0];
                    if(statistika.Contains(new MyLibrary { Znak= inputZnak }))
                    {
                        //toto nebylo na prednasce, ale byla jsem lina psat dalsi cykl for
                        Console.WriteLine(statistika.Find(x => x.Znak.Equals(inputZnak)));
                    }
                    else { Console.WriteLine("Tento znak neni v textu"); }
                }
                else { break; }
                }
            }
        
    }
}