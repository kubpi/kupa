using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Grafika4
{
    public class MainViewModel
    {
        public ObservableCollection<RectangleViewModel> Rectangles { get; set; }
        public ICommand AddRectangleCommand { get; }
        public ICommand RemoveRectangleCommand { get; }
        public ICommand StartDragCommand { get; }
        public ICommand DragCommand { get; }
        public ICommand StopDragCommand { get; }

        public ICommand IncreaseSizeCommand { get; }
        public ICommand DecreaseSizeCommand { get; }

        public MainViewModel()
        {
            Rectangles = new ObservableCollection<RectangleViewModel>();
            AddRectangleCommand = new RelayCommand(AddRectangle);
            RemoveRectangleCommand = new RelayCommand<RectangleViewModel>(RemoveRectangle);
            StartDragCommand = new RelayCommand<RectangleViewModel>(StartDrag);
            DragCommand = new RelayCommand<RectangleViewModel>(Drag);
            StopDragCommand = new RelayCommand<RectangleViewModel>(StopDrag);
            IncreaseSizeCommand = new RelayCommand<RectangleViewModel>(IncreaseSize);
            DecreaseSizeCommand = new RelayCommand<RectangleViewModel>(DecreaseSize);
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
        private void RemoveRectangle(RectangleViewModel rectangle)
        {
            if (rectangle != null)
            {
                Rectangles.Remove(rectangle);
            }
        }

        private void StartDrag(RectangleViewModel rectangle)
        {
            foreach (var rect in Rectangles)
            {
                rect.IsDragging = false;  // Reset flagi IsDragging dla wszystkich prostokątów
            }
        
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                var cursorPosition = Mouse.GetPosition(Application.Current.MainWindow);
                rectangle.IsDragging = true;
                rectangle.StartDragPosition = cursorPosition;
            }
            // Przenieś przesuwany prostokąt na koniec listy, aby był wyświetlany na wierzchu
            Rectangles.Remove(rectangle);
            Rectangles.Add(rectangle);
        }

        private void Drag(RectangleViewModel rectangle)
        {
            if (rectangle.IsDragging && Mouse.RightButton == MouseButtonState.Pressed)
            {
                var currentPosition = Mouse.GetPosition(Application.Current.MainWindow);
                var deltaX = currentPosition.X - rectangle.StartDragPosition.X;
                var deltaY = currentPosition.Y - rectangle.StartDragPosition.Y;

                rectangle.Position = new Point(rectangle.Position.X + deltaX, rectangle.Position.Y + deltaY);
                rectangle.StartDragPosition = currentPosition;
            }
        }

        private void StopDrag(RectangleViewModel rectangle)
        {
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                rectangle.IsDragging = false;
            }
           
        }

        private void IncreaseSize(RectangleViewModel rectangle)
        {
            if (rectangle != null)
            {
                rectangle.Width += 10;
                rectangle.Height += 10;
            }
        }

        private void DecreaseSize(RectangleViewModel rectangle)
        {
            if (rectangle != null && rectangle.Width > 10 && rectangle.Height > 10)
            {
                rectangle.Width -= 10;
                rectangle.Height -= 10;
            }
        }



    }
}
