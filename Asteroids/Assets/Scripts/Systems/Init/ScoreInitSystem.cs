using Configurations;
using HandlerInterfaces;
using Infrastructure.Factories;
using Leopotam.Ecs;
using TMPro;

namespace Systems.Init
{
    internal class ScoreInitSystem : IEcsInitSystem
    {
        private readonly ScoreConfiguration _scoreConfiguration;
        private readonly TMP_Text _scoreText;
        private readonly EcsWorld _world;

        private IFactory _factory;

        public ScoreInitSystem(ScoreConfiguration scoreConfiguration, TMP_Text scoreText)
        {
            _scoreConfiguration = scoreConfiguration;
            _scoreText = scoreText;
        }


        public void Init()
        {
            _factory = new ScoreFactory(_scoreConfiguration, _scoreText);
            _factory.CreateEntity(_world);
        }
    }
}