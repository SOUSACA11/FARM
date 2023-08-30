using UnityEngine;
using TMPro;
using UnityEngine.UI;

//by.J:230830 OrderSlotManagerUI ��ũ��Ʈ �ɰ��� / �ֹ��� �������� ���� ����
//(by.J:230814 ���� ��ư)
//(by.J:230816 �ֹ� Ŭ�� �� ���ν� ��ȭ����)
//(by.J:230817 �ֹ��� Ŭ���� ȿ�� ����)
//9by.J:230830 �ֹ��� Ŭ�� �� ���ν� â�� ������ ����)
public class OrderSlotItemUI : MonoBehaviour
{
    //private TextMeshProUGUI itemNameText;
    private Image itemImage;
    private static GameObject selectedOrderPaper; //���� ���õ� �ֹ��� / ���� ���� �����ϵ��� static
    private Vector3 originalOrderSize;
    public float enlargedScale = 0.5f;

    private void Awake()
    {
       //itemNameText = GetComponentInChildren<TextMeshProUGUI>();
        itemImage = GetComponentInChildren<Image>();
    }

    public void InitializeOrderItem(Order order)
    {
        //itemNameText.text = order.ItemName + " x" + order.Quantity;
        itemImage.sprite = order.ItemImage;
    }

    public void SelectOrderItem(GameObject orderPaper)
    {
        Debug.Log("���� �ֹ���");

        //���� ���� �ֹ����� Ŭ�� �ֹ��� ���� ���
        if (selectedOrderPaper == orderPaper)
        {
            Debug.Log("����");
            //�ֹ��� ũ�� ������� �� ���� ����
            ResetOrderSize(orderPaper);
            selectedOrderPaper = null;
        }
        else
        {
            Debug.Log("��");
            //���� ���� �ֹ��� ũ�� �������
            if (selectedOrderPaper != null)
            {
                ResetOrderSize(selectedOrderPaper);
            }

            //���ο� �ֹ��� ���� �� ũ�� ����
            selectedOrderPaper = orderPaper;
            EnlargeOrderSize(orderPaper);
        }
    }
    //�ֹ��� ũ�� ����
    private void EnlargeOrderSize(GameObject orderPaper)
    {
        orderPaper.transform.localScale = originalOrderSize * enlargedScale;
    }

    //�ֹ��� ũ�� �������
    private void ResetOrderSize(GameObject orderPaper)
    {
        orderPaper.transform.localScale = originalOrderSize;
    }

    //public void RemoveOrderItem()
    //{
    //    // ���� ���� �θ� (OrderSlotManagerUI)���� �˸� ���� �ֽ��ϴ�.
    //    OrderSlotManagerUI01 manager = GetComponentInParent<OrderSlotManagerUI01>();
    //    if (manager != null)
    //    {
    //        manager.RemoveOrderItem(gameObject);
    //    }
    //}

}
