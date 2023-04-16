using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Udemy3.Managers;
using Udemy3.Abstracts.Combats;
using Udemy3.Controller;

namespace Udemy3.Uis
{
    public class QuestionPanel : MonoBehaviour
    {
        [SerializeField] ResultPanel resultPanel;
        TextMeshProUGUI _messageText;
        int _lifeCount;
        int _price;
        IHealth _playerHealth;

        private void Awake()
        {

            _messageText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        }
        private void OnDisable()
        {
            _lifeCount = 0;
            _price = 0;
            _playerHealth = null;
        }

        public void SetLifeCount(int lifeCount, IHealth playerHealth)
        {

            _lifeCount = lifeCount;
            if (_lifeCount == 1) _price = 10;
            else if (_lifeCount == 3) _price = 25;
            else if (_lifeCount == 5) _price = 40;

            _playerHealth = playerHealth;
            _messageText.text = $"DO YOU WANT TO BUY {_lifeCount} LIFE?";
        }

        public void YesClick()
        {
            resultPanel.gameObject.SetActive(true);

            if (_price <= GameManager.Instance.Score)
            {
                resultPanel.SetResultMassege($"YOU HAVE BOUGHT {_lifeCount} life");
                GameManager.Instance.DecreaseScore(_price);
                // IHealth playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
                _playerHealth.Heal(_lifeCount);
            }
            else
            {
                resultPanel.SetResultMassege($"YOU DO NOT HAVE ENOUGH DIAMOND");
            }
            this.gameObject.SetActive(false);
        }

    }


}