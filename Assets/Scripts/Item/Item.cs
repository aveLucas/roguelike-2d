using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{

    [Header("Only Gameplay")]
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    public override bool Equals(object obj)
    {
        if (obj is Item otherItem)
        {
            return name == otherItem.name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

public enum ItemType
{
    Tool,
    Food
}

public enum ActionType
{
    Attack,
    Eat
}