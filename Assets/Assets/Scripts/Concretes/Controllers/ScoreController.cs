using System.Collections;
using System.Collections.Generic;
using Udemy3.Managers;
using UnityEngine;

namespace Udemy3.Controller
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int scorePoint = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                GameManager.Instance.IncreaseScore(scorePoint);
                Destroy(this.gameObject);
            }
        }




    }

}