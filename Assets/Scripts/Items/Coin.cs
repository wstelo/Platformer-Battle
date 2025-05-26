using System;
using UnityEngine;

public class Coin : Item , IItemable
{
    public void Accept(IVisitor visitor)
    {
        DisableObject();
        visitor.Visit(this);
    }
}
