using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Controllers;
using Udemy3.Abstracts.Movements;
using Udemy3.Controller;
using UnityEngine;

namespace Udemy3.Movements
{
    public class Mover : IMover
    {
        IEntityController _controller;

        float _moveSpeed;
        public Mover(IEntityController controller, float moveSpeed)
        {
            _controller = controller;
            _moveSpeed = moveSpeed;
        }


        public void Tick(float horizontal)
        {
            if (horizontal == 0f) return;
            _controller.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
        }

    }
}
