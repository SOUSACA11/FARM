using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//by.J:230827 완성아이템 이미지 드래그 드롭 기능
public class DragFinishItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   // public Transform originalParent;
    private Vector3 startPosition;
    private GameObject clonedImage;


    public DragAndDropCamera cameraDragScript; //카메라 드래그 드롭
    public IngredientManagerUI ingredientManagerUI; //원재료 창
    //public GameObject clonedImage; //복제할 완성품 이미지

    public int index = -1;

    private void Start()
    {
        // 카메라의 DragAndDropCamera 스크립트를 얻기
        cameraDragScript = Camera.main.GetComponent<DragAndDropCamera>();

        // IngredientManagerUI의 참조 설정 (만약 IngredientManagerUI가 같은 오브젝트에 있으면)
        ingredientManagerUI = GetComponent<IngredientManagerUI>();
    }

    //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("완성품 이미지 드래그 시작");

        // 원본 이미지의 raycastTarget을 비활성화
        GetComponent<Image>().raycastTarget = false;
         
        if (cameraDragScript != null)
        {
            cameraDragScript.NoDrag();  // 드래그 시작시 카메라 드래그 비활성화
        }
        Debug.Log($"ingredientManagerUI: {ingredientManagerUI}, index: {index}");

        //// 복제된 이미지 생성
        //clonedImage = Instantiate(gameObject, transform.position, transform.rotation, transform.root);
        //Image clonedImageComp = clonedImage.GetComponent<Image>();
        //if (clonedImageComp != null)
        //{
        //    Debug.Log("이미지 복제");
        //    clonedImageComp.raycastTarget = false;  // 복제된 이미지의 raycastTarget을 비활성화하여 클릭 이벤트에 영향을 주지 않도록 함
        //}


        //// 복제된 이미지 생성
        //clonedImage = Instantiate(gameObject, transform.position, transform.rotation, transform.root);
        //Image originalImageComp = GetComponent<Image>();
        //Image clonedImageComp = clonedImage.GetComponent<Image>();
        //if (originalImageComp != null && clonedImageComp != null)
        //{
        //    clonedImageComp.sprite = originalImageComp.sprite; // Sprite 설정
        //    clonedImageComp.color = originalImageComp.color;   // Color 설정
        //    clonedImageComp.raycastTarget = false;  // 복제된 이미지의 raycastTarget을 비활성화
        //}



        //// 복제된 이미지 생성
        //clonedImage = Instantiate(gameObject, transform.position, transform.rotation);
        //// 메인 캔버스를 찾아서 clonedImage의 부모로 설정
        //Canvas mainCanvas = FindObjectOfType<Canvas>();
        //if (mainCanvas)
        //{
        //    clonedImage.transform.SetParent(mainCanvas.transform, false);
        //    clonedImage.transform.SetAsLastSibling();  // 확실하게 마지막 자식으로 설정
        //}
        //clonedImage.transform.SetAsLastSibling();  // 확실하게 마지막 자식으로 설정

        //Image originalImageComp = GetComponent<Image>();
        //Image clonedImageComp = clonedImage.GetComponent<Image>();
        //if (originalImageComp != null && clonedImageComp != null)
        //{
        //    clonedImageComp.sprite = originalImageComp.sprite; // Sprite 설정
        //    clonedImageComp.color = originalImageComp.color;   // Color 설정
        //    clonedImageComp.raycastTarget = false;  // 복제된 이미지의 raycastTarget을 비활성화
        //}



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
        // 원본 이미지를 숨김
        GetComponent<Image>().enabled = false;

        // 원본 이미지의 raycastTarget을 비활성화
        GetComponent<Image>().raycastTarget = false;



        // 여기서 IngredientManagerUI의 ProductImageClicked를 호출합니다.
        if (ingredientManagerUI != null)
        {
            Debug.Log("원재료 창 불러오기 연결");
            ingredientManagerUI.ProductImageClicked(index);
        }

        //originalParent = transform.parent;
        startPosition = transform.position;
        //transform.SetParent(transform.root);  // 최상위 부모로 설정
    }

    //드래그 중
    public void OnDrag(PointerEventData eventData)
    {
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
            // WorkBuilding의 StartProduction() 메서드 호출
            hit.collider.GetComponent<WorkBuilding>().StartProduction();
        }
        else
        {
            // 다시 원래 위치로 돌아가기
            transform.position = startPosition;
            //transform.SetParent(originalParent);
        }


        // 원본 이미지의 raycastTarget을 다시 활성화
        GetComponent<Image>().raycastTarget = true;
    }
}
