using System.Collections.Generic;
using UnityEngine;
using JinnyCropItem;
using JinnyProcessItem;
using JinnyBuilding;

//by.J:230816 ������ ������
//by.J:230818 �ϼ�ǰ ID �߰�
public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance; //�̱��� ó��
    public Dictionary<BuildingType, List<Recipe>> buildingRecipes = new Dictionary<BuildingType, List<Recipe>>(); //�ǹ� Ÿ��

    public Recipe milkRecipe;         //����
    public Recipe eggRecipe;          //�ް�
    public Recipe porkRecipe;         //�������

    public Recipe breadRecipe;          //�Ļ�
    public Recipe baguetteRecipe;       //�ٰ�Ʈ
    public Recipe croissantRecipe;      //ũ��ͻ�
    public Recipe flourRecipe;          //�а���
    public Recipe chickenfeedRecipe;    //�� ���
    public Recipe pigfeedRecipe;        //���� ���
    public Recipe cowfeedRecipe;        //�� ���
    public Recipe eggflowerRecipe;      //����Ķ���
    public Recipe baconRecipe;          //������
    public Recipe tomatojuiceRecipe;    //�丶�� �꽺
    public Recipe carrotjuiceRecipe;    //��� �꽺
    public Recipe butterRecipe;         //����
    public Recipe cheeseRecipe;         //ġ��

    public CropItem cropItems;
    public ProcessItem processItems;


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

    //������ ���� �ʱ�ȭ
    private void InitializeRecipes() 
    {
        Debug.Log("�����ǸŴ��� �ʱ�ȭ �ǽ� ����");
        // JinnyCropItem���� ������ ��������
        CropItemDataInfo wheat = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_01");  //��
        CropItemDataInfo corn = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_02");   //������
        CropItemDataInfo bean = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_03");   //��
        CropItemDataInfo tomato = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_04"); //�丶��
        CropItemDataInfo carrot = cropItems.cropItemDataInfoList.Find(item => item.cropItemId == "crop_05"); //���

        // JinnyProcessItem���� ������ ��������
        ProcessItemDataInfo milk = processItems.processitemDataInfoList.Find(item => item.processItemId == "animal_01");          //����
        ProcessItemDataInfo egg = processItems.processitemDataInfoList.Find(item => item.processItemId == "animal_02");           //�ް�
        ProcessItemDataInfo pork = processItems.processitemDataInfoList.Find(item => item.processItemId == "animal_03");          //�������
        ProcessItemDataInfo bread = processItems.processitemDataInfoList.Find(item => item.processItemId == "bread_01");          //�Ļ�
        ProcessItemDataInfo baguette = processItems.processitemDataInfoList.Find(item => item.processItemId == "bread_02");       //�ٰ�Ʈ
        ProcessItemDataInfo croissant = processItems.processitemDataInfoList.Find(item => item.processItemId == "bread_03");      //ũ��ͻ�
        ProcessItemDataInfo flour = processItems.processitemDataInfoList.Find(item => item.processItemId == "windmill_01");       //�а���
        ProcessItemDataInfo chickenfeed = processItems.processitemDataInfoList.Find(item => item.processItemId == "windmill_02"); //�� ���
        ProcessItemDataInfo pigfeed = processItems.processitemDataInfoList.Find(item => item.processItemId == "windmill_03");     //���� ���
        ProcessItemDataInfo cowfeed = processItems.processitemDataInfoList.Find(item => item.processItemId == "windmill_04");     //�� ���
        ProcessItemDataInfo eggflower = processItems.processitemDataInfoList.Find(item => item.processItemId == "grill_01");      //����Ķ���
        ProcessItemDataInfo bacon = processItems.processitemDataInfoList.Find(item => item.processItemId == "grill_02");          //������
        ProcessItemDataInfo tomatojuice = processItems.processitemDataInfoList.Find(item => item.processItemId == "juice_01");    //�丶�� �꽺
        ProcessItemDataInfo carrotjuice = processItems.processitemDataInfoList.Find(item => item.processItemId == "juice_02");    //��� �꽺
        ProcessItemDataInfo butter = processItems.processitemDataInfoList.Find(item => item.processItemId == "dairy_01");         //����
        ProcessItemDataInfo cheese = processItems.processitemDataInfoList.Find(item => item.processItemId == "dairy_02");         //ġ��

        if (cropItems == null || processItems == null)
        {
            Debug.LogError("���۹� , ����ǰ �ֳ�");
            return;
        }


        //����
        List<object> milkIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(cowfeed, 1)
        };
        milkRecipe = new Recipe(milkIngredients, milk, 1);
        milkRecipe.finishedProductId = "animal_01";

        //�ް�
        List<object> eggIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(chickenfeed, 1)
        };
        eggRecipe = new Recipe(eggIngredients, egg, 1);
        eggRecipe.finishedProductId = "animal_02";

        //�������
        List<object> porkIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(pigfeed, 1)
        };
        porkRecipe = new Recipe(porkIngredients, pork, 1);
        porkRecipe.finishedProductId = "animal_03";


        //�Ļ�
        List<object> breadIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        breadRecipe = new Recipe(breadIngredients, bread, 1);
        breadRecipe.finishedProductId = "bread_01";

        //�ٰ�Ʈ
        List<object> baguetteIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        baguetteRecipe = new Recipe(baguetteIngredients, baguette, 1);
        baguetteRecipe.finishedProductId = "bread_02";

        //ũ��ͻ� (����)
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
        croissantRecipe = new Recipe(croissantAllIngredients, croissant, 1);
        croissantRecipe.finishedProductId = "bread_03";

        //�а���
        List<object> flourIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(wheat, 1)
        };
        flourRecipe = new Recipe(flourIngredients, flour, 1);
        flourRecipe.finishedProductId = "windmill_01";

        //�� ���
        List<object> chickenfeedIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(corn, 1)
        };
        chickenfeedRecipe = new Recipe(chickenfeedIngredients, chickenfeed, 1);
        chickenfeedRecipe.finishedProductId = "windmill_02";

        //���� ���
        List<object> pigfeedIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(corn, 1)
        };
        pigfeedRecipe = new Recipe(pigfeedIngredients, pigfeed, 1);
        pigfeedRecipe.finishedProductId = "windmill_03";

        //�� ���
        List<object> cowfeedIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(bean, 1)
        };
        cowfeedRecipe = new Recipe(pigfeedIngredients, cowfeed, 1);
        cowfeedRecipe.finishedProductId = "windmill_04";

        //����Ķ���
        List<object> eggflowerIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(egg, 1)
        };
        eggflowerRecipe = new Recipe(eggflowerIngredients, eggflower, 1);
        eggflowerRecipe.finishedProductId = "grill_01";

        //������ 
        List<object> baconIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(pork, 1)
        };
        baconRecipe = new Recipe(baconIngredients, bacon, 1);
        baconRecipe.finishedProductId = "grill_02";

        //�丶�� �꽺
        List<object> tomatojuiceIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(tomato, 1)
        };
        tomatojuiceRecipe = new Recipe(tomatojuiceIngredients, tomatojuice, 1);
        tomatojuiceRecipe.finishedProductId = "juice_01";

        //��� �꽺
        List<object> carrotjuiceIngredients = new List<object>
        {
           new Ingredient<CropItemDataInfo>(carrot, 1)
        };
        carrotjuiceRecipe = new Recipe(carrotjuiceIngredients, carrotjuice, 1);
        carrotjuiceRecipe.finishedProductId = "juice_02";

        //����
        List<object> butterIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(milk, 1)
        };
        butterRecipe = new Recipe(butterIngredients, butter, 1);
        butterRecipe.finishedProductId = "dairy_01";

        //ġ��
        List<object> cheeseIngredients = new List<object>
        {
           new Ingredient<ProcessItemDataInfo>(milk, 1)
        };
        cheeseRecipe = new Recipe(cheeseIngredients, cheese, 1);
        cheeseRecipe.finishedProductId = "dairy_02";


        //�ǹ� Ÿ�Ժ� ������ ����
        buildingRecipes[BuildingType.Cage] = new List<Recipe> { milkRecipe, eggRecipe, breadRecipe };                               //���
        buildingRecipes[BuildingType.Bakery] = new List<Recipe> { breadRecipe, baguetteRecipe, croissantRecipe };                   //����
        buildingRecipes[BuildingType.Windmill] = new List<Recipe> { flourRecipe, chickenfeedRecipe, pigfeedRecipe, cowfeedRecipe }; //���̼�
        buildingRecipes[BuildingType.GrillShop] = new List<Recipe> { eggflowerRecipe, baconRecipe };                                //ö�ǰ���
        buildingRecipes[BuildingType.JuiceShop] = new List<Recipe> { tomatojuiceRecipe, carrotjuiceRecipe };                        //�꽺����
        buildingRecipes[BuildingType.Dairy] = new List<Recipe> { butterRecipe, cheeseRecipe };                                      //����ǰ ������

    }
}