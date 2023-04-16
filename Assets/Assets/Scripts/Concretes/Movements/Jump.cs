using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Movements;
using UnityEngine;

namespace Udemy3.Movements
{
    public class Jump : IJump
    {

        float jumpForce = 180f;

        Rigidbody2D _rigidbody2D;
        IOnGround _onGround;
        public bool IsJump { get; set; }

        public Jump(Rigidbody2D rigidbody, IOnGround onGround)
        {


            _rigidbody2D = rigidbody;
            _onGround = onGround;

        }


        public void TickWithFixedUpdate()
        {
            if (IsJump && _onGround.IsGround)
            {

                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Vector2.up * jumpForce);
                _rigidbody2D.velocity = Vector2.zero;

            }

            IsJump = false;
        }


    }


}