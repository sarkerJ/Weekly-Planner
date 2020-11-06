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

        public void fillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
        }

        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDays.SelectedItem != null)
            {
                _crudManager.setSelectedDay(ComboBoxDays.SelectedItem);
                ListBoxActivities.ItemsSource = _crudManager.ListOfActivities(_crudManager.currentDay.Day);
            }
        }

    }
}
