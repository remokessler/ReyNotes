using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ReyNotes.Services.Notes
{
    public class NotesService
    {
        private static NotesService _instance { get; set; }
        public static NotesService Instance => _instance ?? (_instance = new NotesService());

        public ObservableCollection<Models.Note> Notes { get; private set; }
        public event EventHandler<NotesUpdatedEventArgs> NotesUpdatedEventHandler;
        private NotesService()
        {
            RefreshNotes();
        }

        private void RefreshNotes()
        {
            Notes = new ObservableCollection<Models.Note>(NotesDataAccess.Instance.GetAllNotes().Result);
        }

        public Models.Note GetNoteById(int id)
        {
            return NotesDataAccess.Instance.GetNoteById(id).Result;
        }
        public void SaveNote(Models.Note note)
        {
            NotesDataAccess.Instance.SaveNote(note);
            if (note.Id != 0 && Notes.Any(n => n.Id == note.Id))
            {
                var index = Notes.IndexOf(Notes.First(n => n.Id == note.Id));
                Notes[index] = note;
                NotesUpdatedEventHandler(note, new NotesUpdatedEventArgs(Change.Update));
            }
            else
            {
                RefreshNotes();
                NotesUpdatedEventHandler(note, new NotesUpdatedEventArgs(Change.New));
            }
        }

        public void DeleteNote(Models.Note note)
        {
            NotesDataAccess.Instance.DeleteNote(note);
            Notes.Remove(note);
            NotesUpdatedEventHandler(note, new NotesUpdatedEventArgs(Change.Delete));
        }

        public ObservableCollection<Models.Note> GetAllNotes()
        {
            return Notes;
        }
    }
}
