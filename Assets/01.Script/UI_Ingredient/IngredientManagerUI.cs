using JinnyBuilding;
using JinnyProcessItem;
using JinnyCropItem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//by.J:230817 �ǹ��� ����� �ִ� UI / ����� â �̵�
//by.J:230818 �ϼ�ǰ �̹��� ID �߰�
//by.J:230824 �ϼ�ǰ �̹��� Ŭ���� ����� �̹��� ��Ÿ����
public class IngredientManagerUI : MonoBehaviour
{
    public GameObject copyBuilding;                   //�ǹ� ������
    public Vector3 uiOffset = new Vector3(-1, 1, 0);  //UI ��ġ ������. �ǹ��� ���� ��� �𼭸��� ��Ÿ���� ����µ� ���

    public GameObject arrow;                      //Arrow ���� ������Ʈ
    public RectTransform arrowRectTransform;      //Arrow ������Ʈ RectTransform
    public Image arrowImage;                      //Arrow �̹���
    public Transform copyFinishSlot;              //�ϼ�ǰ ����

    private GameObject clonedIngredientUI;        //����� UIâ
    private Transform currentClickedFinishImage;  //���� Ŭ���� finish Image(Clone)

    public static IngredientManagerUI Instance; //�̱���
    public Recipe specificRecipe;               //������
    public IngredientSlot ingredientSlotPrefab; //����� ������
    public Image finishImagePrefab;             //�ϼ�ǰ �̹��� ������
    public Image ingredientImagePrefab;         //����� �̹��� ������

    public List<IngredientSlot> ingredientSlots = new List<IngredientSlot>(); //����� �̹��� �Ҵ� ����
    public List<Image> productImageDisplays = new List<Image>();              //UI�� ǥ�õ� �ϼ�ǰ �̹���

    private void Awake()
    {
        //�̱���
        Debug.Log("����� ��ũ��Ʈ");
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < productImageDisplays.Count; i++)
        {
            AddEventTriggerToImage(productImageDisplays[i], i);
        }
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

    //�ǹ� ������ Ŭ����
    public void IngredientClick()
    {
        Debug.Log("����� ���");

        //���� ĳ�����ؼ� �ǹ� Ŭ�� �ν�
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        GameObject clickedBuilding = null;
        if (hit.collider != null)
        {
            Debug.Log("�ǹ� Ŭ����: " + hit.collider.gameObject.name);
            clickedBuilding = hit.collider.gameObject;
        }

        //Ŭ���� �ǹ��� ������ ��ȯ
        if (clickedBuilding == null) return;

        //Ŭ���� �ǹ� copyBuilding�� ����
        copyBuilding = clickedBuilding;

        //�ϼ�ǰ UI â �̵�
        SetUIPosition(clickedBuilding);

        WorkBuilding buildingComponent = clickedBuilding.GetComponent<WorkBuilding>();

        if (buildingComponent != null)
        {
            Debug.Log("�ϼ�ǰ �̹��� ��?");
            BuildingType buildingType = buildingComponent.buildingType; //���� Ÿ�� ����

            Debug.Log(RecipeManager.Instance.buildingRecipes.ContainsKey(buildingType));

            if (RecipeManager.Instance.buildingRecipes.ContainsKey(buildingType))
            {
                List<Recipe> recipesForBuilding = RecipeManager.Instance.buildingRecipes[buildingType];

                //�������� �̹��� ���� ����
                CreateProductImageSlots(recipesForBuilding.Count);
                Debug.Log("�̹��� ���� ������ �ǳ�?" + recipesForBuilding.Count);

                //�̹��� �Ҵ�
                for (int i = 0; i < recipesForBuilding.Count; i++)
                {
                    productImageDisplays[i].sprite = recipesForBuilding[i].FinishedProductImage;
                }
            }

            else
            {
                Debug.LogError("����Ÿ�� " + buildingType + " is not present in buildingRecipes dictionary.");
            }
        }

        //ingredient �±� ���� ��� �ν��Ͻ� ã��
        GameObject[] allIngredientUIs = GameObject.FindGameObjectsWithTag("ingredient");
        clonedIngredientUI = null;

        Debug.Log("���� �Գ�?");

        //������ UI ã��
        foreach (var ui in allIngredientUIs)
        {
            Debug.Log("������ ����?");
            if (ui.name.Contains("(Clone)"))
            { 
                clonedIngredientUI = ui;
                Debug.Log(clonedIngredientUI);
                break;
            }
        }

        if (clonedIngredientUI == null)
        {
            Debug.LogError("Ingredient UI�� �������� ã�� �� �����ϴ�.");
            return;
        }
    }
    
    //�ϼ�ǰ Ŭ���� ����� ǥ��
    public void ShowfinishIngredient(Recipe recipe)
    {
        //����� ǥ��
        Debug.Log("�ϼ�ǰ Ŭ�� ����");
        ShowIngredient(recipe);
    }

