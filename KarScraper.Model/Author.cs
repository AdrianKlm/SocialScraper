using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Model
{
    public class Author
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string FirstName { get { return Name.Remove(Name.IndexOf(" ")); } }
        public string LastName  { get { return Name.Remove(0, Name.IndexOf(" ")+1); } }
        public char Sex { get { return FirstName.Last() == 'a' ? 'K' : 'M'; } }
    }
}
