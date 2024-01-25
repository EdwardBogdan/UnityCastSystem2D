using System.Collections.Generic;
using UnityEngine;
using CastSystem2D.Abstract;
using System.Linq;

namespace CastSystem2D
{
    public class CastCombiner : CastCore
    {
        private List<CastComponent> casters;

        private void Start()
        {
            casters = GetComponents<CastComponent>().Where(item => item._useByCombinator).ToList();
        }

        [ContextMenu("Combined Cast")]
        public void CombinatedCast()
        {
            if (_action == null) return;

            HashSet<Collider2D> uniqueColliders = new HashSet<Collider2D>();

            foreach (var caster in casters)
            {
                foreach (var collider in caster.Collect())
                {
                    uniqueColliders.Add(collider);
                }
            }

            InvokeAction(uniqueColliders.ToList());
        }
    }
}
