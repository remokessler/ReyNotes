using ReyNotes.Models;
using ReyNotes.Services.Notes;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReyNotes.ViewModels
{
    public class NotesDetailViewModel : INotifyPropertyChanged
    {
        private Note _note { get; set; }
        public int Id => _note.Id;
        public string Title => _note.Title;
        public string Text => _note.Text;
        public DateTime DateCreated => _note.DateCreated;
        public DateTime DateEdited => _note.DateEdited;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DeleteNote { get; set; }
        public ICommand EditMode { get; set; }
        public Action<int> OpenInEditMode = (int id) => { };

        public NotesDetailViewModel(Note note)
        {
            _note = note;
            DeleteNote = new Command(() => NotesService.Instance.DeleteNote(_note));
            EditMode = new Command(() => OpenInEditMode(Id));
            NotesService.Instance.NotesUpdatedEventHandler += _notesUpdatedEventHandler;
        }
        private void _notesUpdatedEventHandler(object changedNote, NotesUpdatedEventArgs e)
        {
            var note = (Note)changedNote;
            if (note.Id == Id)
            {
                _note = note;
            }
            PropertyChanged(changedNote, new PropertyChangedEventArgs(nameof(changedNote)));
        }
    }
}
