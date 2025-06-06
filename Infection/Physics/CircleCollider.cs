using System;
using OpenTK;

namespace Infection
{
    class CircleCollider : Collider
    {
        private float radius;

        public float Radius { get { return radius; } }

        public CircleCollider(Rigidbody rb, float radius) : base(rb)
        {
            this.radius = radius;
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider other)
        {
            Vector2 dist = other.rb.ball.Position - rb.ball.Position;
            return dist.LengthSquared < Math.Pow(other.radius + radius, 2);
        }
    }
}
