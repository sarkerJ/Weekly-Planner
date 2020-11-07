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
    /// Interaction logic for ActivityExternalView.xaml
    /// </summary>
    public partial class ActivityExternalView : Window
    {
        CRUDManagerActivity _crudManager = new CRUDManagerActivity();

        public ActivityExternalView()
        {
            InitializeComponent();
            fillUpComboBox();
        }

        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDays.SelectedItem != null)
            {
                _crudManager.setSelectedDay(ComboBoxDays.SelectedItem);
                populateListBox();
            }
        }
        public void fillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
            ComboBoxDays.SelectedItem = ComboBoxDays.Items.CurrentItem;
            _crudManager.setSelectedDay(ComboBoxDays.SelectedItem);
            ListBoxActivities.SelectedItem = ListBoxActivities.Items.CurrentItem;
            _crudManager.setSelectedActivity(ListBoxActivities.SelectedItem);

        }
        public void populateListBox()
        {
            ListBoxActivities.ItemsSource = _crudManager.ListOfActivities(_crudManager.currentDay.Day);
        }

      

        private void BEditActivity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.EditActivity(_crudManager.currentActivity.ActivityId, TName.Text.Trim(), TContent.Text.Trim(), _crudManager.currentDay.Day);
                populateListBox();
                ((MainWindow)this.Owner).fillUpLists();
                MessageBox.Show("Updated Activity");
                ((MainWindow)this.Owner).Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occured!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ((MainWindow)this.Owner).Focus();
            }
        }

        private void ListBoxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxActivities.SelectedItem != null)
            {
                _crudManager.setSelectedActivity(ListBoxActivities.SelectedItem);
                TName.Text = _crudManager.currentActivity.Name;
                TContent.Text = _crudManager.currentActivity.Content;
            }

            
        }
    }
}
