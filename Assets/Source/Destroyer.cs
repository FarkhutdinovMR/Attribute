using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _liveTime;

    private void Start()
    {
        Destroy(gameObject, _liveTime);
    }
}