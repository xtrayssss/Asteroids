using Infrastructure.Progress;
using Infrastructure.Services;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class Game
    {
        public readonly ISave SaveService;
        public readonly ILoad LoadService;
        public readonly PlayerProgress PlayerProgress;

        private const int SecondSceneBuildIndex = 1;

        public Game()
        {
            SaveService = new SaveService();
            LoadService = new LoadService();
            PlayerProgress = new PlayerProgress();

            SceneManager.LoadScene(SecondSceneBuildIndex);
        }
    }
}