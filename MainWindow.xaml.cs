using System.Linq;
using System.Windows;
using System.Windows.Input;

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
            var selectedRectangle = viewModel.Shapes.FirstOrDefault(r => r.IsDragging);  // Znajdź wybrany prostokąt

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
