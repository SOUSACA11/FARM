using UnityEngine.UI;
using UnityEngine;
using TMPro;

//by.J:230724 ����UI ���� ����
public class ShopItemUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText; // ������ �̸��� ǥ���� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI itemCostText; // ������ ������ ǥ���� �ؽ�Ʈ ������Ʈ
    public Image itemImage;             // ������ �̹����� ǥ���� �̹��� ������Ʈ

    // ������ ������ UI�� �����ϴ� �޼���
    public void SetInfo(string itemName, int itemCost, Sprite itemSprite)
    {
        itemNameText.text = itemName;            // ������ �̸� ����
        itemCostText.text = itemCost.ToString(); // ������ ���� ����
        itemImage.sprite = itemSprite;           // ������ �̹��� ����
    }

}