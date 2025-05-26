using UnityEngine;

[RequireComponent(typeof(CoinWallet))]
public class CollisionDetector : MonoBehaviour
{
    private VisitorCollector _visitorCollector;
    private CoinWallet _coinWallet;
    private Health _health;

    private void Awake()
    {
        _coinWallet = GetComponent<CoinWallet>();
        _health = GetComponent<Health>();
        _visitorCollector = new VisitorCollector(_coinWallet,_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IItemable item))
        {

            item.Accept(_visitorCollector);
        }
    }
}
