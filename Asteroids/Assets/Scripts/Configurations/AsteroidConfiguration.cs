using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "newAsteroidConfiguration", menuName = "Data/Asteroid")]
    public class AsteroidConfiguration : ScriptableObject
    {
        public GameObject asteroidPrefab;

        [Header("Attack")] public float damage = 10;

        [Header("Spawn")] public float spawnAsteroidsFrequency = 2.0f;
        public float leftSpawnOffset = 0.2f;
        public float rightSpawnOffset = -0.2f;
        public int maxAmountSpawnAsteroids = 3;
        public float minAmountSpawnAsteroids = 1;
        public float minScale = 0.5f;
        public float maxScale = 1.1f;

        [Header("Gravitation")] public float addValueIncreaseGravity = 0.1f;

        [Header("Health")] public float minHealth = 4.0f;
        public float maxHealth = 10.0f;
    }
}