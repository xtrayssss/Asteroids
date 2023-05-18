using Components.Score;
using Leopotam.Ecs;

namespace Systems.Score
{
    internal class AddScoreSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ScoreComponent, AddScoreEvent> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var scoreComponent = ref _filter.Get1(indexEntity);

                scoreComponent.Value += scoreComponent.AddValue;

                scoreComponent.Text.SetText(scoreComponent.Message + scoreComponent.Value);
            }
        }
    }
}