using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

//by.J:230814 �ֹ��� ǥ�� UI / ���� ��ư
//by.J:230816 �ֹ� Ŭ�� �� ���ν� ��ȭ����
//by.J:230817 �ֹ��� Ŭ���� ȿ�� ����
public class OrderSlotManagerUI : MonoBehaviour
{
    public OrderPaper orderPaper;
    public GameObject orderItemPrefab;    //�ֹ� �������� ǥ���ϱ� ���� ������
    public Transform orderListParent;     //�ֹ� �����۵��� �ڽ����� ���� �θ� ��ġ
    public TextMeshProUGUI totalCostText; //�ֹ��� �� ����
    public GameObject orderSheetPrefab;   //�ֹ��� �� UI ������

    private int currentOrderCount = 0;            //���� �ֹ��� ����
    private static GameObject selectedOrderPaper; //���� ���õ� �ֹ��� / ���� ���� �����ϵ��� static

    private Vector3 originalOrderSize;  //�ֹ����� ���� ũ��
    public float enlargedScale = 0.5f;  //ũ�� �� ���� ������ ��

    private void Start()
    {
        // �ʱ� ���� �� �ֹ����� ���� ũ�� ����
        originalOrderSize = orderPaper.transform.localScale;
    }

    private void Update()
    {
        //���콺 Ŭ��, ��ġ�� UI ������Ʈ �ƴҰ�� ���� ũ����
        if (IsInputDetected() && !IsPointerOverUIObject())
        {
            if (selectedOrderPaper != null)
            {
                ResetOrderSize(selectedOrderPaper);
                selectedOrderPaper = null;
            }
        }
    }


    //�ֹ��� ǥ��
    public void TriggerOrder()
    {
        MultipleOrder(3);
    }

    //���� ������ �ߵ�
    public void TriggerRandomOrder()
    {
        DisplayOrder();
    }

    //�ֹ���
    public void DisplayOrder()
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
        totalCostText.text = totalCost.ToString();
        //Debug.Log("�� ���� ǥ��");
    }

    //�ֹ��� ������
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
    public void ResetOrder()
    {
        //��� �ֹ��� ������Ʈ ����
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
        }

        //���� �ֹ��� ���� �ʱ�ȭ
        currentOrderCount = 0;
    }

    //�ֹ��� ����
    public void SelectOrder(GameObject orderPaper)
    {
        //Debug.Log("���� �ֹ���");
        //Debug.Log("�ֹ��� ���þ�" + selectedOrderPaper);

        //���� ���� �ֹ����� Ŭ�� �ֹ��� ���� ���
        if (selectedOrderPaper == orderPaper)
        {
            //�ֹ��� ũ�� ������� �� ���� ����
            ResetOrderSize(orderPaper);
            selectedOrderPaper = null;
        }
        else
        {
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

    //�����ϱ� ��ư
    public void PayButtonClick()
    {
        //Debug.Log("�����ϱ� ��ư Ŭ��");
        //Debug.Log("selectedOrderPaper ��: " + selectedOrderPaper);
        if (selectedOrderPaper != null)
        {
            //Debug.Log("selectedOrderPaper�� null�� �ƴմϴ�.");

            TextMeshProUGUI totalCostText = selectedOrderPaper.transform.Find("gold count").GetComponent<TextMeshProUGUI>();
            //Debug.Log("��" + totalCostText);

            if (totalCostText == null)
            {
                //Debug.Log("costText�� null�Դϴ�." + totalCostText);
                return;
            }

            //Debug.Log("�� ����: " + totalCostText.text);
            int cost = int.Parse(totalCostText.text); //�ؽ�Ʈ���� ��� ����
            MoneySystem.Instance.AddGold(cost);       //��ȭ ����
            Destroy(selectedOrderPaper);              //������ �ֹ��� ����
            selectedOrderPaper = null;                //���� �ʱ�ȭ
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



    //���콺 Ŭ��, ��ġ ����
    private bool IsInputDetected()
    {
        //���콺 Ŭ��
        if (Input.GetMouseButtonDown(0))
            return true;

        //��ġ �Է�
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        return false;
    }

    //���콺 ������, ��ġ�� UI ������Ʈ ���� �ִ��� Ȯ��
    private bool IsPointerOverUIObject()
    {
        //���콺 ������
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}