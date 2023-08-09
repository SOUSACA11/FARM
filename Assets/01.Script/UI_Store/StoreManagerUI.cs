using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230724 상점 창 클릭시 활성화 / 메뉴 버튼 비활성화 / 닫기 버튼 / 상점 아이템 읽기
//by.J:230724 상점 탭 UI 설정 추가
//by.J:230809 상점 아이템 살 경우 상점 창 아래로 내리고 배치 완료 할 경우 원위치
public class StoreManagerUI : MonoBehaviour
{
    public Image image;          //움직일 이미지 
    public Vector3 endPosition;  //마지막 이동 위치
    public float speed = 120f;   //이동 속도

    public Button closeButton;   //닫기 버튼

    public Button inviButton1;   //비활성화 할 버튼 1번
    public Button inviButton2;   //비활성화 할 버튼 2번
    public Button inviButton3;   //비활성화 할 버튼 3번

    private Vector3 startPosition; //시작위치

            
    public GameObject storeItemPrefab;         // 상점 아이템 UI 프리팹
    public Transform storeItemsParent;         // 상점 아이템들을 담을 부모 오브젝트
    public ItemDic itemDic;                   // 아이템 정보를 가진 ItemDic 클래스
    private Dictionary<string, object> items; // 아이템 정보를 담은 사전

    List<StoreItemUI> storeItems = new List<StoreItemUI>(); // 상점 아이템 객체들을 저장할 리스트
    private void Start() //처음은 빌딩아이템 보여지도록 세팅
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
                    // Instantiate = 게임 실행 중 게임 오브젝트 생성
                    var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
                    // 가져온 컴포넌트에 아이템 정보를 설정
                    shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage);
                   // Debug.Log($"Item Name: {data.buildingName}, Item Cost: {data.buildingCost}");
                   // Debug.Log($"SetInfo called with: {data.buildingName}, {data.buildingCost}, {data.buildingImage.name}");

                    storeItems.Add(shopItem); // 리스트에 객체 추가
                }
               
            }
        }
    }
        public void CloseButtonOnClick()
    {
        //메뉴 버튼 비활성화, 닫기 버튼 활성화
        image.transform.position = startPosition;
        inviButton1.gameObject.SetActive(true);
        inviButton2.gameObject.SetActive(true);
        inviButton3.gameObject.SetActive(true);
    }
    public void StoreButton_Click()
    {
        //상점 창 기능 활성화
        StartCoroutine(MoveImageUp());

        //메뉴 버튼 비활성화
        inviButton1.gameObject.SetActive(false);
        inviButton2.gameObject.SetActive(false);
        inviButton3.gameObject.SetActive(false);
    }

    //밖에 있는 상점 창 화면상 배치
    IEnumerator MoveImageUp()
    {

        //처음 y값    : -846
        //마지막 y값  : 318

        float t = 0f; // 시간 변수

        Vector3 startPosition = image.transform.position;  // 시작 위치 저장

        endPosition = new Vector3(948, image.rectTransform.position.y + 1150, 0); //마지막 위치 저장

        while (t < 1f) // t가 1이 될 때까지
        {
            if (image.rectTransform.position.y >= 318) //y값이 318 이상이면 멈춤
            {
                yield break;
            }

            t += Time.deltaTime * speed; // 시간 누적

            // Lerp를 이용해 현재 위치에서 endPosition까지 부드럽게 이동
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; // 프레임 간격대로 실행

        }
    }
    

    public void BottomStore_Click()
    {
        StartCoroutine(MoveImageBottom());
    }

    //화면상 배치된 상점 창 아래로 내리기
    IEnumerator MoveImageBottom()
    {
        //y값 : -191
        //Debug.Log("상점 창 내리기 시그널");
        float t = 0f; // 시간 변수

        Vector3 startPosition = image.transform.position;  // 시작 위치 저장

        endPosition = new Vector3(948, image.rectTransform.position.y - 480, 0); //마지막 위치 저장

        while (t < 1f) // t가 1이 될 때까지
        {
            if (image.rectTransform.position.y >= 2000) //y값 2000 이상이면 멈춤
            {
                yield break;
            }

            t += Time.deltaTime * speed; // 시간 누적

            // Lerp를 이용해 현재 위치에서 endPosition까지 부드럽게 이동
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; // 프레임 간격대로 실행

        }
    }

    public void TopStore_Click()
    {
        StartCoroutine(MoveImageTop());
    }

    //화면상 배치된 상점 창 위로 올리기
    IEnumerator MoveImageTop()
    {
        //Debug.Log("상점 창 올리기 시그널");
        float t = 0f; // 시간 변수

        Vector3 startPosition = image.transform.position;  // 시작 위치 저장

        endPosition = new Vector3(948, image.rectTransform.position.y + 480, 0); //마지막 위치 저장

        while (t < 1f) // t가 1이 될 때까지
        {
            if (image.rectTransform.position.y >= 2000) //y값 2000 이상이면 멈춤
            {
                yield break;
            }

            t += Time.deltaTime * speed; // 시간 누적

            // Lerp를 이용해 현재 위치에서 endPosition까지 부드럽게 이동
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; // 프레임 간격대로 실행

        }
    }

    //빌딩 탭
    public void TabBuildingItem()
    {
        TabClearItem();
        var buildingList = (List<BuildingDataInfo>)items["건물"];
        foreach (var data in buildingList)
        {
            var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
            shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage); ////, data.buildingPrefab);
            //shopItems.Add(shopItem); // 리스트에 객체 추가
        }
    }

    //농장밭 탭
    public void TabFarmitem()
    {
        TabClearItem();
        var farmList = (List<FarmDataInfo>)items["농장밭"];
        foreach (var data in farmList)
        {
            var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
            shopItem.SetInfo(data.farmName, data.farmCost, data.farmImage);

        }
    }

    //동물 탭
    public void TabAnimalitem()
    {
        TabClearItem();
        var farmList = (List<AnimalDataInfo>)items["동물"];
        foreach (var data in farmList)
        {
            var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
            shopItem.SetInfo(data.animalName, data.animalCost, data.animalImage);
        }
    }

    //Storeitem 태그 아이템 지우기
    public void TabClearItem()
    {
        foreach (Transform child in storeItemsParent)
        {
            if (child.CompareTag("StoreItem"))
            {
                Destroy(child.gameObject);
            }
        }
    }

}
