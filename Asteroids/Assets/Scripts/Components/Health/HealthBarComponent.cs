using UnityEngine.UI;

namespace Components.Health
{
    internal struct HealthBarComponent
    {
        public Image FillImage;
        public float TargetValue;
        public float Velocity;
        public float SmoothTime;
    }
}