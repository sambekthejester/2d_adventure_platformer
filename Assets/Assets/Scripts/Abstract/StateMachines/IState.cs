using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Udemy3.Abstracts.StateMachines
{
    public interface IState
    {
        void Tick();
        void OnEnter();
        void OnExit();


    }

}

