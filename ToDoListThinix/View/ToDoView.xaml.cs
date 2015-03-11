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
using ToDoListThinix.ViewModel;
using ToDoListThinix.Model;

namespace ToDoListThinix.View
{
    /// <summary>
    /// Interaction logic for ToDoView.xaml
    /// </summary>
    public partial class ToDoView : UserControl
    {
        ToDoViewModel MyList;
        public ToDoView()
        {
            InitializeComponent();
            MyList = new ToDoViewModel();
            DataContext = MyList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyList.add_to_list();
        }

        private void DeleteMultiple(object sender, RoutedEventArgs e)
        {
            MyList.delete_element();
        }

        private void deletebuttonclick(object sender, RoutedEventArgs e)
        {
            ToDoModel selectedNode = ((Button)sender).DataContext as ToDoModel;
            MyList.delete(selectedNode);
        }
        private void updatebuttonclick(object sender, RoutedEventArgs e)
        {
            ToDoModel selectedNode = ((Button)sender).DataContext as ToDoModel;
            MyList.updatenode(selectedNode);
        }
        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            ToDoModel selectedcheckednode = ((CheckBox)sender).DataContext as ToDoModel;
            MyList.checkboxchecked(selectedcheckednode);
            // Title.

        }
        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            //  strike = ((CheckBox)sender).DataContext as Line;
            // strike.StrokeThickness = 2;

            // block.FontFamily="Arial"
        }
        public void Save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saving");
            MyList.SaveContent();
        }
        public void Load(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Saving");
            MyList.loadContent();
        }

        private void update_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter titles and/or details over here and click the update buton of the currosponding to do item you want to update");
        }
    }
}
