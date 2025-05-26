using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemable
{
    public void Accept (IVisitor visitor);
}
