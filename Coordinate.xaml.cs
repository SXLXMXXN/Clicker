﻿using System;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Clicker
{
    /// <summary>
    /// Interaction logic for Coordinate.xaml
    /// </summary>
    public partial class Coordinate : Window
    {
        private MainWindow _mainWindow;
        private DispatcherTimer _timer = new DispatcherTimer();
        public Coordinate(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainWindow = mainwindow;
            _timer.Interval = new TimeSpan(0, 0, 0, 0,50);
            _timer.Tick += PerformCaptureMouse;
            _timer.Start();
        }

        private void PerformCaptureMouse(object sender, EventArgs eventArgs)
        {
            CaptureMouse();
            var point = MousePosition.GetMousePosition();
            _mainWindow.CoordX.Text = point.X.ToString();
            _mainWindow.CoordY.Text = point.Y.ToString();
            ReleaseMouseCapture();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.IsClick = false;
            _timer.Stop();
            Close();
        }
    }
}
