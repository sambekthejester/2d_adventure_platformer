using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Udemy3.Animations
{
    public class AnimationImpactWatcher : MonoBehaviour
    {
        public event System.Action OnImpact;

        public void Impact()
        {
            OnImpact?.Invoke();
        }


    }
}
