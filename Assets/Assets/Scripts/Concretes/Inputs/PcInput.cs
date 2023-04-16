using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Inputs;
using UnityEngine;

namespace Udemy3.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public bool JumpButtonDown => Input.GetButtonDown("Jump");

        public bool AttackButtonDown => Input.GetButtonDown("Fire1");
    }

}