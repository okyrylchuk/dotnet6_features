using System;
using System.Collections.Generic;

namespace Database_comments_are_scaffolded_to_code_comments.Models
{
    /// <summary>
    /// The post table
    /// </summary>
    public partial class Post
    {
        /// <summary>
        /// The post identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The post name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The description name
        /// </summary>
        public string Description { get; set; }
    }
}
