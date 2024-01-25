using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CastSystem2D.Abstract
{
    public abstract class CastCore : MonoBehaviour
    {
        [SerializeField] protected bool _actionByNull;
        [SerializeField] protected bool _onlyFirstCollected;

        [SerializeField] protected UnityEvent<GameObject> _action;

        protected void InvokeAction(List<Collider2D> list)
        {
            int count = list.Count;

            if (_actionByNull && count == 0)
            {
                _action?.Invoke(null);
                return;
            }

            if (_onlyFirstCollected && count > 0)
            {
                _action?.Invoke(list[0].gameObject);
                return;
            }

            foreach (Collider2D hit in list)
            {
                _action?.Invoke(hit.gameObject);
            }
        }
    }
}
