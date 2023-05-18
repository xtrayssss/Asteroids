using Components.Score;
using Infrastructure;
using Infrastructure.Progress;
using Leopotam.Ecs;
using UnityEngine;

namespace MonoBehaviours
{
    internal class ApplicationHandler : MonoBehaviour
    {
        private Bootstrapper _bootstrapper;
        private EcsWorld _world;

        private void Start() =>
            _bootstrapper = FindObjectOfType<Bootstrapper>();

        public void Init(EcsWorld world) =>
            _world = world;

        private void OnApplicationQuit()
        {
            ref var scoreComponent = ref _world
                .GetFilter(typeof(EcsFilter<ScoreComponent>)).GetEntity(0).Get<ScoreComponent>();

            PlayerProgress playerProgress =
                (PlayerProgress) _bootstrapper.Game.LoadService.Load<PlayerProgress>(Constants.Constants.PlayerJsonFilePath);

            if (scoreComponent.Value > playerProgress.Score)
            {
                _bootstrapper.Game.PlayerProgress.Score = scoreComponent.Value;
                _bootstrapper.Game.SaveService.Save(_bootstrapper.Game.PlayerProgress, Constants.Constants.PlayerJsonFilePath);
            }
        }
    }
}