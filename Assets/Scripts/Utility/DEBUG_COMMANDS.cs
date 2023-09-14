using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Utility
{
    public class DEBUG_COMMANDS : MonoBehaviour
    {
        private void Update()
        {
            //reloads the current scene
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}