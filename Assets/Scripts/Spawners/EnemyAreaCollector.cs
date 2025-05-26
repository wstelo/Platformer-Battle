using UnityEngine;

public class EnemyAreaCollector : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PointCollector _pointCollector;

    private void Awake()
    {        
        SpawnPoint = _spawnPoint;
        PointCollector = _pointCollector;
    }

    public Transform SpawnPoint { get; private set; } 
    public PointCollector PointCollector { get; private set; }
}
