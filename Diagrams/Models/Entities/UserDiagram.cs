using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class UserDiagram : IEntity
    {
        public Guid Id { get; set; }


        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }


        public virtual Guid DiagramId { get; set; }

        [ForeignKey(nameof(DiagramId))]
        public virtual Diagram Diagram { get; set; }

    }
}
