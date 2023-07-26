using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas; // 게임에서 사용하는 Canvas, Inspector에서 지정
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject buildingClone;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        buildingClone = Instantiate(this.gameObject, canvas.transform);
        canvasGroup.alpha = .6f; // 현재 선택한 건물 이미지를 반투명하게 만들어줌
        canvasGroup.blocksRaycasts = false; // 현재 드래그 중인 건물이 Raycast를 막지 않도록 함
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        buildingClone.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f; // 선택이 끝나면 원래대로 돌림
        canvasGroup.blocksRaycasts = true; // 레이캐스트를 다시 활성화
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}