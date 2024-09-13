using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;

    private float _spawnTimerUpRate = 2.5f;
    private float _spawnTimer = 2f;

    private float _currentTime;
    private void Start()
    {
        _currentTime = _spawnTimer;
        ActionsManager.TowerDestroyed += SpawnTimerUp;
    }

    private void Update()
    {
        if (_currentTime <= 0)
        {
            Instantiate(
                m_Prefab,
                transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)),
                transform.rotation);
            _currentTime = _spawnTimer;
        }
        _currentTime -= Time.deltaTime;
    }

    private void SpawnTimerUp(string tag)
    {
        _spawnTimer += _spawnTimerUpRate;
    }
}
