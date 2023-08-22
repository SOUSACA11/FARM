using JinnyBuilding;
using JinnyProcessItem;
using JinnyCropItem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//by.J:230817 �ǹ��� ����� �ִ� UI / ����� â �̵�
//by.J:230818 �ϼ�ǰ �̹��� ID �߰�
//by.J:230819 �̤̤̤̤ФФФ�
public class IngredientManagerUI : MonoBehaviour
{

    //public Image image;            //������ ���� â �̹��� 
    //public Vector3 endPosition;    //������ �̵� ��ġ
    //public float speed = 120f;     //�̵� �ӵ�

    public GameObject copyBuilding;                   //�ǹ� ������
    public Vector3 uiOffset = new Vector3(-1, 1, 0);  //UI ��ġ ������. �ǹ��� ���� ��� �𼭸��� ��Ÿ���� ����µ� ���


    //public RectTransform ret;
    public GameObject arrow;  // Arrow ���� ������Ʈ�� ���� ����
    public RectTransform arrowRectTransform; // Arrow ������Ʈ�� RectTransform ����
    public Image arrowImage;
    public Transform copyFinishSlot; // �ϼ�ǰ ���Կ� ���� ����
    private GameObject clonedIngredientUI;
    private Transform currentClickedFinishImage; // ���� Ŭ���� finish Image(Clone)




    public static IngredientManagerUI Instance; //�̱���
    //public IngredientSlot[] ingredientSlots;   //����� ����
    public Recipe specificRecipe;              //������
    public IngredientSlot ingredientSlotPrefab; // ����� ������

    public List<IngredientSlot> ingredientSlots = new List<IngredientSlot>(); //����� �̹��� �Ҵ� ����
    public List<Image> productImageDisplays = new List<Image>();    //UI�� ǥ�õ� �ϼ�ǰ �̹���
    public Image imagePrefab;                                      //�ϼ�ǰ ������

    private void Awake()
    {
        Debug.Log("����� ��ũ��Ʈ");
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
            //Debug.Log("�ǹ� Ŭ����?");
            Debug.Log("�ǹ� Ŭ����: " + hit.collider.gameObject.name);
            clickedBuilding = hit.collider.gameObject;
         
        }

        //Ŭ���� �ǹ��� ������ ��ȯ
        if (clickedBuilding == null) return;

        //Ŭ���� �ǹ� copyBuilding�� ����
        copyBuilding = clickedBuilding;




        //UI â �̵�
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



        // ingredient�� ��� �ν��Ͻ��� ã���ϴ�.
        GameObject[] allIngredientUIs = GameObject.FindGameObjectsWithTag("ingredient");
        clonedIngredientUI = null;

        Debug.Log("���� �Գ�?");


        // �������� ã���ϴ�. (������ "(Clone)" ���̻簡 �����ϴ�.)
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

    public void ShowfinishIngredient(Recipe recipe)
    {
        //����� ǥ��
        Debug.Log("�ϼ�ǰ Ŭ�� ����");
        ShowIngredient(recipe);
    }




