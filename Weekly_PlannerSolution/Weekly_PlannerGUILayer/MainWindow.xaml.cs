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
                        _crudManager.setSelectedDay(ListBoxMonday.SelectedItem);
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
                        _crudManager.setSelectedDay(ListBoxTuesday.SelectedItem);
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
                        _crudManager.setSelectedDay(ListBoxWednesday.SelectedItem);
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
                        _crudManager.setSelectedDay(ListBoxThursday.SelectedItem);
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
                        _crudManager.setSelectedDay(ListBoxFriday.SelectedItem);
                        TTitle.Text = _crudManager.currentActivity.Name;
                        TContent.Text = _crudManager.currentActivity.Content;
                        TDay.Text = _crudManager.currentDay.Day;
                        
                    }
                    break;
            }

            
        }

        private void BDeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.DeleteActivity(_crudManager.currentActivity.ActivityId);
            fillUpLists();
            TTitle.Text = "";
            TContent.Text = "";
            TDay.Text = "";

        }

        private void BCreateActivity_Click(object sender, RoutedEventArgs e)
        {
            CreateActivity ca = new CreateActivity();
            ca.Show();
            ca.Owner = this;
        }

        private void BEditActivity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.EditActivity(_crudManager.currentActivity.ActivityId, TTitle.Text.Trim(), TContent.Text.Trim(), TDay.Text.Trim());
                fillUpLists();
                MessageBox.Show("Updated Activity");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
