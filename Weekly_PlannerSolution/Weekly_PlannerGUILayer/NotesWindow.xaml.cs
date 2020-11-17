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
using Weekly_PlannerDataLayer;

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
            ListBoxNotes.SelectedItem = ListBoxNotes.Items.CurrentItem;
        }

        //Populates the data for the 2 Filters in the window (colour, Day)
        public void fillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
            ComboBoxColours.ItemsSource = _crudManager.ListOfColours();
            ComboBoxColours.DisplayMemberPath = "Colour";
            fillListBoxNotes1();

            ComboBoxDays2.ItemsSource = _crudManager.ListOfDaysString();
            ComboBoxDays2.SelectedItem = ComboBoxDays2.Items.CurrentItem;
            ComboBoxColours2.ItemsSource = _crudManager.ListOfColourStrings();
            ComboBoxColours2.SelectedItem = ComboBoxColours2.Items.CurrentItem;
        }

        //public void currentEditMenuItem()
        //{

        //}

        //Populates the main notes listbox depending on current filter or if there are no filters
        public void fillListBoxNotes1()
        {
            if (ComboBoxDays.SelectedItem != null)
            {ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);}

            else if (ComboBoxColours.SelectedItem != null)
            {ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);}

            else
            {ListBoxNotes.ItemsSource = _crudManager.ListOfNotes();}
        }

        //resets textbox content
        public void resetText()
        {
            TNContent.Text = "";
            TNName.Text = "";
            TNDay.Text = "";
            TNPriority.Text = "";
        }
        //Changes textbox properties so you can edit
        //Changes background so it is obvious that you can edit
        //Shows the 2 drop down menus
        public void allowEdit()
        {
            TNContent.IsReadOnly = false;
            TNName.IsReadOnly = false;
            TNDay.IsReadOnly = false;
            TNPriority.IsReadOnly = false;
            ComboBoxDays2.Visibility = Visibility.Visible;
            ComboBoxColours2.Visibility = Visibility.Visible;
            TNContent.Background = Brushes.White;
            TNName.Background = Brushes.White;
            TNDay.Background = Brushes.White;
        }

        //Disables everything that allows user input
        //sets everything to its state before allowEdit was used
        public void disableEdit()
        {
            TNContent.IsReadOnly = true;
            TNName.IsReadOnly = true;
            TNDay.IsReadOnly = true;
            TNPriority.IsReadOnly = true;
            TNContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9ECF9"));
            TNName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9ECF9"));
            TNDay.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9ECF9")); 
            ComboBoxDays2.Visibility = Visibility.Hidden;
            ComboBoxColours2.Visibility = Visibility.Hidden;
        }
        
        //changes foreground of the PriorityTextbox based on content
        public void changeTextBackground()
        {
            switch (TNPriority.Text)
            {
                case "Green":
                    TNPriority.Foreground = Brushes.Green;
                    break;
                case "Yellow":
                    TNPriority.Foreground = Brushes.Yellow;
                    break;
                case "Orange":
                    TNPriority.Foreground = Brushes.Orange;
                    break;
                case "Red":
                    TNPriority.Foreground = Brushes.Red;
                    break;
            }


        }

        //ComboBoxes Actions
        private void ComboBoxAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            switch (cb.Name)
            {
                //Used for filtering by day ONLY
                case "ComboBoxDays":
                    if (ComboBoxDays.SelectedItem != null)
                    {
                        ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);
                        ComboBoxColours.SelectedItem = null;
                        ComboBoxColours.Text = "--Select Colour Filter --";
                    }
                    break;

                //Used edit a current note (mainly the day)
                case "ComboBoxDays2":
                    TNDay.Text = ComboBoxDays2.SelectedItem.ToString();
                    changeTextBackground();
                    break;

                //Used for filtering by colour ONLY
                case "ComboBoxColours":
                    if (ComboBoxColours.SelectedItem != null)
                    {
                        ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);
                        ComboBoxDays.SelectedItem = null;
                        ComboBoxDays.Text = "--Select Day Filter --";
                    }
                    break;

                //used to edit a current note (mainly the colour)
                case "ComboBoxColours2":
                    TNPriority.Text = ComboBoxColours2.SelectedItem.ToString();
                    changeTextBackground();
                    break;
            }
        }

        //Populates text boxes based on selected Note Item
        private void ListBoxNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxNotes.SelectedItem != null)
            {
                _crudManager.setSelectedNote(ListBoxNotes.SelectedItem);
                TNName.Text = _crudManager.currentNote.Title;
                TNPriority.Text = _crudManager.currentColour.Colour;
                TNContent.Text = _crudManager.currentNote.Content;
                TNDay.Text = _crudManager.currentDay.Day;
                ComboBoxDays2.SelectedItem = TNDay.Text;
                changeTextBackground();
            }
            else
            {
                //resetText();
                TNName.Text = _crudManager.currentNote.Title;
                TNPriority.Text = _crudManager.currentColour.Colour;
                TNContent.Text = _crudManager.currentNote.Content;
                TNDay.Text = _crudManager.currentDay.Day;
                ComboBoxDays2.SelectedItem = TNDay.Text;
                changeTextBackground();

            } 
            
        }

        //Button Functions
        private void BFunctions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button bt = (Button)sender;
                switch (bt.Content)
                {
                    case "Create New Note":
                        resetText();
                        TNDay.Text = ComboBoxDays2.SelectedItem.ToString();
                        TNPriority.Text = ComboBoxColours2.SelectedItem.ToString();
                        allowEdit();
                        bt.Content = "Add Note";
                        bt.Background = Brushes.DarkCyan;
                        break;

                    case "Add Note":
                   
                        _crudManager.CreateNote(TNPriority.Text, TNDay.Text, TNName.Text, TNContent.Text);
                        disableEdit();
                        bt.Content = "Create New Note";
                        MessageBox.Show("Created New Note");
                        fillListBoxNotes1();
                        ((MainWindow)this.Owner).Focus();
                        bt.Background = Brushes.LightCyan;
                        break;

                    case "Delete Note":
                        if (ListBoxNotes.SelectedItem == null) throw new ArgumentException("Nothing is Selected");
                        _crudManager.DeleteNote(_crudManager.currentNote.NoteId);
                        fillListBoxNotes1();
                        resetText();
                        ((MainWindow)this.Owner).Focus();
                        resetText();
                        break;

                    case "Edit Note":
                    
                        if (ListBoxNotes.SelectedItem == null) throw new ArgumentException("Nothing is Selected");
                        allowEdit();
                        ComboBoxDays2.SelectedItem = TNDay.Text;
                        ComboBoxColours2.SelectedItem = TNPriority.Text;
                        bt.Content = "Update Note";
                        bt.Background = Brushes.DarkCyan;
                        ((MainWindow)this.Owner).Focus();
                        break;

                    case "Update Note":
                    
                        if (ListBoxNotes.SelectedItem == null) throw new ArgumentException("Nothing is Selected");
                        
                        _crudManager.EditNote(_crudManager.currentNote.NoteId, TNName.Text, TNContent.Text, TNDay.Text, TNPriority.Text);
                        disableEdit();
                        bt.Content = "Edit Note";
                        bt.Background = Brushes.LightCyan;
                        TNDay.Text = _crudManager.currentDay.Day;
                        TNPriority.Text = _crudManager.currentColour.Colour;
                        MessageBox.Show("Updated Note");
                        fillListBoxNotes1();
                        ((MainWindow)this.Owner).Focus();
                        break;

                    case "Clear":
                        ComboBoxDays.SelectedItem = null;
                        ComboBoxDays.Text = "--Select Day Filter --";
                        ComboBoxColours.SelectedItem = null;
                        ComboBoxColours.Text = "--Select Colour Filter --";
                        fillListBoxNotes1();
                        resetText();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Duplicate or Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ((MainWindow)this.Owner).Focus();

            }

        }

        
    }
}
