using UnityEngine;

namespace MonoBehaviours
{
    public class ScreenPoints : MonoBehaviour
    {
        private Camera _camera;

        public Vector3 ScreenLowestPoint => _camera.ScreenToWorldPoint(Vector2.zero);
        public Vector3 CenterScreen => _camera.ScreenToWorldPoint(new Vector2(Screen.width / 2.0f, 0));
        public Vector3 LeftXScreen => _camera.ScreenToWorldPoint(new Vector2(-1, 0));
        public Vector3 RightXScreen => _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f));
        public Vector3 ScreenHighestPoint => _camera.ScreenToWorldPoint(new Vector3(0, Screen.height));

        private void Awake() => 
            _camera = Camera.main;
    }
}