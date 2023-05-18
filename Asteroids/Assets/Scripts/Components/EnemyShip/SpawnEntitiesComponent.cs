using System.Collections.Generic;
using Leopotam.Ecs;

namespace Components.EnemyShip
{
    internal struct SpawnEntitiesComponent
    {
        public List<EcsEntity> EntitiesList;

        public void Init(float amount) =>
            EntitiesList = new List<EcsEntity>();
    }
}