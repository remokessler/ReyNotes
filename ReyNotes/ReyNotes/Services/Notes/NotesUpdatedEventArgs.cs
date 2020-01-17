using System;
using System.Collections.Generic;
using System.Text;

namespace ReyNotes.Services.Notes
{
    public class NotesUpdatedEventArgs
    {
        public Change Change;
        public NotesUpdatedEventArgs(Change c)
        {
            Change = c;
        }
    }

    public enum Change
    {
        Update,
        New,
        Delete
    }
}
