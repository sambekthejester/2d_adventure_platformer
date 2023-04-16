using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Combats;
using UnityEngine;

namespace Udemy3.Controller
{
    public class DeadOnTouchController : MonoBehaviour
    {
        IAttacker _attacker;

        private void Awake()
        {
            _attacker = GetComponent<IAttacker>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            IHealth health = collision.GetComponent<IHealth>();
            if (health != null)
            {
                health.TakeHit(_attacker);
            }



        }



    }


}