using UnityEngine;

namespace MonoBehaviours
{
    internal class ExplosionAnimationHandler : MonoBehaviour
    {
        public void DisableExplosion() => 
            transform.parent.gameObject.SetActive(false);
    }
}