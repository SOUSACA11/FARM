using JinnyAnimal;
using JinnyBuilding;
using JinnyCropItem;
using JinnyFarm;
using JinnyProcessItem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private List<Recipe> availableRecipes = new List<Recipe>();



    public GameObject copyBuilding;
    private Transform currentClickedFinishImage;
    public List<Image> productImageDisplays = new List<Image>();

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
        ////////////////////////////
        SetRecipesForBuilding();
        for (int i = 0; i < productImageDisplays.Count; i++)
        {
            AddEventTriggerToImage(productImageDisplays[i], i);
        }
        //////////////////////
    }

    private void Update()
    {
        CheckProduction();
    }

    //���� Ÿ�� �ڵ� ����
    public void Initialize(BuildingType type)
    {
        this.buildingType = type;
        this.farmType = FarmType.None;
        this.animalType = AnimalType.None;

    }

    //���� Ÿ�� �ڵ� ����
    public void Initialize(FarmType type)
    {
        this.farmType = type;
        this.buildingType = BuildingType.None;
        this.animalType = AnimalType.None;
    }

    //��� Ÿ�� �ڵ� ����
    public void Initialize(AnimalType type)
    {
        this.animalType = type;
        this.farmType = FarmType.None;
        this.buildingType = BuildingType.None;
    }


    //���� Ÿ�Ժ� ������ ����
    private void SetRecipesForBuilding()
    {
        //if (RecipeManager.Instance.buildingRecipes.TryGetValue(buildingType, out List<Recipe> recipesForThisBuilding))
        //{
        //    foreach (Recipe recipe in recipesForThisBuilding)
        //    {
        //        this.SetRecipe(recipe);
        //    }
        //}
        //else
        //{
        //    Debug.Log("No recipes found for building type: " + buildingType);
        //}

        Debug.Log("Ÿ�Ժ� ������ ����" + $"Setting recipes for building type: {buildingType}");

        if (RecipeManager.Instance.buildingRecipes.TryGetValue(buildingType, out List<Recipe> recipesForThisBuilding))
        {
            availableRecipes = recipesForThisBuilding;
        }
        else
        {
            Debug.Log("No recipes found for building type: " + buildingType);
        }
    }





    //������ ����
    public void SelectRecipe(Recipe recipe)
    {
        Debug.Log($"Attempting to select recipe: {recipe.finishedProduct.processItemName}");

        if (availableRecipes.Contains(recipe))
        {
            Debug.Log($"Recipe {recipe.finishedProduct.processItemName} is available for this building.");

            SetRecipeDetails(recipe);
        }
        else
        {
            Debug.Log("This building can't use this recipe!");
        }
    }

    private void SetRecipeDetails(Recipe recipe)
    {
        Debug.Log($"Setting recipe for: {recipe.finishedProduct.processItemName}");

        currentRecipe = recipe;
        needIngredient.Clear();

        foreach (var ingredientObj in recipe.ingredients)
        {
            if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
            }
            else if (ingredientObj is Ingredient<CropItemDataInfo> cropIngredient)
            {
                needIngredient.Add(new CropItemIItem(cropIngredient.item));
            }
        }

        product = new ProcessItemIItem(recipe.finishedProduct);
        productionDuration = recipe.productionTime;
        Debug.Log("Setting productionDuration to: " + recipe.productionTime);
    }



    //�ϼ�ǰ �̹��� Ŭ��////////////////////////////////////////////////
    public void ProductImageClicked(int index)
    {
        Debug.Log("�ϼ�ǰ Ŭ�� ����");

        Debug.Log("ProductImageClicked ȣ���.");
        if (copyBuilding == null)
        {
            Debug.LogError("copyBuilding�� null�Դϴ�.");
            return;
        }

        if (copyBuilding == null)
        {
            Debug.LogError("No building has been clicked yet.");
            return;
        }

        //Ŭ�� �̹��� �ε����� �ش� ������ ã�� 
        BuildingType currentBuildingType = copyBuilding.GetComponent<WorkBuilding>().buildingType;
        Recipe clickedRecipe = RecipeManager.Instance.buildingRecipes[currentBuildingType][index];

        Debug.Log("Ŭ���� ������" + clickedRecipe);

        //���� Ŭ���� �ϼ�ǰ �̹��� ����
        currentClickedFinishImage = productImageDisplays[index].transform;
        Debug.Log("Ŭ���� �̹��� �ε���" + productImageDisplays[index].transform);
    }

    //�̹��� Ʈ���� �߰�
    void AddEventTriggerToImage(Image targetImage, int index)
    {
        Debug.Log("�Լ� �߰� ���" + index);

        EventTrigger eventTrigger = targetImage.gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
            eventTrigger = targetImage.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { ProductImageClicked(index); });

        eventTrigger.triggers.Clear();
        eventTrigger.triggers.Add(entry);
    }

    /// /////////////////////////////////////////////////////////////////



    //������ ����
    public void SetRecipe(Recipe recipe)
    {

        if (recipe == null)
        {
            Debug.LogError("Provided recipe is null!");
            return;
        }

        if (!recipe.IsInitialized)
        {
            Debug.LogError("Recipe is not initialized!");
            return;
        }

        if (!recipe.finishedProduct.IsInitialized)
        {

            Debug.LogError("recipe.finishedProduct is not initialized!");
            return;
        }
        foreach (var ingredientObj in recipe.ingredients)
        {
            if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
            }
            else if (ingredientObj is Ingredient<CropItemDataInfo> cropIngredient)
            {
                needIngredient.Add(new CropItemIItem(cropIngredient.item));
            }
        }

        product = new ProcessItemIItem(recipe.finishedProduct);
        productionDuration = recipe.productionTime;
        Debug.Log("Setting productionDuration to: " + recipe.productionTime);




        //Debug.Log($"Setting recipe for: {recipe.finishedProduct.processItemName}");
        //foreach (var ingredient in needIngredient)
        //{
        //    Debug.Log($"Needed ingredient for {recipe.finishedProduct.processItemName}: {ingredient.ItemName}");
        //}

        ////Debug.Log("������ ����");
        ////if (buildingType == BuildingType.None) return;

        ////currentRecipe = recipe;
        ////needIngredient.Clear();
        ////Debug.Log("Setting productionDuration to111: " + recipe.productionTime);

        ////foreach (var ingredientObj in recipe.ingredients)
        ////{
        ////    //��ᰡ Ingredient<ProcessItemDataInfo> Ÿ������ Ȯ��
        ////    if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
        ////    {
        ////        needIngredient.Add(new ProcessItemIItem(processedIngredient.item));
        ////    }
        ////    // CropItemDataInfo Ÿ���� ��� ó��
        ////    else if (ingredientObj is Ingredient<CropItemDataInfo> cropIngredient)
        ////    {
        ////        needIngredient.Add(new CropItemIItem(cropIngredient.item));
        ////    }
        ////}
        ////product = new ProcessItemIItem(recipe.finishedProduct);
        ////productionDuration = recipe.productionTime;
        ////Debug.Log("Setting productionDuration to222: " + recipe.productionTime);


        //if (availableRecipes.Contains(recipe))
        //{
        //    SetRecipe(recipe);
        //}
        //else
        //{
        //    Debug.Log("This building can't use this recipe!");
        //}
    }

    //��� �߰�
    public void AddItem(IItem item)
    {
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
        Debug.Log($"Selected Recipe: {currentRecipe.finishedProduct.processItemName}");
        Debug.Log("Required Ingredients for this recipe:");
        //foreach (var ingredient in needIngredient)
        //{
        //    Debug.Log($"- {ingredient.ItemName}");
        //}


        // �ʿ��� ��ᰡ ������� Ȯ��
        //foreach (IItem requiredItem in needIngredient)
        //{
        Debug.Log("��� ���?");
        //Debug.Log("[WorkBuilding] Needed ingredients for production:");

        //foreach (var ingredient in needIngredient)
        //{
        //    Debug.Log($"- Ingredient: {ingredient.ItemName}");
        //}
        //int requiredCount = needIngredient.Count(item => item.Equals(requiredItem));
        ////â���� �ش� �������� ������ Ȯ��
        //int availableCount = Storage.Instance.GetItemAmount(requiredItem);
        //Debug.Log("�ʿ�������̸�: " + requiredItem.ToString() + " | ������ ����: " + requiredCount + " | â�����: " + availableCount);
        ////Debug.Log("Required item: " + requiredItem.ItemName + " | Required Count: " + requiredCount + " | Available Count: " + availableCount);
        //if (availableCount < requiredCount)
        //{
        //    Debug.Log("��ᰡ �����մϴ�!");
        //    return;
        //}

        bool enoughIngredients = true;
        foreach (IItem requiredItem in needIngredient)
        {
            int requiredCount = needIngredient.Count(item => item.Equals(requiredItem));
            int availableCount = Storage.Instance.GetItemAmount(requiredItem);
<<<<<<< HEAD
=======
            Debug.Log("�ʿ�������̸�: " + requiredItem.ToString() + " | ������ ����: " + requiredCount + " | â�����: " + availableCount);
            //Debug.Log("Required item: " + requiredItem.ItemName + " | Required Count: " + requiredCount + " | Available Count: " + availableCount);
>>>>>>> 9a48014a83e6cc12ac00691a590c038264773074

            if (availableCount < requiredCount)
            {
                Debug.Log($"��� {requiredItem.ItemName} �� �����մϴ�!");
                enoughIngredients = false;
                break;
            }

        }
        // �ʿ��� ��ᰡ ������� �ʴٸ�, ������ �������� �ʴ´�.
        if (!enoughIngredients) return;

        // �ʿ��� ��Ḧ â���� ����
        foreach (IItem requiredItem in needIngredient)
        {
            int requiredCount = needIngredient.Count(item => item.Equals(requiredItem));
            Storage.Instance.RemoveItem(requiredItem, requiredCount);
        }



        // �ִϸ��̼� ����
        StartCoroutine(StartProductionAnimation());
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

    //��¦��¦ ȿ��
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

    //Ŀ���� �پ���
    IEnumerator StartProductionAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.2f; // 1.2�� ũ��� ���� (���ϴ� ������ ���� ����)

        float duration = 0.5f; // �ִϸ��̼� ���� �ð�
        float elapsed = 0;

        // Ŀ���� �ִϸ��̼�
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        elapsed = 0;
        // ���� ũ��� ���ƿ��� �ִϸ��̼�
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}
