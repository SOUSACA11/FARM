using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject buildingPrefab; // ��ġ�� �ǹ��� Prefab
    private Camera mainCamera;        // ���� ī�޶�
    private GameObject buildingClone; // �巡�� ���� �ǹ��� ������

    private void Awake()
    {
        mainCamera = Camera.main; // ���� ī�޶� ��������
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �ǹ��� �������� �����ϰ� �ʱ�ȭ
        buildingClone = Instantiate(buildingPrefab);
        buildingClone.transform.position = GetWorldPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �������� ���콺�� ���� �̵�
        buildingClone.transform.position = GetWorldPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�װ� ������ �������� ���� ������Ʈ�� ����
        buildingClone = null;
    }

    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        // ���콺�� ��ũ�� ��ġ�� ���� ��ġ�� ��ȯ
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0; // 2D ���ӿ����� z ��ǥ�� 0���� ����
        return worldPosition;
    }

}