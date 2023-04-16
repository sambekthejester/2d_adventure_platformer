using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Animations;
using Udemy3.Abstracts.Controllers;
using Udemy3.Abstracts.Movements;
using Udemy3.Abstracts.StateMachines;
using UnityEngine;



namespace Udemy3.Statemachines.EnemyStates
{
    public class ChasePlayer : IState
    {
        System.Func<bool> _isPlayerRightSide;
        IMover _mover;
        IFlip _flip;
        IMyAnimation _animation;
        IStopEdge _stopEdge;

        public ChasePlayer(IMover mover, IFlip flip, IMyAnimation animation, IStopEdge stopEdge, System.Func<bool> isPlayerRightSide)
        {
            _isPlayerRightSide = isPlayerRightSide;
            _mover = mover;
            _flip = flip;
            _animation = animation;
            _stopEdge = stopEdge;

        }
        public void OnEnter()
        {
            _animation.MoveAnimation(1f);

        }

        public void OnExit()
        {

            _animation.MoveAnimation(0f);

        }

        public void Tick()
        {
            if (_stopEdge.ReachEdge())
            {
                if (_stopEdge.IsRightDirection && !_isPlayerRightSide.Invoke())
                {
                    ChaseAgain(-0.8f, -1f, 1f);
                    return;
                }
                else if (!_stopEdge.IsRightDirection && _isPlayerRightSide.Invoke())
                {
                    ChaseAgain(0.8f, 1f, 1f);
                    return;
                }

                _animation.MoveAnimation(0f);
                return;
            }

            if (_isPlayerRightSide.Invoke())
            {
                _mover.Tick(0.8f);
                _flip.FlipCharacter(1f);
            }
            else
            {
                _mover.Tick(-0.8f);
                _flip.FlipCharacter(-1f);
            }
            Debug.Log("chase");
        }
        private void ChaseAgain(float moveDirection, float flipDirection, float animationSpeed)
        {
            _mover.Tick(moveDirection);
            _flip.FlipCharacter(flipDirection);
            _animation.MoveAnimation(animationSpeed);
        }



    }

}