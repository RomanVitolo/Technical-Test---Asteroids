using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalSettings
{
    public class LoadScene : MonoBehaviour {
    
        public void LoadMenuScene() => SceneManager.LoadScene(0); //This can be change at the time the menu scene is implemented.
    }
}
