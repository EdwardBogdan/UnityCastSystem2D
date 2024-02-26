using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CastSystem2D.Abstract
{
    public abstract class CastComponent : CastCore
    {
        [SerializeField] protected Color _color = new(0f,1f,0f,1f);

        [SerializeField] protected string[] _tags;

        [SerializeField] internal bool _useByCombinator;
        [SerializeField] protected bool _tagFilter;

        [SerializeField] protected Vector2 _position;

        [SerializeField] protected LayerMask _layer;

        [ContextMenu("Cast")]
        public void Cast()
        {
            if (_action == null) return;

            InvokeAction(Collect());
        }
        protected Vector3 GetNewPos()
        {
            Vector3 currentPos = transform.position;
            Vector3 scale = transform.lossyScale;
            return new(currentPos.x + (_position.x * scale.x), currentPos.y + (_position.y * scale.y), 0f);
        }
        protected List<Collider2D> SortToList(Collider2D[] mas)
        {
            List<Collider2D> list = new();

            IEnumerable<Collider2D> filteredColliders = mas;

            if (_tagFilter)
            {
                filteredColliders = filteredColliders.Where(item => {
                    foreach (string tag in _tags)
                    {
                        if (item.gameObject.CompareTag(tag))
                            return true;
                    }
                    return false;
                });

                list.AddRange(filteredColliders);
            }
            else
            {
                list.AddRange(mas);
            }

            return list;
        }
        public abstract List<Collider2D> Collect();

#if UNITY_EDITOR
        protected abstract void OnDrawGizmosSelected();
#endif
    }
}

