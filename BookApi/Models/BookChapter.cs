using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class BookChapter
    {
        public string Id { get; set; }

        public int Number { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
    }
}
