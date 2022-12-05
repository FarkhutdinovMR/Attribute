using UnityEngine;

public class TurretMB : WeaponMB
{
    [SerializeField] private float _spread = 0.2f;

    private uint _bulletAmount = 3;

    protected override Bullet CreateBullet()
    {
        for (int i = 0; i < _bulletAmount; i++)
        {
            Bullet bullet = base.CreateBullet();
            Vector3 randomOffset = Random.insideUnitCircle.normalized * _spread;
            bullet.transform.position += randomOffset;
        }

        return null;
    }
}