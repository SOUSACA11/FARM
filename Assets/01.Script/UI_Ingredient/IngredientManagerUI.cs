using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyProcessItem;
using UnityEngine.UI;
using JinnyBuilding;

//by.J:230817 �ǹ��� ����� �ִ� UI / ����� â �̵�
//by.J:230818 �ϼ�ǰ �̹��� ID �߰�
public class IngredientManagerUI : MonoBehaviour
{

    public Image image;            //������ ���� â �̹��� 
    public Vector3 endPosition;    //������ �̵� ��ġ
    public float speed = 120f;     //�̵� �ӵ�
    //private Vector3 startPosition; //������ġ

    public GameObject copyBuilding;//�ǹ� ������
    public Vector3 uiOffset = new Vector3(-1, 1, 0); // UI ��ġ ������. �ǹ��� ���� ��� �𼭸��� ��Ÿ���� ����µ� ���

    public static IngredientManagerUI Instance;
    public IngredientSlot[] ingredientSlots; //����� ����
    public Recipe specificRecipe; //������

    public Image productImageDisplay; // UI�� ǥ�õ� �ϼ�ǰ �̹���

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

        // Ray�� ĳ�����Ͽ� � �ǹ��� Ŭ���Ǿ����� Ȯ���մϴ�.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        GameObject clickedBuilding = null;
        if (hit.collider != null)
        {
            //Debug.Log("�ǹ� Ŭ����?");
            Debug.Log("�ǹ� Ŭ����: " + hit.collider.gameObject.name);
            clickedBuilding = hit.collider.gameObject;
        }
        
        if (clickedBuilding == null) return; // Ŭ���� �ǹ��� ������ ��ȯ

        // Ŭ���� �ǹ��� attachedBuilding�� �����մϴ�.
        copyBuilding = clickedBuilding;


        // �ش� �ǹ��� �����ǿ� ���� UI ��ġ�� ������ ������Ʈ�մϴ�.
        //SetUIPosition(clickedBuilding);

        //WorkBuilding buildingComponent = clickedBuilding.GetComponent<WorkBuilding>();
        //if (buildingComponent != null)
        //{
        //    ShowIngredient(buildingComponent.currentRecipe);
        //}

        WorkBuilding buildingComponent = clickedBuilding.GetComponent<WorkBuilding>();

        if (buildingComponent != null)
        {
            Debug.Log("�ϼ�ǰ �̹��� ��?");
            BuildingType buildingType = buildingComponent.buildingType; // �̰� WorkBuilding Ŭ������ �ǹ� ���� ������ �־�� �մϴ�.
            
            //List<Recipe> recipesForBuilding = RecipeManager.Instance.buildingRecipes[buildingType];

            if (RecipeManager.Instance.buildingRecipes.ContainsKey(buildingType))
            {
                List<Recipe> recipesForBuilding = RecipeManager.Instance.buildingRecipes[buildingType];
                
                Debug.Log("������ ��: " + recipesForBuilding.Count);
                Debug.Log("�ǹ� ����: " + buildingType);

                if (recipesForBuilding != null && recipesForBuilding.Count > 0)
                {
                    // ���÷� ù ��° �������� �ϼ�ǰ �̹����� ����մϴ�.
                    // �ʿ信 ���� �ٸ� �������� Ư�� �����Ǹ� ������ �� �ֽ��ϴ�.
                    Recipe buildingRecipe = recipesForBuilding[0];
                    productImageDisplay.sprite = buildingRecipe.FinishedProductImage;
                    productImageDisplay.gameObject.SetActive(true);

                    Debug.Log(buildingRecipe.FinishedProductImage);

                    ShowIngredient(buildingRecipe);
                }
            }
            else
            {
                Debug.LogError("The building type " + buildingType + " is not present in buildingRecipes dictionary.");
            }

            
        }


        SetUIPosition(clickedBuilding);
        ShowIngredient(specificRecipe);

        //����� â ��� Ȱ��ȭ
        //StartCoroutine(MoveImageUp());
    }

    //������ �� ����� �����ֱ�
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("����� �Լ���");

        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            Debug.Log("0");
            if (i < recipe.ingredients.Count)
            {
                Debug.Log("1");
                object ingredientObj = recipe.ingredients[i];

                if (ingredientObj is Ingredient<IItem> itemIngredient)
                {
                    Debug.Log("2");
                    ingredientSlots[i].SetIngredient(itemIngredient.item);
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
                {
                    Debug.Log("3");
                    ingredientSlots[i].SetIngredient(new ProcessItemIItem(processedIngredient.item));
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

    //����� UI â �̵�
    public void SetUIPosition(GameObject targetBuilding)
    {
        Debug.Log("UI �̵� �̵�");
        if (targetBuilding == null) return;

        SpriteRenderer buildingRenderer = targetBuilding.GetComponent<SpriteRenderer>();
        if (buildingRenderer != null)
        {
            Bounds buildingBounds = buildingRenderer.bounds;

            // �ǹ��� ���� ��� �𼭸� ��ġ�� ����ϰ� �������� �߰��մϴ�.
            Vector3 targetPosition = buildingBounds.center + uiOffset;

            // UIâ�� ��ġ�� �ǹ��� ���� ��� �𼭸��� �°� �����մϴ�.
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);

            Debug.Log("Setting UI to: " + transform.position.ToString());
        }
    }

}

