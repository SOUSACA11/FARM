using System.Collections.Generic;
using UnityEngine;
using JinnyBuilding;
using JinnyProcessItem;

//by.J:230811 복제된 건물 생산품 제작
//by.J:230816 레시피 적용 추가
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false;                            //생산중
    public float startTime;                                     //생산시작
    public float productionDuration = 60f;                      //생산 필요 시간
    public List<IItem> ingredientList = new List<IItem>();      //필요 재료 목록
    public List<IItem> needIngredient = new List<IItem>();      //생산에 필요한 재료 목록
    public IItem product;                                       //생산 완료 아이템
    public BuildingType buildingType;                           //생산 건물 타입
    public Recipe currentRecipe;                                //현재 건물에서 사용할 레시피
    private void Update()
    {
        CheckProduction();
    }

    public void SetRecipe(Recipe recipe) //레시피 설정
    {
        currentRecipe = recipe;
        needIngredient.Clear();

        foreach (var ingredientObj in recipe.ingredients)
        {
            // 재료가 Ingredient<IItem> 타입인지 확인
            if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
            }
        }

        product = new ProcessItemIItem(recipe.outputItem);
    }

    public void AddItem(IItem item) //재료 추가
    {
        if (needIngredient.Contains(item)) // 레시피에 필요한 재료인지 확인
        {
            ingredientList.Add(item);

            // 모든 재료가 추가되었는지 확인
            if (ingredientList.Count == needIngredient.Count)
            {
                StartProduction();
            }
        }
        else
        {
            // 필요하지 않은 재료입니다.
        }
    }

    public void StartProduction() //생산 시작
    {
        isProducing = true;
        startTime = Time.time;
    }

    private void CheckProduction() //생산 완료 체크
    {
        if (isProducing && Time.time - startTime >= productionDuration)
        {
            isProducing = false;
            CompleteProduction();
        }
    }

    private void CompleteProduction() //생산 완료
    {
       // product = new FinishedProduct();

        // 재료 목록 초기화
        ingredientList.Clear();
    }
}
