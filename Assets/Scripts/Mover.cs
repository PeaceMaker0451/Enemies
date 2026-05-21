using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _target;
        
        private void Update()
        {
            if (_target == null)
                return;

            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}