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
            // 모든 터치 이벤트를 가져옵니다.
            Touch[] touches = Input.touches;

            // 터치된 모든 위치를 레이캐스트로 검사합니다.
            foreach (Touch touch in touches)
            {
                // 터치된 화면 좌표를 월드 좌표로 변환합니다.
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f; // 화면 좌표 z값은 카메라와의 거리이므로 0으로 고정합니다.

                // 레이캐스트를 쏩니다.
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                // 레이캐스트가 충돌한 오브젝트를 처리합니다.
                if (hit.collider != null)
                {
                    // 여기에 오브젝트를 클릭한 경우의 동작을 작성합니다.
                    // hit.collider.gameObject 는 터치한 오브젝트를 나타냅니다.
                    // 예를 들어, hit.collider.gameObject.GetComponent<Building>() 를 사용하여 건물 정보를 가져올 수 있습니다.
                }
            }
        }
    }
}
