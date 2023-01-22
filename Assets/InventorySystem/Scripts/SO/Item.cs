using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptables/Item", order = 2)]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        Consumable,
    }

    [System.Serializable]
    public struct ItemInformation
    {
        public ItemType Type;
        public string Name;
        public string Description;
        public Sprite sprite;
    }

    [SerializeField] protected ItemInformation itemInfo;
    public ItemInformation ItemInfo { get { return itemInfo; } }
}
