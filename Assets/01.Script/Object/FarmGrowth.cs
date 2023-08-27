using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyFarm;

//by.J:230825 시간 경과에 따른 이미지 추가(작물 성장)
public class FarmGrowth : MonoBehaviour
{ 
        private SpriteRenderer spriteRenderer;                      //농장밭 이미지
        private FarmDataInfo farmData;                              //현재 농장밭 데이터
        private GrowthFarmType currentStage = GrowthFarmType.Plant; //현재 농장밭의 성장 단계
        private float growthTimer = 0.3f;                           //농장밭 성장 추적 타이머

        //농장밭 성장 데이터 초기화
        public void Initialize(FarmDataInfo data)
        {
            Debug.Log("농장밭 성장 데이터 초기화");
            this.farmData = data;
            spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateSprite();
        }

        //성장 체크
        private void Update()
        {
            growthTimer += Time.deltaTime;

        Debug.Log("농장 성장 체크");

            //성장 단계 변경하고 스프라이트를 업데이트
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

        //현재 성장 단계에 따른 스프라이트 업뎃
        private void UpdateSprite()
        {
        Debug.Log("농장 성장 업뎃");    

            if (spriteRenderer && farmData.farmImage.Length > (int)currentStage)
            {
                spriteRenderer.sprite = farmData.farmImage[(int)currentStage];
            }
        }
    }

