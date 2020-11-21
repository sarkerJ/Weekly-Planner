using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer.Services;

namespace Weekly_Planner_BusinessLayer
{
    public class CRUDManagerNotes : CRUDManager
    {
        readonly WeeklyPlannerDBContext _dbContext;

        private readonly INoteService _noteService;
        private readonly IDayService _dayService;
        private readonly INoteColourService _notesColourService;

        public CRUDManagerNotes()
        {
            _dbContext = new WeeklyPlannerDBContext();
            _noteService = new NoteService(_dbContext);
            _dayService = new DayService(_dbContext);
            _notesColourService = new NotesColourService(_dbContext);
        }
        
        public CRUDManagerNotes(INoteService noteService, INoteColourService colourService, IDayService dayService)
        {
            _noteService = noteService;
            _dayService = dayService;
            _notesColourService = colourService;
        }


        public WeekDay CurrentDay { get; set; }

        public Note CurrentNote { get; set; }

        public NotesColourCategory CurrentColour { get; set; }

        //Setting methods
        public void SetSelectedNote(object selectedItem)
        {
            CurrentNote = (Note)selectedItem;
            SetSelectedColour(); 
            SetSelectedDay();
            
        }
        public void SetSelectedDay(object selectedItem)
        {
            try
            {CurrentDay = (WeekDay)selectedItem;}
            catch
            { SetSelectedDay();}
        }

        public override void SetSelectedDay() => CurrentDay = _dayService.GetDayByNote(CurrentNote);            

        public void SetSelectedColour(object selectedItem)
        {
            try
            {CurrentColour = (NotesColourCategory)selectedItem;}
            catch
            {SetSelectedColour();}
        }

        public void SetSelectedColour() => CurrentColour = _notesColourService.GetColourByNoteId(CurrentNote);
        
        //List Methods
        public override List<WeekDay> ListOfDays() => _dayService.GetListOfDays();

        public override List<string> ListOfDaysString() => _dayService.GetListOfDaysString();

        public List<string> ListOfColourStrings()=> _notesColourService.GetListOfColourStrings();

        public List<NotesColourCategory> ListOfColours() => _notesColourService.GetListOfColourObjects();

        public List<Note> ListOfNotes(object selectedItem)
        {
            
            try
            {
                var getDay = (WeekDay)selectedItem;
                return _noteService.GetListOfNoteByDay(getDay);
            }
            catch //if its not a weekday object it will do try convert it to a coloured one
            {
                var getColour = (NotesColourCategory)selectedItem;
                return _noteService.GetListOfNoteByColour(getColour);
            }
            
        }

        public List<Note> ListOfNotes() =>  _noteService.GetListOfNoteObjects();
        
        public override void CheckInput(string title, string content, string day = null, int? id = null)
        {
           
            if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");
            if (content.Count() == 0) throw new ArgumentException("The Note's content cannot be empty!");

            if(id == null)
            {
                var isCreatedQ = _noteService.GetNoteByTitle(title.Trim());
                if (isCreatedQ != null) throw new ArgumentException("A Note with the same name already exists!");
            }
            else
            {
                var isCreatedQ = _noteService.GetNoteByIdAndTitle(id, title.Trim());
                if (isCreatedQ != null) throw new ArgumentException("A Note with the same name already exists!");
            }
            
        }

        //Creates a new Note
        public void CreateNote(string colour, string day, string title, string content)
        {
            
            CheckInput(title, content);
            var getDay = _dayService.GetDayByString(day.Trim());
            var getColour = _notesColourService.GetColourByNoteColourString(colour.Trim());
            Note newNote = new Note()
            {
                Title = title.Trim(),
                Content = content.Trim(),
                NotesColourCategorys = getColour,
                WeekDays = getDay
            };
            _noteService.AddNote(newNote);
            _noteService.UpdateNote();
            
        }

        //Edits a selected note
        public void EditNote(int id, string title, string content, string day, string colour)
        {
            CheckInput(title.Trim(), content.Trim(), null ,id);

            var getDay = _dayService.GetDayByString(day.Trim());
            var getColour = _notesColourService.GetColourByNoteColourString(colour.Trim());
            var getNote = _noteService.GetNoteById(id);

            getNote.Title = title.Trim();
            getNote.Content = content.Trim();
            getNote.WeekDays = getDay;
            getNote.NotesColourCategorys = getColour;
            _noteService.UpdateNote();

            SetSelectedDay(getDay);
            SetSelectedColour(getColour);
        }

        //deletes a note
        public override void Delete(int id) 
        {
            var getNote = _noteService.GetNoteById(id);
            _noteService.DeleteNote(getNote);
            _noteService.UpdateNote();   
        }
    }
}
