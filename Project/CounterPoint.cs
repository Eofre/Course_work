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
        public int Radius = 100; // радиус
        public int Count = 0; // сам счётчик
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            var p = (particle as ParticleColorful);
            if (r + particle.Radius < Radius / 2) // если частица оказалось внутри окружности
            {
                p.Radius = 0; // чтобы частица не мешалась еще сколько то тиков при смерти, делаю радиус 0
                p.Life = 0; // а частица умерла туть(
                Count++; // а счётчик прибавился туть)
            }
        }
    }
}