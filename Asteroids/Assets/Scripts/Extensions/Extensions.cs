using Leopotam.Ecs;

namespace Extensions
{
    public static class Extensions
    {
        public static void CreateNewEntity<T>(this EcsWorld world, in T message) where T : struct =>
            world.NewEntity().Get<T>() = message;
    }
}