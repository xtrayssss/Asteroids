using UnityEngine;

namespace Configurations
{
    [CreateAssetMenu(fileName = "newScoreConfiguration", menuName = "Data/Score")]
    public class ScoreConfiguration : ScriptableObject
    {
        public float addValue;
        public string message;
    }
}