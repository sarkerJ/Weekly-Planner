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
        CRUDManagerActivity _crudManager = new CRUDManagerActivity();

        public NotesWindow()
        {
            InitializeComponent(); 
            fillUpComboBox();
        }
        public void fillUpComboBox()
        {
            ComboBoxDays.ItemsSource = _crudManager.ListOfDays();
            ComboBoxDays.DisplayMemberPath = "Day";
            ComboBoxDays.SelectedItem = ComboBoxDays.Items.CurrentItem;
            _crudManager.setSelectedDay(ComboBoxDays.SelectedItem);

        }
        private void ComboBoxDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxColours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
