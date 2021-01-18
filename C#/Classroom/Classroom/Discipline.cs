using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    public class Discipline
    {
        public int IdDisc { get; set; }
        public string NameDisc { get; set; }
        public string DescriptionDisc { get; set; }
        public int ActiveDisc { get; set; }

        public Discipline(int id, string name, string description, int active)
        {
            this.IdDisc = id;
            this.NameDisc = name;
            this.DescriptionDisc = description;
            this.ActiveDisc = active;
        }


    }
}
