using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class CounterPoint : IImpactPoint
    {
        public int Radius = 100; 
        public int Count = 0; 
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); 
            var p = (particle as ParticleColorful);
            if (r + particle.Radius < Radius / 2) 
            {
                p.Life = 0; 
                Count++; 
            }
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.White),
                   X - Radius / 2,
                   Y - Radius / 2,
                   Radius,
                   Radius
               );
            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(
            $"{Count}", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
            new Font("Verdana", 10), // шрифт и его размер
            new SolidBrush(Color.White), // цвет шрифта
            X, // расположение в пространстве
            Y,
            stringFormat
        );
        }
    }
}