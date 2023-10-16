using System.ComponentModel;
using System.Windows;

namespace Grafika4
{
    public class RectangleViewModel : INotifyPropertyChanged
    {
        private Point _position;

        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public double Width { get; set; }
        public double Height { get; set; }

        public bool IsDragging { get; set; }
        public Point StartDragPosition { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
