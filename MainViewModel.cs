using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Grafika4
{
    public class MainViewModel
    {       
        
        public ICommand StartDragCommand { get; }
        public ICommand DragCommand { get; }
        public ICommand StopDragCommand { get; }
        public ICommand IncreaseSizeCommand { get; }
        public ICommand DecreaseSizeCommand { get; }

        public ObservableCollection<ShapeViewModel> Shapes { get; set; }
        public ICommand AddRectangleCommand { get; }
        public ICommand AddTriangleCommand { get; }
        public ICommand AddEllipseCommand { get; }
        public ICommand RemoveShapeCommand { get; }

        public MainViewModel()
        {
            Shapes = new ObservableCollection<ShapeViewModel>();
            AddRectangleCommand = new RelayCommand(AddRectangle);
            AddTriangleCommand = new RelayCommand(AddTriangle);
            AddEllipseCommand = new RelayCommand(AddEllipse);
            RemoveShapeCommand = new RelayCommand<ShapeViewModel>(RemoveShape);
            StartDragCommand = new RelayCommand<ShapeViewModel>(StartDrag);
            DragCommand = new RelayCommand<ShapeViewModel>(Drag);
            StopDragCommand = new RelayCommand<ShapeViewModel>(StopDrag);
            IncreaseSizeCommand = new RelayCommand<ShapeViewModel>(IncreaseSize);
            DecreaseSizeCommand = new RelayCommand<ShapeViewModel>(DecreaseSize);
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

            Shapes.Add(newRectangle);
        }

        private void AddTriangle()
        {
            var cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);
            var newTriangle = new TriangleViewModel
            {
                Position = new Point(cursorPosition.X - 25, cursorPosition.Y - 25),
                Vertex1 = new Point(cursorPosition.X - 50, cursorPosition.Y - 50),
                Vertex2 = new Point(cursorPosition.X, cursorPosition.Y + 50),
                Vertex3 = new Point(cursorPosition.X + 50, cursorPosition.Y - 50)
            };

            Shapes.Add(newTriangle);
        }

        private void AddEllipse()
        {
            var cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);
            var newEllipse = new EllipseViewModel
            {
                Position = new Point(cursorPosition.X - 25, cursorPosition.Y - 25),
                RadiusX = 200,
                RadiusY = 200
            };

            Shapes.Add(newEllipse);
        }

        private void RemoveShape(ShapeViewModel shape)
        {
            if (shape != null)
            {
                Shapes.Remove(shape);
            }
        }

        private void StartDrag(ShapeViewModel shape)
        {
            foreach (var shp in Shapes)
            {
                shp.IsDragging = false;  // Reset flag IsDragging for all shapes
            }

            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                var cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);
                shape.IsDragging = true;
                shape.StartDragPosition = cursorPosition;
            }
            // Move the dragged shape to the end of the list, so it's displayed on top
            Shapes.Remove(shape);
            Shapes.Add(shape);
        }

        private void Drag(ShapeViewModel shape)
        {
            if (shape.IsDragging && Mouse.RightButton == MouseButtonState.Pressed)
            {
                var currentPosition = Mouse.GetPosition(Application.Current.MainWindow);
                var deltaX = currentPosition.X - shape.StartDragPosition.X;
                var deltaY = currentPosition.Y - shape.StartDragPosition.Y;

                shape.Position = new Point(shape.Position.X + deltaX, shape.Position.Y + deltaY);
                shape.StartDragPosition = currentPosition;
            }
        }

        private void StopDrag(ShapeViewModel shape)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                shape.IsDragging = false;
            }
        }

        private void IncreaseSize(ShapeViewModel shape)
        {
            if (shape != null && shape is RectangleViewModel rectangle)
            {
                rectangle.Width += 10;
                rectangle.Height += 10;
            }
            else if (shape is EllipseViewModel ellipse)
            {
                ellipse.RadiusX += 10;
                ellipse.RadiusY += 10;
            }
        }

        private void DecreaseSize(ShapeViewModel shape)
        {
            if (shape != null && shape is RectangleViewModel rectangle && rectangle.Width > 10 && rectangle.Height > 10)
            {
                rectangle.Width -= 10;
                rectangle.Height -= 10;
            }
            else if (shape is EllipseViewModel ellipse)
            {
                ellipse.RadiusX -= 10;
                ellipse.RadiusY -= 10;
            }
        }



    }
}
