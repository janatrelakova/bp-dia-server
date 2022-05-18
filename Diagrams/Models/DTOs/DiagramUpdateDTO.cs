using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class DiagramUpdateDTO : DTO
    {
        public string Room { get; set; }
        public string Data { get; set; }
    }
}
