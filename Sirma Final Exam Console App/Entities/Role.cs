using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App.Entities
{
    internal class Role
    {
        public int Id { get; set; }
       public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string CharacterName { get; set; }

    }
}
