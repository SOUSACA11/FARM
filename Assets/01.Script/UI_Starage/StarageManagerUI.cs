using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//by.J:230808 창고 창 클릭시 활성화 / 메뉴 버튼 비활성화 / 닫기 버튼 
public class StarageManagerUI : MonoBehaviour
{
    public Image image; //움직일 이미지
    public Vector3 endPosition; //마지막 이동 위치
    public float speed; //이동 속도

    public Button closeButton; //닫기 버튼

    public Button inviButton1;      //비활성화 할 버튼 1번
    public Button inviButton2;      //비활성화 할 버튼 2번
    public Button inviButton3;      //비활성화 할 버튼 3번

    private Vector3 startPosition; //시작 위치

    private void Start()
    {
        Debug.Log(image.rectTransform.position.x);
        Debug.Log(image.rectTransform.position.y);

        closeButton.onClick.AddListener(CloseButtonOnClick);    //닫기 버튼 클릭
        startPosition = image.transform.position;               //시작 위치 설정
    }

    public void CloseButtonOnClick()
    {
        //메뉴 버튼 비활성화, 닫기 버튼 활성화
        image.transform.position = startPosition;
        inviButton1.gameObject.SetActive(true);
        inviButton2.gameObject.SetActive(true);
        inviButton3.gameObject.SetActive(true);
    }

    public void StarageButton_Click()
    {
        //상점 창 기능 활성화
        StartCoroutine(MoveImage());

        //메뉴 버튼 비활성화
        inviButton1.gameObject.SetActive(false);
        inviButton2.gameObject.SetActive(false);
        inviButton3.gameObject.SetActive(false);
    }

    IEnumerator MoveImage()
    {

        //처음 y값    : 
        //마지막 y값  : 

        float t = 0f; // 시간 변수

        Vector3 startPosition = image.transform.position;  // 시작 위치 저장

        endPosition = new Vector3(948, image.rectTransform.position.y + 1150, 0); //마지막 위치 저장

        while (t < 1f) // t가 1이 될 때까지
        {
            if (image.rectTransform.position.y >= 287) //마지막 위치에 이동했다면 더이상 움직이지 않음
            {
                yield break;
            }

            t += Time.deltaTime * speed; // 시간 누적

            // Lerp를 이용해 현재 위치에서 endPosition까지 부드럽게 이동
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; // 프레임 간격대로 실행

        }
    }
}
