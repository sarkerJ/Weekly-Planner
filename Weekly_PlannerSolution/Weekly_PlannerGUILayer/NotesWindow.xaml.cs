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
            if (ComboBoxDays.SelectedItem != null)
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);
            }
            else if (ComboBoxColours.SelectedItem != null)
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);
            }
            else
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes();
            }
        }
        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxDays.SelectedItem != null)
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxDays.SelectedItem);
                ComboBoxColours.SelectedItem = null;
                ComboBoxColours.Text = "--Select Colour Filter --";
            }
            
            
        }

        private void ComboBoxColours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxColours.SelectedItem != null)
            {
                ListBoxNotes.ItemsSource = _crudManager.ListOfNotes(ComboBoxColours.SelectedItem);
                ComboBoxDays.SelectedItem = null;
                ComboBoxDays.Text = "--Select Day Filter --";
            }
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxDays.SelectedItem = null;
            ComboBoxDays.Text = "--Select Day Filter --";
            ComboBoxColours.SelectedItem = null;
            ComboBoxColours.Text = "--Select Colour Filter --";
            fillListBoxNotes1();
            resetText();
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
                resetText();
            }
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
        }

        public void disableEdit()
        {
            TNContent.IsReadOnly = true;
            TNName.IsReadOnly = true;
            TNDay.IsReadOnly = true;
            TNPriority.IsReadOnly = true;
        }
        private void BFunctions_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            switch (bt.Content)
            {
                case "Create New Note":
                    resetText();
                    allowEdit();
                    bt.Content = "Add Note";
                    break;

                case "Add Note":
                    try
                    {
                        _crudManager.CreateNote(TNPriority.Text, TNDay.Text, TNName.Text, TNContent.Text);
                        disableEdit();
                        bt.Content = "Create New Note";
                        MessageBox.Show("Created New Note");
                        fillListBoxNotes1();
                        ((MainWindow)this.Owner).Focus();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        ((MainWindow)this.Owner).Focus();

                    }
                    break;

                case "Delete Note":
                    try
                    {
                        if (ListBoxNotes.SelectedItem == null) throw new ArgumentException("Nothing is Selected");

                        _crudManager.DeleteNote(_crudManager.currentNote.NoteId);
                        fillListBoxNotes1();
                        resetText();
                        ((MainWindow)this.Owner).Focus();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        ((MainWindow)this.Owner).Focus();

                    }
                    break;

                case "Edit Note":
                    try
                    {
                        if (ListBoxNotes.SelectedItem == null) throw new ArgumentException("Nothing is Selected");
                        allowEdit();
                        bt.Content = "Update Note";
                        ((MainWindow)this.Owner).Focus();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        ((MainWindow)this.Owner).Focus();

                    }


                    break;

                case "Update Note":
                    try
                    {
                        if (ListBoxNotes.SelectedItem == null) throw new ArgumentException("Nothing is Selected");
                        
                            _crudManager.EditNote(_crudManager.currentNote.NoteId, TNName.Text, TNContent.Text, TNDay.Text, TNPriority.Text);
                            disableEdit();
                            bt.Content = "Edit Note";
                            MessageBox.Show("Updated Note");
                            fillListBoxNotes1();
                        ((MainWindow)this.Owner).Focus();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        ((MainWindow)this.Owner).Focus();

                    }
                    break;
            }

            
        }
    }
}
