using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

//by.J:230814 주문서 표시 UI / 리셋 버튼
//by.J:230816 주문 클릭 후 납부시 재화증가
//by.J:230817 주문서 클릭시 효과 적용
public class OrderSlotManagerUI : MonoBehaviour
{
    public OrderPaper orderPaper;
    public GameObject orderItemPrefab;    //주문 아이템을 표시하기 위한 프리팹
    public Transform orderListParent;     //주문 아이템들을 자식으로 가질 부모 위치
    public TextMeshProUGUI totalCostText; //주문서 총 가격
    public GameObject orderSheetPrefab;   //주문서 총 UI 프리팹

    private int currentOrderCount = 0;            //현재 주문서 개수
    private static GameObject selectedOrderPaper; //현재 선택된 주문서 / 같은 변수 공유하도록 static

    private Vector3 originalOrderSize;  //주문서의 원래 크기
    public float enlargedScale = 0.5f;  //크게 할 때의 스케일 값

    private void Start()
    {
        // 초기 설정 시 주문서의 원래 크기 저장
        originalOrderSize = orderPaper.transform.localScale;
    }

    private void Update()
    {
        //마우스 클릭, 터치시 UI 오브젝트 아닐경우 원래 크기대로
        if (IsInputDetected() && !IsPointerOverUIObject())
        {
            if (selectedOrderPaper != null)
            {
                ResetOrderSize(selectedOrderPaper);
                selectedOrderPaper = null;
            }
        }
    }


    //주문서 표시
    public void TriggerOrder()
    {
        MultipleOrder(3);
    }

    //랜덤 아이템 발동
    public void TriggerRandomOrder()
    {
        DisplayOrder();
    }

    //주문서
    public void DisplayOrder()
    {
        //주문서 생성
        List<Order> orders = orderPaper.RandomOrder(3); //아이템 3개 배정

        //기존 주문 아이템 UI 삭제
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
            //Debug.Log("기존 주문 삭제");
        }
        //새 주문 아이템 UI 생성
        foreach (var order in orders)
        {
            GameObject orderItem = Instantiate(orderItemPrefab, orderListParent);
            orderItem.GetComponentInChildren<TextMeshProUGUI>().text = order.ItemName + " x" + order.Quantity;
            orderItem.GetComponentInChildren<Image>().sprite = order.ItemImage;
            //Debug.Log("새 주문 생성");
        }
        //총 가격 표시
        int totalCost = orderPaper.TotalCost(orders);
        totalCostText.text = totalCost.ToString();
        //Debug.Log("총 가격 표시");
    }

    //주문서 여러개
    public void MultipleOrder(int count)
    {
        //최대 3개까지만 생성
        if (currentOrderCount >= 3)
        {
            //Debug.Log("이미 최대 주문서를 생성했습니다.");
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
            //복제된 오브젝트 활성화
            orderSheet.SetActive(true);
        }

        currentOrderCount += count;  //주문서를 생성한 후 현재 주문서 수를 증가

        //현재 주문서 수가 3개 이상이면 3개로 설정
        if (currentOrderCount > 3)
            currentOrderCount = 3;

        //Debug.Log("되나");
    }

    //리셋 버튼
    public void ResetOrder()
    {
        //모든 주문서 오브젝트 삭제
        foreach (Transform child in orderListParent)
        {
            Destroy(child.gameObject);
        }

        //현재 주문서 개수 초기화
        currentOrderCount = 0;
    }

    //주문서 선택
    public void SelectOrder(GameObject orderPaper)
    {
        //Debug.Log("선택 주문서");
        //Debug.Log("주문서 선택쓰" + selectedOrderPaper);

        //이전 선택 주문서와 클릭 주문서 같을 경우
        if (selectedOrderPaper == orderPaper)
        {
            //주문서 크기 원래대로 후 선택 해제
            ResetOrderSize(orderPaper);
            selectedOrderPaper = null;
        }
        else
        {
            //이전 선택 주문서 크기 원래대로
            if (selectedOrderPaper != null)
            {
                ResetOrderSize(selectedOrderPaper);
            }

            //새로운 주문서 선택 및 크기 증가
            selectedOrderPaper = orderPaper;
            EnlargeOrderSize(orderPaper);
        }
    }

    //납부하기 버튼
    public void PayButtonClick()
    {
        //Debug.Log("납부하기 버튼 클릭");
        //Debug.Log("selectedOrderPaper 값: " + selectedOrderPaper);
        if (selectedOrderPaper != null)
        {
            //Debug.Log("selectedOrderPaper는 null이 아닙니다.");

            TextMeshProUGUI totalCostText = selectedOrderPaper.transform.Find("gold count").GetComponent<TextMeshProUGUI>();
            //Debug.Log("ㅋ" + totalCostText);

            if (totalCostText == null)
            {
                //Debug.Log("costText는 null입니다." + totalCostText);
                return;
            }

            //Debug.Log("총 가격: " + totalCostText.text);
            int cost = int.Parse(totalCostText.text); //텍스트에서 비용 추출
            MoneySystem.Instance.AddGold(cost);       //재화 증가
            Destroy(selectedOrderPaper);              //납부한 주문서 삭제
            selectedOrderPaper = null;                //선택 초기화
        }

    }

    //주문서 크기 증가
    private void EnlargeOrderSize(GameObject orderPaper)
    {
        orderPaper.transform.localScale = originalOrderSize * enlargedScale;
    }

    //주문서 크기 원래대로
    private void ResetOrderSize(GameObject orderPaper)
    {
        orderPaper.transform.localScale = originalOrderSize;
    }



    //마우스 클릭, 터치 감지
    private bool IsInputDetected()
    {
        //마우스 클릭
        if (Input.GetMouseButtonDown(0))
            return true;

        //터치 입력
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        return false;
    }

    //마우스 포인터, 터치가 UI 오브젝트 위에 있는지 확인
    private bool IsPointerOverUIObject()
    {
        //마우스 포지션
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}