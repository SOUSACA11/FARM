using UnityEngine;
using UnityEngine.UI;
using TMPro;

//by.J:230811 ��ȭ �ý��� UI / �̺�Ʈ ������ �߰�
public class MoneyManagerUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        //�ʱ� ��ȭ ����
<<<<<<< HEAD
        MoneySystem.Instance.AddGold(30);
=======
        MoneySystem.Instance.AddGold(0);
>>>>>>> 9a48014a83e6cc12ac00691a590c038264773074
        UpdateMoneyUI();

        MoneySystem.Instance.OnMoneychange += UpdateMoneyUI; //�̺�Ʈ ������
    }

    private void OnDestroy()
    {
        MoneySystem.Instance.OnMoneychange -= UpdateMoneyUI; //�̺�Ʈ ������
    } 

    private void UpdateMoneyUI()
    {
        moneyText.text = MoneySystem.Instance.Gold.ToString();
    }
}
