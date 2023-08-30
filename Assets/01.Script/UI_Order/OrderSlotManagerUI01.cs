using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

//by.J:230830 OrderSlotManagerUI 스크립트 쪼개기 / 주문서 전체 관리
//(by.J:230814 주문서 표시 UI)
public class OrderSlotManagerUI01 : MonoBehaviour
{
    public OrderPaper orderPaper;
    public GameObject orderItemPrefab;    //주문 아이템을 표시하기 위한 프리팹
    public Transform orderListParent;     //주문 아이템들을 자식으로 가질 부모 위치
    public TextMeshProUGUI totalCostText; //주문서 총 가격
    private int currentOrderCount = 0;    //현재 주문서 개수
    public GameObject orderSheetPrefab;   //주문서 총 UI 프리팹
    public Transform orderHolderTransform; //OrderHolder의 Transform을 위한 public 변수

    // private List<GameObject> orderItems = new List<GameObject>();

    //주문서 표시
    public void TriggerOrder()
    {
        Debug.Log("트리거");
        MultipleOrder(3);
    }

    //주문서 여러개
    public void MultipleOrder(int count)
    {
        //최대 3개까지만 생성
        if (currentOrderCount >= 3)
        {
            Debug.Log("이미 최대 주문서를 생성했습니다.");
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

            //복제된 오브젝트 활성화
            
            orderSheet.SetActive(true);
        }
        currentOrderCount += count;  //주문서를 생성한 후 현재 주문서 수를 증가

        //현재 주문서 수가 3개 이상이면 3개로 설정
        if (currentOrderCount > 3)
            currentOrderCount = 3;

        //Debug.Log("되나");
    }

    //랜덤 아이템 발동
    public void TriggerRandomOrder()
    {
        DisplayOrder();
    }

    //주문서
    public void DisplayOrder()
    {
        ////주문서 생성
        OrdersTable.orders = orderPaper.RandomOrder(3); //아이템 3개 배
        Debug.Log(OrdersTable.orders.Count);

        //기존 주문 아이템 UI 삭제
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
            //Debug.Log("기존 주문 삭제");
        }
        //새 주문 아이템 UI 생성
        foreach (var order in OrdersTable.orders)
        {
            GameObject orderItem = Instantiate(orderItemPrefab, orderListParent);
            orderItem.GetComponentInChildren<TextMeshProUGUI>().text = order.ItemName + " x" + order.Quantity;
            orderItem.GetComponentInChildren<Image>().sprite = order.ItemImage;

            Debug.Log($"Order created with ItemId22222: {order.ItemId}");

        }
        //총 가격 표시
        int totalCost = orderPaper.TotalCost(OrdersTable.orders);
        totalCostText.text = totalCost.ToString();
        //Debug.Log("총 가격 표시");

        Debug.Log("디플 마지막" + OrdersTable.orders.Count);

    }

}
