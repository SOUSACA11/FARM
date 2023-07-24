using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

////by.J:230724 건물 상점 UI
public class BuildUI : MonoBehaviour
{
    public Text itemNameText; // 아이템 이름을 표시할 Text 컴포넌트
    public Text itemPriceText; // 아이템 가격을 표시할 Text 컴포넌트
    public GameObject storePanel; // 상점 패널
    public Button purchaseButton; // 구매 버튼

    private ItemDic itemDic;
    private string selectedItem;

    private void Start()
    {
        itemDic = FindObjectOfType<ItemDic>(); // 아이템 사전 참조 가져오기

        // 구매 버튼에 클릭 이벤트 추가
        purchaseButton.onClick.AddListener(PurchaseItem);
    }

    public void ShowItem(string itemType)
    {
        selectedItem = itemType;

        // 아이템 이름과 가격을 UI에 표시하기
        // 이 부분은 실제 게임에 따라 달라질 수 있음
        // itemType에 따라 해당 아이템의 이름과 가격을 가져와야 함
        itemNameText.text = itemType;
        itemPriceText.text = "가격";
    }

    public void PurchaseItem()
    {
        // 구매 로직
        // 이 부분은 실제 게임의 구매 로직에 따라 달라질 수 있음
        Debug.Log(selectedItem + " 구매!");
    }
}


    //public GameObject storePanel;  // 상점 패널 참조
    //public Button openStoreButton; // 상점 열기 버튼 참조
    //public Button closeStoreButton; // 상점 닫기 버튼 참조
    //public Transform itemListPanel; // 아이템 리스트 패널 참조
    //public GameObject itemPrefab; // 아이템 버튼 Prefab 참조

    //// 임시 아이템 리스트
    //private List<string> items = new List<string>() { "item1", "item2", "item3" };

    //private void Start()
    //{
    //    // 버튼에 클릭 리스너 추가
    //    openStoreButton.onClick.AddListener(OpenStore);
    //    closeStoreButton.onClick.AddListener(CloseStore);

    //    // 초기 상태에서는 상점 패널을 숨김
    //    storePanel.SetActive(false);

    //    // 아이템 리스트 초기화
    //    InitItemList();
    //}

    //// 상점 열기 버튼을 누를 시 호출되는 함수
    //public void OpenStore()
    //{
    //    // 상점 패널 활성화
    //    storePanel.SetActive(true);
    //}

    //// 상점 닫기 기능 (이를 호출하는 버튼이 필요)
    //public void CloseStore()
    //{
    //    // 상점 패널 비활성화
    //    storePanel.SetActive(false);
    //}

    //// 아이템 리스트 초기화
    //private void InitItemList()
    //{
    //    foreach (string item in items)
    //    {
    //        GameObject itemButton = Instantiate(itemPrefab, itemListPanel);
    //        itemButton.GetComponentInChildren<Text>().text = item;
    //        itemButton.GetComponent<Button>().onClick.AddListener(() => PurchaseItem(item));
    //    }
    //}

    //// 아이템 구매 기능
    //private void PurchaseItem(string item)
    //{
    //    Debug.Log($"{item}을(를) 구매했습니다.");
    //    // 실제 구매 기능 구현 필요.
    //}

