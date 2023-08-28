using JinnyFarm;
using UnityEngine;
using System.Collections.Generic;

//by.J:230825 �ð� ����� ���� �̹��� �߰�(�۹� ����)
//by.J:230828 �ð� ����� �̹��� �ڵ� ��ȭ
public class FarmGrowth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;                      //����� �̹���
    public FarmDataInfo farmData;                              //���� ����� ������
    private GrowthFarmType currentStage = GrowthFarmType.Plant; //���� ������� ���� �ܰ�
    private float growthTimer = 1.0f;                           //����� ���� ���� Ÿ�̸�


    public void InitializeFromSelectedData()
    {
        if (StoreSlot.SelectedFarmData != null)
        {
            FarmDataInfo selectedFarmData = StoreSlot.SelectedFarmData.Value;
            Initialize(selectedFarmData);
        }
    }


    private void Start()
    {
        InitializeFromSelectedData();
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

        Debug.Log("���� ���� üũ");

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

        Debug.Log("����ð�" + growthTimer);
        Debug.Log("����� ���� �ð�" + farmData.farmGrowTime);
    }

    //���� ���� �ܰ迡 ���� ��������Ʈ ����
    private void UpdateSprite()
    {
        Debug.Log("���� ���� ����");

        if (spriteRenderer && farmData.farmImage.Length > (int)currentStage)
        {
            spriteRenderer.sprite = farmData.farmImage[(int)currentStage];
        }
    }
}

