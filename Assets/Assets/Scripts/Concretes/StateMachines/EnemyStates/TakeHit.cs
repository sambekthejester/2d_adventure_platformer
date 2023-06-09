using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Animations;
using Udemy3.Abstracts.Combats;
using Udemy3.Abstracts.StateMachines;
using UnityEngine;



namespace Udemy3.Statemachines.EnemyStates
{
    public class TakeHit : IState
    {
        IMyAnimation _animation;
        float _maxDelayTime = 0.1f;
        float _currentDelayTime = 0f;

        public bool IsTakeHit { get; private set; }

        public TakeHit(IHealth health, IMyAnimation animation)
        {
            _animation = animation;
            health.OnHealthChanged += (currentHealth, maxHealth) => OnEnter();
        }
        public void OnEnter()
        {

            IsTakeHit = true;
        }

        public void OnExit()
        {
            _currentDelayTime = 0f;
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;

            if (_currentDelayTime > _maxDelayTime && IsTakeHit)
            {
                _animation.TakeHitAnimation();
                IsTakeHit = false;

            }

            Debug.Log("takehit tick");
        }

    }

}