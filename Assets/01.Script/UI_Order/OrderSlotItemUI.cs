using UnityEngine;
using TMPro;
using UnityEngine.UI;

//by.J:230830 OrderSlotManagerUI 스크립트 쪼개기 / 주문서 직접적인 동작 실행
//(by.J:230814 리셋 버튼)
//(by.J:230816 주문 클릭 후 납부시 재화증가)
//(by.J:230817 주문서 클릭시 효과 적용)
//9by.J:230830 주문서 클릭 후 납부시 창고 아이템 차감)
public class OrderSlotItemUI : MonoBehaviour
{
    //private TextMeshProUGUI itemNameText;
    private Image itemImage;
    private static GameObject selectedOrderPaper; //현재 선택된 주문서 / 같은 변수 공유하도록 static
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
        Debug.Log("선택 주문서");

        //이전 선택 주문서와 클릭 주문서 같을 경우
        if (selectedOrderPaper == orderPaper)
        {
            Debug.Log("에스");
            //주문서 크기 원래대로 후 선택 해제
            ResetOrderSize(orderPaper);
            selectedOrderPaper = null;
        }
        else
        {
            Debug.Log("노");
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

    //public void RemoveOrderItem()
    //{
    //    // 삭제 전에 부모 (OrderSlotManagerUI)에게 알릴 수도 있습니다.
    //    OrderSlotManagerUI01 manager = GetComponentInParent<OrderSlotManagerUI01>();
    //    if (manager != null)
    //    {
    //        manager.RemoveOrderItem(gameObject);
    //    }
    //}

}
