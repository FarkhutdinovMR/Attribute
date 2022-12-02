using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private DamageHitView _damageHitView;

    private Rigidbody _rigidbody;
    private uint _damage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(uint damage)
    {
        _damage = damage;
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageHitView hitView = Instantiate(_damageHitView, collision.contacts[0].point, Quaternion.identity);
        hitView.Init(_damage.ToString());
        Destroy(gameObject);
    }
}