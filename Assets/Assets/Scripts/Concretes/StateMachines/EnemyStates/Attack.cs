using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Animations;
using Udemy3.Abstracts.Combats;
using Udemy3.Abstracts.Controllers;
using Udemy3.Abstracts.Movements;
using Udemy3.Abstracts.StateMachines;
using UnityEngine;



namespace Udemy3.Statemachines.EnemyStates
{
    public class Attack : IState
    {
        IMyAnimation _animation;
        IAttacker _attacker;
        IHealth _playerHealth;
        System.Func<bool> _isPlayerRightSide;
        IFlip _flip;

        float _currentAttackTime;
        float _maxAttackTime;
        public Attack(IHealth playerHealth, IFlip flip, IMyAnimation animation, IAttacker attacker, float maxAttackTime,
            System.Func<bool> isPlayerRightSide)
        {
            _animation = animation;
            _attacker = attacker;
            _playerHealth = playerHealth;
            _maxAttackTime = maxAttackTime;
            _isPlayerRightSide = isPlayerRightSide;
            _flip = flip;


        }
        public void OnEnter()
        {
            _currentAttackTime = 0.2f;
        }

        public void OnExit()
        {
            Debug.Log("attack on exit");
        }

        public void Tick()
        {
            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _maxAttackTime)
            {
                _flip.FlipCharacter(_isPlayerRightSide.Invoke() ? 1f : -1f);
                _animation.AttackAnimation();
                _attacker.Attack(_playerHealth);
                _currentAttackTime = 0f;

            }

            Debug.Log("attack tick");

        }
    }


}
