using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.Model
{
    public class Music
    {
        public Guid Id  { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Album Album { get; set; }
    }
}
