﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserDiagram> Diagrams { get; set; }
    }
}
