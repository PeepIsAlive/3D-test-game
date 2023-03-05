using UnityEngine;
using Extensions;
using Types;

namespace Core
{
    public sealed class PaperUnit : MonoBehaviour, IUnitable
    {
#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private UnitType _unitType = UnitType.Paper; 

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
