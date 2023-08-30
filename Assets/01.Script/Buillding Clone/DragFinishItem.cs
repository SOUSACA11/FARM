using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JinnyBuilding;

//by.J:230827 �ϼ������� �̹��� �巡�� ��� ���
public class DragFinishItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   // public Transform originalParent;
    private Vector3 startPosition;
    private GameObject clonedImage;

    public DragAndDropCamera cameraDragScript;      //ī�޶� �巡�� ���
    public IngredientManagerUI ingredientManagerUI; //����� â
    public Recipe currentSelectedRecipe;            //���� ������
  
    public GameObject copyBuilding;          //�ǹ� ������
    public BuildingType currentBuildingType; //���� Ÿ�� 
    public Recipe currentRecipe; //���� ������

    public WorkBuilding finishImageBuilding;
    public int index;

    //public int index = -1;

    private void Awake()
    {
        //StoreSlot.OnBuildingTypeChanged += UpdateCurrentBuildingType;
        cameraDragScript = Camera.main.GetComponent<DragAndDropCamera>();

        //    if (finishImageBuilding != null)
        //{
        //    finishImageBuilding.Initialize(type);
        //}

    }


    private void Start()
    {
        if (finishImageBuilding != null)
        {
            currentBuildingType = finishImageBuilding.buildingType;
            Debug.Log("Assigned Building Type from WorkBuilding: " + currentBuildingType);
        }
        else
        {
            Debug.LogError("finishImageBuilding is not assigned in the inspector.");
        }


        //// index�� �ʱ� ���� -1�̹Ƿ� �� ���� �˻��Ͽ� ��ȿ�� �������� Ȯ���մϴ�.
        //if (index >= 0)
        //{
        //    UpdateAvailableRecipes(index);
        //}
        //else
        //{
        //    Debug.LogError("Invalid index value.");
        //}

        // ī�޶��� DragAndDropCamera ��ũ��Ʈ�� ���
        // cameraDragScript = Camera.main.GetComponent<DragAndDropCamera>();


    }


    //// ���� ���� Ÿ�Կ� ���� ��� ������ ������ ����� �������� �޼��� �߰�
    //private void UpdateAvailableRecipes()
    //{
    //    if (RecipeManager.Instance.buildingRecipes.ContainsKey(currentBuildingType))
    //    {
    //        List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];

    //        // ����: ù ��° �����Ǹ� �����ϴ� ���
    //        // �����δ� ������� ���ÿ� ���� �ش� �����Ǹ� �����ؾ� �մϴ�.
    //        if (recipesForThisBuilding.Count > 0)
    //        {
    //            currentSelectedRecipe = recipesForThisBuilding[0];
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Building type " + currentBuildingType + " not found in the dictionary.");
    //    }
    //}
    // ���� ���� Ÿ�Կ� ���� ��� ������ ������ ����� �������� �޼��� �߰�
    private void UpdateAvailableRecipes(int selectedIndex = 0)
    {
        if (RecipeManager.Instance.buildingRecipes.ContainsKey(currentBuildingType))
        {
            List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];
            Debug.Log("Number of recipes for this building: " + recipesForThisBuilding.Count);
            Debug.Log("Selected index: " + selectedIndex);

            if (selectedIndex >= 0 && selectedIndex < recipesForThisBuilding.Count)
            {
                currentSelectedRecipe = recipesForThisBuilding[selectedIndex];
            }
            else
            {
                Debug.LogError("Selected index is out of range.");
            }
        }
        else
        {
            Debug.LogError("Building type " + currentBuildingType + " not found in the dictionary.");
        }
    }

    

    private void Update()
    {
        //Debug.Log(gameObject + "Current Building Type: " + currentBuildingType);
        Debug.Log("Current Recipe in DragFinishItem: " + currentRecipe);
        //UpdateAvailableRecipes(index);

    }


    public void FinishImageOnClick()
    {
        Debug.Log("Current Building Type222: " + currentBuildingType);

        Debug.Log("�ϼ�ǰ �̹��� Ŭ��");
        // ���� �̹����� raycastTarget�� ��Ȱ��ȭ
        GetComponent<Image>().raycastTarget = false;

        //if (cameraDragScript != null)
        //{
        //    cameraDragScript.NoDrag();  // �巡�� ���۽� ī�޶� �巡�� ��Ȱ��ȭ
        //}
        //Debug.Log($"ingredientManagerUI: {ingredientManagerUI}, index: {index}");

        // ������ �̹��� ����
        clonedImage = Instantiate(gameObject, transform.position, transform.rotation);
        // ���� ĵ������ ã�Ƽ� clonedImage�� �θ�� ����
        Canvas mainCanvas = FindObjectOfType<Canvas>();
        if (mainCanvas)
        {
            clonedImage.transform.SetParent(mainCanvas.transform, false);
            clonedImage.transform.SetAsLastSibling();  // Ȯ���ϰ� ������ �ڽ����� ����
        }
        clonedImage.transform.SetAsLastSibling();  // Ȯ���ϰ� ������ �ڽ����� ����

        Image originalImageComp = GetComponent<Image>();
        Image clonedImageComp = clonedImage.GetComponent<Image>();
        if (originalImageComp != null && clonedImageComp != null)
        {
            clonedImageComp.sprite = originalImageComp.sprite; // Sprite ����
            clonedImageComp.color = originalImageComp.color;   // Color ����
            clonedImageComp.raycastTarget = false;  // ������ �̹����� raycastTarget�� ��Ȱ��ȭ
        }
        //// ���� �̹����� ����
        //GetComponent<Image>().enabled = false;

        //// ���� �̹����� raycastTarget�� ��Ȱ��ȭ
        //GetComponent<Image>().raycastTarget = false;

        // ���⼭ IngredientManagerUI�� ProductImageClicked�� ȣ���մϴ�.
        if (ingredientManagerUI != null)
        {
            Debug.Log("����� â �ҷ����� ����");
            int obtainedIndex = ingredientManagerUI.GetIndexFromImage(this.GetComponent<Image>().gameObject);
            if (obtainedIndex >= 0)
            {
                ingredientManagerUI.ProductImageClicked(obtainedIndex);
            }
            else
            {
                Debug.LogError("Invalid index obtained from the image.");
            }
        }

        startPosition = transform.position;
    }

    //�巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(gameObject + "Current Building Type: " + currentBuildingType);
        Debug.Log("�ϼ�ǰ �̹��� �巡�� ����");

        // ���� ���� Ÿ�Կ� ���� ������ ����Ʈ�� ���
        // List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];

        //if (RecipeManager.Instance.buildingRecipes.ContainsKey(currentBuildingType))
        //{
        //    List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];
        //    // ... ������ �ڵ�
        //}
        //else
        //{
        //    Debug.LogError("Building type " + currentBuildingType + " not found in the dictionary.");
        //}

        //Debug.Log("������ �̹���?" + recipesForThisBuilding);
        if (ingredientManagerUI != null)
        {
            int obtainedIndex = ingredientManagerUI.GetIndexFromImage(this.GetComponent<Image>().gameObject);  // <-- �� �κ� ����
            if (obtainedIndex >= 0)
            {
                UpdateAvailableRecipes(obtainedIndex);
            }
            else
            {
                Debug.LogError("Invalid index obtained from the image.");
            }
        }


        if (cameraDragScript != null)
        {
            cameraDragScript.NoDrag();  // �巡�� ���۽� ī�޶� �巡�� ��Ȱ��ȭ
        }

        // ���� �̹����� ����
        GetComponent<Image>().enabled = false;

        // ���� �̹����� raycastTarget�� ��Ȱ��ȭ
        GetComponent<Image>().raycastTarget = false;


        // ���⼭�� �����Ǹ� �о���� ������ �����մϴ�.
        if (currentSelectedRecipe != null)
        {
            Debug.Log("���õ� ������: " + currentSelectedRecipe);
        }
        else
        {
            Debug.Log("���õ� �����ǰ� �����ϴ�.");
        }
    }

    //�巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�ϼ�ǰ �̹��� �巡�� ����");
        //transform.position = Input.mousePosition;

        if (clonedImage != null)
        {
            clonedImage.transform.position = Input.mousePosition;
        }

    }

    //�巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�ϼ�ǰ �̹��� �巡�� ��");

        // ������ �̹��� �ı�
        if (clonedImage != null)
        {
            Destroy(clonedImage);
        }

        if (cameraDragScript != null)
        {
            cameraDragScript.OkDrag();  // �巡�� ����� ī�޶� �巡�� Ȱ��ȭ
        }

        //���� �̹����� �ٽ� ǥ��
        GetComponent<Image>().enabled = true;

        // ���� �̹����� raycastTarget�� �ٽ� Ȱ��ȭ
        GetComponent<Image>().raycastTarget = true;


        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.GetComponent<WorkBuilding>())
        {
            // WorkBuilding ���� ���
            WorkBuilding building = hit.collider.GetComponent<WorkBuilding>();

            // �巡�׵� �����Ǹ� ������ ����
            if (currentSelectedRecipe != null)
            {
                
                building.SetRecipe(currentSelectedRecipe);
                Debug.Log("�巡�� �� ������ ������ �Ҵ�" + currentSelectedRecipe);
            }


            // ���� ���õ� �����Ǹ� ������ ����
           //building.SetRecipe(currentSelectedRecipe);

            // ���� ���� ����!
            building.StartProduction();
        }
        else
        {
            // �ٽ� ���� ��ġ�� ���ư���
            transform.position = startPosition;
        }


        // ���� �̹����� raycastTarget�� �ٽ� Ȱ��ȭ
        GetComponent<Image>().raycastTarget = true;
    }
}
