using System.Collections.Generic;

namespace Models.DTOs
{
    public class UserDiagramsPageDTO : DTO
    {
        public string Name { get; set; }

        public ICollection<string> Diagrams { get; set; }

    }
}
