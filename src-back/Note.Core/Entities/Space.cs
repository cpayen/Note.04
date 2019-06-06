using Note.Core.Entities.Base;
using System.Collections.Generic;

namespace Note.Core.Entities
{
    public class Space : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public AppUser Owner { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
