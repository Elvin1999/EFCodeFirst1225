using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace EFCodeFirst.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return Firstname;
        }
    }
}
