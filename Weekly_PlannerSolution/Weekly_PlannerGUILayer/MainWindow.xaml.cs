using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weekly_Planner_BusinessLayer;


namespace Weekly_PlannerGUILayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUDManagerActivity _crudManager = new CRUDManagerActivity();
        public MainWindow()
        {
            InitializeComponent();
            fillUpLists();
            fillUpComboBox();

            //Once window is open it automatically selects the first item to be displayed from Monday's list
            ListBoxMonday.SelectedItem = ListBoxMonday.Items.CurrentItem;

            //Setting mainwindow to appear in the middle of the screen
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        //populates the edit Day listbox with the names of each day
        public void fillUpComboBox()
        {
            ComboBoxDays.Background = Brushes.White;
            ComboBoxDays.ItemsSource = _crudManager.ListOfDaysString();
        }

        //populates the list of each day in their appropriate listbox
        public void fillUpLists()
        {
            ListBoxMonday.ItemsSource = _crudManager.ListOfActivities("Monday");
            ListBoxTuesday.ItemsSource = _crudManager.ListOfActivities("Tuesday");
            ListBoxWednesday.ItemsSource = _crudManager.ListOfActivities("Wednesday");
            ListBoxThursday.ItemsSource = _crudManager.ListOfActivities("Thursday");
            ListBoxFriday.ItemsSource = _crudManager.ListOfActivities("Friday");
        }


       //Method that deals with the selected item for any of the Week Day listboxes 
       //If one is selected the rest of the boxes are set to null
       //Displays information of the selected item in the text boxes
        private void ListBoxAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lbox = (ListBox)sender;
            switch (lbox.Name)
            {
                case "ListBoxMonday":
                    if (ListBoxMonday.SelectedItem != null)
                    {
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.SetSelectedActivity(ListBoxMonday.SelectedItem);
                        
                        //make a method for this 
                        TTitle.Text = _crudManager.CurrentActivity.Name;
                        TContent.Text = _crudManager.CurrentActivity.Content;
                        TDay.Text = _crudManager.CurrentDay.Day;
                    }
                    break;

                case "ListBoxTuesday":
                    if (ListBoxTuesday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.SetSelectedActivity(ListBoxTuesday.SelectedItem);

                        //
                        TTitle.Text = _crudManager.CurrentActivity.Name;
                        TContent.Text = _crudManager.CurrentActivity.Content;
                        TDay.Text = _crudManager.CurrentDay.Day;
                        
                    }
                    break;
                case "ListBoxWednesday":
                    if (ListBoxWednesday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.SetSelectedActivity(ListBoxWednesday.SelectedItem);

                        //
                        TTitle.Text = _crudManager.CurrentActivity.Name;
                        TContent.Text = _crudManager.CurrentActivity.Content;
                        TDay.Text = _crudManager.CurrentDay.Day;
                        
                    }
                    break;
                case "ListBoxThursday":
                    if (ListBoxThursday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.SetSelectedActivity(ListBoxThursday.SelectedItem);
                        TTitle.Text = _crudManager.CurrentActivity.Name;
                        TContent.Text = _crudManager.CurrentActivity.Content;
                        TDay.Text = _crudManager.CurrentDay.Day;
                        
                    }
                    break;
                case "ListBoxFriday":
                    if (ListBoxFriday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        _crudManager.SetSelectedActivity(ListBoxFriday.SelectedItem);
                        TTitle.Text = _crudManager.CurrentActivity.Name;
                        TContent.Text = _crudManager.CurrentActivity.Content;
                        TDay.Text = _crudManager.CurrentDay.Day;
                    }
                    break;
            }

            
        }


        //Allows user input in the text boxes
        //Displays the drop down menu to select a day 
        //Changes text box background to make it clear its editable
        public void isEditable()
        {
            TDay.IsReadOnly = false;
            TTitle.IsReadOnly = false;
            TTitle.Background = Brushes.White;
            TContent.IsReadOnly = false;
            TContent.Background = Brushes.White;
            ComboBoxDays.Visibility = Visibility.Visible;

        }

        //Disables text boxes from being changed
        //Hides drop down menu
        //Changes text box background to what it was previously
        public void isDisabled()
        {
            TDay.IsReadOnly = true;
            TTitle.IsReadOnly = true;
            TTitle.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9ECF9"));
            TContent.IsReadOnly = true;
            TContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9ECF9"));
            ComboBoxDays.Visibility = Visibility.Hidden;

        }

        private void BAllButton_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            switch (bt.Content)
            {
                //Opens Create Window and sets its owner to be MainWindow
                //Window should open in the middle of owner
                case "Create an Activity":
                    CreateActivity ca = new CreateActivity();
                    ca.Owner = this;
                    ca.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    ca.Show();
                    break;

                //sets day drop down menu selected item to the current day
                // text boxes and menu are usable
                case "Edit Activity":
                    isEditable();
                    ComboBoxDays.SelectedItem = _crudManager.CurrentDay.Day;
                    bt.Content = "Update Activity";
                    bt.Background = Brushes.DarkCyan;
                    break;

                //Checks if currentday is null to prevent crash
                //updates activity based on information on the text boxes
                //shows message if its updated or if there is an error
                //sets everything back so user can't edit again unless Button is clicked once more
                case "Update Activity":
                    try
                    {
                        if (_crudManager.CurrentActivity == null) throw new Exception("You have not selected anything!");
                        _crudManager.EditActivity(_crudManager.CurrentActivity.ActivityId, TTitle.Text.Trim(), TContent.Text.Trim(), TDay.Text.Trim());
                        fillUpLists();
                        _crudManager.SetSelectedDay();
                        MessageBox.Show("Updated Activity");

                    }
                    catch (Exception ex) //there is a bug -> once messagebox dissapear the text content remains with the wrong day until you click out and click back the activity
                    { MessageBox.Show(ex.Message, "Missing/Wrong input values!", MessageBoxButton.OK, MessageBoxImage.Warning);} 

                    bt.Content = "Edit Activity";
                    isDisabled();
                    bt.Background = Brushes.LightCyan;
                    break;

                //Checks if currentday is null to prevent crash
                //Deletes current activity and resets text
                //Shows message if your are trying to delete when nothing is selected
                case "Delete an Activity":
                    try
                    {
                        if (_crudManager.CurrentActivity == null) throw new Exception("You have not selected anything!");
                        _crudManager.DeleteActivity(_crudManager.CurrentActivity.ActivityId);
                        fillUpLists();
                        TTitle.Text = "";
                        TContent.Text = "";
                        TDay.Text = "";
                    }
                    catch (Exception ex)
                    {MessageBox.Show(ex.Message, "No Activity Selected!", MessageBoxButton.OK, MessageBoxImage.Warning);}
                    break;

                //Opens external activity Window and 
                //Sets its owner to be Main Window 
                case "Activity External View":
                    ActivityExternalView nw = new ActivityExternalView();
                    nw.Owner = this;
                    nw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    nw.Show();
                    break;

                //Opens Notes Window
                //Sets its owner to be Main Window
                case "Notes":
                    NotesWindow notesW = new NotesWindow();
                    notesW.Owner = this;
                    notesW.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    notesW.Show();
                    break;
            }
        }

        //Drop down menu used to change day for an activity
        //sets new value in the Day Text box -> used then in update function
        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxDays.SelectedItem != null)
            {
                _crudManager.SetSelectedDay(ComboBoxDays.SelectedItem.ToString());
                TDay.Text = _crudManager.CurrentDay.Day;
            }
        }
    }
}
