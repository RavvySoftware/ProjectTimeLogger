using System;
using System.Collections.Generic;

namespace ProjectTimeLogger.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
