using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JinnyBuilding;
using JinnyProcessItem;
using JinnyFarm;
using System.Linq;

//by.J:230811 복제된 건물 관련 정보 / 생산품 제작
//by.J:230816 레시피 적용 추가
//by.J:230825 타입 설정 추가
//by.J:230827 완성품 이미지 드래그 드롭시 생산 시작
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false;                            //생산중
    public float startTime;                                     //생산시작
    public float productionDuration = 60f;                      //생산 필요 시간
    public List<IItem> ingredientList = new List<IItem>();      //필요 재료 목록
    public List<IItem> needIngredient = new List<IItem>();      //생산에 필요한 재료 목록
    public IItem product;                                       //생산 완료 아이템
    public BuildingType buildingType;                           //생산 건물 타입
    public FarmType farmType;                                   //농장 타입

    public Recipe currentRecipe;                                //현재 건물에서 사용할 레시피

    public Sprite finishedProductImage; //완성품 이미지

    public GameObject finishedProductUI; //드래그 할 완성품 창



    private void Update()
    {
        CheckProduction();
    }

    //빌딩 타입 자동 설정
    public void Initialize(BuildingType type)
    {
        //Debug.Log("농장쓰스2");
        this.buildingType = type;
        this.farmType = FarmType.None;
        //Debug.Log(buildingType);
    }

    //농장 타입 자동 설정
    public void Initialize(FarmType type)
    {
        Debug.Log("빌딩쓰스2");
        this.farmType = type;
        this.buildingType = BuildingType.None;


        //Debug.Log(farmType);
    }

    //레시피 설정
    public void SetRecipe(Recipe recipe)
    {
        if (buildingType == BuildingType.None) return;

        currentRecipe = recipe;
        needIngredient.Clear();

        foreach (var ingredientObj in recipe.ingredients)
        {
            //재료가 Ingredient<IItem> 타입인지 확인
            if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
            }
        }
        product = new ProcessItemIItem(recipe.outputItem);
    }

    //재료 추가
    public void AddItem(IItem item)
    {
        if (buildingType == BuildingType.None) return;

        if (!isProducing && needIngredient.Contains(item)) //레시피에 필요한 재료인지 확인 및 생산 중이 아닌지 확인
        {
            ingredientList.Add(item);

            //모든 재료가 추가되었는지 확인
            if (ingredientList.Count == needIngredient.Count)
            {
                StartProduction();
            }
        }
        else
        {
            //필요하지 않은 재료
        }
    }

    //생산 시작
    public void StartProduction() 
    {
        // 필요한 재료가 충분한지 확인
        foreach (IItem requiredItem in needIngredient)
        {
            int requiredCount = needIngredient.Count(item => item == requiredItem);
            int availableCount = ingredientList.Count(item => item == requiredItem);

            if (availableCount < requiredCount)
            {
                Debug.Log("재료가 부족합니다!");
                return;
            }
        }

        //이미지 숨기기
        if (finishedProductUI)
        {
            finishedProductUI.SetActive(false);
        }

        isProducing = true;
        startTime = Time.time;
    }

    //생산 완료 체크
    private void CheckProduction() 
    {
        if (isProducing && Time.time - startTime >= productionDuration)
        {
            isProducing = false;
            CompleteProduction();
        }
    }

    //생산 완료
    private void CompleteProduction() 
    {
       // product = new FinishedProduct();

        //재료 목록 초기화
        ingredientList.Clear();

        //재료가 사용되면 저장소에서 재료를 제거하는 추가 로직을 여기에 삽입할 수 있습니다.
    }

    //void OnMouseDown() //건물 클릭
    //{
    //    if (EventSystem.current.IsPointerOverGameObject()) // UI 클릭을 방지
    //        return;

    //    // 해당 건물의 레시피에 따라 UI 업데이트
    //    IngredientUI.Instance.IngredientClick();
    //    Debug.Log("여기 작동됨?");

    //}
}
