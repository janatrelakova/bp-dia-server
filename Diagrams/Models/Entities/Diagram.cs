using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public class Diagram : IEntity
    {
        public Guid Id { get; set; }

        public string Room { get; set; }

        public string Data { get; set; }

        public virtual ICollection<UserDiagram> Users { get; set; }
    }
}
