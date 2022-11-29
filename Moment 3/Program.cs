using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-----Ändrar lite utseende, bara för roligt
            Console.Title = "Marcus Gästbok"; 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

            bool exit = false; //Boolean för att avgöra om programmet ska avslutas eller inte
            while (exit == false) //Kör loopen så länge inte användaren vill avsluta programmet
            {
                Guestbook myGuestbook = new Guestbook("marcusGuestbook.json"); //Instansiera Guestbook och öppna marcusGuestbook.json
                string? pressedKey = ""; //string? för att hantera felmeddelande om possible null
                Console.WriteLine("MARCUS GÄSTBOK!");
                Console.WriteLine("\n \n Meny: \n\t[1] Skriv ett nytt inlägg\n\t[2] Ta bort ett inlägg \n \n\t[X] Avsluta programmet");


                pressedKey = Console.ReadLine();
                
                switch(pressedKey)
                {
                    case "1": //Skriv nytt inlägg
                        Console.Clear(); //Rensa skärmen
                        //Fråga efter Input Nytt namn på författare + inlägg

                        //Kontrollera Input

                        //Spara inlägg och visa meddelande om det ELLER skriv ut felmeddelande

                    break;

                    case "2": //Ta bort inlägg
                        Console.Clear(); //Rensa skärmen

                        //Skriv ut alla inlägg för att visa Index

                        //Fråga efter Input om valt Index

                        //Kontrollera input

                        //Radera valt index eller skriv ut felmeddelande


                    break;
                    case "x": //Avsluta, oavsett om anv. skriver litet x eller X
                    case "X":
                        Console.Clear(); //Rensa skärmen
                        exit = true; //Användaren vill avsluta, sätt exit till true
                    break;
                    default: //Om inte 1, 2 eller X/x så har användaren gjort ett felaktigt val.
                        Console.Clear(); //Rensa skärmen
                        Console.WriteLine("\n\tFelaktigt val! Försök igen\n\n\a"); //\a = spela upp "alert"-ljud
                    break;
                }

                myGuestbook.readGuestbook();
            }
        }
    }
}