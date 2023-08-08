using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JinnyBuilding;
using JinnyFarm;
using JinnyAnimal;

//by.J:230724 ���� â Ŭ���� Ȱ��ȭ / �޴� ��ư ��Ȱ��ȭ / �ݱ� ��ư / ���� ������ �б�
//by.J:230724 ���� �� UI ���� �߰�
public class StoreManagerUI : MonoBehaviour
{
    public Image image;          //������ �̹��� 
    public Vector3 endPosition;  //������ �̵� ��ġ
    public float speed = 120f;   //�̵� �ӵ�

    public Button closeButton;   //�ݱ� ��ư

    public Button inviButton1;   //��Ȱ��ȭ �� ��ư 1��
    public Button inviButton2;   //��Ȱ��ȭ �� ��ư 2��
    public Button inviButton3;   //��Ȱ��ȭ �� ��ư 3��

    private Vector3 startPosition; //������ġ

            
    public GameObject storeItemPrefab;         // ���� ������ UI ������
    public Transform storeItemsParent;         // ���� �����۵��� ���� �θ� ������Ʈ
    public ItemDic itemDic;                   // ������ ������ ���� ItemDic Ŭ����
    private Dictionary<string, object> items; // ������ ������ ���� ����

    List<StoreItemUI> storeItems = new List<StoreItemUI>(); // ���� ������ ��ü���� ������ ����Ʈ
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
                    var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
                    // ������ ������Ʈ�� ������ ������ ����
                    shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage);
                   // Debug.Log($"Item Name: {data.buildingName}, Item Cost: {data.buildingCost}");
                   // Debug.Log($"SetInfo called with: {data.buildingName}, {data.buildingCost}, {data.buildingImage.name}");

                    storeItems.Add(shopItem); // ����Ʈ�� ��ü �߰�
                }
               
            }
        }
    }

        public void CloseButtonOnClick()
    {
        //�޴� ��ư ��Ȱ��ȭ, �ݱ� ��ư Ȱ��ȭ
        image.transform.position = startPosition;
        inviButton1.gameObject.SetActive(true);
        inviButton2.gameObject.SetActive(true);
        inviButton3.gameObject.SetActive(true);
    }
    public void StoreButton_Click()
    {
        //���� â ��� Ȱ��ȭ
        StartCoroutine(MoveImage());

        //�޴� ��ư ��Ȱ��ȭ
        inviButton1.gameObject.SetActive(false);
        inviButton2.gameObject.SetActive(false);
        inviButton3.gameObject.SetActive(false);
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
            var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
            shopItem.SetInfo(data.buildingName, data.buildingCost, data.buildingImage); ////, data.buildingPrefab);
            //shopItems.Add(shopItem); // ����Ʈ�� ��ü �߰�
        }
    }

    //����� ��
    public void TabFarmitem()
    {
        TabClearItem();
        var farmList = (List<FarmDataInfo>)items["�����"];
        foreach (var data in farmList)
        {
            var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
            shopItem.SetInfo(data.farmName, data.farmCost, data.farmImage);

        }
    }

    //���� ��
    public void TabAnimalitem()
    {
        TabClearItem();
        var farmList = (List<AnimalDataInfo>)items["����"];
        foreach (var data in farmList)
        {
            var shopItem = Instantiate(storeItemPrefab, storeItemsParent).GetComponent<StoreItemUI>();
            shopItem.SetInfo(data.AnimalName, data.AnimalCost, data.AnimalImage);
        }
    }

    //Storeitem �±� ������ �����
    public void TabClearItem()
    {
        foreach (Transform child in storeItemsParent)
        {
            if (child.CompareTag("StoreItem"))
            {
                Destroy(child.gameObject);
            }
        }
    }

    //private void Update()
    //{
    //    //Debug.Log(image.rectTransform.position.y);
    //}
}
