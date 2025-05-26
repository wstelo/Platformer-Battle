using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorCollector : IVisitor
{
    private CoinWallet _wallet;
    private Health _health;

    public VisitorCollector(CoinWallet wallet, Health health)
    {
        _wallet = wallet;
        _health = health;
    }

    public void Visit(Coin coin)
    {
        _wallet.IncreaseCount();
    }

    public void Visit(FirstAidKit firstAidKit)
    {
        _health.IncreaseHealth(firstAidKit.HealthRecoveryCount);
    }
}
