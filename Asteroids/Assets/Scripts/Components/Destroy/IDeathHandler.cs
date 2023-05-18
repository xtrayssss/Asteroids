using Leopotam.Ecs;

namespace Components.Destroy
{
    internal interface IDeathHandler
    {
        public void DeathHandle(EcsEntity entity);
    }
}