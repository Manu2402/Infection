using OpenTK;

namespace Infection
{
    class NotInfectedState : State
    {
        public NotInfectedState(Ball owner) : base(owner) { }

        public override void OnEnter()
        {
            Owner.SetColor(new Vector4(0f, 1f, 0f, 0f));
            Owner.AtRisk = false;
            Owner.IsInfected = false;
        }
        
    }
}
