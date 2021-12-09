using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agar.io
{
    public class Food:GameObject
    {
        private const int FOOD_SIZE= 10;
        
        public override void SetCentre()
        {
            CentreX = X - Size / 2;
            CentreY = Y - Size / 2;
        }
        public override void Update(TimeSpan dt, Point p)
        {

        }
        public Food(int maxWidth,int maxHeigth)
        {
            int width= new Random().Next(maxWidth);
            int heigth = new Random().Next(maxWidth);
            X = width;
            Y = heigth;
            Size = FOOD_SIZE;
        }


    }
}
