using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _direction;
    private bool _isIntialized = false;

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
        _isIntialized = true;
    }
    
    private void Update()
    {
        if (_isIntialized == false)
            return;
        
        transform.Translate(_direction * Time.deltaTime * _speed, Space.World);
    }
}
