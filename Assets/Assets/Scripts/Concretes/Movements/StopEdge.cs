
using System.Collections;
using System.Collections.Generic;
using Udemy3.Abstracts.Movements;
using UnityEngine;

namespace Udemy3.Movements
{
    [RequireComponent(typeof(Collider2D))]
    public class StopEdge : MonoBehaviour, IStopEdge
    {
        [SerializeField] float distance = 0.2f;
        [SerializeField] LayerMask layerMask;

        public bool IsRightDirection { get; private set; }

        Collider2D _collider;
        float _direction;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _direction = transform.localScale.x;
        }

        public bool ReachEdge()
        {
            float x = GetXPosition();
            float y = _collider.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, layerMask);
            Debug.DrawRay(origin, Vector2.down * distance, Color.red);

            if (hit.collider != null)
            {
                _direction = transform.localScale.x;
                return false;
            }

            return true;
        }

        private float GetXPosition()
        {
            IsRightDirection = _direction == 1f;

            if (IsRightDirection)
            {
                return _collider.bounds.max.x;
            }
            else
            {
                return _collider.bounds.min.x;
            }
        }
    }

}