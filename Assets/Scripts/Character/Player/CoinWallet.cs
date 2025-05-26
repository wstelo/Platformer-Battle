using UnityEngine;


public class CoinWallet : MonoBehaviour
{
    private int _count = 0;

    public void IncreaseCount()
    {
        _count++;
        Debug.Log(_count);
    }
}
