using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Inputs;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Udemy3.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => CrossPlatformInputManager.GetAxis("Horizontal");

        public bool JumpButtonDown => CrossPlatformInputManager.GetButtonDown("Jump");

        public bool AttackButtonDown => CrossPlatformInputManager.GetButtonDown("Fire1");
    }

}

