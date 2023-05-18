using Leopotam.Ecs;

namespace MonoBehaviours.Views
{
    public interface IEntityView
    {
        public EcsEntity Entity { get; set; }
    }
}