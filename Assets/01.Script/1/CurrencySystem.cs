using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    private static Dictionary<CurrencyType, int> currencyAmounts = new Dictionary<CurrencyType, int>();

    [SerializeField] private List<GameObject> texts;

    private Dictionary<CurrencyType, TextMeshProUGUI> currencyTexts = new Dictionary<CurrencyType, TextMeshProUGUI>();

    private void Awake()
    {
        for (int i =0; i< texts.Count; i++)
        {
            currencyAmounts.Add((CurrencyType)i, 0);
            currencyTexts.Add((CurrencyType)i, texts[i].transform.GetComponent<TextMeshProUGUI>());
        }
    }

    //private void OnCurrencyChange(CurrencyChangeGameEvent)
    //{
    //    currencyAmounts[info.currenytype] +=
    //}
}

public enum CurrencyType
{
    Coins,
    Crystals
}
