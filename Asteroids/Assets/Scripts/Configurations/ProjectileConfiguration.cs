using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "newProjectileConfiguration", menuName = "Data/Projectile")]
    public class ProjectileConfiguration : ScriptableObject
    {
        public GameObject prefabProjectile;
        public float speed = 5.5f;
        public float frequency = 0.2f;
        public float damage = 5.0f;
    }
}