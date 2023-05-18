using Leopotam.Ecs;
using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player")]
    public class PlayerConfiguration : ScriptableObject
    {
        public GameObject playerPrefab;
        public EcsEntity CurrentEntity;

        public float speed = 2.0f;
        public Vector2 offsetSpawn = new Vector2(0, 0.3f);

        [Header("Projectile")] public ProjectileConfiguration projectileConfiguration;
        public GameObject attackPointPrefab;

        [Header("Damage")] public float bodyDamage = 5.0f;

        [Header("Health")] public float health = 20.0f;
        public float smoothFillHpBar = 10.0f;

        [Header("Death")] public GameObject explosionPrefab;
    }
}