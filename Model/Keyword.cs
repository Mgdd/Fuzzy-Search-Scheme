using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Keyword
    {
        public int Id { get; set; }
        public int FileIndex { get; set; }
        public string KeyWord { get; set; }
        public int Rank { get; set; }
    }
}
