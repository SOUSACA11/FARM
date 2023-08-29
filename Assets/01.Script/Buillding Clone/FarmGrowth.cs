using JinnyFarm;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using JinnyCropItem;

//by.J:230825 시간 경과에 따른 이미지 추가(작물 성장)
//by.J:230828 시간 경과시 이미지 자동 변화
//by.J:230829 성장 완료된 밭 클릭시 작물 획득
public class FarmGrowth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;                      //농장밭 이미지
    public FarmDataInfo farmData;                               //현재 농장밭 데이터
    private GrowthFarmType currentStage = GrowthFarmType.Plant; //현재 농장밭의 성장 단계
    private float growthTimer = 1.0f;                           //농장밭 성장 추적 타이머
    public Storage playerStorage;                               //창고

    private void Start()
    {
        //창고 가져오기
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

    //농장밭 성장 데이터 초기화
    public void Initialize(FarmDataInfo data)
    {
        Debug.Log("농장밭 성장 데이터 초기화");

        growthTimer = 0f; // 초기화
        this.farmData = data;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    //성장 체크
    private void Update()
    {
        growthTimer += Time.deltaTime;

        //Debug.Log("농장 성장 체크");

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

        //Debug.Log("성장시간" + growthTimer);
        //Debug.Log("농장밭 성장 시간" + farmData.farmGrowTime);
    }

    //현재 성장 단계에 따른 스프라이트 업뎃
    private void UpdateSprite()
    {
        //Debug.Log("농장 성장 업뎃");

        if (spriteRenderer && farmData.farmImage.Length > (int)currentStage)
        {
            spriteRenderer.sprite = farmData.farmImage[(int)currentStage];
        }
    }

    //농장밭 클릭 시
    void OnMouseDown()
    {
        Debug.Log("농장밭 클릭");

        if (IngredientManagerUI.ProcessedBuildingClick)//빌딩 타입 할당시 끝
            return;

        if (currentStage == GrowthFarmType.Born) //완전히 자란 상태
        {
            CollectCrop();
        }
    }

    //작물 획득
    void CollectCrop()
    {
        Debug.Log("작물 획득");
        if (playerStorage == null)
        {
            Debug.LogError("창고 없음");
            return;
        }

        // 현재 농장밭의 데이터를 기반으로 CropItem에서 해당 작물 아이템을 찾는다.
        JinnyCropItem.CropItemDataInfo cropToCollect = JinnyCropItem.CropItem.Instance.cropItemDataInfoList.Find(item => item.cropItemId == farmData.cropItemId);

        if (cropToCollect.cropItemId == null)
        {
            Debug.LogError("연관 작물 아이템 없음");
            return;
        }

        // 창고에 작물 아이템을 추가
        if (playerStorage.AddItem(cropToCollect, 1))
        {
            Debug.Log("창고에 작물 추가");

            // 농장밭 초기화 및 스프라이트 업데이트
            currentStage = GrowthFarmType.Plant;
            growthTimer = 0f;
            UpdateSprite();
        }
        else
        {
            Debug.Log("창고 꽉 참");
        }

    }
}

