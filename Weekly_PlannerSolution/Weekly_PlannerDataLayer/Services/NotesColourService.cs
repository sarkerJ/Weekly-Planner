using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Weekly_PlannerDataLayer.Services
{
    public class NotesColourService : INoteColourService
    {
        private readonly WeeklyPlannerDBContext _context;
        
        public NotesColourService (WeeklyPlannerDBContext context) => _context = context;

        public NotesColourCategory GetColourByNoteColourString(string colour)
        {
           return _context.NotesColourCategories.Where(p => p.Colour == colour.Trim()).FirstOrDefault();
        }

        public NotesColourCategory GetColourByNoteId(Note note)
        {
            return _context.Notes.Where(a => a.NoteId == note.NoteId).Include(o => o.NotesColourCategorys).Select(o => o.NotesColourCategorys).FirstOrDefault();
        }

        public List<NotesColourCategory> GetListOfColourObjects()
        {
            return _context.NotesColourCategories.ToList();
        }

        public List<string> GetListOfColourStrings()
        {
            List<String> colours = new List<string>();
            foreach (var item in _context.NotesColourCategories.ToList()) colours.Add(item.Colour);
            return colours;
        }
    }
}
