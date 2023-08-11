using UnityEngine;

//주문서 프로퍼티
public class Order : MonoBehaviour
{
    public string ItemId { get; set; }
    public Sprite ItemImage { get; set; }
    public int Quantity { get; set; }
    public int TotalCost { get; set; }
}