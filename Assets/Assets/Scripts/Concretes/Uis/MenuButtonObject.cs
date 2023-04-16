using System.Collections;
using System.Collections.Generic;
using Udemy3.Enums;
using Udemy3.Managers;
using UnityEngine;

namespace Udemy3.Uis
{
    public class MenuButtonObject : MonoBehaviour
    {

        public void StartGame()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);

        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }



    }
}
