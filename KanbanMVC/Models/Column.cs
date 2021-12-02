using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.Models
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BoardId { get; set; }
    }
}