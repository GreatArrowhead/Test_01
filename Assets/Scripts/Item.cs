using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item", order = 50)]
public class Item : ScriptableObject
{
    [SerializeField] string displayName;
    [SerializeField] string description;
    [SerializeField] int price;

    [SerializeField] Sprite icon;

    public string DisplayName => displayName;
    public string Description => description;
    public float Price => price;
    public Sprite Icon => icon;

}
