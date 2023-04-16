using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Udemy3.Managers;


namespace Udemy3.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _scoreText.text = GameManager.Instance.Score.ToString();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }


        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int score)
        {
            _scoreText.text = score.ToString();
        }




    }
}
