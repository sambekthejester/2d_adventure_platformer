using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Combats;
using Udemy3.Controller;
using UnityEngine;

namespace Udemy3.Uis
{
    public class ShopGameObject : MonoBehaviour
    {

        [SerializeField] QuestionPanel questionPanel;
        [SerializeField] GameObject shop;

        IHealth _playerHealth;


        private void OnEnable()
        {
            _playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        }

        private void OnDisable()
        {
            _playerHealth = null;
        }

        public void BuyLifeClick(int lifeCount)
        {

            questionPanel.gameObject.SetActive(true);
            questionPanel.SetLifeCount(lifeCount, _playerHealth);
        }

        public void IsActiveShop(bool isActive)
        {
            shop.SetActive(isActive);
        }


    }
}
