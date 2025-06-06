using OpenTK;

namespace Infection
{
    static class BallMgr
    {
        private static Ball[] balls;
        private static int numBalls;
        private static int halfWidth;
        private static int halfHeight;

        public static Ball[] Balls { get { return balls; } }

        public static void Init()
        {
            numBalls = 50;
            balls = new Ball[numBalls];
            
            halfWidth = 16;
            halfHeight = 16;
            
            for (int i = 0; i < numBalls; i++)
            {
                balls[i] = new Ball(new Vector2(RandomGenerator.GetRandomFloat(halfWidth, Program.Window.Width - halfWidth), RandomGenerator.GetRandomFloat(halfHeight, Program.Window.Height - halfHeight)));
            }
        }

        public static void Update()
        {
            for (int i = 0; i < numBalls; i++)
            {
                balls[i].Update();
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < numBalls; i++)
            {
                balls[i].Draw();
            }
        }
        
    }
}
