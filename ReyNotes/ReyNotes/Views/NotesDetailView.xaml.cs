using ReyNotes.Services.Notes;
using ReyNotes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReyNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesDetailView : ContentPage
    {
        private NotesDetailViewModel _notesDetailViewModel { get; set; }
        public NotesDetailView(int noteId)
        {
            InitializeComponent();
            _notesDetailViewModel = new NotesDetailViewModel(NotesService.Instance.GetNoteById(noteId));
            _notesDetailViewModel.OpenInEditMode = (int id) => Navigation.PushAsync(new NotesEditView(noteId));
            BindingContext = _notesDetailViewModel;
        }
    }
}