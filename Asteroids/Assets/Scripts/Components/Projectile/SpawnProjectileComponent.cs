using Pool;
using UnityEngine;

namespace Components.Projectile
{
    internal struct SpawnProjectileComponent
    {
        public PoolObject ProjectilesPool;
        public float Speed;
        public float Frequency;
        public Transform SpawnPoint;
        public GameObject PrefabProjectile;
        public Vector2 MovementDirection;
        public float Damage;
        public float ProjectileIncreaseSpeedAddValue;
        public float ProjectileIncreaseSpeedMultiplier;
    }
}