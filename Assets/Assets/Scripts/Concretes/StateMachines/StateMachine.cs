
using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.StateMachines;
using UnityEngine;

namespace Udemy3.Statemachines
{
    public class StateMachine
    {
        List<StateTranstion> _stateTranstions = new List<StateTranstion>();
        List<StateTranstion> _anyStatetransition = new List<StateTranstion>();

        IState _currentState;
        public void SetState(IState state)
        {
            if (state == _currentState) return;
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }

        public void Tick()
        {
            StateTranstion stateTranstion = CheckForTranstion();

            if (stateTranstion != null)
            {
                SetState(stateTranstion.To);
            }

            _currentState.Tick();
        }

        private StateTranstion CheckForTranstion()
        {
            foreach (StateTranstion anyStatetransition in _anyStatetransition)
            {
                if (anyStatetransition.Condition.Invoke()) return anyStatetransition;

            }



            foreach (StateTranstion stateTranstion in _stateTranstions)
            {
                if (stateTranstion.Condition() && stateTranstion.From == _currentState)
                {

                    return stateTranstion;

                }

            }

            return null;
        }

        public void AddTransition(IState from, IState to, System.Func<bool> condition)
        {
            StateTranstion stateTranstion = new StateTranstion(from, to, condition);
            _stateTranstions.Add(stateTranstion);
        }

        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTranstion anyStatetransition = new StateTranstion(null, to, condition);
            _anyStatetransition.Add(anyStatetransition);

        }

    }

}

