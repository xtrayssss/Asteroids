using Components.Bounds;
using Components.Move;
using Leopotam.Ecs;

namespace HandlerInterfaces
{
    internal class AsteroidsBeyondBorders : ICanBeyondBorders
    {
        public void HandlerBeyondBorders(EcsEntity entity)
        {
            entity.Get<ModelComponent>().Transform.gameObject.SetActive(false);
        }
    }
}