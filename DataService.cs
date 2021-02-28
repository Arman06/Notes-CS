using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Foundation;
namespace NotesApp
{

    public class DataServiceArgs: EventArgs
    {
        public Note Note { get; set; }
    }

    public class DataService
    {

        public event EventHandler<DataServiceArgs> DataBaseChanged;

        public event EventHandler<DataServiceArgs> ItemDeleted;

        public event EventHandler<DataServiceArgs> ItemAdded;

        public static DataService sharedInstance = new DataService();

        public List<Note> notes = new List<Note>();

        public static void DataAccess()
        {
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "notes2Demo.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Note>();
            if (db.Table<Note>().Count() == 0)
            { 
                var newNote = new Note();
                newNote.Title = "ha";
                newNote.Contents = "lol";
                db.Insert(newNote);
            }
            sharedInstance.notes = GetAllNotes();
        }

        public static List<Note> GetAllNotes()
        {
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "notes2Demo.db3");
            var db = new SQLiteConnection(dbPath);
            var notes = db.Query<Note>("SELECT * FROM Items");
            return notes;
        }

        public static void DeleteNote(Note note, NSIndexPath index)
        {
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "notes2Demo.db3");
            var db = new SQLiteConnection(dbPath);
            var rowindex = db.Delete<Note>(note.ID);
            sharedInstance.notes = GetAllNotes();
            sharedInstance.onItemDelete(index, note);
            sharedInstance.onDataBaseChange();
        }

        public static void AddNote(Note note)
        {
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "notes2Demo.db3");
            var db = new SQLiteConnection(dbPath);
            db.Insert(note);
            sharedInstance.notes = GetAllNotes();
            sharedInstance.onItemAdd(GetAllNotes().Count, note);
            sharedInstance.onDataBaseChange();
        }

        protected virtual void onDataBaseChange()
        {
            DataBaseChanged?.Invoke(this, new DataServiceArgs());
        }

        protected virtual void onItemDelete(NSIndexPath index, Note note)
        {
            ItemDeleted?.Invoke(this, new DataServiceArgs { Note = note });
        }

        protected virtual void onItemAdd(int index, Note note)
        {
            ItemAdded?.Invoke(this, new DataServiceArgs { Note = note });
        }

    }
}
