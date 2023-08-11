//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using JinnyBuilding;
//using JinnyFarm;
//using JinnyAnimal;

////by.J:230725 ���� �巡��
////by.J:230811 ���� ������ ��ġ �Ϸ� �� ��ȭ ����
//public class StoreDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//    private Camera mainCamera;                  //���� ī�޶�
//    public Image itemImage;                     //������ �̹���
//    private GameObject clone;                   //�巡�� ���� �ǹ� ������
//    public GameObject currentPrefab;            //��ġ�� ������ ������

//    private BuildingDataInfo currentBuildingData = new BuildingDataInfo(); //���� ���� �ǹ� ������
//    //private FarmDataInfo currentFarmData = new FarmDataInfo();             //���� ���� ����� ������
//    //private AnimalDataInfo currentAnimalData = new AnimalDataInfo();       //���� ���� ���� ������

//    private void Awake()
//    {
//        mainCamera = Camera.main; //���� ī�޶� ��������
//    }

//    //�巡�� ���۽�
//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        //Debug.Log("���� Ȯ�� : �巡�� ");
//        //Debug.Log("OnBeginDrag: " + currentBuildingData.buildingName);

//        if (currentPrefab != null)
//        {
//            //�ǹ� ������ ���� �� �ʱ�ȭ
//            clone = Instantiate(currentPrefab);
//            clone.transform.position = GetWorldPosition(eventData);

//            //������ ��������Ʈ ������ ����
//            SpriteRenderer cloneSpriteRenderer = clone.GetComponent<SpriteRenderer>();
//            if (cloneSpriteRenderer != null)
//            {
//                cloneSpriteRenderer.sprite = itemImage.sprite;
//            }

//            Debug.Log("���Կ��� �巡�� ����: " + gameObject.name + " ���� ����: " + currentBuildingData.buildingCost);
//            Debug.Log("�巡������ �ǹ� ���� ����: " + JsonUtility.ToJson(currentBuildingData));

//        }
//    }

//    //�巡�� ��
//    public void OnDrag(PointerEventData eventData)
//    {
//        //Debug.Log("OnDrag: " + currentBuildingData.buildingName);

//        if (clone != null)
//        {
//            //������ ���콺 ���� �̵�
//            clone.transform.position = GetWorldPosition(eventData);
//        }
//    }

//    //�巡�� ���� ��
//    public void OnEndDrag(PointerEventData eventData)
//    {

//        if (clone != null)
//        {
//            //�巡�װ� ������ ������ ���� ������Ʈ�� ����
//            clone = null;

//            Debug.Log("���� ���� ����" + currentBuildingData.buildingCost);
//            MoneySystem.Instance.DeductGold(currentBuildingData.buildingCost);
//        }
//    }

//    private Vector3 GetWorldPosition(PointerEventData eventData)
//    {
//        //���콺�� ��ũ�� ��ġ�� ���� ��ġ�� ��ȯ
//        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
//        worldPosition.z = 0; //2D �����̶� z ��ǥ 0���� ����
//        return worldPosition;
//    }
//}
