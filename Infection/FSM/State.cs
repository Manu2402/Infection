namespace Infection
{
    abstract class State
    {
        protected Ball[] balls;
        public StateMachine fsm;
        public Ball Owner;

        public State(Ball owner)
        {
            Owner = owner;
            balls = BallMgr.Balls;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void Update() { }
    }
}
