using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230810 ���� ���� ���� / �巡�� �� ������ ���ӿ� ��ġ (��ũ��Ʈ ���� by.J:230725 ���� �巡�� )
public class StoreSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image itemImage;                     //������ �̹���
    public TextMeshProUGUI itemName;            //������ �̸�
    public TextMeshProUGUI itemCost;            //������ ����
    public GameObject currentPrefab;            //��ġ�� ������ ������
    private SpriteRenderer itemSpriteRenderer;  //������ ��������Ʈ ������ �̹���

    private Camera mainCamera;        //���� ī�޶�
    private GameObject buildingClone; //�巡�� ���� �ǹ� ������

    private void Awake()
    {
        mainCamera = Camera.main; //���� ī�޶� ��������
        itemSpriteRenderer = GetComponent<SpriteRenderer>(); //��������Ʈ ������ ��������
    }

    public void SetSlotBuilding(BuildingDataInfo buildingData) //���� ����
    {
        itemName.text = buildingData.buildingName;
        itemCost.text = buildingData.buildingCost.ToString();
        itemImage.sprite = buildingData.buildingImage;

        if (itemSpriteRenderer != null) //��������Ʈ �������� �ִٸ� ��������Ʈ ����
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

        if (itemSpriteRenderer != null) //��������Ʈ �������� �ִٸ� ��������Ʈ ����
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

        if (itemSpriteRenderer != null) //��������Ʈ �������� �ִٸ� ��������Ʈ ����
        {
            itemSpriteRenderer.sprite = animalData.animalImage;
            currentPrefab = animalData.animalPrefab;
        }
    }



    public void OnBeginDrag(PointerEventData eventData) //�巡�� ���۽�
    {
        if (currentPrefab != null)
        {
            //�ǹ� ������ ���� �� �ʱ�ȭ
            buildingClone = Instantiate(currentPrefab);
            buildingClone.transform.position = GetWorldPosition(eventData);

            //������ ��������Ʈ ������ ����
            SpriteRenderer cloneSpriteRenderer = buildingClone.GetComponent<SpriteRenderer>();
            if (cloneSpriteRenderer != null)
            {
                cloneSpriteRenderer.sprite = itemImage.sprite;
            }
        }
    }

    public void OnDrag(PointerEventData eventData) //�巡�� ��
    {
        if (buildingClone != null)
        {
            //������ ���콺 ���� �̵�
            buildingClone.transform.position = GetWorldPosition(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData) //�巡�� ���� ��
    {
        if (buildingClone != null)
        {
            //�巡�װ� ������ ������ ���� ������Ʈ�� ����
            buildingClone = null;
        }
    }

    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        //���콺�� ��ũ�� ��ġ�� ���� ��ġ�� ��ȯ
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; //2D �����̶� z ��ǥ 0���� ����
        return worldPosition;
    }
}