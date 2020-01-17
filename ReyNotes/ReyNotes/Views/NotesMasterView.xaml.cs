using ReyNotes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReyNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesMasterView : ContentPage
    {
        private NotesMasterViewModel _notesMaterViewModel { get; set; }
        public NotesMasterView()
        {
            InitializeComponent();
            _notesMaterViewModel = new NotesMasterViewModel();
            _notesMaterViewModel.NavigateToDetailAction = (int noteId) => Navigation.PushAsync(new NotesDetailView(noteId));
            _notesMaterViewModel.NavigateToNewPage = () => Navigation.PushAsync(new NotesEditView());
            BindingContext = _notesMaterViewModel;
            
        }
    }
}