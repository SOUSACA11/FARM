using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230810 ���� ���� ���� / ���� �ǹ� �巡��
//by.J:230817 �ǹ� �巡�� �� ���� Ȱ��ȭ
public class StoreSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera mainCamera;                  //���� ī�޶�
    public Image itemImage;                     //������ �̹���
    public TextMeshProUGUI itemName;            //������ �̸�
    public TextMeshProUGUI itemCost;            //������ ����
    public GameObject currentPrefab;            //��ġ�� ������ ������
    private GameObject clone;                   //�巡�� ���� �ǹ� ������
    private SpriteRenderer itemSpriteRenderer;  //������ ��������Ʈ ������ �̹���
    public BuildingType currentBuildingType;    //�ǹ� Ÿ��

    private BuildingDataInfo currentBuildingData = new BuildingDataInfo(); //���� ���� �ǹ� ������
    private FarmDataInfo currentFarmData = new FarmDataInfo();             //���� ���� ����� ������
    private AnimalDataInfo currentAnimalData = new AnimalDataInfo();       //���� ���� ���� ������

    private void Awake()
    {
        mainCamera = Camera.main; //���� ī�޶� ��������
        itemSpriteRenderer = GetComponent<SpriteRenderer>(); //��������Ʈ ������ ��������
    }

    //���� ����
    public void SetSlotBuilding(BuildingDataInfo buildingData)
    {
        //Debug.Log("SetSlotBuilding �ǳ��� " + buildingData.buildingName);

        itemName.text = buildingData.buildingName;
        itemCost.text = buildingData.buildingCost.ToString();
        itemImage.sprite = buildingData.buildingImage;
        currentBuildingType = buildingData.buildingType;

        if (itemSpriteRenderer != null) //��������Ʈ �������� �ִٸ� ��������Ʈ ����
        {
            itemSpriteRenderer.sprite = buildingData.buildingImage;
            currentPrefab = buildingData.buildingPrefab; 
        }

        currentBuildingData = buildingData; // currentBuildingDat ������Ʈ
        Debug.Log("���� ���� �ҷ����� ���� " + buildingData.buildingCost);///
        Debug.Log("���Կ��� �������� " + gameObject.name + " ���� ����: " + buildingData.buildingCost);///
        Debug.Log("���� ��������" + currentBuildingData.buildingCost);///
    }

    //����� ����
    public void SetSlotFarm(FarmDataInfo farmData)
    {
        itemName.text = farmData.farmName;
        itemCost.text = farmData.farmCost.ToString();
        itemImage.sprite = farmData.farmImage;

        if (itemSpriteRenderer != null) //��������Ʈ �������� �ִٸ� ��������Ʈ ����
        {
            itemSpriteRenderer.sprite = farmData.farmImage;
            currentPrefab = farmData.farmPrefab;
        }

        currentFarmData = farmData; // currentFarmData ������Ʈ
        //Debug.Log("���� ���� �ҷ����� ���� " + farmData.farmCost);
    }

    //���� ����
    public void SetSlotAnimal(AnimalDataInfo animalData)
    {
        itemName.text = animalData.animalName;
        itemCost.text = animalData.animalCost.ToString();
        itemImage.sprite = animalData.animalImage;

        if (itemSpriteRenderer != null) //��������Ʈ �������� �ִٸ� ��������Ʈ ����
        {
            itemSpriteRenderer.sprite = animalData.animalImage;
            currentPrefab = animalData.animalPrefab;
        }

        currentAnimalData = animalData; //currentAnimalData ������Ʈ
        //Debug.Log("���� ���� �ҷ����� ���� " + animalData.animalCost);
    }

    // *�巡�� ���*

    //�巡�� ���۽�
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("���� Ȯ�� : �巡�� ");
        //Debug.Log("OnBeginDrag: " + currentBuildingData.buildingName);

        if (currentPrefab != null)
        {
            //�ǹ� ������ ���� �� �ʱ�ȭ
            clone = Instantiate(currentPrefab);
            clone.transform.position = GetWorldPosition(eventData);

            //������ ��������Ʈ ������ ����
            SpriteRenderer cloneSpriteRenderer = clone.GetComponent<SpriteRenderer>();
            if (cloneSpriteRenderer != null)
            {
                cloneSpriteRenderer.sprite = itemImage.sprite;
            }
            BoxColliderSize(clone);
            //Debug.Log("���Կ��� �巡�� ����: " + gameObject.name + " ���� ����: " + currentBuildingData.buildingCost);
            //Debug.Log("�巡������ �ǹ� ���� ����: " + JsonUtility.ToJson(currentBuildingData));
        }
    }

    //�巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag: " + currentBuildingData.buildingName);

        if (clone != null)
        {
            Vector3 mousePosition = GetWorldPosition(eventData);
            clone.transform.position = GridSnap(mousePosition);
        }
    }

    //�巡�� ���� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        if (clone != null)
        {
            WorkBuilding workBuilding = clone.GetComponent<WorkBuilding>();

            if (clone != null)
            {
                Vector3 mousePosition = GetWorldPosition(eventData);
                clone.transform.position = GridSnap(mousePosition);
            }

                //�巡�װ� ������ ������ ���� ������Ʈ�� ����
                clone = null;

            //Debug.Log("���� ���� ����" + currentBuildingData.buildingCost);
            MoneySystem.Instance.DeductGold(currentBuildingData.buildingCost);
        }
    }

    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        //���콺�� ��ũ�� ��ġ�� ���� ��ġ�� ��ȯ
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; //2D �����̶� z ��ǥ 0���� ����
        return worldPosition;
    }

    //���� ���
    private Vector3 GridSnap(Vector3 position)
    {
        int xCount = Mathf.RoundToInt(position.x);
        int yCount = Mathf.RoundToInt(position.y);
        int zCount = Mathf.RoundToInt(position.z);

        return new Vector3(xCount, yCount, zCount);
    }

    //�ڽ� �ݶ��̴� 
    private void BoxColliderSize(GameObject buildingClone)
    {
        //��������Ʈ ������ ��������
        SpriteRenderer spriteRenderer = buildingClone.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return; 

        //BoxCollider2D�� �������ų�, ������ �߰�
        BoxCollider2D collider = buildingClone.GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = buildingClone.AddComponent<BoxCollider2D>();
        }

        //Box Collider�� ũ�⸦ SpriteRenderer�� bounds ũ��� ����
        collider.size = spriteRenderer.bounds.size;
    }
}

