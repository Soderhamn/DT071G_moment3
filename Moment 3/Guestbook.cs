using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Moment_3
{
    internal class Guestbook
    {
        //Fält/medlemsvariabler för att lagra nödändig data. Private för att bara vara åtkomlig inom klassen och inte i hela programmet
        private string filename;
        private string path;
        private string filePath;

        public Guestbook(string filename) //Konstruktor, tänker att det kan bli möjligt att öppna olika gästböcker med olika namn i framtiden
        {
            this.filename = filename;
            this.path = Directory.GetCurrentDirectory().ToString();
            this.filePath = this.path + this.filename;
        }

        public bool saveGuestbook(string data)
        {
            if(filePath != null) //Kontrollera att filsökvägen inte är null
            {
                FileStream f = File.Open(this.filePath, FileMode.OpenOrCreate); //Öppna fil, om den inte finns så skapa den.
                //f.WriteAsync("", default);
                return true; //True, metoden lyckades skriva till fil
            }
            else
            {
                Console.WriteLine("Error: FilePath är null."); //Skriv ut felmeddelande   
            }
            return false; //False, metoden misslyckades att skriva till fil

        }

        public string readGuestbook()
        {
            //JsonConverter.
            var guestbookStr = "TEMP: LÄSER UT HELA GUESTBOOK!"; //För testning
            return guestbookStr;
        }
    }
}
