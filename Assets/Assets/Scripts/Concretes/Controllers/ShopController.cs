using System.Collections;
using System.Collections.Generic;
using Udemy3.Uis;
using UnityEngine;

namespace Udemy3.Controller
{
    public class ShopController : MonoBehaviour
    {
        ShopGameObject _shopGameObject;

        private void Start()
        {
            _shopGameObject = FindObjectOfType<ShopGameObject>();

           
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                _shopGameObject.IsActiveShop(true);
                
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                _shopGameObject.IsActiveShop(false);
                
            }
        }



    }

}