using Leopotam.Ecs;

namespace Infrastructure.Factories
{
    internal interface IFactory
    {
        public void CreateEntity(EcsWorld world);
    }
}