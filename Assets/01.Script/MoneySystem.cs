using UnityEngine;

//by.J:230719 ��ȭ�ý��� �̱��� 
public class MoneySystem : MonoBehaviour
{
    private static MoneySystem instance;

    //by.J:230719 ��ȭ ����
    private int gold;

    //by.J:230719 ������ ������Ƽ
    public int Gold { get { return gold; } }


    //by.J:230719 �̱��� �ν��Ͻ� ������
    public static MoneySystem Instance
    {
        get
        {
            //by.J:230719 �ν��Ͻ��� ���� ��� ����
            if (instance == null)
            {
                //by.J:230719 ������ ��ȭ�ý��� ������Ʈ ã��
                instance = FindAnyObjectByType<MoneySystem>();

                //by.J:230719 ���� ���� ���� ��� ���� ����
                if (instance == null)
                {
                    GameObject singletonobj = new GameObject("MoneySystem");
                    instance = singletonobj.AddComponent<MoneySystem>();
                }
            }

            //by.J:230719 �Լ� Ż��
            return instance;
        }
    }


    //by.J:230719 �ʱ�ȭ
    private void Awake()
    {
        //by.J:230719 �ν��Ͻ��� ���� ���
        if (instance == null)
        {
            //by.J:230719 �� ���� �� ���� ����
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //by.J:230719 �̹� �ν��Ͻ� ���� �� �ߺ� �ν��Ͻ� ����
        else
        {
            Destroy(gameObject);
        }

    }


    //by.J:230719 ��ȭ ���� ���
    public void AddGold(int amount)
    {
        gold += amount;
    }

    //by.J:230719 ��ȭ ���� ���(���̳ʽ� ����)
    public void DeductGold(int amount)
    {
        //by.J:230719 Mathf.Max(float a, float b) -> a�� b �߿� �� ū ���� ��ȯ
        gold = Mathf.Max(gold - amount, 0);
    }
}
