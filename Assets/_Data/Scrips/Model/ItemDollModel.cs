
using System;
using UnityEngine;

[System.Serializable]

public class ItemDollModel
{
    public String name;
    public Color color;

    public ItemDollModel(String name)
    {
        this.name = name;
    }


    public ItemDollModel(Color color)
    {
        this.color = color;
    }
}
