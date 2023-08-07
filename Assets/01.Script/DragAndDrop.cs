using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject buildingPrefab; // 배치할 건물의 Prefab
    private Camera mainCamera;        // 메인 카메라
    private GameObject buildingClone; // 드래그 중인 건물의 복제본

    private void Awake()
    {
        mainCamera = Camera.main; // 메인 카메라 가져오기
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 건물의 복제본을 생성하고 초기화
        buildingClone = Instantiate(buildingPrefab);
        buildingClone.transform.position = GetWorldPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 복제본을 마우스에 따라 이동
        buildingClone.transform.position = GetWorldPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝나면 복제본을 게임 오브젝트로 남김
        buildingClone = null;
    }

    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        // 마우스의 스크린 위치를 월드 위치로 변환
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; // 2D 게임에서는 z 좌표를 0으로 설정
        return worldPosition;
    }

}