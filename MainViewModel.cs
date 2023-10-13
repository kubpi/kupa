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
            var newRectangle = new RectangleViewModel
            {
                Position = Mouse.GetPosition(Application.Current.MainWindow),
                Width = 50,
                Height = 50
            };

            Rectangles.Add(newRectangle);
        }
    }
}
