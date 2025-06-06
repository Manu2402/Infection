using System;

namespace Infection
{
    static class RandomGenerator
    {
        public static Random Random;

        static RandomGenerator()
        {
            Random = new Random();
        }

        public static float GetRandomFloat(float min, float max)
        {
            return (float)((Random.NextDouble() * (max - min)) + min);
        }
    }
}
