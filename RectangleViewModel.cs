using System.ComponentModel;
using System.Windows;

namespace Grafika4
{
    public class RectangleViewModel : ShapeViewModel
    {
        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

    }
}
