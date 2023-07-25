using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230724 Ŭ���� ���� â Ȱ��ȭ / �޴� ��ư ��Ȱ��ȭ / �ݱ� ��ư / ���� ������ �б�
//by.J:230724 ���� �� UI ���� �߰�
public class ShopManagerUI : MonoBehaviour
{
    public Image image;          //������ �̹��� 
    public Vector3 endPosition;  //������ �̵� ��ġ
    public float speed = 120f;   //�̵� �ӵ�

    public Button closeButton;   //�ݱ� ��ư

    public Button button1;      //��Ȱ��ȭ �� ��ư 1��
    public Button button2;      //��Ȱ��ȭ �� ��ư 2��
    public Button button3;      //��Ȱ��ȭ �� ��ư 3��

    private Vector3 startPosition; //������ġ

            
    public GameObject shopItemPrefab;         // ���� ������ UI ������
    public Transform shopItemsParent;         // ���� �����۵��� ���� �θ� ������Ʈ
    public ItemDic itemDic;                  // ������ ������ ���� ItemDic Ŭ����
    private Dictionary<string, object> items; // ������ ������ ���� ����

    List<ShopItemUI> shopItems = new List<ShopItemUI>(); // ���� ������ ��ü���� ������ ����Ʈ
    private void Start() //ó���� ���������� ���������� ����
    {
        //Debug.Log(image.rectTransform.position.x);
        //Debug.Log(image.rectTransform.position.y);

        closeButton.onClick.AddListener(CloseButtonOnClick);    //�ݱ� ��ư Ŭ��
        startPosition = image.transform.position;               //���� ��ġ ����

        itemDic = FindObjectOfType<ItemDic>(); // ItemDic Ŭ������ ã�Ƽ� itemDic�� ����
        items = itemDic.Item;                  // ItemDic Ŭ������ �ִ� Item ������ items�� ����


        foreach (var item in items) // ������ �ִ� ��� �����ۿ� ���ؼ�
        {
            if (item.Key == "�ǹ�")
            {
                foreach (var data in (List<BuildingDataInfo>)item.Value) // �������� ���� ����Ʈ ��ȸ
                {
                    // ���� ������ UI �������� �����ϰ� �� ������Ʈ�� ������
                    // Instantiate = ���� ���� �� ���� ������Ʈ ����
                    var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
                    // ������ ������Ʈ�� ������ ������ ����
                    shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage);
                   // Debug.Log($"Item Name: {data.buildingName}, Item Cost: {data.buildingCost}");
                    Debug.Log($"SetInfo called with: {data.buildingName}, {data.buildingCost}, {data.buildingImage.name}");

                    shopItems.Add(shopItem); // ����Ʈ�� ��ü �߰�
                }
               
            }
        }
    }

        public void CloseButtonOnClick()
    {
        //�޴� ��ư ��Ȱ��ȭ, �ݱ� ��ư Ȱ��ȭ
        image.transform.position = startPosition;
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
    }
    public void ShopButton_Click()
    {
        //���� â ��� Ȱ��ȭ
        StartCoroutine(MoveImage());

        //�޴� ��ư ��Ȱ��ȭ
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
    }

    IEnumerator MoveImage()
    {

        //ó�� y��    : -846
        //������ y��  : 318

        float t = 0f; // �ð� ����

        Vector3 startPosition = image.transform.position;  // ���� ��ġ ����

        endPosition = new Vector3(948, image.rectTransform.position.y + 1150, 0); //������ ��ġ ����

        while (t < 1f) // t�� 1�� �� ������
        {
            if (image.rectTransform.position.y >= 287) //������ ��ġ�� �̵��ߴٸ� ���̻� �������� ����
            {
                yield break;
            }

            t += Time.deltaTime * speed; // �ð� ����

            // Lerp�� �̿��� ���� ��ġ���� endPosition���� �ε巴�� �̵�
            image.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null; // ������ ���ݴ�� ����

        }
    }

    //���� ��
    public void TabBuildingItem()
    {
        TabClearItem();
        var buildingList = (List<BuildingDataInfo>)items["�ǹ�"];
        foreach (var data in buildingList)
        {
            var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
            shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage);
            shopItems.Add(shopItem); // ����Ʈ�� ��ü �߰�
        }
    }

    //����� ��
    public void TabFarmitem()
    {
        TabClearItem();
        var farmList = (List < FarmDataInfo >) items["�����"];
        foreach(var data in farmList)
        {
            var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
            shopItem.SetInfo(data.farmName, data.farmCost, data.farmImage);
            Debug.Log($"Item Name: {data.farmName}, Item Cost: {data.farmCost}");
        }
    }

    //���� ��
    public void TabAnimalitem()
    {
        TabClearItem();
        var farmList = (List<AnimalDataInfo>)items["����"];
        foreach (var data in farmList)
        {
            var shopItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItemUI>();
            shopItem.SetInfo(data.AnimalName, data.AnimalCost, data.AnimalImage);
        }
    }

    //Storeitem �±� ������ �����
    public void TabClearItem()
    {
        foreach(Transform child in shopItemsParent)
        {
            if(child.CompareTag("StoreItem"))
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void Update()
    {
        //Debug.Log(image.rectTransform.position.y);
    }
}
