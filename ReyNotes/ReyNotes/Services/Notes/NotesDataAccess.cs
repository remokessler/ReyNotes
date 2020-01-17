using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReyNotes.Services.Notes
{
    public class NotesDataAccess
    {
        private static NotesDataAccess _instance;
        public static NotesDataAccess Instance => _instance ?? (_instance = new NotesDataAccess(path));
        private readonly SQLiteAsyncConnection _dataBase;
        private static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
        private NotesDataAccess(string dbPath)
        {
            _dataBase = new SQLiteAsyncConnection(dbPath);
            _dataBase.CreateTableAsync<Models.Note>().Wait();
        }

        public Task<List<Models.Note>> GetAllNotes()
        {
            return _dataBase.Table<Models.Note>().ToListAsync();
        }

        public Task<Models.Note> GetNoteById(int id)
        {
            return _dataBase.Table<Models.Note>().FirstAsync(table => table.Id == id);
        }

        public Task<int> SaveNote(Models.Note note)
        {
            return note.Id == 0 ? _dataBase.InsertAsync(note) : _dataBase.UpdateAsync(note);
        }

        public Task<int> DeleteNote(Models.Note note)
        {
            return _dataBase.DeleteAsync(note);
        }
    }
}
