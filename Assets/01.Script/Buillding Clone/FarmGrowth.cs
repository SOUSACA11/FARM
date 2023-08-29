using JinnyFarm;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using JinnyCropItem;

//by.J:230825 �ð� ����� ���� �̹��� �߰�(�۹� ����)
//by.J:230828 �ð� ����� �̹��� �ڵ� ��ȭ
//by.J:230829 ���� �Ϸ�� �� Ŭ���� �۹� ȹ��
public class FarmGrowth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;                      //����� �̹���
    public FarmDataInfo farmData;                               //���� ����� ������
    private GrowthFarmType currentStage = GrowthFarmType.Plant; //���� ������� ���� �ܰ�
    private float growthTimer = 1.0f;                           //����� ���� ���� Ÿ�̸�
    public Storage playerStorage;                               //â��

    private void Start()
    {
        //â�� ��������
        if (playerStorage == null)
        {
            playerStorage = Storage.Instance;
        }
        InitializeFromSelectedData();
    }

    public void InitializeFromSelectedData()
    {
        if (StoreSlot.SelectedFarmData != null)
        {
            FarmDataInfo selectedFarmData = StoreSlot.SelectedFarmData.Value;
            Initialize(selectedFarmData);
        }
    }

    //����� ���� ������ �ʱ�ȭ
    public void Initialize(FarmDataInfo data)
    {
        Debug.Log("����� ���� ������ �ʱ�ȭ");

        growthTimer = 0f; // �ʱ�ȭ
        this.farmData = data;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    //���� üũ
    private void Update()
    {
        growthTimer += Time.deltaTime;

        //Debug.Log("���� ���� üũ");

        //���� �ܰ� �����ϰ� ��������Ʈ�� ������Ʈ
        if (currentStage == GrowthFarmType.Plant && growthTimer >= farmData.farmGrowTime / 2)
        {
            currentStage = GrowthFarmType.Growth;
            UpdateSprite();
        }
        else if (currentStage == GrowthFarmType.Growth && growthTimer >= farmData.farmGrowTime)
        {
            currentStage = GrowthFarmType.Born;
            UpdateSprite();
        }

        //Debug.Log("����ð�" + growthTimer);
        //Debug.Log("����� ���� �ð�" + farmData.farmGrowTime);
    }

    //���� ���� �ܰ迡 ���� ��������Ʈ ����
    private void UpdateSprite()
    {
        //Debug.Log("���� ���� ����");

        if (spriteRenderer && farmData.farmImage.Length > (int)currentStage)
        {
            spriteRenderer.sprite = farmData.farmImage[(int)currentStage];
        }
    }

    //����� Ŭ�� ��
    void OnMouseDown()
    {
        Debug.Log("����� Ŭ��");

        if (IngredientManagerUI.ProcessedBuildingClick)//���� Ÿ�� �Ҵ�� ��
            return;

        if (currentStage == GrowthFarmType.Born) //������ �ڶ� ����
        {
            CollectCrop();
        }
    }

    //�۹� ȹ��
    void CollectCrop()
    {
        Debug.Log("�۹� ȹ��");
        if (playerStorage == null)
        {
            Debug.LogError("â�� ����");
            return;
        }

        // ���� ������� �����͸� ������� CropItem���� �ش� �۹� �������� ã�´�.
        JinnyCropItem.CropItemDataInfo cropToCollect = JinnyCropItem.CropItem.Instance.cropItemDataInfoList.Find(item => item.cropItemId == farmData.cropItemId);

        if (cropToCollect.cropItemId == null)
        {
            Debug.LogError("���� �۹� ������ ����");
            return;
        }

        // â�� �۹� �������� �߰�
        if (playerStorage.AddItem(cropToCollect, 1))
        {
            Debug.Log("â�� �۹� �߰�");

            // ����� �ʱ�ȭ �� ��������Ʈ ������Ʈ
            currentStage = GrowthFarmType.Plant;
            growthTimer = 0f;
            UpdateSprite();
        }
        else
        {
            Debug.Log("â�� �� ��");
        }

    }
}

