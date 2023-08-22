using JinnyBuilding;
using JinnyProcessItem;
using JinnyCropItem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//by.J:230817 건물에 원재료 넣는 UI / 원재료 창 이동
//by.J:230818 완성품 이미지 ID 추가
//by.J:230819 ㅜㅜㅜㅜㅠㅠㅠㅠ
public class IngredientManagerUI : MonoBehaviour
{

    //public Image image;            //움직일 상점 창 이미지 
    //public Vector3 endPosition;    //마지막 이동 위치
    //public float speed = 120f;     //이동 속도

    public GameObject copyBuilding;                   //건물 복제본
    public Vector3 uiOffset = new Vector3(-1, 1, 0);  //UI 위치 오프셋. 건물의 좌측 상단 모서리에 나타나게 만드는데 사용


    //public RectTransform ret;
    public GameObject arrow;  // Arrow 게임 오브젝트에 대한 참조
    public RectTransform arrowRectTransform; // Arrow 오브젝트의 RectTransform 참조
    public Image arrowImage;
    public Transform copyFinishSlot; // 완성품 슬롯에 대한 참조
    private GameObject clonedIngredientUI;
    private Transform currentClickedFinishImage; // 현재 클릭된 finish Image(Clone)




    public static IngredientManagerUI Instance; //싱글톤
    //public IngredientSlot[] ingredientSlots;   //원재료 슬롯
    public Recipe specificRecipe;              //레시피
    public IngredientSlot ingredientSlotPrefab; // 원재료 프리팹

    public List<IngredientSlot> ingredientSlots = new List<IngredientSlot>(); //원재료 이미지 할당 슬롯
    public List<Image> productImageDisplays = new List<Image>();    //UI에 표시될 완성품 이미지
    public Image imagePrefab;                                      //완성품 프리팹

    private void Awake()
    {
        Debug.Log("원재료 스크립트");
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //건물 복제본 클릭시
    public void IngredientClick()
    {
        Debug.Log("원재료 띠용");

        //레이 캐스팅해서 건물 클릭 인식
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        GameObject clickedBuilding = null;
        if (hit.collider != null)
        {
            //Debug.Log("건물 클릭됨?");
            Debug.Log("건물 클릭됨: " + hit.collider.gameObject.name);
            clickedBuilding = hit.collider.gameObject;
         
        }

        //클릭된 건물이 없으면 반환
        if (clickedBuilding == null) return;

        //클릭된 건물 copyBuilding에 저장
        copyBuilding = clickedBuilding;




        //UI 창 이동
        SetUIPosition(clickedBuilding);

        WorkBuilding buildingComponent = clickedBuilding.GetComponent<WorkBuilding>();

        if (buildingComponent != null)
        {
            Debug.Log("완성품 이미지 뜸?");
            BuildingType buildingType = buildingComponent.buildingType; //빌딩 타입 저장

            Debug.Log(RecipeManager.Instance.buildingRecipes.ContainsKey(buildingType));

            if (RecipeManager.Instance.buildingRecipes.ContainsKey(buildingType))
            {
                List<Recipe> recipesForBuilding = RecipeManager.Instance.buildingRecipes[buildingType];

                //동적으로 이미지 슬롯 생성
                CreateProductImageSlots(recipesForBuilding.Count);
                Debug.Log("이미지 슬롯 생성이 되나?" + recipesForBuilding.Count);

                //이미지 할당
                for (int i = 0; i < recipesForBuilding.Count; i++)
                {
                    productImageDisplays[i].sprite = recipesForBuilding[i].FinishedProductImage;
                }

            }

            else
            {
                Debug.LogError("빌딩타입 " + buildingType + " is not present in buildingRecipes dictionary.");
            }
        }



        // ingredient의 모든 인스턴스를 찾습니다.
        GameObject[] allIngredientUIs = GameObject.FindGameObjectsWithTag("ingredient");
        clonedIngredientUI = null;

        Debug.Log("순서 왔나?");


        // 복제본을 찾습니다. (원본은 "(Clone)" 접미사가 없습니다.)
        foreach (var ui in allIngredientUIs)
        {
            Debug.Log("복제본 ㅇㅇ?");
            if (ui.name.Contains("(Clone)"))
            {
                
                clonedIngredientUI = ui;
                Debug.Log(clonedIngredientUI);
                break;
            }
        }

        if (clonedIngredientUI == null)
        {
            Debug.LogError("Ingredient UI의 복제본을 찾을 수 없습니다.");
            return;
        }





    }

    public void ShowfinishIngredient(Recipe recipe)
    {
        //원재료 표시
        Debug.Log("완성품 클릭 유도");
        ShowIngredient(recipe);
    }




    public void ProductImageClicked(int index)//완성품 이미지 클릭
    {
        Debug.Log("클릭 실행");
        // 클릭된 이미지의 인덱스를 사용하여 해당 레시피를 찾습니다.
        BuildingType currentBuildingType = copyBuilding.GetComponent<WorkBuilding>().buildingType;
        Recipe clickedRecipe = RecipeManager.Instance.buildingRecipes[currentBuildingType][index];

        Debug.Log("clickedRecipe" + clickedRecipe);

        // 현재 클릭된 finish Image(Clone) 업데이트
        currentClickedFinishImage = productImageDisplays[index].transform;

        Debug.Log("클릭된 이미지" + productImageDisplays[index].transform);

        // 해당 레시피의 원재료 표시
        ShowfinishIngredient(clickedRecipe);

        ShowIngredient(clickedRecipe);

        // Ingredient Slot(Clone) 생성
        CreateIngredientSlot(clickedRecipe, currentClickedFinishImage);

        // 여기서 클릭된 이미지의 위치를 참조합니다.
        RectTransform clickedImageTransform = productImageDisplays[index].rectTransform;

        /// Ingredient Slot(Clone)의 위치를 설정합니다. 위치는 클릭된 이미지 아래에 있어야 합니다.
        for (int i = 0; i < ingredientSlots.Count; i++)
        {
            RectTransform slotRect = ingredientSlots[i].GetComponent<RectTransform>();

            // 클릭된 이미지 아래에 Ingredient Slot(Clone)을 배치합니다.
            float offsetY = (i + 1) * slotRect.sizeDelta.y;
            //slotRect.position = new Vector3(clickedImageTransform.position.x, clickedImageTransform.position.y - offsetY, clickedImageTransform.position.z);
            slotRect.position = new Vector3(currentClickedFinishImage.position.x, currentClickedFinishImage.position.y - offsetY, currentClickedFinishImage.position.z);
        }
    }



    //레시피 별 원재료 보여주기
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("원재료 함수쓰");

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

    //완성품 UI 창 이동
    public void SetUIPosition(GameObject targetBuilding)
    {
        Debug.Log("UI 이동 이동");
        if (targetBuilding == null) return;

        SpriteRenderer buildingRenderer = targetBuilding.GetComponent<SpriteRenderer>();
        if (buildingRenderer != null)
        {
            Bounds buildingBounds = buildingRenderer.bounds;

            //건물의 좌측 상단 모서리 위치에 오프셋 추가
            Vector3 targetPosition = buildingBounds.center + uiOffset;

            //UI창의 위치를 건물의 좌측 상단 모서리 맞게 조정
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);

            Debug.Log("Setting UI to: " + transform.position.ToString());
        }
    }

