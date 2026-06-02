using System;
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

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Start()
        {
            if (_pathPoints.Length == 0)
                throw new Exception("Точек пути не может быть 0");

            _currentPathPoint = 0;
            _mover.SetTarget(_pathPoints[_currentPathPoint]);
        }

        private void Update()
        {
            if (Vector3.SqrMagnitude(transform.position - _pathPoints[_currentPathPoint].transform.position) <= MathF.Pow(_switchPathPointDistance, 2))
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