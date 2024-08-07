using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookShelf.Core
{
        public class User
        {            
            public int Id { get; set; }           
            public string FullName { get; set; }          
            public string Password { get; set; }
            public string EmailAddress { get; set; }
           public List<string> Roles { get; set; } = new List<string>();
    }
    }


