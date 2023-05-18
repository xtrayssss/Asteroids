using Components.Bounds;
using Components.Destroy;
using Components.Move;
using Leopotam.Ecs;

namespace HandlerInterfaces
{
    internal class ProjectileBeyondBorders : ICanBeyondBorders
    {
        public void HandlerBeyondBorders(EcsEntity entity)
        {
            entity.Get<ModelComponent>().Transform.gameObject.SetActive(false);
            entity.Get<DestroyEvent>();
        }
    }
}