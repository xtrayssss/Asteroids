using UnityEngine;

namespace MonoBehaviours
{
    public class BackGroundScroller : MonoBehaviour
    {
        [SerializeField] private float speedScroll;
        [SerializeField] private GameObject backGround;
        private ScreenPoints _screenPoints;

        private Vector3 _startPoint;

        private void Start()
        {
            _screenPoints = FindObjectOfType<ScreenPoints>();
            _startPoint = transform.position;
            
        }

        private void Update()
        {
            if (CheckReachedPoint())
            {
                backGround.transform.position = _startPoint;
            }

            transform.position -= new Vector3(0, Time.deltaTime * speedScroll);
        }

        private bool CheckReachedPoint() =>
            backGround.transform.position.y < _screenPoints.ScreenLowestPoint.y;
    }
}