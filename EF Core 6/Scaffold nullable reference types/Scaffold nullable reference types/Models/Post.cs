using System;
using System.Collections.Generic;

namespace Scaffold_nullable_reference_types.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Desciption { get; set; }
    }
}
