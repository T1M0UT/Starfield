using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfield
{
    public class Star
    {
        private static readonly Random random = new Random();

        private static int width;
        private static int height;

        private float x;
        private float y;
        private float z;

        private float previousZ;

        public static void Setup(int width, int height)
        {
            Star.width = width;
            Star.height = height;
        }

        public Star()
        {
            SetNewCoords();
        }

        private void SetNewCoords()
        {
            x = random.Next(-width, width);
            y = random.Next(-height, height);
            z = random.Next(width);
            previousZ = z;
        }

        public void Update()
        {
            z = z - 10;
            if(z < 1)
            {
                SetNewCoords();
            }

        }

        public void Show(Graphics graphics, Color starColor)
        {
            float sx = Map(x / z, 0, 1, 0, width);
            float sy = Map(y / z, 0, 1, 0, height);

            float r = Map(z, 0, width, 5, 0);

            float previousX = Map(x / previousZ, 0, 1, 0, width);
            float previousY = Map(y / previousZ, 0, 1, 0, height);

            graphics.FillEllipse(new SolidBrush(starColor), sx - r / 2, sy - r / 2, r, r);
            graphics.DrawLine(new Pen(starColor), previousX, previousY, sx, sy);

            previousZ = z;
        }

        private static float Map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }
    }
}
