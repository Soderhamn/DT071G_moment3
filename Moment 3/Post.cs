using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment_3
{
    internal class Post
    {
        private int id; //Medlemsvariabler för att lagra info för posten
        private string authorName;
        private string postText;

        public void setId(int id)
        {
            this.id = id;
        }

        public void setAuthorName(string authorName)
        {
            this.authorName = authorName;
        }

        public void setPostText(string text)
        {
            this.postText = text;
        }
        public int getId() //Get-funktioner för att returnera värdet av medlemsvariablerna
        {
            return this.id;
        }

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
