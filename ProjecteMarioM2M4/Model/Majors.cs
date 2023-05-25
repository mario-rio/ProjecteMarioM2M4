using ProjecteMarioM2M4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteMarioM2M4.Model
{
    public class Majors
    {
        public string Joc { get; set; }
        public string Organitzador { get; set; }
        public string Pais { get; set; }
        public string NomMajor { get; set; }
        public string Data { get; set; }
        public string Ubicacio { get; set; }
        public List<Classificats> Classificats { get; set; }
    }
}