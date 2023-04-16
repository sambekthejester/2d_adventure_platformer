
using System.Collections;
using System.Collections.Generic;
using Udemy3.Enums;
using Udemy3.Managers;
using UnityEngine;

namespace Udemy3.Controller
{
    public class CanvasSceneController : MonoBehaviour
    {
        [SerializeField] SceneTypeEnum sceneType;
        [SerializeField] GameObject canvasObject;

        private void Start()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }



        private void OnDestroy()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(SceneTypeEnum sceneType)
        {
            if (sceneType == this.sceneType)
            {
                canvasObject.SetActive(true);
            }
            else
            {
                canvasObject.SetActive(false);
            }
        }

    }

}