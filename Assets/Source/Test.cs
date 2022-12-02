using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Root _root;

    public void TakeDamage()
    {
        _root.Character.Health.TakeDamage(20);
    }

    public void Shoot()
    {
        _root.Character.Weapons[0].Shoot();
    }
}