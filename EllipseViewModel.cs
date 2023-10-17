using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika4
{
    public class EllipseViewModel : ShapeViewModel
    {
        private double _radiusX;
        public double RadiusX
        {
            get { return _radiusX; }
            set
            {
                _radiusX = value;
                OnPropertyChanged(nameof(RadiusX));
            }
        }

        private double _radiusY;
        public double RadiusY
        {
            get { return _radiusY; }
            set
            {
                _radiusY = value;
                OnPropertyChanged(nameof(RadiusY));
            }
        }
    }
}
