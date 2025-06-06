using OpenTK;

namespace Infection
{
    class AtRiskState : State
    {
        private float riskTimer;
        private float maxTimer = 0.8f;

        public AtRiskState(Ball owner) : base(owner) { }

        public override void OnEnter()
        {
            Owner.SetColor(new Vector4(1f, 1f, 0f, 0f));
            Owner.AtRisk = true;
            riskTimer = maxTimer;
        }

        public override void OnExit()
        {
            Owner.AtRisk = false;
        }

        public override void Update()
        {
            riskTimer -= Program.DeltaTime;

            if (riskTimer <= 0f)
            {
                for (int i = 0; i < balls.Length; i++)
                {
                    if (Owner != balls[i])
                    {
                        Vector2 dist = balls[i].Position - Owner.Position;
                        if (dist.LengthSquared < Owner.VisionRadius * Owner.VisionRadius && balls[i].IsInfected)
                        {
                            fsm.GoTo(States.Infected);
                            return;
                        }
                    }
                }
                
                fsm.GoTo(States.NotInfected);
                riskTimer = maxTimer;
            }
        }
        
    }
}
