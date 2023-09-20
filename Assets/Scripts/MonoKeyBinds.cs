using Game.Utility;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class MonoKeyBinds : MonoBehaviour
    {
        SceneSwitching sceneSwitching;

        private void Awake()
        {
            sceneSwitching = FindObjectOfType<SceneSwitching>();
        }

        private void Update()
        {
            Util.RunIfKeyDown(KeyCode.R, sceneSwitching.ReloadScene);
            Util.RunIfKeyDown(KeyCode.N, sceneSwitching.NextScene);
        }
    }
}