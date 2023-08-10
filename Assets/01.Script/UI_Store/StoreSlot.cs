using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230810 상점 슬롯 정보 / 드래그 시 복제본 게임에 배치 (스크립트 통합 by.J:230725 상점 드래그 )
public class StoreSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image itemImage;                     //아이템 이미지
    public TextMeshProUGUI itemName;            //아이템 이름
    public TextMeshProUGUI itemCost;            //아이템 가격
    public GameObject currentPrefab;            //배치할 아이템 프리팹
    private SpriteRenderer itemSpriteRenderer;  //아이템 스프라이트 렌더러 이미지

    private Camera mainCamera;        //메인 카메라
    private GameObject buildingClone; //드래그 중인 건물 복제본

    private void Awake()
    {
        mainCamera = Camera.main; //메인 카메라 가져오기
        itemSpriteRenderer = GetComponent<SpriteRenderer>(); //스프라이트 렌더러 가져오기
    }

    public void SetSlotBuilding(BuildingDataInfo buildingData) //빌딩 정보
    {
        itemName.text = buildingData.buildingName;
        itemCost.text = buildingData.buildingCost.ToString();
        itemImage.sprite = buildingData.buildingImage;

        if (itemSpriteRenderer != null) //스프라이트 렌더러가 있다면 스프라이트 설정
        {
            itemSpriteRenderer.sprite = buildingData.buildingImage;
            currentPrefab = buildingData.buildingPrefab; 
        }

    }

    public void SetSlotFarm(FarmDataInfo farmData)
    {
        itemName.text = farmData.farmName;
        itemCost.text = farmData.farmCost.ToString();
        itemImage.sprite = farmData.farmImage;

        if (itemSpriteRenderer != null) //스프라이트 렌더러가 있다면 스프라이트 설정
        {
            itemSpriteRenderer.sprite = farmData.farmImage;
            currentPrefab = farmData.farmPrefab;
        }
    }

    public void SetSlotAnimal(AnimalDataInfo animalData)
    {
        itemName.text = animalData.animalName;
        itemCost.text = animalData.animalCost.ToString();
        itemImage.sprite = animalData.animalImage;

        if (itemSpriteRenderer != null) //스프라이트 렌더러가 있다면 스프라이트 설정
        {
            itemSpriteRenderer.sprite = animalData.animalImage;
            currentPrefab = animalData.animalPrefab;
        }
    }



    public void OnBeginDrag(PointerEventData eventData) //드래그 시작시
    {
        if (currentPrefab != null)
        {
            //건물 복제본 생성 및 초기화
            buildingClone = Instantiate(currentPrefab);
            buildingClone.transform.position = GetWorldPosition(eventData);

            //복제본 스프라이트 렌더러 설정
            SpriteRenderer cloneSpriteRenderer = buildingClone.GetComponent<SpriteRenderer>();
            if (cloneSpriteRenderer != null)
            {
                cloneSpriteRenderer.sprite = itemImage.sprite;
            }
        }
    }

    public void OnDrag(PointerEventData eventData) //드래그 중
    {
        if (buildingClone != null)
        {
            //복제본 마우스 따라 이동
            buildingClone.transform.position = GetWorldPosition(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData) //드래그 끝난 후
    {
        if (buildingClone != null)
        {
            //드래그가 끝나면 복제본 게임 오브젝트로 존재
            buildingClone = null;
        }
    }

    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        //마우스의 스크린 위치를 월드 위치로 변환
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; //2D 게임이라 z 좌표 0으로 설정
        return worldPosition;
    }
}