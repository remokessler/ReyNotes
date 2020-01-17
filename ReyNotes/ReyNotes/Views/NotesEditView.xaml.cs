using ReyNotes.Services.Notes;
using ReyNotes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReyNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesEditView : ContentPage
    {
        private NotesEditViewModel _notesEditViewModel { get; set; }
        public NotesEditView(int noteId)
        {
            InitializeComponent();
            _notesEditViewModel = new NotesEditViewModel(NotesService.Instance.GetNoteById(noteId));
            _notesEditViewModel.SaveNoteNavigationBack = () => Navigation.PopAsync();
            BindingContext = _notesEditViewModel;
        }
        public NotesEditView()
        {
            InitializeComponent();
            _notesEditViewModel = new NotesEditViewModel();
            _notesEditViewModel.SaveNoteNavigationBack = () => Navigation.PopAsync();
            BindingContext = _notesEditViewModel;
        }
    }
}