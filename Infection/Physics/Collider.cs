namespace Infection
{
    abstract class Collider
    {
        protected Rigidbody rb;

        public Collider(Rigidbody rb)
        {
            this.rb = rb;
        }

        public abstract bool Collides(Collider other);

        public abstract bool Collides(CircleCollider other);
    }
}
