using OpenTK;

namespace Infection
{
    class Rigidbody
    {
        public Vector2 Velocity;
        public Ball ball;
        public Collider Collider;

        public float mass;
        public float p;

        public Rigidbody(Vector2 velocity, Ball ball)
        {
            Velocity = velocity;
            this.ball = ball;
            mass = RandomGenerator.GetRandomFloat(0.8f, 1.2f);
        }

        public void Update()
        {
            ball.Position += Velocity.Normalized() * ball.maxSpeed * Program.DeltaTime;
            
            if (ball.Position.X - ball.HalfWidth < 0f)
            {
                ball.X = ball.HalfWidth;
                Velocity.X = -Velocity.X;
            }
            else if (ball.Position.X + ball.HalfWidth > Program.Window.Width)
            {
                ball.X = Program.Window.Width - ball.HalfWidth;
                Velocity.X = -Velocity.X;
            }
            else if (ball.Position.Y - ball.HalfHeight < 0f)
            {
                ball.Y = ball.HalfHeight;
                Velocity.Y = -Velocity.Y;
            }
            else if (ball.Position.Y + ball.HalfHeight > Program.Window.Height)
            {
                ball.Y = Program.Window.Height - ball.HalfHeight;
                Velocity.Y = -Velocity.Y;
            }
        }

        public bool Collides(Rigidbody other)
        {
            return other.Collider.Collides(Collider);
        }
    }
}
