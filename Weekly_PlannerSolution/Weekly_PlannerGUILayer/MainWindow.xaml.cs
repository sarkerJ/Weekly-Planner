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
            ListBoxMonday.SelectedItem = ListBoxMonday.Items.CurrentItem;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        public void fillUpComboBox()
        {
            ComboBoxDays.Background = Brushes.White;
            ComboBoxDays.ItemsSource = _crudManager.ListOfDaysString();
            //ComboBoxDays.DisplayMemberPath = "Day";
        }

        public void fillUpLists()
        {
            ListBoxMonday.ItemsSource = _crudManager.ListOfActivities("Monday");
            ListBoxTuesday.ItemsSource = _crudManager.ListOfActivities("Tuesday");
            ListBoxWednesday.ItemsSource = _crudManager.ListOfActivities("Wednesday");
            ListBoxThursday.ItemsSource = _crudManager.ListOfActivities("Thursday");
            ListBoxFriday.ItemsSource = _crudManager.ListOfActivities("Friday");
        }
       
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
                        _crudManager.setSelectedActivity(ListBoxMonday.SelectedItem);
                        TTitle.Text = _crudManager.currentActivity.Name;
                        TContent.Text = _crudManager.currentActivity.Content;
                        TDay.Text = _crudManager.currentDay.Day;
                        
                    }
                    break;

                case "ListBoxTuesday":
                    if (ListBoxTuesday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.setSelectedActivity(ListBoxTuesday.SelectedItem);
                        TTitle.Text = _crudManager.currentActivity.Name;
                        TContent.Text = _crudManager.currentActivity.Content;
                        TDay.Text = _crudManager.currentDay.Day;
                        
                    }
                    break;
                case "ListBoxWednesday":
                    if (ListBoxWednesday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.setSelectedActivity(ListBoxWednesday.SelectedItem);
                        TTitle.Text = _crudManager.currentActivity.Name;
                        TContent.Text = _crudManager.currentActivity.Content;
                        TDay.Text = _crudManager.currentDay.Day;
                        
                    }
                    break;
                case "ListBoxThursday":
                    if (ListBoxThursday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxFriday.SelectedItem = null;
                        _crudManager.setSelectedActivity(ListBoxThursday.SelectedItem);
                        TTitle.Text = _crudManager.currentActivity.Name;
                        TContent.Text = _crudManager.currentActivity.Content;
                        TDay.Text = _crudManager.currentDay.Day;
                        
                    }
                    break;
                case "ListBoxFriday":
                    if (ListBoxFriday.SelectedItem != null)
                    {
                        ListBoxMonday.SelectedItem = null;
                        ListBoxTuesday.SelectedItem = null;
                        ListBoxWednesday.SelectedItem = null;
                        ListBoxThursday.SelectedItem = null;
                        _crudManager.setSelectedActivity(ListBoxFriday.SelectedItem);
                        TTitle.Text = _crudManager.currentActivity.Name;
                        TContent.Text = _crudManager.currentActivity.Content;
                        TDay.Text = _crudManager.currentDay.Day;
                        
                    }
                    break;
            }

            
        }

        private void BDeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (_crudManager.currentActivity == null) throw new Exception("You have not selected anything!");
                _crudManager.DeleteActivity(_crudManager.currentActivity.ActivityId);
                fillUpLists();
                TTitle.Text = "";
                TContent.Text = "";
                TDay.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No Activity Selected!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BCreateActivity_Click(object sender, RoutedEventArgs e)
        {
            CreateActivity ca = new CreateActivity();
            ca.Owner = this;
            ca.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ca.Show();
        }


        public void isEditable()
        {
            TDay.IsReadOnly = false;
            TTitle.IsReadOnly = false;
            TTitle.Background = Brushes.White;
            TContent.IsReadOnly = false;
            TContent.Background = Brushes.White;

        }

        public void isDisabled()
        {
            TDay.IsReadOnly = true;
            TTitle.IsReadOnly = true;
            TTitle.Background = Brushes.LightBlue;
            TContent.IsReadOnly = true;
            TContent.Background = Brushes.LightBlue;
        }

        private void BEditActivity_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            switch (bt.Content)
            {
                case "Edit Activity":
                    isEditable();
                    ComboBoxDays.SelectedItem = _crudManager.currentDay.Day;
                    ComboBoxDays.Visibility = Visibility.Visible;
                    bt.Content = "Update Activity";
                    break;

                case "Update Activity":
                    try
                    {
                        if (_crudManager.currentActivity == null) throw new Exception("You have not selected anything!");
                        _crudManager.EditActivity(_crudManager.currentActivity.ActivityId, TTitle.Text.Trim(), TContent.Text.Trim(), TDay.Text.Trim());
                        fillUpLists();
                        _crudManager.setSelectedDay();
                        MessageBox.Show("Updated Activity");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    bt.Content = "Edit Activity";
                    ComboBoxDays.Visibility = Visibility.Hidden;
                    isDisabled();
                    break;
            }

            
        }

        private void BAExternalView_Click(object sender, RoutedEventArgs e)
        {
            ActivityExternalView nw = new ActivityExternalView();
            nw.Owner = this;
            nw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            nw.Show();

        }

        private void BNotes_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow nw = new NotesWindow();
            nw.Owner = this;
            nw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            nw.Show();


        }

        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxDays.SelectedItem != null)
            {
                _crudManager.setSelectedDay(ComboBoxDays.SelectedItem.ToString());
                TDay.Text = _crudManager.currentDay.Day;
            }
            
        }
    }
}
