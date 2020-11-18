using System;
using System.Collections.Generic;
using System.Text;

namespace Weekly_PlannerDataLayer.Services
{
    interface INoteColourService
    {
        NotesColourCategory GetColourByNoteId(Note note);
        NotesColourCategory GetColourByNoteColourString(String colour);
        List<string> GetListOfColourStrings();
        List<NotesColourCategory> GetListOfColourObjects();


    }
}
