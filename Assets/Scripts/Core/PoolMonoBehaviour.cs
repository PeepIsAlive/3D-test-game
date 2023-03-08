using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public sealed class PoolMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private readonly List<T> _pool;
        private Vector3 _spawnPosition;
        private T _prefab;
        private bool _isAutoExpand;

        private const int DEFAULT_AMOUNT_OBJECTS = 3;

        public PoolMonoBehaviour(T prefab, Vector3 spawPosition, bool isAutoExpand)
        {
            _pool = new List<T>();
            _prefab = prefab;
            _spawnPosition = spawPosition;
            _isAutoExpand = isAutoExpand;

            FillPool();
        }

        public bool TryGetObject(out T obj)
        {
            obj = null;

            if (!_pool.Any(x => !x.enabled))
            {
                if (_isAutoExpand)
                {
                    obj = CreateObject();
                    _pool.Add(obj);

                    return true;
                }
            }
            else
            {
                obj = GetObject();

                return true;
            }

            return false;
        }

        private T GetObject()
        {
            return _pool.FirstOrDefault(x => !x.enabled);
        }

        private void FillPool()
        {
            for (int i = 0; i < DEFAULT_AMOUNT_OBJECTS; ++i)
            {
                _pool.Add(CreateObject());
            }
        }

        private T CreateObject()
        {
            T obj = Instantiate(_prefab, _spawnPosition, Quaternion.identity);
            obj.gameObject.SetActive(false);

            return obj;
        }
    }
}
