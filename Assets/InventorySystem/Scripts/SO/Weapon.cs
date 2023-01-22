
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptables/Item/Weapon", order = 1)]
public class Weapon : Item
{
    public enum WeaponType
    {
        Axe,
        Sword,
        Shield,
        Spear,
    }

    public WeaponType Type;
    public int attack;
    public int defense;
    public int damage;
    public int level;


    private void Awake()
    {
        itemInfo.Type = ItemType.Weapon;
    }
}
