using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : Pickable
{
    public enum Type
    {
        Cube,
        NotCube
    }

    public Type itemType;
    public Sprite sprite;

    public override void PickUp(Interactor interactor)
    {
        Inventory.Instance.AddItem(this);
        Destroy(gameObject);
    }
}
