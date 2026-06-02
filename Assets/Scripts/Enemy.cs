using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;
    private Transform _target;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (_target == null)
            return;

        transform.LookAt(_target);
    }

    public void Initialize(Transform target)
    {
        _target = target;
        _mover.SetTarget(target);
    }
}
