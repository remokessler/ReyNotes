using System;
using System.Collections.Generic;
using System.Text;

namespace ReyNotes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public bool IsFavorite { get; set; }
    }
}
