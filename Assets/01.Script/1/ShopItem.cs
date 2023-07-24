using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New ITem", menuName ="Game Objects/Shop", order =0)]

public class ShopItem : MonoBehaviour
{
    public string Names = "Default";
    public string Descriptions = "Description";
    public int Levels;
    public int Prices;
    public CurrencyType currency;
    public ObjectType Types;
    public Sprite Icos;
    public GameObject Prefabs;
}

public enum ObjectType
{
    Buildings,
    Farms,
    CropItems,
    ProcessItems
}
