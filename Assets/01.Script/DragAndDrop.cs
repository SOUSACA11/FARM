using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas; // 게임에서 사용하는 Canvas, Inspector에서 지정
    private Camera mainCamera; // 메인 카메라
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject buildingClone;
    public GameObject buildingPrefab;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        mainCamera = Camera.main; // 메인 카메라 가져오기
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

        // 마우스의 스크린 좌표를 월드 좌표로 변환
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        // z 좌표를 오브젝트의 원래 z 좌표로 설정 (2D 게임에서는 z 좌표를 변경하면 안 됩니다)
        worldPosition.z = buildingClone.transform.position.z;

        // 변환된 월드 좌표로 오브젝트 이동
        buildingClone.transform.position = worldPosition;

        // 마우스 커서의 스크린 좌표를 캔버스 좌표로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);

        // RectTransform의 anchoredPosition을 변경하여 이미지를 이동
        buildingClone.GetComponent<RectTransform>().anchoredPosition = localPoint + new Vector2(buildingClone.GetComponent<RectTransform>().sizeDelta.x / 2, buildingClone.GetComponent<RectTransform>().sizeDelta.y / 2);

        //마우스 위치에서 Ray를 생성
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);

        // Ray가 "Ground" Layer와 충돌하는 지점을 찾음
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            // 충돌 지점으로 건물 이동
            buildingClone.transform.position = hit.point;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // 마우스의 월드 위치를 계산
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; // 2D 게임에서는 z 좌표를 0으로 설정해야 합니다.

        // 월드 위치에 새 건물 생성
        GameObject newBuilding = Instantiate(buildingPrefab, worldPosition, Quaternion.identity);
        // 생성한 건물을 월드 공간에 배치하기 위해 필요한 처리를 추가하세요.
        // 예: newBuilding.layer = LayerMask.NameToLayer("Buildings");

        // UI 건물 이미지 삭제
        Destroy(buildingClone);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }
}