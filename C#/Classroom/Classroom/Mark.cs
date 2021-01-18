using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    public class Mark
    {
        public int IdMark { get; set; }
        public string StudentMark { get; set; }
        public string TeacherMark { get; set; }
        public string DisciplineMark { get; set; }
        public int MarkMark { get; set; }
        public string DateMark { get; set; }
        public string GroupMark { get; set; }

        public Mark(int id, string student, string teacher, string discipline, int mark, string date, string group)
        {
            this.IdMark = id;
            this.StudentMark = student;
            this.TeacherMark = teacher;
            this.DisciplineMark = discipline;
            this.MarkMark = mark;
            this.DateMark = date;
            this.GroupMark = group;
        }


    }
}
