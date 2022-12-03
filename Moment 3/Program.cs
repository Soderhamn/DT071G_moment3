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
                //Post myPost = new Post("", "");
                string? pressedKey = ""; //string? för att hantera felmeddelande om possible null
                Console.WriteLine("MARCUS GÄSTBOK!");
                Console.WriteLine("\n \n Meny: \n\t[1] Skriv ett nytt inlägg\n\t[2] Ta bort ett inlägg \n \n\t[X] Avsluta programmet");

                myGuestbook.printPosts();

                pressedKey = Console.ReadLine();
                
                switch(pressedKey)
                {
                    case "1": //Skriv nytt inlägg
                        Console.Clear(); //Rensa skärmen
                        //Fråga efter Input Nytt namn på författare + inlägg
                        Console.WriteLine("Ange ditt namn: ");
                        string authorName = Console.ReadLine();
                        Console.WriteLine("Skriv ditt inlägg: ");
                        string postText = Console.ReadLine();
                        Console.Clear();

                        //Kontrollera Input
                        if (!String.IsNullOrEmpty(authorName) && !String.IsNullOrEmpty(postText))
                        {
                            myGuestbook.newPost(authorName, postText); //Skapa nytt inlägg
                        }
                        else
                        {
                            Console.WriteLine("Fel: du måste fylla i både namn och text");
                        }

                    break;

                    case "2": //Ta bort inlägg
                        Console.WriteLine("Vilket inlägg vill du ta bort? (Ange siffra)");
                        string input = Console.ReadLine();

                        Console.Clear(); //Rensa skärmen efter val

                        if (!String.IsNullOrEmpty(input)) //Om strängen ej är tom
                        {
                            int idToDelete = Convert.ToInt32(input); //Läs in text och konvertera till int
                            myGuestbook.DeletePost(idToDelete);
                        }
                        else //Om strängen är tom
                        {
                            Console.WriteLine("Fel: Du kan inte lämna valet tomt!");
                        }
                        
                        

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

                
            }
        }
    }
}