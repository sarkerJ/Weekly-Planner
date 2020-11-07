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
    /// Interaction logic for CreateActivity.xaml
    /// </summary>
    public partial class CreateActivity : Window
    {
        CRUDManagerActivity _crudManager = new CRUDManagerActivity();
        public CreateActivity()
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
            if(ComboBoxDays.SelectedItem != null)
            {
                _crudManager.setSelectedDay(ComboBoxDays.SelectedItem);
            }
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudManager.CreateActivity(TName.Text, TContent.Text, _crudManager.currentDay.Day);
                this.Close();
                ((MainWindow)this.Owner).fillUpLists();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Duplicate Title or Missing input values!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ((MainWindow)this.Owner).Focus(); //to ensure when you close the 2nd window using "x" the mainwindow does not go behind other applications
            }
        }
    }
}
