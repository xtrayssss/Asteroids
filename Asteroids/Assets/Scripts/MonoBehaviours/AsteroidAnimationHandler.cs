using Components.Destroy;
using Components.Move;
using Leopotam.Ecs;
using MonoBehaviours.Views;
using UnityEngine;

namespace MonoBehaviours
{
    internal class AsteroidAnimationHandler : MonoBehaviour
    {
        private IEntityView _asteroidView;

        private void Start() =>
            _asteroidView = GetComponentInParent<IEntityView>();

        public void SetDestroyEvent()
        {
            _asteroidView.Entity.Get<ModelComponent>().Transform.gameObject.SetActive(false);
            _asteroidView.Entity.Del<PreDeathProgress>();
        }
    }
}