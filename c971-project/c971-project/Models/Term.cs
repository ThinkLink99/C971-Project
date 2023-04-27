using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace c971_project.Models
{
    public class Term : BaseViewModel
    {
        [PrimaryKey]
        public int TermId { get; set; }
        public string TermName { get; set; } = "Default";
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }
    }
}
