using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Weekly_PlannerDataLayer.Services
{
    public class NoteService : INoteService
    {
        private  readonly WeeklyPlannerDBContext _context;

        public NoteService(WeeklyPlannerDBContext context) => _context = context;

        //add/delete/update
        public void AddNote(Note note) => _context.Notes.Add(note);

        public void DeleteNote(Note note) => _context.Notes.RemoveRange(note);
        
        public void UpdateNote() => _context.SaveChanges();

        //getNote
        public Note GetNoteById(int id) => _context.Notes.Where(w => w.NoteId == id).FirstOrDefault();

        public Note GetNoteByTitle(string title) => _context.Notes.Where(a => a.Title == title.Trim()).FirstOrDefault();

        public Note GetNoteByIdAndTitle(int? id, string title) => _context.Notes.Where(a => a.Title == title.Trim() & a.NoteId != id).FirstOrDefault();

        //getList
        public List<Note> GetListOfNoteByColour(NotesColourCategory colour) => _context.Notes.Where(o => o.NotesColourCategoryId == colour.NotesColourCategoryId).Include(s => s.NotesColourCategorys).ToList();
        
        public List<Note> GetListOfNoteByDay(WeekDay day) => _context.Notes.Where(o => o.WeekDayId == day.WeekDayId).Include(s => s.WeekDays).Include(o => o.NotesColourCategorys).ToList();

        public List<Note> GetListOfNoteObjects() => _context.Notes.Include(o => o.NotesColourCategorys).ToList();
        

        

        

        
        
    }
}
