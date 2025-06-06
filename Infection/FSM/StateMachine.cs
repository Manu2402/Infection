using System.Collections.Generic;

namespace Infection
{
    enum States { Infected, AtRisk, NotInfected }

    class StateMachine
    {
        public Dictionary<States, State> states;
        public State CurrentState;

        public StateMachine()
        {
            states = new Dictionary<States, State>();
            CurrentState = null;
        }

        public void AddState(States stateName, State state)
        {
            states[stateName] = state;
            states[stateName].fsm = this;
        }

        public void GoTo(States state)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }

            CurrentState = states[state];
            CurrentState.OnEnter();
        }

        public void Update()
        {
            CurrentState.Update();
        }
    }
    
}
