using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas; // ���ӿ��� ����ϴ� Canvas, Inspector���� ����
    private Camera mainCamera; // ���� ī�޶�
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject buildingClone;
    public GameObject buildingPrefab;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        mainCamera = Camera.main; // ���� ī�޶� ��������
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        buildingClone = Instantiate(this.gameObject, canvas.transform);
        buildingClone.GetComponent<CanvasGroup>().alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        // ���콺�� ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        // z ��ǥ�� ������Ʈ�� ���� z ��ǥ�� ���� (2D ���ӿ����� z ��ǥ�� �����ϸ� �� �˴ϴ�)
        worldPosition.z = buildingClone.transform.position.z;

        // ��ȯ�� ���� ��ǥ�� ������Ʈ �̵�
        buildingClone.transform.position = worldPosition;

        // ���콺 Ŀ���� ��ũ�� ��ǥ�� ĵ���� ��ǥ�� ��ȯ
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);

        // RectTransform�� anchoredPosition�� �����Ͽ� �̹����� �̵�
        buildingClone.GetComponent<RectTransform>().anchoredPosition = localPoint + new Vector2(buildingClone.GetComponent<RectTransform>().sizeDelta.x / 2, buildingClone.GetComponent<RectTransform>().sizeDelta.y / 2);

        //���콺 ��ġ���� Ray�� ����
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);

        // Ray�� "Ground" Layer�� �浹�ϴ� ������ ã��
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            // �浹 �������� �ǹ� �̵�
            buildingClone.transform.position = hit.point;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // ���콺�� ���� ��ġ�� ���
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; // 2D ���ӿ����� z ��ǥ�� 0���� �����ؾ� �մϴ�.

        // ���� ��ġ�� �� �ǹ� ����
        GameObject newBuilding = Instantiate(buildingPrefab, worldPosition, Quaternion.identity);
        // ������ �ǹ��� ���� ������ ��ġ�ϱ� ���� �ʿ��� ó���� �߰��ϼ���.
        // ��: newBuilding.layer = LayerMask.NameToLayer("Buildings");

        // UI �ǹ� �̹��� ����
        Destroy(buildingClone);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }
}