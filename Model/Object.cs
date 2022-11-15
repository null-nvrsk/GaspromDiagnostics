using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaspromDiagnostics
{
    public class Object
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Distance { get; set; }
        public float Angle { get; set; }
        public float Width { get; set; }
        public float Heigth { get; set; }
        public bool IsDefect { get; set; }

    }
}
