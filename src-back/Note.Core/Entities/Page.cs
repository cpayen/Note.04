using Note.Core.Entities.Base;

namespace Note.Core.Entities
{
    public class Page : Entity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public Space Space { get; set; }
        public AppUser Owner { get; set; }
    }
}
