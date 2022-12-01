using System;
using System.Collections.Generic;
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
                var jsonString = JsonSerializer.Serialize(posts); //Serialisera listan med poster
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
            Console.WriteLine("I n l ä g g   i   G ä s t b o k e n: ");
            foreach(Post p in this.posts)
            {
                Console.WriteLine("ID: " + p.getId() + " FÖRFATTARE: " + p.getAuthorName() + " TEXT: " + p.getPostText());
            }
            return true;
        }

        public bool newPost(Post post)
        {
            var id = posts.Count() + 1;
            post.setId(id);
            posts.Add(post);
            Console.WriteLine("Listan är sparad");
            saveGuestbook(); //Spara gästboken
            return true;
        }
        public bool DeletePost(int id)
        {
            Console.WriteLine("I deletepost-funktionen");
            return true;
        }
    }
}
