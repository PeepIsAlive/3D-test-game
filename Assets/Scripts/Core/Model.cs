using Leopotam.Ecs;
using System.Collections.Generic;

namespace Project
{
    public sealed class Model : IEcsSystem
    {
        private List<EcsEntity> GetEntities<T>(EcsFilter<T> filter) where T : struct
        {
            var result = new List<EcsEntity>();

            if (filter != null)
            {
                foreach (var i in filter)
                {
                    result.Add(filter.GetEntity(i));
                }
            }

            return result;
        }
    }
}
