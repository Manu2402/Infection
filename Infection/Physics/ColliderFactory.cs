namespace Infection
{
    static class ColliderFactory
    {
        public static CircleCollider CreateCircleFor(Ball ball)
        {
            return new CircleCollider(ball.Rigidbody, ball.HalfWidth);
        }
    }
}
