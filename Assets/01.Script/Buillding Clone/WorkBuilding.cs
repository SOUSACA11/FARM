using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JinnyBuilding;
using JinnyProcessItem;
using JinnyCropItem;
using JinnyFarm;
using JinnyAnimal;
using System.Linq;
using System.Collections;

//by.J:230811 복제된 건물 관련 정보 / 생산품 제작
//by.J:230816 레시피 적용 추가
//by.J:230825 타입 설정 추가
//by.J:230827 완성품 이미지 드래그 드롭시 생산 시작
//by.J:230829 생산완료시 반짝반짝 효과
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false;                            //생산중
    public float startTime;                                     //생산시작
    private float productionDuration;                           //생산 필요 시간
    public List<IItem> ingredientList = new List<IItem>();      //필요 재료 목록
    public List<IItem> needIngredient = new List<IItem>();      //생산에 필요한 재료 목록
    public IItem product;                                       //생산 완료 아이템
    public BuildingType buildingType;                           //생산 건물 타입
    public FarmType farmType;                                   //농장 타입
    public AnimalType animalType;                               //축사 타입

    public Recipe currentRecipe;                                //현재 건물에서 사용할 레시피

    public Sprite finishedProductImage;                         //완성품 이미지
    public GameObject finishedProductUI;                        //드래그 할 완성품 창

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public WorkBuilding finishImageBuilding;


    private List<Recipe> availableRecipes = new List<Recipe>();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void Start()
    {
        //SetRecipesForBuilding();
    }

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
        this.animalType = AnimalType.None;

        // 추가된 코드: finishImage의 buildingType도 동일하게 설정
        if (finishImageBuilding != null)
        {
            finishImageBuilding.Initialize(type);
        }
        Debug.Log(gameObject + "work빌딩 타입" +  buildingType);
    }

    //농장 타입 자동 설정
    public void Initialize(FarmType type)
    {
        Debug.Log("빌딩쓰스2");
        this.farmType = type;
        this.buildingType = BuildingType.None;
        this.animalType = AnimalType.None;
        //Debug.Log(farmType);
    }

    //축사 타입 자동 설정
    public void Initialize(AnimalType type)
    {
        Debug.Log("빌딩쓰스3");
        this.animalType = type;
        this.buildingType = BuildingType.None;
        this.farmType = FarmType.None;
        //Debug.Log(farmType);
    }

    //빌딩 타입별 레시피 설정
    private void SetRecipesForBuilding()
    {
       
        Debug.Log("타입별 레시피 설정" + $"Setting recipes for building type: {buildingType}");

        if (RecipeManager.Instance.buildingRecipes.TryGetValue(buildingType, out List<Recipe> recipesForThisBuilding))
        {
            availableRecipes = recipesForThisBuilding;
        }
        else
        {
            Debug.Log("건물에 할당된 레시피 없음: " + buildingType);
        }
    }

    //레시피 선택
    public void SelectRecipe(Recipe recipe)
    {
        Debug.Log(gameObject + "레시피 생산품 이름" + $"Attempting to select recipe: {recipe.finishedProduct.processItemName}");

        if (availableRecipes.Contains(recipe))
        {
            Debug.Log($"Recipe {recipe.finishedProduct.processItemName} is available for this building.");

            SetRecipe(recipe);
        }
        else
        {
            Debug.Log("레시피 사용 불가");
        }
    }

    //private void SetRecipeDetails(Recipe recipe)
    //{
    //    Debug.Log("레시피 생산품 이름2" + $"Setting recipe for: {recipe.finishedProduct.processItemName}");

    //    currentRecipe = recipe;
    //    needIngredient.Clear();

    //    foreach (var ingredientObj in recipe.ingredients)
    //    {
    //        if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
    //        {
    //            needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
    //        }
    //        else if (ingredientObj is Ingredient<CropItemDataInfo> cropIngredient)
    //        {
    //            needIngredient.Add(new CropItemIItem(cropIngredient.item));
    //        }
    //    }

    //    product = new ProcessItemIItem(recipe.finishedProduct);
    //    productionDuration = recipe.productionTime;
    //    Debug.Log("세팅된 레시피 생산 시간 : " + recipe.productionTime);
    //}



    //레시피 설정
    public void SetRecipe(Recipe recipe)
    {
        
        Debug.Log("레시피 설정");
        Debug.Log($"[WorkBuilding] Set Recipe ID: {recipe.finishedProductId}");
        Debug.Log("여기에 설정된 레시피 뭐임" + recipe);
        Debug.Log($"Recipe IsInitialized: {recipe.IsInitialized}");
        Debug.Log($"Recipe Finished Product ID: {recipe.finishedProductId}");



        if (recipe == null)
        {
            Debug.LogError("레시피 없음");
            return;
        }


        Debug.Log(gameObject +  "레시피 이름" + $"Setting recipe for: {recipe.finishedProduct.processItemName}");

        currentRecipe = recipe;
        needIngredient.Clear();

       
        if (!recipe.finishedProduct.IsInitialized)
        {
            Debug.LogError("recipe.finishedProduct이 초기화되지 않았습니다!");
            return;
        }
        foreach (var ingredientObj in recipe.ingredients)
        {
            Debug.Log("Checking ingredient: " + ingredientObj.ToString());

            if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
            }
            else if (ingredientObj is Ingredient<CropItemDataInfo> cropIngredient)
            {
                needIngredient.Add(new CropItemIItem(cropIngredient.item));
            }
        }

        Debug.Log("레시피 데이터 확인" + recipe.ingredients);
        product = new ProcessItemIItem(recipe.finishedProduct);
        productionDuration = recipe.productionTime;
        Debug.Log("레시피 생산 시간: " + recipe.productionTime);

    }

    //재료 추가
    public void AddItem(IItem item)
    {
        Debug.Log("재료 추가");
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



    // 드래그로 완성품 이미지를 놓았을 때 호출되는 메서드
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("완성품 이미지 놓고 호출");

        if (eventData.pointerDrag == finishedProductUI)
        {
            StartProduction();
        }
    }


    //생산 시작
    public void StartProduction() 
    {
        Debug.Log("생산 시작");


        // 현재 선택된 레시피와 필요 원재료 디버그 로그 추가
        Debug.Log($"선택 레시피: {currentRecipe.finishedProduct.processItemName}");
        //Debug.Log("Required Ingredients for this recipe:");
        

        foreach (var ingredient in needIngredient)
        {
            Debug.Log($"- {ingredient.ItemName}");
        }


        // 필요한 재료가 충분한지 확인
        foreach (IItem requiredItem in needIngredient)
        {
            Debug.Log("재료 충분?");

            Debug.Log("[WorkBuilding] Needed ingredients for production:");


            foreach (var ingredient in needIngredient)
            {
                Debug.Log($"- Ingredient: {ingredient.ItemName}");
            }



            int requiredCount = needIngredient.Count(item => item.Equals(requiredItem));

            //창고에서 해당 아이템의 갯수를 확인
            int availableCount = Storage.Instance.GetItemAmount(requiredItem);

            Debug.Log("Required item: " + requiredItem.ToString() + " | Required Count: " + requiredCount + " | Available Count: " + availableCount);

            if (availableCount < requiredCount)
            {
                Debug.Log("재료가 부족합니다!");
                return;
            }
        }

        // 재료를 창고에서 제거
        foreach (IItem requiredItem in needIngredient)
        {
            int requiredCount = needIngredient.Count(item => item == requiredItem);
            Storage.Instance.RemoveItem(requiredItem, requiredCount);
        }

        //이미지 숨기기
        if (finishedProductUI)
        {
            finishedProductUI.SetActive(false);
        }

        isProducing = true;
        startTime = Time.time;
        Debug.Log(isProducing);
        Debug.Log("Start Time: " + startTime);
        Debug.Log("Production Duration: " + productionDuration);
        Debug.Log("Current Time.time: " + Time.time);
    }

    //생산 완료 체크
    private void CheckProduction() 
    {
        //Debug.Log("생산완료 체크");
        //Debug.Log("Current Time: " + Time.time);
        //Debug.Log("Start Time: " + startTime);
        //Debug.Log("Difference: " + (Time.time - startTime));
        if (isProducing && Time.time - startTime >= productionDuration)
        {
            Debug.Log("Inside production check condition.");
            isProducing = false;
            CompleteProduction();
        }

        if (isProducing && Time.time - startTime >= productionDuration)
        {
            isProducing = false;
            CompleteProduction();
        }
    }

    //생산 완료
    private void CompleteProduction() 
    {
        Debug.Log("생산 완료");

        // 완성품을 창고에 추가
        Storage.Instance.AddItem(product, 1);

        //재료 목록 초기화
        ingredientList.Clear();

        if (spriteRenderer != null)
        {
            StartCoroutine(BlinkEffect());
        }

    }

    IEnumerator BlinkEffect()
    {
        int blinkTimes = 5;
        float blinkDuration = 0.1f;

        for (int i = 0; i < blinkTimes; i++)
        {
            // 투명하게 설정
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
            yield return new WaitForSeconds(blinkDuration);

            // 원래 색상으로 설정
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
