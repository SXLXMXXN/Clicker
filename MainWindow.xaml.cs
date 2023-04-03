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

namespace Clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isBinding = false;
        private bool _isStartBinding = false;
        public bool IsClick = false;
        private Key _actionKey;
        public MainWindow()
        {
            InitializeComponent();
            ListView_SizeChanged(OrderList, null);

        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void WindowSizeChange(object sender, SizeChangedEventArgs e)
        {
            Window window = sender as Window;
            var workingWidth = window.ActualWidth;
            window.Height = workingWidth / 1.77;
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;
            var workingWidth = listView.ActualWidth;
            
            var col1 = 0.05;
            var col2 = 0.10;
            var col3 = 0.05;
            var col4 = 0.10;
            var col5 = 0.10;
            var col6 = 0.20;
            var col7 = 0.20;
            var col8 = 0.05;
            var col9 = 0.05;
            var col10 = 0.05;
            var col11 = 0.05;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
            gView.Columns[5].Width = workingWidth * col6;
            gView.Columns[6].Width = workingWidth * col7;
            gView.Columns[7].Width = workingWidth * col8;
            gView.Columns[8].Width = workingWidth * col9;
            gView.Columns[9].Width = workingWidth * col10;
            gView.Columns[10].Width = workingWidth * col11;
        }

        private void KeyBind_Click(object sender, RoutedEventArgs e)
        {
            _isBinding = true;
        }


        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isBinding)
            {
                KeyBindText.Text = e.Key.ToString();
                _actionKey = e.Key;
                _isBinding = false;
            }
            else if (_isStartBinding)
            {
                StartScriptText.Text = e.Key.ToString();
                _isStartBinding = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsClick = true;
            Coordinate _coordinate = new Coordinate(this);
            _coordinate.Show();
        }

       

        private void StartBindButton_Click(object sender, RoutedEventArgs e)
        {
            _isStartBinding = true;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            int delay = Convert.ToInt32(DelayText.Text);
            var type = BaseAction.FromString((ActionComboBox.SelectedItem as ComboBoxItem).Name);
            int coordx = Convert.ToInt32(CoordX.Text);
            int coordy = Convert.ToInt32(CoordY.Text);
            int repeat = Convert.ToInt32(RepeatText.Text);

            BaseAction action = new BaseAction(_actionKey, delay, type , coordx, coordy, repeat);
            OrderList.Items.Add(action);
        }
    }
}
