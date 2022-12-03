using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Moment_3
{
    internal class Post
    {
        //Medlemsvariabler för att lagra info för posten
        public string authorName { get; set; } //public + {get; set; } För att få Json-deserialization att fungera 
        public string postText { get; set; }

        public Post(string authorName, string postText) //Constructor
        {
            this.authorName = authorName;
            this.postText = postText;
        }

        public void setAuthorName(string authorName)
        {
            this.authorName = authorName;
        }

        public void setPostText(string text)
        {
            this.postText = text;
        }
       //Get-funktioner för att returnera värdet av medlemsvariablerna
        public string getAuthorName()
        {
            return this.authorName;
        }

        public string getPostText()
        {
            return this.postText;
        }

    }
}
