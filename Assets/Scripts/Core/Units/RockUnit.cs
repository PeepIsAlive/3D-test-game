using UnityEngine;
using Extensions;
using Types;

namespace Core
{
    public sealed class RockUnit : MonoBehaviour, IMovable
    {
#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private readonly UnitType _unitType = UnitType.Rock;

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
