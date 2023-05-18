using System.Globalization;
using Infrastructure;
using Infrastructure.Progress;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours
{
    public class StartMenuHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private string message;

        private Bootstrapper _bootstrapper;

        private void Awake() =>
            _bootstrapper = FindObjectOfType<Bootstrapper>();

        private void Start()
        {
            PlayerProgress playerProgress =
                (PlayerProgress) _bootstrapper.Game.LoadService.Load<PlayerProgress>(Constants.Constants.PlayerJsonFilePath);

            if (playerProgress != null)
            {
                scoreText.text = message + playerProgress.Score;
            }
        }

        public void PlayButtonOnClick() =>
            SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}