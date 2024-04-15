using Animation;
using UnityEngine;

namespace Pooling.Pools
{
    public class PointDeathEffectPool : MonoBehaviour
    {
        [SerializeField] private PointDeathEffect pointDeathEffectPrefab;
        
        private ObjectPool<PointDeathEffect> _pointDeathEffectPool;

        private void Awake()
        {
            _pointDeathEffectPool = new ObjectPool<PointDeathEffect>(pointDeathEffectPrefab);
        }
        
        public PointDeathEffect GetObject()
        {
            var poolAble = _pointDeathEffectPool.GetFreeObject();
            return poolAble as PointDeathEffect;
        }
    }
}