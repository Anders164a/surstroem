using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
