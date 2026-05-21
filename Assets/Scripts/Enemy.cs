using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void Initialize(Transform target)
    {
        _mover.SetTarget(target);
    }
}
