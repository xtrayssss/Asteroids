using Leopotam.Ecs;

namespace Components.Bounds
{
    internal interface ICanBeyondBorders
    {
        public void HandlerBeyondBorders(EcsEntity entity);
    }
}