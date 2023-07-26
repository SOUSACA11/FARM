using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas; // ���ӿ��� ����ϴ� Canvas, Inspector���� ����
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
        canvasGroup.alpha = .6f; // ���� ������ �ǹ� �̹����� �������ϰ� �������
        canvasGroup.blocksRaycasts = false; // ���� �巡�� ���� �ǹ��� Raycast�� ���� �ʵ��� ��
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        buildingClone.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f; // ������ ������ ������� ����
        canvasGroup.blocksRaycasts = true; // ����ĳ��Ʈ�� �ٽ� Ȱ��ȭ
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}