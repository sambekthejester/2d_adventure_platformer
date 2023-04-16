using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Controllers;
using Udemy3.Abstracts.Movements;
using Udemy3.Controller;
using UnityEngine;

namespace Udemy3.Movements
{
    public class Flip : IFlip
    {
        IEntityController _entity;
        PlayerController _player;

        public Flip(IEntityController entity)
        {
            _entity = entity;
        }

        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if (mathValue != _entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue, 1f);
            }


        }

    }

}