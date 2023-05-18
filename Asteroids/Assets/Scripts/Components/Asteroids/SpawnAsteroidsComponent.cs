using Pool;

namespace Components.Asteroids
{
    internal struct SpawnAsteroidsComponent
    {
        public PoolObject PoolAsteroids;
        public int MAXAmountAsteroidsSpawn;
        public float AddValueIncreaseGravity;
        public float MINSpawnAmountAsteroids;
        public float MINScale;
        public float MAXScale;
    }
}