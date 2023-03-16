using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovState
{
    public int animationVar;

    public virtual MovState HandleInput()
    {
        return this;
    }
}
