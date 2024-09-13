using UnityEngine;

public class Tower : MonoBehaviour, IDamagable
{
    [SerializeField, Min(1)] private int _health;
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
            ActionsManager.OnTowerDestroyed(gameObject.tag);
        }
    }
}
