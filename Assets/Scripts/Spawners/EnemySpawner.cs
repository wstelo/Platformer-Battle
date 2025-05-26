using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<EnemyAreaCollector> _spawnArea;

    private void Start()
    {
        Instantiate(_prefab);
    }

    private void Instantiate(Enemy prefab)
    {
        for (int i = 0; i < _spawnArea.Count; i++)
        {
            var newEnemy = Instantiate(prefab, _spawnArea[i].SpawnPoint.position, Quaternion.identity);
            newEnemy.Initialize(_spawnArea[i].PointCollector);

            if(newEnemy.TryGetComponent(out Health enemy))
            {
                enemy.HealthEnded += DisableObject;
            }
        }
    }

    private void DisableObject(Health enemy)
    {
        Destroy(enemy.gameObject);
    }
}
