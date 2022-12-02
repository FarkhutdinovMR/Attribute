using System;
using System.Collections;
using UnityEngine;

public class PistolMB : MonoBehaviour, IWeapon
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletTarget;

    private IAttribute _rateOfFire;
    private IAttribute _damage;
    private bool _canShoot;

    public Attribute[] Attributes { get; private set; }

    public void Init(Attribute[] attributes)
    {
        Attributes = attributes;
        _rateOfFire = Array.Find(Attributes, item => item.Type == AttributeType.RateOfFire);
        _damage = Array.Find(Attributes, item => item.Type == AttributeType.Damage);
        _canShoot = true;
    }

    public void Shoot()
    {
        if (_canShoot == false)
            return;

        Bullet newBullet = Instantiate(_bullet, _bulletTarget.position, Quaternion.identity);
        newBullet.Init((uint)_damage.Value);
        StartCoroutine(WaitRollback());
    }

    private IEnumerator WaitRollback()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_rateOfFire.Value);
        _canShoot = true;
    }
}