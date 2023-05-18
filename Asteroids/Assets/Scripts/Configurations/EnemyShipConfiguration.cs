using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "newShipEnemyConfiguration", menuName = "Data/ShipEnemy")]
    public class EnemyShipConfiguration : ScriptableObject
    {
        public GameObject[] enemiesPrefabs;
        public GameObject[] explosionPrefabs;

        public ProjectileConfiguration[] projectileConfigurations;

        [Header("Healths")] public float minHealth = 5;
        public float maxHealth = 100;

        [Header("Spawn")] public float minSpawnFrequency = 1;
        public float maxSpawnFrequency = 5;
        public int minAmountSpawnShipEnemy = 1;
        public int maxAmountSpawnShipEnemy = 4;
        public float spawnOffsetY = 0.5f;
        public float recalculationEntitiesTime = 1.0f;

        [Header("Speeds")] public float minSpeed = -0.5f;
        public float maxSpeed = 1.5f;
        public float ProjectileIncreaseSpeedAddValue => Time.deltaTime;
        public float projectileIncreaseSpeedMultiplier = 1.0f;

        [Header("SwapDirection")] public float swapDirectionDistance = 0.3f;
        public float timeSwapBlock = 1.0f;
    }
}