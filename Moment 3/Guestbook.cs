using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
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
        private List<Post> posts = new List<Post>(); //Fält för att lagra lista med poster

        public Guestbook(string filename) //Konstruktor, tänker att det kan bli möjligt att öppna olika gästböcker med olika namn i framtiden
        {
            this.filename = filename;
            this.path = Directory.GetCurrentDirectory().ToString(); //Directory.GetCurrentDirectory() efter förslag från Lars via Moodle
            this.filePath = this.path + "\\" + this.filename; 
            

            if(File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                this.posts = JsonSerializer.Deserialize<List<Post>>(jsonString);
                //Console.WriteLine("Posts: ÄR EFTER INLADDNING " + this.posts);
            } 
            else
            {
                Console.WriteLine("Error: Gästboken: " + this.filePath + " existerar inte!");
            }
        }

        public bool saveGuestbook()
        {
            if(filePath != null) //Kontrollera att filsökvägen inte är null
            {
                var jsonString = JsonSerializer.Serialize(getPosts()); //Serialisera listan med poster
                //Console.WriteLine("Följande jsonString sparades: " + jsonString);
                File.WriteAllText(filePath, jsonString); //Skriv jsondata till fil
                return true; //True, metoden lyckades skriva till fil
            }
            else
            {
                Console.WriteLine("Error: FilePath är null."); //Skriv ut felmeddelande   
            }
            return false; //False, metoden misslyckades att skriva till fil

        }

        public bool printPosts()
        {
            Console.WriteLine("\n\n I n l ä g g   i   G ä s t b o k e n: ");
            int i = 0; //Räknare
            foreach(Post p in posts)
            {
                string aName = p.getAuthorName();
                string pText = p.getPostText();
                Console.WriteLine("ID: " + i++ + " FÖRFATTARE: " + aName + " TEXT: " + pText);
            }
            return true;
        }

        public Post newPost(string name, string post)
        {
            Post newP = new Post(name, post); //Skapa det nya inlägget

            posts.Add(newP); //Lägg till inlägget i listan med inlägg

            saveGuestbook(); //Spara gästboken
            return newP;
        }
        public bool DeletePost(int id)
        {
            posts.RemoveAt(id); //Ta bort inlägg med valt index
            saveGuestbook(); //Spara gästboken
            return true;
        }

        public List<Post> getPosts()
        {
            return posts;
        }
    }
}
