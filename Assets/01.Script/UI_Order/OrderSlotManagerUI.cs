using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//by.J:230814 �ֹ��� ǥ�� UI / ���� ��ư
public class OrderSlotManagerUI : MonoBehaviour
{
    public OrderPaper orderPaper;
    public GameObject orderItemPrefab;    //�ֹ� �������� ǥ���ϱ� ���� ������
    public Transform orderListParent;     //�ֹ� �����۵��� �ڽ����� ���� �θ� ��ġ
    public TextMeshProUGUI totalCostText; //�ֹ��� �� ����
    public GameObject orderSheetPrefab;   //�ֹ��� �� UI ������

    private int currentOrderCount = 0;    //���� �ֹ��� ����

    //�ֹ��� ǥ��
    public void TriggerOrder()
    {
        MultipleOrder(3);
    }

    //���� ������ �ߵ�
    public void TriggerRandomOrder()
    {
        DisplayOrders();
    }

    public void DisplayOrders()
    {
        //�ֹ��� ����
        List<Order> orders = orderPaper.RandomOrder(3); //������ 3�� ����

        //���� �ֹ� ������ UI ����
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
            //Debug.Log("���� �ֹ� ����");
        }
        //�� �ֹ� ������ UI ����
        foreach (var order in orders)
        {
            GameObject orderItem = Instantiate(orderItemPrefab, orderListParent);
            orderItem.GetComponentInChildren<TextMeshProUGUI>().text = order.ItemName + " x" + order.Quantity;
            orderItem.GetComponentInChildren<Image>().sprite = order.ItemImage;
            //Debug.Log("�� �ֹ� ����");
        }
        //�� ���� ǥ��
        int totalCost = orderPaper.TotalCost(orders);
        totalCostText.text = totalCost + " ";
        //Debug.Log("�� ���� ǥ��");
    }

    public void MultipleOrder(int count)
    {
        //�ִ� 3�������� ����
        if (currentOrderCount >= 3)
        {
            //Debug.Log("�̹� �ִ� �ֹ����� �����߽��ϴ�.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            GameObject orderSheet = Instantiate(orderSheetPrefab);
            orderSheet.transform.SetParent(orderListParent);

            OrderSlotManagerUI orderSlotManager = orderSheet.GetComponent<OrderSlotManagerUI>();
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

    //���� ��ư
    public void ResetOrders()
    {
        //��� �ֹ��� ������Ʈ ����
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
        }

        //���� �ֹ��� ���� �ʱ�ȭ
        currentOrderCount = 0;

    }
}


