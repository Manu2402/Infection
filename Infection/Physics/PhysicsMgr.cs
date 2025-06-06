using System.Collections.Generic;

namespace Infection
{
    static class PhysicsMgr
    {
        private static List<Rigidbody> balls;

        static PhysicsMgr()
        {
            balls = new List<Rigidbody>();
        }

        public static void AddItem(Rigidbody ball)
        {
            balls.Add(ball);
        }

        public static void RemoveItem(Rigidbody ball)
        {
            balls.Remove(ball);
        }

        public static void CheckCollision()
        {
            for (int i = 0; i < balls.Count - 1; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    if (balls[i].Collides(balls[j]))
                    {
                        balls[i].ball.OnCollide(balls[j].ball);
                    }
                }
            }
        }
    }
}
