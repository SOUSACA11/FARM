using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyFarm;

//by.J:230825 �ð� ����� ���� �̹��� �߰�(�۹� ����)
public class FarmGrowth : MonoBehaviour
{ 
        private SpriteRenderer spriteRenderer;                      //����� �̹���
        private FarmDataInfo farmData;                              //���� ����� ������
        private GrowthFarmType currentStage = GrowthFarmType.Plant; //���� ������� ���� �ܰ�
        private float growthTimer = 0.3f;                           //����� ���� ���� Ÿ�̸�

        //����� ���� ������ �ʱ�ȭ
        public void Initialize(FarmDataInfo data)
        {
            Debug.Log("����� ���� ������ �ʱ�ȭ");
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

