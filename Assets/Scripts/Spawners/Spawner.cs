using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : Item ,IItemable

{
    [SerializeField] private T _prefab;
    [SerializeField] private PointCollector _objectWithPoints;

    private void Start()
    {
        CreateObject(_prefab);
    }

    private void CreateObject(T prefab)
    {
        for (int i = 0; i < _objectWithPoints.TargetPoints.Count; i++)
        {
            var currentObject = Instantiate(prefab, _objectWithPoints.TargetPoints[i].transform.position, Quaternion.identity);
            currentObject.OnCollected += DestroyObject;
        }
    }

    private void DestroyObject(Item item)
    {
        item.OnCollected -= DestroyObject;
        Destroy(item.gameObject);
    }
}
