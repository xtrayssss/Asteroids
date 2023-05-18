using Leopotam.Ecs;
using UnityEngine;

namespace MonoBehaviours.Views
{
    public class AsteroidView : MonoBehaviour, IEntityView
    {
        public EcsEntity Entity { get; set; }

        public void Init(EcsEntity entity) =>
            Entity = entity;
    }
}