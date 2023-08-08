using UnityEngine.UI;
using UnityEngine;
using TMPro;

//by.J:230724 상점UI 설정 도움
public class StoreItemUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText; // 아이템 이름을 표시할 텍스트 컴포넌트
    public TextMeshProUGUI itemCostText; // 아이템 가격을 표시할 텍스트 컴포넌트
    public Image itemImage;             // 아이템 이미지를 표시할 이미지 컴포넌트

    ////public GameObject itemPrefab; // 이 아이템에 대한 프리팹

    // 아이템 정보를 UI에 설정하는 메서드
    public void SetInfo(string itemName, int itemCost, Sprite itemSprite) ////, GameObject prefab)
    {
        itemNameText.text = itemName;            // 아이템 이름 설정
        itemCostText.text = itemCost.ToString(); // 아이템 가격 설정
        itemImage.sprite = itemSprite;           // 아이템 이미지 설정


        ////itemPrefab = prefab; // 아이템에 대한 프리팹을 설정

        ////// 아이템 프리팹의 SpriteRenderer에도 동일한 스프라이트를 설정
        ////SpriteRenderer prefabSpriteRenderer = itemPrefab.GetComponent<SpriteRenderer>();
        ////if (prefabSpriteRenderer != null)
        ////{
        ////    prefabSpriteRenderer.sprite = itemSprite;
        ////}

        // 강제로 UI를 갱신하는 코드
        //Canvas.ForceUpdateCanvases();
    }
}