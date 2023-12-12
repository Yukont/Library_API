using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public int Isbn { get; set; }

        public string Name { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Author { get; set; } = null!;

        public DateOnly TakingTime { get; set; }

        public DateOnly ReturnTime { get; set; }
    }
}
