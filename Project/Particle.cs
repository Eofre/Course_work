using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Particle
    {
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float Direction; // направление движения
        public float Speed; // скорость перемещения
        public float Life;

        public static Random rand = new Random();

       
        public Particle()
        {

            Direction = rand.Next(360);
            Speed = 1 + rand.Next(10);
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }

        public void Draw(Graphics g)
        {
            
            float k = Math.Min(1f, Life / 100);
            
            int alpha = (int)(k * 255);

            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

    }
}
