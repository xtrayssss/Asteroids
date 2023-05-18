using Components.Score;
using Configurations;
using Leopotam.Ecs;
using TMPro;

namespace Infrastructure.Factories
{
    internal class ScoreFactory : IFactory
    {
        private readonly ScoreConfiguration _scoreConfiguration;
        private readonly TMP_Text _scoreText;

        public ScoreFactory(ScoreConfiguration scoreConfiguration, TMP_Text scoreText)
        {
            _scoreConfiguration = scoreConfiguration;
            _scoreText = scoreText;
        }

        public void CreateEntity(EcsWorld world)
        {
            EcsEntity entity = world.NewEntity();

            ref var scoreComponent = ref entity.Get<ScoreComponent>();
            scoreComponent.Text = _scoreText;
            scoreComponent.AddValue = _scoreConfiguration.addValue;
            scoreComponent.Message = _scoreConfiguration.message;
        }
    }
}