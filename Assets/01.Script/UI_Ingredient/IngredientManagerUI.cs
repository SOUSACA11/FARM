using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyProcessItem;
using UnityEngine.UI;
using JinnyBuilding;

//by.J:230817 건물에 원재료 넣는 UI / 원재료 창 이동
//by.J:230818 완성품 이미지 ID 추가
public class IngredientManagerUI : MonoBehaviour
{

    public Image image;            //움직일 상점 창 이미지 
    public Vector3 endPosition;    //마지막 이동 위치
    public float speed = 120f;     //이동 속도
    //private Vector3 startPosition; //시작위치

    public GameObject copyBuilding;//건물 복제본
    public Vector3 uiOffset = new Vector3(-1, 1, 0); // UI 위치 오프셋. 건물의 좌측 상단 모서리에 나타나게 만드는데 사용

    public static IngredientManagerUI Instance;
    public IngredientSlot[] ingredientSlots; //원재료 슬롯
    public Recipe specificRecipe; //레시피

    public Image productImageDisplay; // UI에 표시될 완성품 이미지

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

        // Ray를 캐스팅하여 어떤 건물이 클릭되었는지 확인합니다.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        GameObject clickedBuilding = null;
        if (hit.collider != null)
        {
            //Debug.Log("건물 클릭됨?");
            Debug.Log("건물 클릭됨: " + hit.collider.gameObject.name);
            clickedBuilding = hit.collider.gameObject;
        }
        
        if (clickedBuilding == null) return; // 클릭된 건물이 없으면 반환

        // 클릭된 건물을 attachedBuilding에 저장합니다.
        copyBuilding = clickedBuilding;


        // 해당 건물의 레시피에 따라 UI 위치와 내용을 업데이트합니다.
        //SetUIPosition(clickedBuilding);

        //WorkBuilding buildingComponent = clickedBuilding.GetComponent<WorkBuilding>();
        //if (buildingComponent != null)
        //{
        //    ShowIngredient(buildingComponent.currentRecipe);
        //}

        WorkBuilding buildingComponent = clickedBuilding.GetComponent<WorkBuilding>();

        if (buildingComponent != null)
        {
            Debug.Log("완성품 이미지 뜸?");
            BuildingType buildingType = buildingComponent.buildingType; // 이건 WorkBuilding 클래스에 건물 유형 정보가 있어야 합니다.
            
            //List<Recipe> recipesForBuilding = RecipeManager.Instance.buildingRecipes[buildingType];

            if (RecipeManager.Instance.buildingRecipes.ContainsKey(buildingType))
            {
                List<Recipe> recipesForBuilding = RecipeManager.Instance.buildingRecipes[buildingType];
                
                Debug.Log("레시피 수: " + recipesForBuilding.Count);
                Debug.Log("건물 유형: " + buildingType);

                if (recipesForBuilding != null && recipesForBuilding.Count > 0)
                {
                    // 예시로 첫 번째 레시피의 완성품 이미지를 사용합니다.
                    // 필요에 따라 다른 로직으로 특정 레시피를 선택할 수 있습니다.
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

        //원재료 창 기능 활성화
        //StartCoroutine(MoveImageUp());
    }

    //레시피 별 원재료 보여주기
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("원재료 함수쓰");

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

    //원재료 UI 창 이동
    public void SetUIPosition(GameObject targetBuilding)
    {
        Debug.Log("UI 이동 이동");
        if (targetBuilding == null) return;

        SpriteRenderer buildingRenderer = targetBuilding.GetComponent<SpriteRenderer>();
        if (buildingRenderer != null)
        {
            Bounds buildingBounds = buildingRenderer.bounds;

            // 건물의 좌측 상단 모서리 위치를 계산하고 오프셋을 추가합니다.
            Vector3 targetPosition = buildingBounds.center + uiOffset;

            // UI창의 위치를 건물의 좌측 상단 모서리에 맞게 조정합니다.
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);

            Debug.Log("Setting UI to: " + transform.position.ToString());
        }
    }

}

