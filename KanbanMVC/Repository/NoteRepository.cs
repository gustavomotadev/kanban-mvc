using KanbanMVC.DAL;
using KanbanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanMVC.Repository
{
    public class NoteRepository
    {
        public static int DeleteNote(int id)
        {
            return NoteManagement.DeleteNote(id);
        }

        public static int UpdateNote(int id, string title, string text)
        {
            return NoteManagement.UpdateNote(id, title, text);
        }

        public static int? CreateNote(int columnId, string title, string text)
        {
            return NoteManagement.CreateNote(title, text, columnId);
        }

        public static Note ReadNote(int id)
        {
            var noteDB = NoteManagement.ReadNote(id);

            return new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId };
        }

        public static List<Note> ReadAllNotes()
        {
            var notesDB = NoteManagement.ReadAllNotes();
            var notes = new List<Note>();

            foreach (var noteDB in notesDB)
            {
                notes.Add(new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId });
            }

            return notes;
        }

        public static List<Note> ReadNotesInColumn(int columnId)
        {
            var notesDB = NoteManagement.ReadNotesInColumn(columnId);
            var notes = new List<Note>();

            foreach (var noteDB in notesDB)
            {
                notes.Add(new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId });
            }

            return notes;
        }
    }
}