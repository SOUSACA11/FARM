using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230810 상점 슬롯 정보
public class StoreSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera mainCamera;                  //메인 카메라
    public Image itemImage;                     //아이템 이미지
    public TextMeshProUGUI itemName;            //아이템 이름
    public TextMeshProUGUI itemCost;            //아이템 가격
    public GameObject currentPrefab;            //배치할 아이템 프리팹
    private GameObject clone;                   //드래그 중인 건물 복제본
    private SpriteRenderer itemSpriteRenderer;  //아이템 스프라이트 렌더러 이미지
    public BuildingType currentBuildingType;    //건물 타입

    private BuildingDataInfo currentBuildingData = new BuildingDataInfo(); //현재 설정 건물 데이터
    private FarmDataInfo currentFarmData = new FarmDataInfo();             //현재 설정 농장밭 데이터
    private AnimalDataInfo currentAnimalData = new AnimalDataInfo();       //현재 설정 동물 데이터

    private void Awake()
    {
        mainCamera = Camera.main; //메인 카메라 가져오기
        itemSpriteRenderer = GetComponent<SpriteRenderer>(); //스프라이트 렌더러 가져오기
    }

    //빌딩 정보
    public void SetSlotBuilding(BuildingDataInfo buildingData)
    {
        //Debug.Log("SetSlotBuilding 되나염 " + buildingData.buildingName);

        itemName.text = buildingData.buildingName;
        itemCost.text = buildingData.buildingCost.ToString();
        itemImage.sprite = buildingData.buildingImage;
        currentBuildingType = buildingData.buildingType;

        if (itemSpriteRenderer != null) //스프라이트 렌더러가 있다면 스프라이트 설정
        {
            itemSpriteRenderer.sprite = buildingData.buildingImage;
            currentPrefab = buildingData.buildingPrefab; 
        }

        currentBuildingData = buildingData; // currentBuildingDat 업데이트
        Debug.Log("빌딩 가격 불러오기 성공 " + buildingData.buildingCost);///
        Debug.Log("슬롯에서 빌딩정보 " + gameObject.name + " 빌딩 가격: " + buildingData.buildingCost);///
        Debug.Log("현재 빌딩가격" + currentBuildingData.buildingCost);///
    }

    //농장밭 정보
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

        currentFarmData = farmData; // currentFarmData 업데이트
        //Debug.Log("농장 가격 불러오기 성공 " + farmData.farmCost);
    }

    //동물 정보
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

        currentAnimalData = animalData; // currentAnimalData 업데이트
        //Debug.Log("동물 가격 불러오기 성공 " + animalData.animalCost);
    }

    //드래그 시작시
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("순서 확인 : 드래그 ");
        //Debug.Log("OnBeginDrag: " + currentBuildingData.buildingName);

        if (currentPrefab != null)
        {
            //건물 복제본 생성 및 초기화
            clone = Instantiate(currentPrefab);
            clone.transform.position = GetWorldPosition(eventData);

            //복제본 스프라이트 렌더러 설정
            SpriteRenderer cloneSpriteRenderer = clone.GetComponent<SpriteRenderer>();
            if (cloneSpriteRenderer != null)
            {
                cloneSpriteRenderer.sprite = itemImage.sprite;
            }

            //Debug.Log("슬롯에서 드래그 시작: " + gameObject.name + " 빌딩 가격: " + currentBuildingData.buildingCost);
            //Debug.Log("드래그중인 건물 현재 가격: " + JsonUtility.ToJson(currentBuildingData));

        }
    }

    //드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag: " + currentBuildingData.buildingName);

        if (clone != null)
        {
            //복제본 마우스 따라 이동
            clone.transform.position = GetWorldPosition(eventData);
        }
    }

    //드래그 끝난 후
    public void OnEndDrag(PointerEventData eventData)
    {

        if (clone != null)
        {
            WorkBuilding workBuilding = clone.GetComponent<WorkBuilding>();
            if (workBuilding != null)
            {
                workBuilding.buildingType = currentBuildingType; //복제본 건물 타입 배정
            }

            //드래그가 끝나면 복제본 게임 오브젝트로 존재
            clone = null;

            //Debug.Log("현재 빌딩 가격" + currentBuildingData.buildingCost);
            MoneySystem.Instance.DeductGold(currentBuildingData.buildingCost);
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

