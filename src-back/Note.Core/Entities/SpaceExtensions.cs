using System.Collections.Generic;
using System.Linq;

namespace Note.Core.Entities
{
    public static class SpaceExtensions
    {
        public static List<Page> GetPages(this Space space)
        {
            return space.Pages.OrderByDescending(o => o.CreatedAt).ToList();
        }
    }
}
