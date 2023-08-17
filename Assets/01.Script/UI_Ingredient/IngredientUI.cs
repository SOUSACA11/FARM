using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JinnyProcessItem;
using UnityEngine.UI;

//by.J:230817 건물에 원재료 넣는 UI / 원재료 창 이동
public class IngredientUI : MonoBehaviour
{
    public Image image;            //움직일 상점 창 이미지 
    public Vector3 endPosition;    //마지막 이동 위치
    public float speed = 120f;     //이동 속도
    private Vector3 startPosition; //시작위치


    public static IngredientUI Instance;
    public IngredientSlot[] ingredientSlots; //원재료 슬롯
    public Recipe specificRecipe; //레시피

    private void Awake()
    {
        Debug.Log("원재료 스크립트");
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //건물 복제본 클릭
    public void IngredientClick()
    {
        Debug.Log("원재료 띠용");

        // Ray를 캐스팅하여 어떤 건물이 클릭되었는지 확인합니다.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        GameObject clickedBuilding = null;
        if (hit.collider != null)
        {
            Debug.Log("됨?");
            clickedBuilding = hit.collider.gameObject;
        }

        if (clickedBuilding == null) return; // 클릭된 건물이 없으면 반환

        // SpriteRenderer를 사용하여 클릭된 건물의 크기와 위치를 가져옵니다.
        SpriteRenderer buildingRenderer = clickedBuilding.GetComponent<SpriteRenderer>();
        if (buildingRenderer != null)
        {
            Debug.Log("됨22?");
            Bounds buildingBounds = buildingRenderer.bounds;

            // 건물의 상단 모서리 위치를 계산합니다.
            Vector3 targetPosition = new Vector3(buildingBounds.max.x, buildingBounds.max.y, 0);

            // UI창의 위치를 건물의 모서리에 맞게 조정합니다.
            transform.position = Camera.main.WorldToScreenPoint(targetPosition);
        }

        ShowIngredient(specificRecipe);
        
        //원재료 창 기능 활성화
        StartCoroutine(MoveImageUp());
    }

    //레시피 별 원재료 보여주기
    public void ShowIngredient(Recipe recipe)
    {
        Debug.Log("원재료 함수쓰");
        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            if (i < recipe.ingredients.Count)
            {
                object ingredientObj = recipe.ingredients[i];

                if (ingredientObj is Ingredient<IItem> itemIngredient)
                {
                    ingredientSlots[i].SetIngredient(itemIngredient.item);
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else if (ingredientObj is Ingredient<ProcessItemDataInfo> processedIngredient)
                {
                    ingredientSlots[i].SetIngredient(new ProcessItemIItem(processedIngredient.item));
                    ingredientSlots[i].gameObject.SetActive(true);
                }
                else
                {
                    ingredientSlots[i].gameObject.SetActive(false);
                }
            }
            else
            {
                ingredientSlots[i].gameObject.SetActive(false);
            }
        }
    }


    // *UI 이미지 움직임 처리*

    //밖에 있는 원재료 창 화면상 배치
    IEnumerator MoveImageUp()
    {
        //처음 y값    : -846
        //마지막 y값  : 318

        float t = 0f; //시간 변수

        Vector3 startPosition = image.transform.position;  //시작 위치 저장

        endPosition = new Vector3(948, image.rectTransform.position.y + 1150, 0); //마지막 위치 저장

        while (t < 1f) //t가 1이 될 때까지
        {
            if (image.rectTransform.position.y >= 318) //y값이 318 이상이면 멈춤
            {
                yield break;
            }

            t += Time.deltaTime * speed; //시간 누적

            //Lerp를 이용해 현재 위치에서 endPosition까지 부드럽게 이동
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; //프레임 간격대로 실행
        }
    }

}
