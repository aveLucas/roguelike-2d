using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Weapon")]
public class Weapon : ScriptableObject
{

    [Header("Only Gameplay")]
    public ItemType itemType;
    public WeaponType weaponType;
    public ActionType actionType;
    public float damage;

    [Header("Only UI")]
    public bool stackable = false;

    [Header("Both")]
    public Sprite image;

    public override bool Equals(object obj)
    {
        if (obj is Weapon otherWeapon)
        {
            return name == otherWeapon.name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

public enum WeaponType
{
    Sword
    
}