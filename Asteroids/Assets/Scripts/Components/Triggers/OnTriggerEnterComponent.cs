using Leopotam.Ecs;
using UnityEngine;

namespace Components.Triggers
{
    internal struct OnTriggerEnterComponent
    {
        public GameObject ThisGO;
        public Collider2D Other;
        public EcsEntity ThisEntity;
    }
}