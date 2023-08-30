using JinnyCropItem;
using JinnyProcessItem;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//by.J:230814 �ֹ��� ǥ�� UI / ���� ��ư
//by.J:230816 �ֹ� Ŭ�� �� ���ν� ��ȭ����
//by.J:230817 �ֹ��� Ŭ���� ȿ�� ����
//by.J:230830 �ֹ��� Ŭ�� �� ���ν� â�� ������ ����
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

    //�ֹ��� ����

    //private static List<Order> orders; //������ 3�� ����
    //List<Order> test;

    private void Start()
    {
        // �ʱ� ���� �� �ֹ����� ���� ũ�� ����
        originalOrderSize = orderPaper.transform.localScale;
        if(gameObject.name != "order slot")
        {
            Debug.Log(gameObject.name + "Start orders");
            OrdersTable.orders = new List<Order>();
        }
        
        //test = new List<Order>();

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
        Debug.Log("Ʈ����");
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
        //Debug.Log("����" + orders.Count);

        ////�ֹ��� ����
        OrdersTable.orders = orderPaper.RandomOrder(3); //������ 3�� ����
        //test = orders;

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
            //Order orderComponent = orderItem.GetComponent<Order>();
            //if (orderComponent != null)
            //{
            //    orderComponent.ItemId = order.ItemId;
            //    orderComponent.ItemName = order.ItemName;
            //    orderComponent.ItemImage = order.ItemImage;
            //    orderComponent.Quantity = order.Quantity;
            //    orderComponent.TotalCost = order.TotalCost;
            //}


        }
        //�� ���� ǥ��
        int totalCost = orderPaper.TotalCost(OrdersTable.orders);
        totalCostText.text = totalCost.ToString();
        //Debug.Log("�� ���� ǥ��");

        Debug.Log ("���� ������" + OrdersTable.orders.Count);

    }

    //�ֹ��� ������
    public void MultipleOrder(int count)
    {

        Debug.Log(gameObject.name + "��Ƽ��" + OrdersTable.orders.Count); 
        //�ִ� 3�������� ����
        if (currentOrderCount >= 3)
        {
            Debug.Log("�̹� �ִ� �ֹ����� �����߽��ϴ�.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Debug.Log("��Ƽ��2" + OrdersTable.orders.Count);
            GameObject orderSheet = Instantiate(orderSheetPrefab);
            orderSheet.transform.SetParent(orderListParent);



            OrderSlotManagerUI orderSlotManager = orderSheet.GetComponent<OrderSlotManagerUI>();
            if (orderSlotManager != null)
            {
                
                Debug.Log("��Ƽ��3" + OrdersTable.orders.Count);
                if (orderSlotManager.orderPaper == null || orderSlotManager.orderItemPrefab == null)
                {
                    Debug.Log("��Ƽ��4" + OrdersTable.orders.Count);
                    continue;
                }
                orderSlotManager.TriggerRandomOrder();
                Debug.Log("��Ƽ��777" + OrdersTable.orders.Count);
            }
            //������ ������Ʈ Ȱ��ȭ
            ;
            orderSheet.SetActive(true);
            Debug.Log("��Ƽ��888" + OrdersTable.orders.Count);
        }

        Debug.Log("��Ƽ��5" + OrdersTable.orders.Count);
        currentOrderCount += count;  //�ֹ����� ������ �� ���� �ֹ��� ���� ����

        //���� �ֹ��� ���� 3�� �̻��̸� 3���� ����
        if (currentOrderCount > 3)
            currentOrderCount = 3;

        //Debug.Log("�ǳ�");
        Debug.Log(gameObject.name + " : ��Ƽ��6" + OrdersTable.orders.Count);
    }

    //���� ��ư
    public void ResetOrder()
    {
        //��� �ֹ��� ������Ʈ ����
        foreach (Transform child in orderListParent)
        {
            Debug.Log("����");
            Destroy(child.gameObject);
        }

        //���� �ֹ��� ���� �ʱ�ȭ
        currentOrderCount = 0;
    }

    //�ֹ��� ����
    public void SelectOrder(GameObject orderPaper)
    {
        Debug.Log("���� �ֹ���");
        //Debug.Log("�ֹ��� ���þ�" + selectedOrderPaper);
        Debug.Log(gameObject.name +" : "+ OrdersTable.orders.Count);
        //Debug.Log(test.Count);

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

    //�����ϱ� ��ư
    public void PayButtonClick()
    {
        //Debug.Log("�����ϱ� ��ư Ŭ��");
        //Debug.Log("selectedOrderPaper ��: " + selectedOrderPaper);

        //Debug.Log("selectedOrderPaper�� null�� �ƴմϴ�.");

        //Debug.Log(test.Count);
        Debug.Log("����" + OrdersTable.orders.Count);

        if (selectedOrderPaper != null)
        {



            // �ֹ������� �ʿ��� ������ ��ϰ� ������ �����ɴϴ�.
            // Order orderDetails = selectedOrderPaper.GetComponent<Order>();
         

            if (OrdersTable.orders == null)
            {
                Debug.LogError("Order component not found on selectedOrderPaper!");
                return;
            }
            Debug.Log(OrdersTable.orders.Count);
           //Debug.Log(test.Count);
           // Debug.Log("Checking itemId: " + test[1].ItemId);

            


            // â���� �ش� �������� ������ Ȯ���մϴ�.
            IItem requiredItem = GetItemFromID(OrdersTable.orders[1].ItemId);  // �� �Լ��� ������ ID�� �޾� IItem�� ��ȯ�ؾ��մϴ�.
            if (requiredItem == null)
            {
                Debug.Log("Checking itemId: " + OrdersTable.orders[1].ItemId);
                Debug.LogError("No item found with the given ID!");
                return;
            }

            int storageAmount = Storage.Instance.GetItemAmount(requiredItem);
            if (storageAmount < OrdersTable.orders[1].Quantity)
            {
                Debug.LogWarning("â�� �ʿ��� �������� �����մϴ�.");
                return;
            }

            // â���� �ʿ��� �����۰� ������ �����մϴ�.
            Storage.Instance.RemoveItem(requiredItem, OrdersTable.orders[1].Quantity);

            TextMeshProUGUI totalCostText = selectedOrderPaper.transform.Find("gold count").GetComponent<TextMeshProUGUI>();
            if (totalCostText == null)
            {
                Debug.LogError("Failed to find gold count text component!");
                return;
            }

            int cost = int.Parse(totalCostText.text); //�ؽ�Ʈ���� ��� ����
            MoneySystem.Instance.AddGold(cost);       //��ȭ ����
            Destroy(selectedOrderPaper);              //������ �ֹ��� ����
            selectedOrderPaper = null;                //���� �ʱ�ȭ
        }







        //    TextMeshProUGUI totalCostText = selectedOrderPaper.transform.Find("gold count").GetComponent<TextMeshProUGUI>();
        //    //Debug.Log("��" + totalCostText);

        //    if (totalCostText == null)
        //    {
        //        //Debug.Log("costText�� null�Դϴ�." + totalCostText);
        //        return;
        //    }

        //    //Debug.Log("�� ����: " + totalCostText.text);
        //    int cost = int.Parse(totalCostText.text); //�ؽ�Ʈ���� ��� ����
        //    MoneySystem.Instance.AddGold(cost);       //��ȭ ����
        //    Destroy(selectedOrderPaper);              //������ �ֹ��� ����
        //    selectedOrderPaper = null;                //���� �ʱ�ȭ


    }



    // ������ ID�� ����Ͽ� IItem�� ������
    private IItem GetItemFromID(string itemId)
    {
        // Crop items Ȯ��
        CropItemDataInfo cropItem = JinnyCropItem.CropItem.Instance.cropItemDataInfoList.FirstOrDefault(item => item.ItemId == itemId);
       
        if (cropItem.IsInitialized)
        {
            Debug.Log("Found in Crop Items: " + cropItem.ItemId);
            return cropItem;
        }

        // Process items Ȯ��
        ProcessItemDataInfo processItem = JinnyProcessItem.ProcessItem.Instance.processItemDataInfoList.FirstOrDefault(item => item.ItemId == itemId);
        if (processItem.IsInitialized)
        {
            return processItem;
        }

        // �ش� ID�� ��ġ�ϴ� �������� ����
        return null;
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