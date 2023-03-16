using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

[System.Serializable]
public class Idle : MovState
{
    public override MovState HandleInput()
    {
        animationVar = 0;

        if (Input.GetAxisRaw("Horizontal") == 1) return new WalkDown();
        if (Input.GetAxisRaw("Horizontal") == -1) return new WalkLeft();

        //if (Input.GetAxisRaw("Vertical") == 1) return new WalkUp();
        //if (Input.GetAxisRaw("Vertical") == -1) return new WalkDown();

        return this;
    }
}

[System.Serializable]
public class WalkUp : MovState
{
    public override MovState HandleInput()
    {
        animationVar = 1;

        if (Input.GetAxisRaw("Vertical") == -1) return new WalkDown();
        if (Input.GetAxisRaw("Vertical") == 1) return this;

        if (Input.GetAxisRaw("Horizontal") == 1) return new WalkRight();
        if (Input.GetAxisRaw("Horizontal") == -1) return new WalkLeft();

        return new Idle();
    }
}

[System.Serializable]
public class WalkDown : MovState
{
    public override MovState HandleInput()
    {
        animationVar = 2;

        if (Input.GetAxisRaw("Vertical") == 1) return new WalkUp();
        if (Input.GetAxisRaw("Vertical") == -1) return this;

        if (Input.GetAxisRaw("Horizontal") == 1) return new WalkRight();
        if (Input.GetAxisRaw("Horizontal") == -1) return new WalkLeft();

        return new Idle();
    }
}

[System.Serializable]
public class WalkLeft : MovState
{
    public override MovState HandleInput()
    {
        animationVar = 3;

        if (Input.GetAxisRaw("Horizontal") == -1) return new WalkLeft();
        if (Input.GetAxisRaw("Horizontal") == 1) return this;

        if (Input.GetAxisRaw("Vertical") == 1) return new WalkUp();
        if (Input.GetAxisRaw("Vertical") == -1) return new WalkDown();

        return new Idle();
    }
}

[System.Serializable]
public class WalkRight : MovState
{
    public override MovState HandleInput()
    {
        animationVar = 4;

        if (Input.GetAxisRaw("Horizontal") == 1) return new WalkRight();
        if (Input.GetAxisRaw("Horizontal") == -1) return this;

        if (Input.GetAxisRaw("Vertical") == 1) return new WalkUp();
        if (Input.GetAxisRaw("Vertical") == -1) return new WalkDown();

        return new Idle();
    }
}