    //�ϼ�ǰ �̹��� Ŭ��
    public void ProductImageClicked(int index)
    {
        Debug.Log("�ϼ�ǰ Ŭ�� ����");
        //Ŭ�� �̹��� �ε����� �ش� ������ ã�� 
        BuildingType currentBuildingType = copyBuilding.GetComponent<WorkBuilding>().buildingType;
        Recipe clickedRecipe = RecipeManager.Instance.buildingRecipes[currentBuildingType][index];

        Debug.Log("Ŭ���� ������" + clickedRecipe);

        //���� Ŭ���� �ϼ�ǰ �̹��� ����
        currentClickedFinishImage = productImageDisplays[index].transform;
        Debug.Log("Ŭ���� �̹��� �ε���" + productImageDisplays[index].transform);

        //�ش� �������� ����� ǥ��
        ShowfinishIngredient(clickedRecipe);

        //Ingredient Slot(Clone) ����
        CreateIngredientSlot(clickedRecipe);

        //Ŭ���� �̹��� ��ġ ����
        RectTransform clickedImageTransform = productImageDisplays[index].rectTransform;

        //Ingredient Slot(Clone)�� ��ġ ���� - Ŭ���� �̹��� �Ʒ�
        for (int i = 0; i < ingredientSlots.Count; i++)
        {
            RectTransform slotRect = ingredientSlots[i].GetComponent<RectTransform>();

            //Ŭ���� �̹��� �Ʒ��� Ingredient Slot(Clone) ��ġ
            float offsetY = (i + 1) * slotRect.sizeDelta.y;
            slotRect.position = new Vector3
                (currentClickedFinishImage.position.x, currentClickedFinishImage.position.y - offsetY, currentClickedFinishImage.position.z);
        }
    }


    //������ �� ����� �����ֱ�
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("����� �Լ���");

        for (int i = 0; i < ingredientSlots.Count; i++)
        {
            Debug.Log("0");
            if (i < recipe.ingredients.Count)
            {
                Debug.Log("1");
                object ingredientObj = recipe.ingredients[i];

                if (ingredientObj is Ingredient<IItem> itemIngredient)
                {
                    Debug.Log("2");
                    ingredientSlots[i].SetIngredient(itemIngredient.item, itemIngredient.quantity);
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
                {
                    Debug.Log("3");
                    ingredientSlots[i].SetIngredient(new ProcessItemIItem(processedIngredient.item), processedIngredient.quantity);
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("4");
                    ingredientSlots[i].gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("5");
                ingredientSlots[i].gameObject.SetActive(false);
            }

            Debug.Log("6");
        }

        Debug.Log("7");
    }

    //�ϼ�ǰ UI â �̵�
    public void SetUIPosition(GameObject targetBuilding)
    {
        Debug.Log("UI �̵� �̵�");
        if (targetBuilding == null) return;

        SpriteRenderer buildingRenderer = targetBuilding.GetComponent<SpriteRenderer>();
        if (buildingRenderer != null)
        {
            Bounds buildingBounds = buildingRenderer.bounds;

            //�ǹ��� ���� ��� �𼭸� ��ġ�� ������ �߰�
            Vector3 targetPosition = buildingBounds.center + uiOffset;

            //UIâ�� ��ġ�� �ǹ��� ���� ��� �𼭸� �°� ����
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);

            Debug.Log("Setting UI to: " + transform.position.ToString());
        }
    }

    //�ϼ�ǰ �̹��� ���� ����
    public void CreateProductImageSlots(int numberOfSlots)
    {
        Debug.Log("�ϼ�ǰ �̹��� ���� ����");
        //���� ���� ��Ȱ��ȭ
        foreach (Image img in productImageDisplays)
        {
            img.gameObject.SetActive(false);
        }

        //�ʿ��� ���� Ȱ��ȭ, ���� 
        for (int i = 0; i < numberOfSlots; i++)
        {
            if (i >= productImageDisplays.Count)
            {
                Image newImage = Instantiate(finishImagePrefab, transform);
                productImageDisplays.Add(newImage);
                Debug.Log("Image created at: " + Time.time);
            }
            else
            {
                productImageDisplays[i].gameObject.SetActive(true);
            }

            //�� �̹����� EventTrigger �߰� �� �ε��� ����
            AddEventTriggerToImage(productImageDisplays[i], i);
        }
    }

    //����� ���� ����
    public void CreateIngredientSlot(Recipe recipe)
    {
        Debug.Log("����� ���� Ȱ��ȭ?");

        // ���� ���� ��� ��Ȱ��ȭ
        foreach (var slot in ingredientSlots)
        {
            Debug.Log("��Ȱ��ȭ");
            Destroy(slot.gameObject);

        }
        ingredientSlots.Clear();

        //IngredientSlot �� �� ����
        IngredientSlot newSlot = Instantiate(ingredientSlotPrefab, clonedIngredientUI.transform);
        newSlot.gameObject.SetActive(true);
        

        //������ ���Կ��� arrow ã��
        Transform arrowChild = newSlot.transform.Find("arrow");
        if (arrowChild != null)
        {
            //arrow ������Ʈ ����
            Destroy(arrowChild.gameObject);
            Debug.Log("����");
        }

        //������ ����� ���� ���� �̹��� ������Ʈ ����
        for (int i = 0; i < recipe.ingredients.Count; i++)
        {
            Debug.Log("����� �̹��� �߰�");

            Image ingredientImage = Instantiate(ingredientImagePrefab, newSlot.transform);
            ingredientImage.gameObject.SetActive(true);

            object ingredientObj = recipe.ingredients[i];
            if (ingredientObj is Ingredient<CropItemDataInfo> cropIngredient)
            {
                Debug.Log("if��");
                ingredientImage.sprite = cropIngredient.item.cropItemImage;
                newSlot.SetIngredient(new CropItemIItem(cropIngredient.item), cropIngredient.quantity);
            }
            else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                Debug.Log("else if��");
                ingredientImage.sprite = processedIngredient.item.processItemImage;
                newSlot.SetIngredient(new ProcessItemIItem(processedIngredient.item), processedIngredient.quantity);
            }
        }
        ingredientSlots.Add(newSlot);
    }
}

