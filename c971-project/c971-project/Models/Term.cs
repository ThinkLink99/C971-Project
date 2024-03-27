using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace c971_project.Models
{
    public class Term
    {
        [PrimaryKey]
        public int TermId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }
    }
}
