using ReyNotes.Models;
using ReyNotes.Services.Notes;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReyNotes.ViewModels
{
    public class NotesEditViewModel : INotifyPropertyChanged
    {
        private Note _note { get; set; }
        public int Id
        {
            get => _note.Id;
            set 
            {
                if (_note.Id == value) return;
                _note.Id = value;
                PropertyChanged(_note, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        public string Title
        {
            get => _note.Title;
            set
            {
                if (_note.Title == value) return;
                _note.Title = value;
                PropertyChanged(_note, new PropertyChangedEventArgs(nameof(Title)));
            }
        }
        public string Text
        {
            get => _note.Text;
            set
            {
                if (_note.Text == value) return;
                _note.Text = value;
                PropertyChanged(_note, new PropertyChangedEventArgs(nameof(Text)));
            }
        }
        public DateTime DateCreated
        {
            get => _note.DateCreated;
            set
            {
                if (_note.DateCreated == value || _note.DateCreated != null) return;
                _note.DateCreated = value;
                PropertyChanged(_note, new PropertyChangedEventArgs(nameof(DateCreated)));
            }
        }
        public DateTime DateEdited
        {
            get => _note.DateEdited;
            set
            {
                if (_note.DateEdited == value) return;
                _note.DateEdited = value;
                PropertyChanged(_note, new PropertyChangedEventArgs(nameof(DateEdited)));
            }
        }
        public ICommand SaveNote { get; set; }
        public Action SaveNoteNavigationBack = () => { };

        public event PropertyChangedEventHandler PropertyChanged;
        public NotesEditViewModel(Note note)
        {
            _note = note;
            SaveNote = new Command(() => {
                NotesService.Instance.SaveNote(_note);
                SaveNoteNavigationBack();
            });
        }
        public NotesEditViewModel()
        {
            _note = new Note();
            _note.DateCreated = DateTime.Now;
            SaveNote = new Command(() => {
                NotesService.Instance.SaveNote(_note);
                SaveNoteNavigationBack();
            });
        }
    }
}
