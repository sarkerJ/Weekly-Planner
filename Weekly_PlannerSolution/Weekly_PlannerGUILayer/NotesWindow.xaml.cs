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
        public void fillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
            ComboBoxColours.ItemsSource = _crudManager.ListOfColours();
            ComboBoxColours.DisplayMemberPath = "Colour";
            fillListBoxNotes1();

            ComboBoxDays2.ItemsSource = _crudManager.ListOfDaysString();
            ComboBoxColours2.ItemsSource = _crudManager.ListOfColourStrings();
        }

        public void fillListBoxNotes1()
        {
            if (ComboBoxDays.SelectedItem != null)
            {ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);}
            else if (ComboBoxColours.SelectedItem != null)
            {ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);}
            else
            {ListBoxNotes.ItemsSource = _crudManager.ListOfNotes();}
        }

        public void resetText()
        {
            TNContent.Text = "";
            TNName.Text = "";
            TNDay.Text = "";
            TNPriority.Text = "";
        }
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

        public void disableEdit()
        {
            TNContent.IsReadOnly = true;
            TNName.IsReadOnly = true;
            TNDay.IsReadOnly = true;
            TNPriority.IsReadOnly = true;
            TNContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9F9E1"));
            TNName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9F9E1"));
            TNDay.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9F9E1")); 
            ComboBoxDays2.Visibility = Visibility.Hidden;
            ComboBoxColours2.Visibility = Visibility.Hidden;

        }

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
                case "ComboBoxDays":
                    if (ComboBoxDays.SelectedItem != null)
                    {
                        ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);
                        ComboBoxColours.SelectedItem = null;
                        ComboBoxColours.Text = "--Select Colour Filter --";
                    }
                    break;

                case "ComboBoxDays2":
                    TNDay.Text = ComboBoxDays2.SelectedItem.ToString();
                    changeTextBackground();
                    break;

                case "ComboBoxColours":
                    if (ComboBoxColours.SelectedItem != null)
                    {
                        ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);
                        ComboBoxDays.SelectedItem = null;
                        ComboBoxDays.Text = "--Select Day Filter --";
                    }
                    break;

                case "ComboBoxColours2":
                    TNPriority.Text = ComboBoxColours2.SelectedItem.ToString();
                    changeTextBackground();
                    break;
            }
        }

        //Notes List when selected
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
            else resetText();
            
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
