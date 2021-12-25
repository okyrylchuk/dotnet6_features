using System;
using System.Collections.Generic;

namespace Scaffolding_many_to_many_relationships.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
