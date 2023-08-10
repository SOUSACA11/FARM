using UnityEngine;

//by.J:230719 ��ȭ�ý��� �̱��� 
public class MoneySystem : MonoBehaviour
{
    private static MoneySystem instance;

    private int gold; //��ȭ ����
    
    public int Gold { get { return gold; } } //������ ������Ƽ

    //�̱��� �ν��Ͻ� ������
    public static MoneySystem Instance
    {
        get
        {
            //�ν��Ͻ��� ���� ��� ����
            if (instance == null)
            {
                //������ ��ȭ�ý��� ������Ʈ ã��
                instance = FindAnyObjectByType<MoneySystem>();

                //���� ���� ���� ��� ���� ����
                if (instance == null)
                {
                    GameObject singletonobj = new GameObject("MoneySystem");
                    instance = singletonobj.AddComponent<MoneySystem>();
                }
            }

            //�Լ� Ż��
            return instance;
        }
    }


    //�ʱ�ȭ
    private void Awake()
    {
        //�ν��Ͻ��� ���� ���
        if (instance == null)
        {
            //�� ���� �� ���� ����
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //�̹� �ν��Ͻ� ���� �� �ߺ� �ν��Ͻ� ����
        else
        {
            Destroy(gameObject);
        }

    }


    //��ȭ ���� ���
    public void AddGold(int amount)
    {
        gold += amount;
    }

    //��ȭ ���� ���(���̳ʽ� ����)
    public void DeductGold(int amount)
    {
        //Mathf.Max(float a, float b) -> a�� b �߿� �� ū ���� ��ȯ
        gold = Mathf.Max(gold - amount, 0);
    }
}
