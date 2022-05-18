using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ConnectionDTO : DTO
    {
        public string Room { get; set; }

        public Guid UserId { get; set; }
    }
}
