using OpenTK;

namespace Infection
{
    class InfectedState : State
    {
        public InfectedState(Ball owner) : base(owner) { }

        public override void OnEnter()
        {
            Owner.SetColor(new Vector4(1f, 0f, 0f, 0f));
            Owner.IsInfected = true;
            Owner.AtRisk = false;
        }

        public override void Update()
        {
            for (int i = 0; i < balls.Length; i++)
            {
                Vector2 dist = balls[i].Position - Owner.Position;
                if(dist.LengthSquared < Owner.VisionRadius * Owner.VisionRadius)
                {
                    if (!balls[i].IsInfected && !balls[i].AtRisk)
                    {
                        balls[i].Fsm.GoTo(States.AtRisk);
                    }
                }
            }
        }
        
    }
}
