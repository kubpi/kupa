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

namespace Grafika4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();      
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            var selectedRectangle = viewModel.Rectangles.FirstOrDefault(r => r.IsDragging);  // Znajdź wybrany prostokąt

            if (selectedRectangle != null)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        viewModel.IncreaseSizeCommand.Execute(selectedRectangle);
                        break;

                    case Key.Down:
                        viewModel.DecreaseSizeCommand.Execute(selectedRectangle);
                        break;
                }
            }
        }

    }
}
