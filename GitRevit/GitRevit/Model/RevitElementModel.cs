using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.Model
{
    public class RevitElementModel
    {
        public string Id { get; set; }
        public string CommonId { get; set; }
        public string ElementId { get; set; }
        public string DrawingId { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
    }
}