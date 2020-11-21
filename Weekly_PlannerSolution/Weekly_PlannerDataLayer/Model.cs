using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Weekly_PlannerDataLayer
{
    public class WeeklyPlannerDBContext : DbContext
    {
        public WeeklyPlannerDBContext() { }
        public WeeklyPlannerDBContext(DbContextOptions<WeeklyPlannerDBContext> options) : base (options)
        { }

        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<NotesColourCategory> NotesColourCategories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=WeeklyPlannerDB;");
            }

        } 
    }

    public partial class WeekDay
    {
        public int WeekDayId { get; set; }

        public string Day { get; set; }

        public List<Activity> Activities = new List<Activity>();

        public List<Note> Notes = new List<Note>();

    }
    public class NotesColourCategory
    {
        public int NotesColourCategoryId { get; set; }

        public string Colour { get; set; }
    }

    public partial class Activity
    {
        public int ActivityId { get;set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }

    }

    public partial class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int NotesColourCategoryId { get; set; }
        public NotesColourCategory NotesColourCategorys { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDays { get; set; }
    }
}
