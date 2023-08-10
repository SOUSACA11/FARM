using UnityEngine;

//by.J:230719 재화시스템 싱글톤 
public class MoneySystem : MonoBehaviour
{
    private static MoneySystem instance;

    private int gold; //재화 변수
    
    public int Gold { get { return gold; } } //접근자 프로퍼티

    //싱글톤 인스턴스 접근자
    public static MoneySystem Instance
    {
        get
        {
            //인스턴스가 없을 경우 생성
            if (instance == null)
            {
                //씬에서 재화시스템 오브젝트 찾기
                instance = FindAnyObjectByType<MoneySystem>();

                //만약 씬에 없을 경우 새로 생성
                if (instance == null)
                {
                    GameObject singletonobj = new GameObject("MoneySystem");
                    instance = singletonobj.AddComponent<MoneySystem>();
                }
            }

            //함수 탈출
            return instance;
        }
    }


    //초기화
    private void Awake()
    {
        //인스턴스가 없을 경우
        if (instance == null)
        {
            //씬 변경 시 삭제 방지
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //이미 인스턴스 존재 시 중복 인스턴스 삭제
        else
        {
            Destroy(gameObject);
        }

    }


    //재화 증가 기능
    public void AddGold(int amount)
    {
        gold += amount;
    }

    //재화 감소 기능(마이너스 방지)
    public void DeductGold(int amount)
    {
        //Mathf.Max(float a, float b) -> a와 b 중에 더 큰 값을 반환
        gold = Mathf.Max(gold - amount, 0);
    }
}
