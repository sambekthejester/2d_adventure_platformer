
using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Animations;
using Udemy3.Abstracts.Combats;
using Udemy3.Abstracts.Controllers;
using Udemy3.Abstracts.Movements;
using Udemy3.Animations;
using Udemy3.Movements;
using Udemy3.Statemachines;
using Udemy3.Statemachines.EnemyStates;
using UnityEngine;

namespace Udemy3.Controller
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] float moveSpeed = 0.8f;
        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] Transform[] patrols;
        [SerializeField] float maxAttackTime = 1.15f;

        StateMachine _stateMachine;
        IEntityController _player;

        [SerializeField] ScoreController scorePrefab;


        private void Awake()
        {

            _stateMachine = new StateMachine();

            _player = FindObjectOfType<PlayerController>();

        }




        private IEnumerator Start()
        {
            IMover mover = new Mover(this, moveSpeed);
            IMyAnimation animation = new CharacterAnimation(GetComponent<Animator>());
            IFlip flip = new Flip(this);
            IHealth health = GetComponent<IHealth>();
            IAttacker attacker = GetComponent<IAttacker>();
            IStopEdge stopEdge = GetComponent<IStopEdge>();

            Idle idle = new Idle(mover, animation);
            Walk walk = new Walk(this, mover, animation, flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(mover, flip, animation, stopEdge, IsPlayerRightSide);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(), flip, animation, attacker, maxAttackTime, IsPlayerRightSide);
            TakeHit takeHit = new TakeHit(health, animation);
            Dead dead = new Dead(this, animation, () => Instantiate(scorePrefab, transform.position, Quaternion.identity));


            _stateMachine.AddTransition(idle, walk, () => idle.IsIdle == false);
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromMeToPlayer() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromMeToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromMeToPlayer() > attackDistance);

            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);
            _stateMachine.AddAnyState(dead, () => health.IsDead);

            _stateMachine.AddTransition(takeHit, chasePlayer, () => takeHit.IsTakeHit == false);

            _stateMachine.SetState(idle);

            yield return null;
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
        }

        private float DistanceFromMeToPlayer()
        {
            return Vector2.Distance(transform.position, _player.transform.position);
        }

        private bool IsPlayerRightSide()
        {
            Vector3 result = _player.transform.position - this.transform.position;

            if (result.x > 0f)
            {
                return true;

            }
            else
            {

                return false;

            }

        }
    }

}

