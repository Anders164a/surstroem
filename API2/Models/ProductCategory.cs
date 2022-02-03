using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Category Product { get; set; }
    }
}
