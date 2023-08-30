using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JinnyBuilding;

//by.J:230827 완성아이템 이미지 드래그 드롭 기능
public class DragFinishItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   // public Transform originalParent;
    private Vector3 startPosition;
    private GameObject clonedImage;

    public DragAndDropCamera cameraDragScript;      //카메라 드래그 드롭
    public IngredientManagerUI ingredientManagerUI; //원재료 창
    public Recipe currentSelectedRecipe;            //현재 레시피
  
    public GameObject copyBuilding;          //건물 복제본
    public BuildingType currentBuildingType; //빌딩 타입 
    public Recipe currentRecipe; //현재 레시피

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


        //// index는 초기 값이 -1이므로 이 값을 검사하여 유효한 범위인지 확인합니다.
        //if (index >= 0)
        //{
        //    UpdateAvailableRecipes(index);
        //}
        //else
        //{
        //    Debug.LogError("Invalid index value.");
        //}

        // 카메라의 DragAndDropCamera 스크립트를 얻기
        // cameraDragScript = Camera.main.GetComponent<DragAndDropCamera>();


    }


    //// 현재 빌딩 타입에 따라 사용 가능한 레시피 목록을 가져오는 메서드 추가
    //private void UpdateAvailableRecipes()
    //{
    //    if (RecipeManager.Instance.buildingRecipes.ContainsKey(currentBuildingType))
    //    {
    //        List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];

    //        // 예시: 첫 번째 레시피를 선택하는 경우
    //        // 실제로는 사용자의 선택에 따라 해당 레시피를 설정해야 합니다.
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
    // 현재 빌딩 타입에 따라 사용 가능한 레시피 목록을 가져오는 메서드 추가
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

        Debug.Log("완성품 이미지 클릭");
        // 원본 이미지의 raycastTarget을 비활성화
        GetComponent<Image>().raycastTarget = false;

        //if (cameraDragScript != null)
        //{
        //    cameraDragScript.NoDrag();  // 드래그 시작시 카메라 드래그 비활성화
        //}
        //Debug.Log($"ingredientManagerUI: {ingredientManagerUI}, index: {index}");

        // 복제된 이미지 생성
        clonedImage = Instantiate(gameObject, transform.position, transform.rotation);
        // 메인 캔버스를 찾아서 clonedImage의 부모로 설정
        Canvas mainCanvas = FindObjectOfType<Canvas>();
        if (mainCanvas)
        {
            clonedImage.transform.SetParent(mainCanvas.transform, false);
            clonedImage.transform.SetAsLastSibling();  // 확실하게 마지막 자식으로 설정
        }
        clonedImage.transform.SetAsLastSibling();  // 확실하게 마지막 자식으로 설정

        Image originalImageComp = GetComponent<Image>();
        Image clonedImageComp = clonedImage.GetComponent<Image>();
        if (originalImageComp != null && clonedImageComp != null)
        {
            clonedImageComp.sprite = originalImageComp.sprite; // Sprite 설정
            clonedImageComp.color = originalImageComp.color;   // Color 설정
            clonedImageComp.raycastTarget = false;  // 복제된 이미지의 raycastTarget을 비활성화
        }
        //// 원본 이미지를 숨김
        //GetComponent<Image>().enabled = false;

        //// 원본 이미지의 raycastTarget을 비활성화
        //GetComponent<Image>().raycastTarget = false;

        // 여기서 IngredientManagerUI의 ProductImageClicked를 호출합니다.
        if (ingredientManagerUI != null)
        {
            Debug.Log("원재료 창 불러오기 연결");
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

    //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(gameObject + "Current Building Type: " + currentBuildingType);
        Debug.Log("완성품 이미지 드래그 시작");

        // 현재 빌딩 타입에 따른 레시피 리스트를 얻기
        // List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];

        //if (RecipeManager.Instance.buildingRecipes.ContainsKey(currentBuildingType))
        //{
        //    List<Recipe> recipesForThisBuilding = RecipeManager.Instance.buildingRecipes[currentBuildingType];
        //    // ... 나머지 코드
        //}
        //else
        //{
        //    Debug.LogError("Building type " + currentBuildingType + " not found in the dictionary.");
        //}

        //Debug.Log("레시피 이미지?" + recipesForThisBuilding);
        if (ingredientManagerUI != null)
        {
            int obtainedIndex = ingredientManagerUI.GetIndexFromImage(this.GetComponent<Image>().gameObject);  // <-- 이 부분 수정
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
            cameraDragScript.NoDrag();  // 드래그 시작시 카메라 드래그 비활성화
        }

        // 원본 이미지를 숨김
        GetComponent<Image>().enabled = false;

        // 원본 이미지의 raycastTarget을 비활성화
        GetComponent<Image>().raycastTarget = false;


        // 여기서는 레시피를 읽어오는 로직만 수행합니다.
        if (currentSelectedRecipe != null)
        {
            Debug.Log("선택된 레시피: " + currentSelectedRecipe);
        }
        else
        {
            Debug.Log("선택된 레시피가 없습니다.");
        }
    }

    //드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("완성품 이미지 드래그 중중");
        //transform.position = Input.mousePosition;

        if (clonedImage != null)
        {
            clonedImage.transform.position = Input.mousePosition;
        }

    }

    //드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("완성품 이미지 드래그 끝");

        // 복제된 이미지 파괴
        if (clonedImage != null)
        {
            Destroy(clonedImage);
        }

        if (cameraDragScript != null)
        {
            cameraDragScript.OkDrag();  // 드래그 종료시 카메라 드래그 활성화
        }

        //원본 이미지를 다시 표시
        GetComponent<Image>().enabled = true;

        // 원본 이미지의 raycastTarget을 다시 활성화
        GetComponent<Image>().raycastTarget = true;


        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.GetComponent<WorkBuilding>())
        {
            // WorkBuilding 참조 얻기
            WorkBuilding building = hit.collider.GetComponent<WorkBuilding>();

            // 드래그된 레시피를 빌딩에 설정
            if (currentSelectedRecipe != null)
            {
                
                building.SetRecipe(currentSelectedRecipe);
                Debug.Log("드래그 된 레시피 빌딩에 할당" + currentSelectedRecipe);
            }


            // 현재 선택된 레시피를 빌딩에 설정
           //building.SetRecipe(currentSelectedRecipe);

            // 이제 생산 시작!
            building.StartProduction();
        }
        else
        {
            // 다시 원래 위치로 돌아가기
            transform.position = startPosition;
        }


        // 원본 이미지의 raycastTarget을 다시 활성화
        GetComponent<Image>().raycastTarget = true;
    }
}
