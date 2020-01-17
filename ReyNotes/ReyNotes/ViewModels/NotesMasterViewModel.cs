using ReyNotes.Services.Notes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReyNotes.ViewModels
{
    public class NotesMasterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<NotesDetailViewModel> NotesDetailViewModels { get;set; }

        private NotesDetailViewModel _selectedItem = null;
        public NotesDetailViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == _selectedItem) return;
                _selectedItem = value;
                PropertyChanged(value, new PropertyChangedEventArgs(nameof(SelectedItem)));
                NavigateToDetail(value);
            }
        }
        public ICommand AddNewNote { get; set; }
        public ICommand Delete { get; set; }

        public Action<int> NavigateToDetailAction = new Action<int>((int id) => { });
        public Action NavigateToNewPage = () => { };

        public NotesMasterViewModel()
        {
            RefreshNotes();
            AddNewNote = new Command(() => NavigateToNewPage());
            NotesService.Instance.NotesUpdatedEventHandler += _notesUpdatedEventHandler;
        }

        private void RefreshNotes()
        {
            NotesDetailViewModels = new ObservableCollection<NotesDetailViewModel>(
                NotesService.Instance.GetAllNotes()
                    .OrderBy(n => !n.IsFavorite)
                    .OrderByDescending(n => n.DateEdited)
                    .Select(n => new NotesDetailViewModel(n)));
        }

        private void _notesUpdatedEventHandler(object changedNote, NotesUpdatedEventArgs e)
        {
            var note = (Models.Note)changedNote;
            switch(e.Change)
            {
                case Change.Update:
                    var id = NotesDetailViewModels.IndexOf(NotesDetailViewModels.First(ndvm => ndvm.Id == note.Id));
                    NotesDetailViewModels[id] = new NotesDetailViewModel(note);
                    PropertyChanged(NotesDetailViewModels.First(ndvm => ndvm.Id == note.Id), new PropertyChangedEventArgs(nameof(NotesDetailViewModels)));
                    break;

                case Change.New:
                    NotesDetailViewModels.Add(new NotesDetailViewModel(note));
                    PropertyChanged(NotesDetailViewModels, new PropertyChangedEventArgs(nameof(NotesDetailViewModels)));
                    break;

                case Change.Delete:
                    NotesDetailViewModels.Remove(NotesDetailViewModels.First(ndvm => ndvm.Id == note.Id));
                    PropertyChanged(NotesDetailViewModels, new PropertyChangedEventArgs(nameof(NotesDetailViewModels)));
                    break;
            }
        }

        private void NavigateToDetail(NotesDetailViewModel selectedItem)
        {
            if (SelectedItem == null) return;
            NavigateToDetailAction(selectedItem.Id);
            SelectedItem = null;
        }
    }
}
