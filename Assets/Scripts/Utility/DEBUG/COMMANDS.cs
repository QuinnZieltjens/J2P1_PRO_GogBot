using System;
using UnityEngine;

namespace Game.Utility.DEBUG
{
    public class COMMANDS : MonoBehaviour
    {
        SceneSwitching sceneSwitching;

        private void Awake()
        {
            sceneSwitching = FindObjectOfType<SceneSwitching>();
        }

        private void Update()
        {
            RunIfKeyDown(KeyCode.R, sceneSwitching.ReloadScene);
            RunIfKeyDown(KeyCode.N, sceneSwitching.NextScene);
        }

        private void RunIfKeyDown(KeyCode _key, Action _action)
        {
            if (Input.GetKeyDown(_key))
                _action.Invoke();
        }
    }
}