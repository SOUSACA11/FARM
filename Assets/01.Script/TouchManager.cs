using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            // ��� ��ġ �̺�Ʈ�� �����ɴϴ�.
            Touch[] touches = Input.touches;

            // ��ġ�� ��� ��ġ�� ����ĳ��Ʈ�� �˻��մϴ�.
            foreach (Touch touch in touches)
            {
                // ��ġ�� ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ�մϴ�.
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f; // ȭ�� ��ǥ z���� ī�޶���� �Ÿ��̹Ƿ� 0���� �����մϴ�.

                // ����ĳ��Ʈ�� ���ϴ�.
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                // ����ĳ��Ʈ�� �浹�� ������Ʈ�� ó���մϴ�.
                if (hit.collider != null)
                {
                    // ���⿡ ������Ʈ�� Ŭ���� ����� ������ �ۼ��մϴ�.
                    // hit.collider.gameObject �� ��ġ�� ������Ʈ�� ��Ÿ���ϴ�.
                    // ���� ���, hit.collider.gameObject.GetComponent<Building>() �� ����Ͽ� �ǹ� ������ ������ �� �ֽ��ϴ�.
                }
            }
        }
    }
}
