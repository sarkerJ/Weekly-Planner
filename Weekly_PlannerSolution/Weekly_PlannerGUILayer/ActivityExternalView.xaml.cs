﻿using System;
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
        readonly CRUDManagerActivity _crudManager = new CRUDManagerActivity();

        public ActivityExternalView()
        {
            InitializeComponent();
            FillUpComboBox();
        }

        //Action when item is selected in day combobox
        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDays.SelectedItem != null)
            {
                _crudManager.SetSelectedDay(ComboBoxDays.SelectedItem);
                PopulateListBox();
            }
        }
        //populates the combo box filter 
        //automatically sets the filter to monday 
        public void FillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
            ComboBoxDays.SelectedItem = ComboBoxDays.Items.CurrentItem;
            _crudManager.SetSelectedDay(ComboBoxDays.SelectedItem);
            ListBoxActivities.SelectedItem = ListBoxActivities.Items.CurrentItem;
            _crudManager.SetSelectedActivity(ListBoxActivities.SelectedItem);

        }

        //populates the activity listbox
        public void PopulateListBox() => ListBoxActivities.ItemsSource = _crudManager.ListOfActivities(_crudManager.CurrentDay.Day);
              
        //Edit button function
        private void BEditActivity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.EditActivity(_crudManager.CurrentActivity.ActivityId, TName.Text.Trim(), TContent.Text.Trim(), _crudManager.CurrentDay.Day);
                PopulateListBox();
                ((MainWindow)this.Owner).FillUpLists();
                MessageBox.Show("Updated Activity");
                ((MainWindow)this.Owner).Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occured!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ((MainWindow)this.Owner).Focus();
            }
        }

        //Action when an item in the activities is selected
        private void ListBoxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxActivities.SelectedItem != null)
            {
                _crudManager.SetSelectedActivity(ListBoxActivities.SelectedItem);
                TName.Text = _crudManager.CurrentActivity.Name;
                TContent.Text = _crudManager.CurrentActivity.Content;
            }                        
        }
    }
}
