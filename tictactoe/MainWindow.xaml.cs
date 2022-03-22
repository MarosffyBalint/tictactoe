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

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logic logic = new Logic();
            renderer.SetupLogic(logic);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            renderer.ReSize(new Size(grid.ActualWidth, grid.ActualHeight));
            renderer.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            renderer.InvalidateVisual();
        }

        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mouse = e.GetPosition(grid);
            int x = (int)((mouse.X));
            int y = (int)((mouse.Y));

            renderer.InvalidateVisual();
            if (x < grid.ActualWidth / 3)
            {
                x = 0;
            }
            else if (x < grid.ActualWidth / 3 * 2 && x >= grid.ActualWidth / 3)
            {
                x = 1;
            }
            else
            {
                x = 2;
            }
            if (y < grid.ActualHeight / 3)
            {
                y = 0;
            }
            else if (y < grid.ActualHeight / 3 * 2 && y >= grid.ActualHeight / 3)
            {
                y = 1;
            }
            else
            {
                y = 2;
            }
            renderer.logic.BoardClick(x,y);

        }
    }
}
