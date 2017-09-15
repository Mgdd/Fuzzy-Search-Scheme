using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class File
    {
        public int FileIndex { get; set; }
        public string Title { get; set; }
        public string FileContent { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
    }
}
