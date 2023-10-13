using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Grafika4
{
    public class MainViewModel
    {
        public ObservableCollection<RectangleViewModel> Rectangles { get; set; }
        public ICommand AddRectangleCommand { get; }

        public MainViewModel()
        {
            Rectangles = new ObservableCollection<RectangleViewModel>();
            AddRectangleCommand = new RelayCommand(AddRectangle);
        }

        private void AddRectangle()
        {
            var cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);
            var newRectangle = new RectangleViewModel
            {
                Position = new Point(cursorPosition.X - 25, cursorPosition.Y - 25),
                Width = 50,
                Height = 50
            };

            Rectangles.Add(newRectangle);
        }
    }
}
