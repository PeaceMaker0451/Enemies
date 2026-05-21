using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Mover))]
    public class MovableTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] _pathPoints;
        
        private float _switchPathPointDistance = 0.5f;
        private int _currentPathPoint;
        private Mover _mover;

        private void Start()
        {
            if (_pathPoints.Length == 0)
                throw new System.Exception("Точек пути не может быть 0");

            _mover = GetComponent<Mover>();

            _currentPathPoint = 0;
            _mover.SetTarget(_pathPoints[_currentPathPoint]);
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _pathPoints[_currentPathPoint].transform.position) <= _switchPathPointDistance)
                SwitchPathPoint();
        }

        private void SwitchPathPoint()
        {
            _currentPathPoint++;

            if( _currentPathPoint >= _pathPoints.Length)
                _currentPathPoint = 0;

            _mover.SetTarget(_pathPoints[_currentPathPoint]);
        }
    }
}