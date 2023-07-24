using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyCropItem;
using JinnyProcessItem;

//by.J:230724 클릭시 상점 창 활성화 / 메뉴 버튼 비활성화 / 닫기 버튼 / 상점 아이템 읽기
public class ShopManagerUI : MonoBehaviour
{
    public Image image;          //움직일 이미지 
    public Vector3 endPosition;  //마지막 이동 위치
    public float speed = 120f;   //이동 속도

    public Button closeButton;   //닫기 버튼

    public Button button1;      //비활성화 할 버튼 1번
    public Button button2;      //비활성화 할 버튼 2번
    public Button button3;      //비활성화 할 버튼 3번

    private Vector3 startPosition; //시작위치

            
    public GameObject shopItemPrefab;         // 상점 아이템 UI 프리팹
    public Transform shopItemsParent;         // 상점 아이템들을 담을 부모 오브젝트
    public ItemDic itemDic;                  // 아이템 정보를 가진 ItemDic 클래스
    private Dictionary<string, object> items; // 아이템 정보를 담은 사전


    private void Start()
    {
        //Debug.Log(image.rectTransform.position.x);
        //Debug.Log(image.rectTransform.position.y);

        closeButton.onClick.AddListener(CloseButtonOnClick);    //닫기 버튼 클릭
        startPosition = image.transform.position;               //시작 위치 설정

        itemDic = FindObjectOfType<ItemDic>(); // ItemDic 클래스를 찾아서 itemDic에 저장
        items = itemDic.Item;                  // ItemDic 클래스에 있는 Item 사전을 items에 저장


        foreach (var item in items) // 사전에 있는 모든 아이템에 대해서
        {
            if (item.Key == "건물")
            {
                foreach (var data in (List<BuildingDataInfo>)item.Value) // 아이템의 정보 리스트 순회
                {
                    // 상점 아이템 UI 프리팹을 생성하고 그 컴포넌트를 가져옴
                    var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
                    // 가져온 컴포넌트에 아이템 정보를 설정
                    shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage);
                }
            }
            else if (item.Key == "농장밭")
            {
                foreach (var data in (List<FarmDataInfo>)item.Value)
                {
                    var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
                    shopItem.SetInfo(data.farmName, data.farmCost, data.farmImage);
                }
            }

            else if (item.Key == "농장 생산품")
            {
                foreach (var data in (List<CropItemDataInfo>)item.Value)
                {
                    var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
                    shopItem.SetInfo(data.cropItemName, data.cropItemCost, data.cropItemImage);
                }
            }

            else if (item.Key == "가공 생산품")
            {
                foreach (var data in (List<ProcessItemDataInfo>)item.Value)
                {
                    var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
                    shopItem.SetInfo(data.processItemName, data.processItemCost, data.processItemImage);
                }
            }
        }
    }

        public void CloseButtonOnClick()
    {
        //메뉴 버튼 비활성화, 닫기 버튼 활성화
        image.transform.position = startPosition;
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
    }
    public void ShopButton_Click()
    {
        //상점 창 기능 활성화
        StartCoroutine(MoveImage());

        //메뉴 버튼 비활성화
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
    }

    IEnumerator MoveImage()
    {

        //처음 y값    : 287
        //마지막 y값  : -493

        float t = 0f; // 시간 변수

        Vector3 startPosition = image.transform.position;  // 시작 위치 저장

        endPosition = new Vector3(948, image.rectTransform.position.y + 780, 0); //마지막 위치 저장

        while (t < 1f) // t가 1이 될 때까지
        {
            if (image.rectTransform.position.y >= 287) //마지막 위치에 이동했다면 더이상 움직이지 않음
            {
                yield break;
            }

            t += Time.deltaTime * speed; // 시간 누적

            // Lerp를 이용해 현재 위치에서 endPosition까지 부드럽게 이동
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; // 프레임 간격대로 실행

        }
    }

    private void Update()
    {
        //Debug.Log(image.rectTransform.position.y);
    }
}
