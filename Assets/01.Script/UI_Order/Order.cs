using UnityEngine;

//by.J:230811 �ֹ��� ������Ƽ
public class Order : MonoBehaviour
{
    public string ItemName { get; set; }  //�̸�
    public string ItemId { get; set; }    //ID
    public Sprite ItemImage { get; set; } //�̹���
    public int Quantity { get; set; }     //����
    public int TotalCost { get; set; }    //�� ���
}