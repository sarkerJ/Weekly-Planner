using System;
using System.Collections.Generic;
using System.Text;

namespace Weekly_PlannerDataLayer.Services
{
    interface INoteService 
    {
        List<Note> GetListOfNoteByColour(NotesColourCategory colour);
        List<Note> GetListOfNoteByDay(WeekDay day);
        List<Note> GetListOfNoteObjects();

        void UpdateNote();
        void DeleteNote(Note note);
        Note GetNoteById(int id);
        Note GetNoteByTitle(string title);
        Note GetNoteByIdAndTitle(int? id, string title);
        void AddNote(Note note);


    }
}
