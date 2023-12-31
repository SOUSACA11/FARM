using UnityEngine;
using UnityEngine.UI;
using TMPro;

//by.J:230811 재화 시스템 UI / 이벤트 리스너 추가
public class MoneyManagerUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        //초기 재화 설정
<<<<<<< HEAD
        MoneySystem.Instance.AddGold(30);
=======
        MoneySystem.Instance.AddGold(0);
>>>>>>> 9a48014a83e6cc12ac00691a590c038264773074
        UpdateMoneyUI();

        MoneySystem.Instance.OnMoneychange += UpdateMoneyUI; //이벤트 리스너
    }

    private void OnDestroy()
    {
        MoneySystem.Instance.OnMoneychange -= UpdateMoneyUI; //이벤트 리스너
    } 

    private void UpdateMoneyUI()
    {
        moneyText.text = MoneySystem.Instance.Gold.ToString();
    }
}
