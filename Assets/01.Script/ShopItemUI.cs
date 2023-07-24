using UnityEngine.UI;
using UnityEngine;

public class ShopItemUI : MonoBehaviour
{
    public Text itemNameText; // ������ �̸��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text itemCostText; // ������ ������ ǥ���� �ؽ�Ʈ ������Ʈ
    public Image itemImage; // ������ �̹����� ǥ���� �̹��� ������Ʈ

    // ������ ������ UI�� �����ϴ� �޼���
    public void SetInfo(string itemName, int itemCost, Sprite itemSprite)
    {
        itemNameText.text = itemName; // ������ �̸� ����
        itemCostText.text = itemCost.ToString(); // ������ ���� ����
        itemImage.sprite = itemSprite; // ������ �̹��� ����
    }
}
