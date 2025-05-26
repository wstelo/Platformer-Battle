using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor
{
    void Visit(Coin coin);
    void Visit(FirstAidKit firstAidKit);
}
