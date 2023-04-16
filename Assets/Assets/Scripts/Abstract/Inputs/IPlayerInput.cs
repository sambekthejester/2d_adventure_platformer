using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Udemy3.Abstracts.Inputs
{
    public interface IPlayerInput 
    {
        float Horizontal { get; }

        bool JumpButtonDown { get; }
        bool AttackButtonDown { get; }
    }
}