using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "newGameConfiguration", menuName = "Data/Game")]
    public class GameConfigurations : ScriptableObject
    {
        public PlayerConfiguration playerConfiguration;
        public GameObject poolContainer;
        public EnemyShipConfiguration enemyShipConfiguration;
        public AsteroidConfiguration asteroidConfiguration;
        public ScoreConfiguration scoreConfiguration;
    }
}