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

//by.J:230811 ������ �ǹ� ���� ���� / ����ǰ ����
//by.J:230816 ������ ���� �߰�
//by.J:230825 Ÿ�� ���� �߰�
//by.J:230827 �ϼ�ǰ �̹��� �巡�� ��ӽ� ���� ����
//by.J:230829 ����Ϸ�� ��¦��¦ ȿ��
public class WorkBuilding : MonoBehaviour
{
    public bool isProducing = false;                            //������
    public float startTime;                                     //�������
    private float productionDuration;                           //���� �ʿ� �ð�
    public List<IItem> ingredientList = new List<IItem>();      //�ʿ� ��� ���
    public List<IItem> needIngredient = new List<IItem>();      //���꿡 �ʿ��� ��� ���
    public IItem product;                                       //���� �Ϸ� ������
    public BuildingType buildingType;                           //���� �ǹ� Ÿ��
    public FarmType farmType;                                   //���� Ÿ��
    public AnimalType animalType;                               //��� Ÿ��

    public Recipe currentRecipe;                                //���� �ǹ����� ����� ������

    public Sprite finishedProductImage;                         //�ϼ�ǰ �̹���
    public GameObject finishedProductUI;                        //�巡�� �� �ϼ�ǰ â

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

    //���� Ÿ�� �ڵ� ����
    public void Initialize(BuildingType type)
    {
        //Debug.Log("���徲��2");
        this.buildingType = type;
        this.farmType = FarmType.None;
        this.animalType = AnimalType.None;

        // �߰��� �ڵ�: finishImage�� buildingType�� �����ϰ� ����
        if (finishImageBuilding != null)
        {
            finishImageBuilding.Initialize(type);
        }
        Debug.Log(gameObject + "work���� Ÿ��" +  buildingType);
    }

    //���� Ÿ�� �ڵ� ����
    public void Initialize(FarmType type)
    {
        Debug.Log("��������2");
        this.farmType = type;
        this.buildingType = BuildingType.None;
        this.animalType = AnimalType.None;
        //Debug.Log(farmType);
    }

    //��� Ÿ�� �ڵ� ����
    public void Initialize(AnimalType type)
    {
        Debug.Log("��������3");
        this.animalType = type;
        this.buildingType = BuildingType.None;
        this.farmType = FarmType.None;
        //Debug.Log(farmType);
    }

    //���� Ÿ�Ժ� ������ ����
    private void SetRecipesForBuilding()
    {
       
        Debug.Log("Ÿ�Ժ� ������ ����" + $"Setting recipes for building type: {buildingType}");

        if (RecipeManager.Instance.buildingRecipes.TryGetValue(buildingType, out List<Recipe> recipesForThisBuilding))
        {
            availableRecipes = recipesForThisBuilding;
        }
        else
        {
            Debug.Log("�ǹ��� �Ҵ�� ������ ����: " + buildingType);
        }
    }

    //������ ����
    public void SelectRecipe(Recipe recipe)
    {
        Debug.Log(gameObject + "������ ����ǰ �̸�" + $"Attempting to select recipe: {recipe.finishedProduct.processItemName}");

        if (availableRecipes.Contains(recipe))
        {
            Debug.Log($"Recipe {recipe.finishedProduct.processItemName} is available for this building.");

            SetRecipe(recipe);
        }
        else
        {
            Debug.Log("������ ��� �Ұ�");
        }
    }

    //private void SetRecipeDetails(Recipe recipe)
    //{
    //    Debug.Log("������ ����ǰ �̸�2" + $"Setting recipe for: {recipe.finishedProduct.processItemName}");

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
    //    Debug.Log("���õ� ������ ���� �ð� : " + recipe.productionTime);
    //}



