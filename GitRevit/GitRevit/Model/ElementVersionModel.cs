using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.Model
{
    public class ElementVersionModel
    {
        public string Id { get; set; }
        public string RevitElementId { get; set; }
        public string Geometry { get; set; }
        public string Original { get; set; }
        public string Direction { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedUserId { get; set; }
    }
}