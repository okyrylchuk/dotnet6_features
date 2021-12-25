using System;
using System.Collections.Generic;

namespace Scaffolding_many_to_many_relationships.Models
{
    public partial class Post
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
