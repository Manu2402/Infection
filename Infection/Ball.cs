using System;
using Aiv.Fast2D;
using OpenTK;

namespace Infection
{
    class Ball
    {
        private Texture texture;
        private Sprite sprite;
        public float maxSpeed;

        public Rigidbody Rigidbody;

        private bool isInfected;
        private bool atRisk;

        private static bool firstInfected = false;

        private StateMachine fsm;

        public float VisionRadius;

        public Vector2 Position { get { return sprite.position; } set { sprite.position = value; } }
        public float X { get { return sprite.position.X; } set { sprite.position.X = value; } }
        public float Y { get { return sprite.position.Y; } set { sprite.position.Y = value; } }

        public int HalfWidth { get { return (int)(sprite.Width * 0.5f); } }
        public int HalfHeight { get { return (int)(sprite.Height * 0.5f); } }

        public bool IsInfected { get { return isInfected; } set { isInfected = value; } }
        public bool AtRisk { get { return atRisk; } set { atRisk = value; } }

        public StateMachine Fsm { get { return fsm; } }

        public Ball(Vector2 position)
        {
            texture = new Texture("Assets/grey_ball.png");
            sprite = new Sprite(texture.Width, texture.Height);

            sprite.pivot = new Vector2(HalfWidth, HalfHeight);
            Position = position;

            maxSpeed = RandomGenerator.GetRandomFloat(100f, 200f);

            Rigidbody = new Rigidbody(new Vector2(RandomGenerator.GetRandomFloat(-1f, 1f), RandomGenerator.GetRandomFloat(-1f, 1f)), this);
            Rigidbody.Collider = ColliderFactory.CreateCircleFor(this);
            Rigidbody.p = Rigidbody.mass * maxSpeed; // Momentum.
            PhysicsMgr.AddItem(Rigidbody);

            VisionRadius = 64f;

            isInfected = false;
            atRisk = false;

            fsm = new StateMachine();
            fsm.AddState(States.NotInfected, new NotInfectedState(this));
            fsm.AddState(States.AtRisk, new AtRiskState(this));
            fsm.AddState(States.Infected, new InfectedState(this));

            if (!firstInfected)
            {
                firstInfected = true;
                fsm.GoTo(States.Infected);
                IsInfected = true;
            }
            else
            {
                fsm.GoTo(States.NotInfected);
            }
        }

        public void Update()
        {
            fsm.Update();
            Rigidbody.Update();
        }

        public void SetColor(Vector4 color)
        {
            sprite.SetAdditiveTint(color);
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }

        public void Momentum(Ball other)
        {
            float temp = maxSpeed;
            maxSpeed = other.maxSpeed;
            other.maxSpeed = temp;
        }

        public void OnCollide(Ball other)
        {
            Momentum(other);

            Vector2 dist = other.Position - Position;
            Vector2 distOther = Position - other.Position;

            float absDistX = Math.Abs(dist.X);
            float absDistY = Math.Abs(dist.Y);

            if (absDistX > absDistY)
            {
                if (Math.Sign(Rigidbody.Velocity.X) != Math.Sign(other.Rigidbody.Velocity.X))
                {
                    Rigidbody.Velocity.X = -Rigidbody.Velocity.X;
                    other.Rigidbody.Velocity.X = -other.Rigidbody.Velocity.X;
                }
            }
            else if (absDistX < absDistY)
            {
                if (Math.Sign(Rigidbody.Velocity.Y) != Math.Sign(other.Rigidbody.Velocity.Y))
                {
                    Rigidbody.Velocity.Y = -Rigidbody.Velocity.Y;
                    other.Rigidbody.Velocity.Y = -other.Rigidbody.Velocity.Y;
                }
            }

            float angle = (float)Math.Atan2(dist.Y, dist.X);
            float angleOther = (float)Math.Atan2(distOther.Y, distOther.X);

            float cosAngle = (float)Math.Cos(angle);
            float sinAngle = (float)Math.Sin(angle);
            float cosAngleOther = (float)Math.Cos(angleOther);
            float sinAngleOther = (float)Math.Sin(angleOther);

            float overflow = ((CircleCollider)Rigidbody.Collider).Radius + ((CircleCollider)other.Rigidbody.Collider).Radius - dist.Length;

            X -= cosAngle * overflow;
            Y -= sinAngle * overflow;

            other.X -= cosAngleOther * overflow;
            other.Y -= sinAngleOther * overflow;
        }
    }
}
