using UnityEngine.UI;
using UnityEngine;
using TMPro;

//by.J:230724 ����UI ���� ����
public class StoreItemUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText; // ������ �̸��� ǥ���� �ؽ�Ʈ ������Ʈ
    public TextMeshProUGUI itemCostText; // ������ ������ ǥ���� �ؽ�Ʈ ������Ʈ
    public Image itemImage;             // ������ �̹����� ǥ���� �̹��� ������Ʈ

    ////public GameObject itemPrefab; // �� �����ۿ� ���� ������

    // ������ ������ UI�� �����ϴ� �޼���
    public void SetInfo(string itemName, int itemCost, Sprite itemSprite) ////, GameObject prefab)
    {
        itemNameText.text = itemName;            // ������ �̸� ����
        itemCostText.text = itemCost.ToString(); // ������ ���� ����
        itemImage.sprite = itemSprite;           // ������ �̹��� ����


        ////itemPrefab = prefab; // �����ۿ� ���� �������� ����

        ////// ������ �������� SpriteRenderer���� ������ ��������Ʈ�� ����
        ////SpriteRenderer prefabSpriteRenderer = itemPrefab.GetComponent<SpriteRenderer>();
        ////if (prefabSpriteRenderer != null)
        ////{
        ////    prefabSpriteRenderer.sprite = itemSprite;
        ////}

        // ������ UI�� �����ϴ� �ڵ�
        //Canvas.ForceUpdateCanvases();
    }
}