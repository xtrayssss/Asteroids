using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Pool
{
    public class PoolObject
    {
        private readonly List<GameObject> _pool;

        private readonly GameObject _prefab;
        private readonly int _amountObjects;
        private readonly bool _autoExpand;
        private readonly Transform _container;

        public PoolObject(GameObject prefab, int amountObjects, bool autoExpand, Transform container = null)
        {
            _prefab = prefab;
            _amountObjects = amountObjects;
            _autoExpand = autoExpand;
            _container = container;

            _pool = new List<GameObject>(amountObjects);

            CreateObjects();
        }

        public GameObject GetFreeObject()
        {
            foreach (GameObject item in _pool)
            {
                bool activeSelf = item.GameObject().activeSelf;

                if (!activeSelf)
                {
                    item.SetActive(true);

                    return item;
                }
            }

            if (_autoExpand)
            {
                return Instantiate();
            }

            return null;
        }

        private void CreateObjects()
        {
            for (int i = 0; i < _amountObjects; i++)
            {
                GameObject prefab = Instantiate();

                prefab.SetActive(false);

                _pool.Add(prefab);
            }
        }

        public int GetLength() =>
            _pool.Count;

        private GameObject Instantiate()
        {
            if (_container != null)
            {
                return Object.Instantiate(_prefab, _container);
            }

            return Object.Instantiate(_prefab);
        }

        public List<GameObject> GetPoolList() => 
            _pool;
    }
}