using UnityEngine;

//by.J:230811 주문서 프로퍼티
public class Order : MonoBehaviour
{
    public string ItemName { get; set; }  //이름
    public string ItemId { get; set; }    //ID
    public Sprite ItemImage { get; set; } //이미지
    public int Quantity { get; set; }     //수량
    public int TotalCost { get; set; }    //총 비용
}