using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ranking
    {
        public int Id { get; set; }
        public int KeyWordId { get; set; }
        public int FileId { get; set; }
        public int Rank { get; set; }
    }
}
