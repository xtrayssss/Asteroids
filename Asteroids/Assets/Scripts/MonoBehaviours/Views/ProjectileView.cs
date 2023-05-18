using Leopotam.Ecs;
using UnityEngine;

namespace MonoBehaviours.Views
{
    public class ProjectileView : MonoBehaviour, IEntityView
    {
        public EcsEntity Entity { get; set; }

        public void Init(EcsEntity entity) => 
            Entity = entity;
    }
}