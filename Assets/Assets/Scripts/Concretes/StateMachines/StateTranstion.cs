using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.StateMachines;
using UnityEngine;

namespace Udemy3.Statemachines
{
    public class StateTranstion
    {
        IState _from;
        IState _to;
        System.Func<bool> _condition;

        public IState From => _from;
        public IState To => _to;
        public System.Func<bool> Condition => _condition;
        public StateTranstion(IState from, IState to, System.Func<bool> condition)
        {
            _from = from;
            _to = to;
            _condition = condition;
        }



    }
}