    //완성품 이미지 슬롯 생성
    public void CreateProductImageSlots(int numberOfSlots)
    {
        //기존 슬롯 비활성화
        foreach (Image img in productImageDisplays)
        {
            img.gameObject.SetActive(false);
        }

        //필요한 슬롯 활성화, 생성 
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

    //원재료 슬롯 생성


    public void CreateIngredientSlot(Recipe recipe, Transform clickedFinishImage)
    {
        Debug.Log("원재료 슬롯 활성화?");

        // 현재 슬롯 모두 비활성화
        foreach (var slot in ingredientSlots)
        {
            Debug.Log("비활성화");
            Destroy(slot.gameObject);
        }
        ingredientSlots.Clear();

        // 클릭된 finish Image(Clone)의 arrow 참조를 가져옵니다.
        //RectTransform arrowInClickedFinishImage = currentClickedFinishImage ? currentClickedFinishImage.Find("arrow").GetComponent<RectTransform>() : null;
        RectTransform arrowInClickedFinishImage = clickedFinishImage ? clickedFinishImage.Find("arrow").GetComponent<RectTransform>() : null;



        if (arrowInClickedFinishImage == null)
        {
            Debug.LogError("클릭된 finish Image(Clone)에 arrow가 없습니다.");
            return;
        }

        // 레시피의 원재료 수에 맞게 슬롯 생성
        for (int i = 0; i < recipe.ingredients.Count; i++)
        {
            Debug.Log("원재료 슬롯 생성 가능?");
            IngredientSlot newSlot = Instantiate(ingredientSlotPrefab, clonedIngredientUI.transform);

            newSlot.gameObject.SetActive(true);

            // 새로운 슬롯의 RectTransform을 가져옵니다
            RectTransform newSlotRectTransform = newSlot.GetComponent<RectTransform>();

            // 새로운 슬롯의 위치를 finish image 아래로 설정
            newSlotRectTransform.anchoredPosition = arrowInClickedFinishImage.anchoredPosition - new Vector2(0, (newSlotRectTransform.sizeDelta.y + arrowImage.rectTransform.sizeDelta.y) * (i + 1));

            object ingredientObj = recipe.ingredients[i];
            if (ingredientObj is Ingredient<IItem> itemIngredient)
            {
                Debug.Log("if문");
                newSlot.SetIngredient(itemIngredient.item, itemIngredient.quantity);
            }
            else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
            {
                Debug.Log("else if문");
                newSlot.SetIngredient(new ProcessItemIItem(processedIngredient.item), processedIngredient.quantity);
            }
            ingredientSlots.Add(newSlot);
        }
    }
}

