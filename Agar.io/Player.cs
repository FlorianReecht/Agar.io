using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agar.io
{
    public class Player :GameObject
    {
       
        public override void Update(TimeSpan dt,Point p)
        {
            double directionX = (p.X - CentreX < 0) ? -SpeedX : SpeedX;
            double directionY = (p.Y - CentreY < 0) ? -SpeedY : SpeedY;

            X +=( dt.TotalSeconds * directionX);
            Y += (dt.TotalSeconds * directionY);
        
          
        }
        public override void SetCentre()
        {
            CentreX = X + Size / 2;
            CentreY = Y + Size / 2;
        }
    }
}
