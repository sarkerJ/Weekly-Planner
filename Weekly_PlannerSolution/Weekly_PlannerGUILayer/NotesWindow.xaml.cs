using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Weekly_Planner_BusinessLayer;

namespace Weekly_PlannerGUILayer
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        CRUDManagerNotes _crudManager = new CRUDManagerNotes();

        public NotesWindow()
        {
            InitializeComponent(); 
            fillUpComboBox();
        }
        public void fillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
            //ComboBoxDays.SelectedItem = ComboBoxDays.Items.CurrentItem; //may not need them since it would force a filter
            //_crudManager.setSelectedDay(ComboBoxDays.SelectedItem);

            ComboBoxColours.ItemsSource = _crudManager.ListOfColours();
            ComboBoxColours.DisplayMemberPath = "Colour";
            //ComboBoxColours.SelectedItem = ComboBoxColours.Items.CurrentItem;
            //_crudManager.setSelectedColour(ComboBoxColours.SelectedItem);

            fillListBoxNotes1();
        }

        public void fillListBoxNotes1()
        {
            ListBoxNotes.ItemsSource = _crudManager.ListOfNotes();
        }
        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxDays.SelectedItem != null)
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);
            }
        }

        private void ComboBoxColours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxColours.SelectedItem != null)
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);
            }
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxDays.SelectedItem = null;
            ComboBoxDays.Text = "--Select Day Filter --";
            ComboBoxColours.SelectedItem = null;
            ComboBoxColours.Text = "--Select Colour Filter --";
            fillListBoxNotes1();
        }

        private void ListBoxNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxNotes.SelectedItem != null)
            {
                _crudManager.setSelectedNote(ListBoxNotes.SelectedItem);
                TNName.Text = _crudManager.currentNote.Title;
                TNPriority.Text = _crudManager.currentColour.Colour;
                TNContent.Text = _crudManager.currentNote.Content;
                TNDay.Text = _crudManager.currentDay.Day;
            }
            else
            {
                TNContent.Text = "";
                TNName.Text = "";
                TNDay.Text = "";
            }
        }
    }
}
