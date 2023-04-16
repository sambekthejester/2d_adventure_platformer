using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Animations;
using Udemy3.Abstracts.Combats;
using Udemy3.Abstracts.Controllers;
using Udemy3.Abstracts.Inputs;
using Udemy3.Abstracts.Movements;
using Udemy3.Animations;
using Udemy3.Inputs;
using Udemy3.Managers;
using Udemy3.Movements;
using Udemy3.Uis;
using UnityEngine;

namespace Udemy3.Controller
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] float moveSpeed = 2f;
        IPlayerInput _input;
        IMover _mover;
        IMyAnimation _animation;
        IFlip _flip;
        IJump _jump;
        IOnGround _onGround;
        IHealth _health;

        float _horizontal;



        private void Awake()
        {
            _input = new MobileInput();
            _mover = new Mover(this, moveSpeed);
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new Flip(this);
            _onGround = GetComponent<IOnGround>();
            _jump = new Jump(GetComponent<Rigidbody2D>(), _onGround);
            _health = GetComponent<IHealth>();

        }

        private void OnEnable()
        {
            _health.OnDead += _animation.DeadAnimation;
            _health.OnDead += GameManager.Instance.ResetScore;
        }
        private void Start()
        {
            GameOverObject gameOverObject = FindObjectOfType<GameOverObject>();
            gameOverObject.SetPlayerHealth(_health);
        }

        private void Update()
        {
            if (_health.IsDead) return;
            _horizontal = _input.Horizontal;

            if (_input.AttackButtonDown && _horizontal == 0f)
            {
                _animation.AttackAnimation();
                return;

            }

            if (_input.JumpButtonDown)
            {
                _jump.IsJump = true;
            }

            _animation.JumpAnimation(!_onGround.IsGround);
            _animation.MoveAnimation(_horizontal);

        }

        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);


            _jump.TickWithFixedUpdate();



        }

    }
}
