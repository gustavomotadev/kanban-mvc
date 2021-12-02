using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int ColumnId { get; set; }
    }
}