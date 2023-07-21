using UnityEngine;

//by.J:230719 재화시스템 싱글톤 
public class MoneySystem : MonoBehaviour
{
    private static MoneySystem instance;

    //by.J:230719 재화 변수
    private int gold;

    //by.J:230719 접근자 프로퍼티
    public int Gold { get { return gold; } }


    //by.J:230719 싱글톤 인스턴스 접근자
    public static MoneySystem Instance
    {
        get
        {
            //by.J:230719 인스턴스가 없을 경우 생성
            if (instance == null)
            {
                //by.J:230719 씬에서 재화시스템 오브젝트 찾기
                instance = FindAnyObjectByType<MoneySystem>();

                //by.J:230719 만약 씬에 없을 경우 새로 생성
                if (instance == null)
                {
                    GameObject singletonobj = new GameObject("MoneySystem");
                    instance = singletonobj.AddComponent<MoneySystem>();
                }
            }

            //by.J:230719 함수 탈출
            return instance;
        }
    }


    //by.J:230719 초기화
    private void Awake()
    {
        //by.J:230719 인스턴스가 없을 경우
        if (instance == null)
        {
            //by.J:230719 씬 변경 시 삭제 방지
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //by.J:230719 이미 인스턴스 존재 시 중복 인스턴스 삭제
        else
        {
            Destroy(gameObject);
        }

    }


    //by.J:230719 재화 증가 기능
    public void AddGold(int amount)
    {
        gold += amount;
    }

    //by.J:230719 재화 감소 기능(마이너스 방지)
    public void DeductGold(int amount)
    {
        //by.J:230719 Mathf.Max(float a, float b) -> a와 b 중에 더 큰 값을 반환
        gold = Mathf.Max(gold - amount, 0);
    }
}
