using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
   public interface IBookChaptersRepository
    {
        void Init();

        void Add(BookChapter chapter);
        BookChapter Remove(string id);
        IEnumerable<BookChapter> GetAll();
        BookChapter Find(string id);
        void Update(BookChapter chapter);
    }
}