    public void ProductImageClicked(int index)//�ϼ�ǰ �̹��� Ŭ��
    {
        Debug.Log("Ŭ�� ����");
        // Ŭ���� �̹����� �ε����� ����Ͽ� �ش� �����Ǹ� ã���ϴ�.
        BuildingType currentBuildingType = copyBuilding.GetComponent<WorkBuilding>().buildingType;
        Recipe clickedRecipe = RecipeManager.Instance.buildingRecipes[currentBuildingType][index];

        Debug.Log("clickedRecipe" + clickedRecipe);

        // ���� Ŭ���� finish Image(Clone) ������Ʈ
        currentClickedFinishImage = productImageDisplays[index].transform;

        Debug.Log("Ŭ���� �̹���" + productImageDisplays[index].transform);

        // �ش� �������� ����� ǥ��
        ShowfinishIngredient(clickedRecipe);

        ShowIngredient(clickedRecipe);

        // Ingredient Slot(Clone) ����
        CreateIngredientSlot(clickedRecipe, currentClickedFinishImage);

        // ���⼭ Ŭ���� �̹����� ��ġ�� �����մϴ�.
        RectTransform clickedImageTransform = productImageDisplays[index].rectTransform;

        /// Ingredient Slot(Clone)�� ��ġ�� �����մϴ�. ��ġ�� Ŭ���� �̹��� �Ʒ��� �־�� �մϴ�.
        for (int i = 0; i < ingredientSlots.Count; i++)
        {
            RectTransform slotRect = ingredientSlots[i].GetComponent<RectTransform>();

            // Ŭ���� �̹��� �Ʒ��� Ingredient Slot(Clone)�� ��ġ�մϴ�.
            float offsetY = (i + 1) * slotRect.sizeDelta.y;
            //slotRect.position = new Vector3(clickedImageTransform.position.x, clickedImageTransform.position.y - offsetY, clickedImageTransform.position.z);
            slotRect.position = new Vector3(currentClickedFinishImage.position.x, currentClickedFinishImage.position.y - offsetY, currentClickedFinishImage.position.z);
        }
    }



    //������ �� ����� �����ֱ�
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("����� �Լ���");

        CreateIngredientSlot(recipe, currentClickedFinishImage);

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
                Image newImage = Instantiate(imagePrefab, transform);
                productImageDisplays.Add(newImage);
            }
            else
            {
                productImageDisplays[i].gameObject.SetActive(true);
            }
        }
    }

    //����� ���� ����


    public void CreateIngredientSlot(Recipe recipe, Transform clickedFinishImage)
    {
        Debug.Log("����� ���� Ȱ��ȭ?");

        // ���� ���� ��� ��Ȱ��ȭ
        foreach (var slot in ingredientSlots)
        {
            Debug.Log("��Ȱ��ȭ");
            Destroy(slot.gameObject);
        }
        ingredientSlots.Clear();

        // Ŭ���� finish Image(Clone)�� arrow ������ �����ɴϴ�.
        //RectTransform arrowInClickedFinishImage = currentClickedFinishImage ? currentClickedFinishImage.Find("arrow").GetComponent<RectTransform>() : null;
        RectTransform arrowInClickedFinishImage = clickedFinishImage ? clickedFinishImage.Find("arrow").GetComponent<RectTransform>() : null;



        if (arrowInClickedFinishImage == null)
        {
            Debug.LogError("Ŭ���� finish Image(Clone)�� arrow�� �����ϴ�.");
            return;
        }

        // �������� ����� ���� �°� ���� ����
        for (int i = 0; i < recipe.ingredients.Count; i++)
        {
            Debug.Log("����� ���� ���� ����?");
            IngredientSlot newSlot = Instantiate(ingredientSlotPrefab, clonedIngredientUI.transform);

            newSlot.gameObject.SetActive(true);

            // ���ο� ������ RectTransform�� �����ɴϴ�
            RectTransform newSlotRectTransform = newSlot.GetComponent<RectTransform>();

            // ���ο� ������ ��ġ�� finish image �Ʒ��� ����
            newSlotRectTransform.anchoredPosition = arrowInClickedFinishImage.anchoredPosition - new Vector2(0, (newSlotRectTransform.sizeDelta.y + arrowImage.rectTransform.sizeDelta.y) * (i + 1));

            object ingredientObj = recipe.ingredients[i];
            if (ingredientObj is Ingredient<IItem> itemIngredient)
            {
                Debug.Log("if��");
                newSlot.SetIngredient(itemIngredient.item, itemIngredient.quantity);
            }
            else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                Debug.Log("else if��");
                newSlot.SetIngredient(new ProcessItemIItem(processedIngredient.item), processedIngredient.quantity);
            }
            ingredientSlots.Add(newSlot);
        }
    }
}

