using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

//by.J:230830 OrderSlotManagerUI ��ũ��Ʈ �ɰ��� / �ֹ��� ��ü ����
//(by.J:230814 �ֹ��� ǥ�� UI)
public class OrderSlotManagerUI01 : MonoBehaviour
{
    public OrderPaper orderPaper;
    public GameObject orderItemPrefab;    //�ֹ� �������� ǥ���ϱ� ���� ������
    public Transform orderListParent;     //�ֹ� �����۵��� �ڽ����� ���� �θ� ��ġ
    public TextMeshProUGUI totalCostText; //�ֹ��� �� ����
    private int currentOrderCount = 0;    //���� �ֹ��� ����
    public GameObject orderSheetPrefab;   //�ֹ��� �� UI ������
    public Transform orderHolderTransform; //OrderHolder�� Transform�� ���� public ����

    // private List<GameObject> orderItems = new List<GameObject>();

    //�ֹ��� ǥ��
    public void TriggerOrder()
    {
        Debug.Log("Ʈ����");
        MultipleOrder(3);
    }

    //�ֹ��� ������
    public void MultipleOrder(int count)
    {
        //�ִ� 3�������� ����
        if (currentOrderCount >= 3)
        {
            Debug.Log("�̹� �ִ� �ֹ����� �����߽��ϴ�.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            GameObject orderSheet = Instantiate(orderSheetPrefab);
            orderSheet.transform.SetParent(orderHolderTransform);
          
            OrderSlotManagerUI01 orderSlotManager = orderSheet.GetComponent<OrderSlotManagerUI01>();
            if (orderSlotManager != null)
            {
                if (orderSlotManager.orderPaper == null || orderSlotManager.orderItemPrefab == null)
                {
                    continue;
                }
                orderSlotManager.TriggerRandomOrder();
            }

            //������ ������Ʈ Ȱ��ȭ
            
            orderSheet.SetActive(true);
        }
        currentOrderCount += count;  //�ֹ����� ������ �� ���� �ֹ��� ���� ����

        //���� �ֹ��� ���� 3�� �̻��̸� 3���� ����
        if (currentOrderCount > 3)
            currentOrderCount = 3;

        //Debug.Log("�ǳ�");
    }

    //���� ������ �ߵ�
    public void TriggerRandomOrder()
    {
        DisplayOrder();
    }

    //�ֹ���
    public void DisplayOrder()
    {
        ////�ֹ��� ����
        OrdersTable.orders = orderPaper.RandomOrder(3); //������ 3�� ��
        Debug.Log(OrdersTable.orders.Count);

        //���� �ֹ� ������ UI ����
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
            //Debug.Log("���� �ֹ� ����");
        }
        //�� �ֹ� ������ UI ����
        foreach (var order in OrdersTable.orders)
        {
            GameObject orderItem = Instantiate(orderItemPrefab, orderListParent);
            orderItem.GetComponentInChildren<TextMeshProUGUI>().text = order.ItemName + " x" + order.Quantity;
            orderItem.GetComponentInChildren<Image>().sprite = order.ItemImage;

            Debug.Log($"Order created with ItemId22222: {order.ItemId}");

        }
        //�� ���� ǥ��
        int totalCost = orderPaper.TotalCost(OrdersTable.orders);
        totalCostText.text = totalCost.ToString();
        //Debug.Log("�� ���� ǥ��");

        Debug.Log("���� ������" + OrdersTable.orders.Count);

    }

}
