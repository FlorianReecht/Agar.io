using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agar.io
{
    public class GameObject : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _x, _y;
        private double _size;
        public double CentreX { get; set; }
        public double CentreY { get; set; }
        public double Size { get { return _size; } set { _size = value; OnPropertyChanged(nameof(Size)); } }
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
        public double SpeedX { get; set; } // Pixels / seconde
        public double SpeedY { get; set; }
        public bool IsInRange(GameObject o)
        {
           
            double distance = Math.Sqrt(((o.CentreX - CentreX) * (o.CentreX - CentreX)) + ((o.CentreY - CentreY) * (o.CentreY - CentreY)));
            return distance < Size/2 ? true : false;
        }
            
  
        
        public virtual void Update(TimeSpan dt,Point p)
        {

        }
        public virtual void SetCentre()
        {

        }

    }
}
