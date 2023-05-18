using Components.Collider;
using Components.Destroy;
using Components.Score;
using Configurations;
using Leopotam.Ecs;
using TMPro;

namespace HandlerInterfaces
{
    internal class AsteroidDeathHandler : IDeathHandler
    {
        private readonly ScoreConfiguration _scoreConfiguration;
        private readonly EcsWorld _world;
        private readonly TMP_Text _scoreText;
        private readonly EcsEntity _scoreEntity;

        public AsteroidDeathHandler(EcsWorld world) =>
            _scoreEntity = world.GetFilter(typeof(EcsFilter<ScoreComponent>)).GetEntity(0);

        public void DeathHandle(EcsEntity entity)
        {
            entity.Get<DisableColliderEvent>();
            entity.Get<PreDeathProgress>();

            _scoreEntity.Get<AddScoreEvent>();
        }
    }
}