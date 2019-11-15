using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.Model
{
    public class DrawingModel
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string DrawingName { get; set; }
        public string Category { get; set; }
    }
}