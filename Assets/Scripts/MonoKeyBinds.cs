using Game.Utility;
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

            if (Input.GetKey(KeyCode.LeftShift))
                Util.RunIfKeyDown(KeyCode.N, sceneSwitching.NextScene);
        }
    }
}