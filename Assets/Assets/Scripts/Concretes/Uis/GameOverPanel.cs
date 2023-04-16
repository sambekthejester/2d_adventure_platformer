using System.Collections;
using System.Collections.Generic;
using Udemy3.Enums;
using Udemy3.Managers;
using UnityEngine;

namespace Udemy3.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }
        public void NoButton()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Menu);
        }
    }

}