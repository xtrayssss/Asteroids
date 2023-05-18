using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    internal class GameOverMenuHandler : MonoBehaviour
    {
        public void ClickRestartButton() => 
            SceneManager.LoadScene(2);
    }
}