    //������ ����
    public void SetRecipe(Recipe recipe)
    {
        
        Debug.Log("������ ����");
        Debug.Log($"[WorkBuilding] Set Recipe ID: {recipe.finishedProductId}");
        Debug.Log("���⿡ ������ ������ ����" + recipe);
        Debug.Log($"Recipe IsInitialized: {recipe.IsInitialized}");
        Debug.Log($"Recipe Finished Product ID: {recipe.finishedProductId}");



        if (recipe == null)
        {
            Debug.LogError("������ ����");
            return;
        }


        Debug.Log(gameObject +  "������ �̸�" + $"Setting recipe for: {recipe.finishedProduct.processItemName}");

        currentRecipe = recipe;
        needIngredient.Clear();

       
        if (!recipe.finishedProduct.IsInitialized)
        {
            Debug.LogError("recipe.finishedProduct�� �ʱ�ȭ���� �ʾҽ��ϴ�!");
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

        Debug.Log("������ ������ Ȯ��" + recipe.ingredients);
        product = new ProcessItemIItem(recipe.finishedProduct);
        productionDuration = recipe.productionTime;
        Debug.Log("������ ���� �ð�: " + recipe.productionTime);

    }

    //��� �߰�
    public void AddItem(IItem item)
    {
        Debug.Log("��� �߰�");
        if (buildingType == BuildingType.None) return;

        if (!isProducing && needIngredient.Contains(item)) //�����ǿ� �ʿ��� ������� Ȯ�� �� ���� ���� �ƴ��� Ȯ��
        {
            ingredientList.Add(item);

            //��� ��ᰡ �߰��Ǿ����� Ȯ��
            if (ingredientList.Count == needIngredient.Count)
            {
                StartProduction();
            }
        }
        else
        {
            //�ʿ����� ���� ���
        }
    }



    // �巡�׷� �ϼ�ǰ �̹����� ������ �� ȣ��Ǵ� �޼���
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("�ϼ�ǰ �̹��� ���� ȣ��");

        if (eventData.pointerDrag == finishedProductUI)
        {
            StartProduction();
        }
    }


    //���� ����
    public void StartProduction() 
    {
        Debug.Log("���� ����");


        // ���� ���õ� �����ǿ� �ʿ� ����� ����� �α� �߰�
        Debug.Log($"���� ������: {currentRecipe.finishedProduct.processItemName}");
        //Debug.Log("Required Ingredients for this recipe:");
        

        foreach (var ingredient in needIngredient)
        {
            Debug.Log($"- {ingredient.ItemName}");
        }


        // �ʿ��� ��ᰡ ������� Ȯ��
        foreach (IItem requiredItem in needIngredient)
        {
            Debug.Log("��� ���?");

            Debug.Log("[WorkBuilding] Needed ingredients for production:");


            foreach (var ingredient in needIngredient)
            {
                Debug.Log($"- Ingredient: {ingredient.ItemName}");
            }



            int requiredCount = needIngredient.Count(item => item.Equals(requiredItem));

            //â���� �ش� �������� ������ Ȯ��
            int availableCount = Storage.Instance.GetItemAmount(requiredItem);

            Debug.Log("Required item: " + requiredItem.ToString() + " | Required Count: " + requiredCount + " | Available Count: " + availableCount);

            if (availableCount < requiredCount)
            {
                Debug.Log("��ᰡ �����մϴ�!");
                return;
            }
        }

        // ��Ḧ â���� ����
        foreach (IItem requiredItem in needIngredient)
        {
            int requiredCount = needIngredient.Count(item => item == requiredItem);
            Storage.Instance.RemoveItem(requiredItem, requiredCount);
        }

        //�̹��� �����
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

    //���� �Ϸ� üũ
    private void CheckProduction() 
    {
        //Debug.Log("����Ϸ� üũ");
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

    //���� �Ϸ�
    private void CompleteProduction() 
    {
        Debug.Log("���� �Ϸ�");

        // �ϼ�ǰ�� â�� �߰�
        Storage.Instance.AddItem(product, 1);

        //��� ��� �ʱ�ȭ
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
            // �����ϰ� ����
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
            yield return new WaitForSeconds(blinkDuration);

            // ���� �������� ����
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
