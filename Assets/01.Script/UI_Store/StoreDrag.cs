//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using JinnyBuilding;
//using JinnyFarm;
//using JinnyAnimal;

////by.J:230725 상점 드래그
////by.J:230811 상점 아이템 배치 완료 시 재화 차감
//public class StoreDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//    private Camera mainCamera;                  //메인 카메라
//    public Image itemImage;                     //아이템 이미지
//    private GameObject clone;                   //드래그 중인 건물 복제본
//    public GameObject currentPrefab;            //배치할 아이템 프리팹

//    private BuildingDataInfo currentBuildingData = new BuildingDataInfo(); //현재 설정 건물 데이터
//    //private FarmDataInfo currentFarmData = new FarmDataInfo();             //현재 설정 농장밭 데이터
//    //private AnimalDataInfo currentAnimalData = new AnimalDataInfo();       //현재 설정 동물 데이터

//    private void Awake()
//    {
//        mainCamera = Camera.main; //메인 카메라 가져오기
//    }

//    //드래그 시작시
//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        //Debug.Log("순서 확인 : 드래그 ");
//        //Debug.Log("OnBeginDrag: " + currentBuildingData.buildingName);

//        if (currentPrefab != null)
//        {
//            //건물 복제본 생성 및 초기화
//            clone = Instantiate(currentPrefab);
//            clone.transform.position = GetWorldPosition(eventData);

//            //복제본 스프라이트 렌더러 설정
//            SpriteRenderer cloneSpriteRenderer = clone.GetComponent<SpriteRenderer>();
//            if (cloneSpriteRenderer != null)
//            {
//                cloneSpriteRenderer.sprite = itemImage.sprite;
//            }

//            Debug.Log("슬롯에서 드래그 시작: " + gameObject.name + " 빌딩 가격: " + currentBuildingData.buildingCost);
//            Debug.Log("드래그중인 건물 현재 가격: " + JsonUtility.ToJson(currentBuildingData));

//        }
//    }

//    //드래그 중
//    public void OnDrag(PointerEventData eventData)
//    {
//        //Debug.Log("OnDrag: " + currentBuildingData.buildingName);

//        if (clone != null)
//        {
//            //복제본 마우스 따라 이동
//            clone.transform.position = GetWorldPosition(eventData);
//        }
//    }

//    //드래그 끝난 후
//    public void OnEndDrag(PointerEventData eventData)
//    {

//        if (clone != null)
//        {
//            //드래그가 끝나면 복제본 게임 오브젝트로 존재
//            clone = null;

//            Debug.Log("현재 빌딩 가격" + currentBuildingData.buildingCost);
//            MoneySystem.Instance.DeductGold(currentBuildingData.buildingCost);
//        }
//    }

//    private Vector3 GetWorldPosition(PointerEventData eventData)
//    {
//        //마우스의 스크린 위치를 월드 위치로 변환
//        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
//        worldPosition.z = 0; //2D 게임이라 z 좌표 0으로 설정
//        return worldPosition;
//    }
//}
