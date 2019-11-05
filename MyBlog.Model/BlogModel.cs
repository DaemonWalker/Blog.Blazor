using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Model
{
    public class BlogModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "标题过长")]
        public string Title { get; set; }
    }
}
