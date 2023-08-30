using System.Collections.Generic;
using UnityEngine;
using JinnyCropItem;
using JinnyProcessItem;
using JinnyBuilding;

//by.J:230816 레시피 데이터
//by.J:230818 완성품 ID 추가
//by.J:230829 생산시간 추가
public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance; //싱글톤 처리
    public Dictionary<BuildingType, List<Recipe>> buildingRecipes = new Dictionary<BuildingType, List<Recipe>>(); //건물 타입

    public Recipe milkRecipe;         //우유
    public Recipe eggRecipe;          //달걀
    public Recipe porkRecipe;         //돼지고기

    public Recipe breadRecipe;          //식빵
    public Recipe baguetteRecipe;       //바게트
    public Recipe croissantRecipe;      //크루와상
    public Recipe flourRecipe;          //밀가루
    public Recipe chickenfeedRecipe;    //닭 사료
    public Recipe pigfeedRecipe;        //돼지 사료
    public Recipe cowfeedRecipe;        //소 사료
    public Recipe eggflowerRecipe;      //계란후라이
    public Recipe baconRecipe;          //베이컨
    public Recipe tomatojuiceRecipe;    //토마토 쥬스
    public Recipe carrotjuiceRecipe;    //당근 쥬스
    public Recipe butterRecipe;         //버터
    public Recipe cheeseRecipe;         //치즈

    public CropItem cropItems;
    public ProcessItem processItems;

    // 모든 레시피를 담을 리스트 추가
    public List<Recipe> allRecipes = new List<Recipe>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        InitializeRecipes();
    }
    
    //ID 기반으로 레시피 가져오기
    public Recipe GetRecipeByProductId(string productId)
    {
        foreach (var recipes in buildingRecipes.Values)
        {
            foreach (var recipe in recipes)
            {
                if (recipe.finishedProductId == productId)
                {
                    return recipe;
                }
            }
        }
        return null;
    }

    private void Start()
    {
        //InitializeRecipes();
    }

    //레시피 모음 초기화
    private void InitializeRecipes()
    {
        Debug.Log("레시피매니저 초기화 실시 시작");


        // JinnyCropItem에서 아이템 가져오기
        CropItemDataInfo wheat = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_01");  //밀
        CropItemDataInfo corn = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_02");   //옥수수
        CropItemDataInfo bean = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_03");   //콩
        CropItemDataInfo tomato = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_04"); //토마토
        CropItemDataInfo carrot = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_05"); //당근

        // JinnyProcessItem에서 아이템 가져오기
        ProcessItemDataInfo milk = processItems.processItemDataInfoList.Find(item => item.processItemId == "animal_01");          //우유
        ProcessItemDataInfo egg = processItems.processItemDataInfoList.Find(item => item.processItemId == "animal_02");           //달걀
        ProcessItemDataInfo pork = processItems.processItemDataInfoList.Find(item => item.processItemId == "animal_03");          //돼지고기
        ProcessItemDataInfo bread = processItems.processItemDataInfoList.Find(item => item.processItemId == "bread_01");          //식빵
        ProcessItemDataInfo baguette = processItems.processItemDataInfoList.Find(item => item.processItemId == "bread_02");       //바게트
        ProcessItemDataInfo croissant = processItems.processItemDataInfoList.Find(item => item.processItemId == "bread_03");      //크루와상
        ProcessItemDataInfo flour = processItems.processItemDataInfoList.Find(item => item.processItemId == "windmill_01");       //밀가루
        ProcessItemDataInfo chickenfeed = processItems.processItemDataInfoList.Find(item => item.processItemId == "windmill_02"); //닭 사료
        ProcessItemDataInfo pigfeed = processItems.processItemDataInfoList.Find(item => item.processItemId == "windmill_03");     //돼지 사료
        ProcessItemDataInfo cowfeed = processItems.processItemDataInfoList.Find(item => item.processItemId == "windmill_04");     //소 사료
        ProcessItemDataInfo eggflower = processItems.processItemDataInfoList.Find(item => item.processItemId == "grill_01");      //계란후라이
        ProcessItemDataInfo bacon = processItems.processItemDataInfoList.Find(item => item.processItemId == "grill_02");          //베이컨
        ProcessItemDataInfo tomatojuice = processItems.processItemDataInfoList.Find(item => item.processItemId == "juice_01");    //토마토 쥬스
        ProcessItemDataInfo carrotjuice = processItems.processItemDataInfoList.Find(item => item.processItemId == "juice_02");    //당근 쥬스
        ProcessItemDataInfo butter = processItems.processItemDataInfoList.Find(item => item.processItemId == "dairy_01");         //버터
        ProcessItemDataInfo cheese = processItems.processItemDataInfoList.Find(item => item.processItemId == "dairy_02");         //치즈


        if (cropItems == null || processItems == null)
        {
            Debug.LogError("농작물 , 생산품 있냐");
            return;
        }

        //우유
        List<object> milkIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(cowfeed, 1)
        };
        milkRecipe = new Recipe(milkIngredients, milk, 1, 10f);
        milkRecipe.finishedProductId = "animal_01";
        allRecipes.Add(milkRecipe);
        Debug.Log($"[RecipeManager] Milk Recipe ID: {milkRecipe.finishedProductId}");

        //달걀
        List<object> eggIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(chickenfeed, 1)
        };
        eggRecipe = new Recipe(eggIngredients, egg, 1, 10f);
        eggRecipe.finishedProductId = "animal_02";
        allRecipes.Add(eggRecipe);

        //돼지고기
        List<object> porkIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(pigfeed, 1)
        };
        porkRecipe = new Recipe(porkIngredients, pork, 1, 10f);
        porkRecipe.finishedProductId = "animal_03";
        allRecipes.Add(porkRecipe);

        //식빵
        List<object> breadIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        breadRecipe = new Recipe(breadIngredients, bread, 1, 10f);
        breadRecipe.finishedProductId = "bread_01";
        allRecipes.Add(breadRecipe);

        Debug.Log($"[RecipeManager] Milk Recipe ID: {breadRecipe.finishedProductId}");

        //바게트
        List<object> baguetteIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        baguetteRecipe = new Recipe(baguetteIngredients, baguette, 1, 10f);
        baguetteRecipe.finishedProductId = "bread_02";
        allRecipes.Add(baguetteRecipe);

        Debug.Log($"[RecipeManager] Milk Recipe ID: {baguetteRecipe.finishedProductId}");

        //크루와상 (조합)
        List<Ingredient<CropItemDataInfo>> croissantCropIngredients = new List<Ingredient<CropItemDataInfo>>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        List<Ingredient<ProcessItemDataInfo>> croissantProcessIngredients = new List<Ingredient<ProcessItemDataInfo>>
        {
           new Ingredient<ProcessItemDataInfo>(butter, 1)
        };
        List<object> croissantAllIngredients = new List<object>();
        croissantAllIngredients.AddRange(croissantCropIngredients);
        croissantAllIngredients.AddRange(croissantProcessIngredients);
        croissantRecipe = new Recipe(croissantAllIngredients, croissant, 1, 10f);
        croissantRecipe.finishedProductId = "bread_03";
        allRecipes.Add(croissantRecipe);

        //밀가루
        List<object> flourIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        flourRecipe = new Recipe(flourIngredients, flour, 1, 10f);
        flourRecipe.finishedProductId = "windmill_01";
        allRecipes.Add(flourRecipe);

        //닭 사료
        List<object> chickenfeedIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(corn, 1)
        };
        chickenfeedRecipe = new Recipe(chickenfeedIngredients, chickenfeed, 1, 10f);
        chickenfeedRecipe.finishedProductId = "windmill_02";
        allRecipes.Add(chickenfeedRecipe);

        //돼지 사료
        List<object> pigfeedIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(corn, 1)
        };
        pigfeedRecipe = new Recipe(pigfeedIngredients, pigfeed, 1, 10f);
        pigfeedRecipe.finishedProductId = "windmill_03";
        allRecipes.Add(pigfeedRecipe);

        //소 사료
        List<object> cowfeedIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(bean, 1)
        };
        cowfeedRecipe = new Recipe(pigfeedIngredients, cowfeed, 1, 10f);
        cowfeedRecipe.finishedProductId = "windmill_04";
        allRecipes.Add(cowfeedRecipe);

        //계란후라이
        List<object> eggflowerIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(egg, 1)
        };
        eggflowerRecipe = new Recipe(eggflowerIngredients, eggflower, 1, 10f);
        eggflowerRecipe.finishedProductId = "grill_01";
        allRecipes.Add(eggflowerRecipe);

        //베이컨 
        List<object> baconIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(pork, 1)
        };
        baconRecipe = new Recipe(baconIngredients, bacon, 1, 10f);
        baconRecipe.finishedProductId = "grill_02";
        allRecipes.Add(baconRecipe);

        //토마토 쥬스
        List<object> tomatojuiceIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(tomato, 1)
        };
        tomatojuiceRecipe = new Recipe(tomatojuiceIngredients, tomatojuice, 1, 10f);
        tomatojuiceRecipe.finishedProductId = "juice_01";
        allRecipes.Add(tomatojuiceRecipe);

        //당근 쥬스
        List<object> carrotjuiceIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(carrot, 1)
        };
        carrotjuiceRecipe = new Recipe(carrotjuiceIngredients, carrotjuice, 1, 10f);
        carrotjuiceRecipe.finishedProductId = "juice_02";
        allRecipes.Add(carrotjuiceRecipe);

        //버터
        List<object> butterIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(milk, 1)
        };
        butterRecipe = new Recipe(butterIngredients, butter, 1, 10f);
        butterRecipe.finishedProductId = "dairy_01";
        allRecipes.Add(butterRecipe);

        //치즈
        List<object> cheeseIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(milk, 1)
        };
        cheeseRecipe = new Recipe(cheeseIngredients, cheese, 1, 10f);
        cheeseRecipe.finishedProductId = "dairy_02";
        allRecipes.Add(cheeseRecipe);


        //건물 타입별 레시피 정의
        buildingRecipes[BuildingType.Cage] = new List<Recipe> { milkRecipe, eggRecipe, breadRecipe };                               //축사
        buildingRecipes[BuildingType.Bakery] = new List<Recipe> { breadRecipe, baguetteRecipe, croissantRecipe };                   //빵집
        buildingRecipes[BuildingType.Windmill] = new List<Recipe> { flourRecipe, chickenfeedRecipe, pigfeedRecipe, cowfeedRecipe }; //정미소
        buildingRecipes[BuildingType.GrillShop] = new List<Recipe> { eggflowerRecipe, baconRecipe };                                //철판가게
        buildingRecipes[BuildingType.JuiceShop] = new List<Recipe> { tomatojuiceRecipe, carrotjuiceRecipe };                        //쥬스가게
        buildingRecipes[BuildingType.Dairy] = new List<Recipe> { butterRecipe, cheeseRecipe };                                      //유제품 가공소

    }
}