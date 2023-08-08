using UnityEngine;
using UnityEngine.UI;
using TMPro;

//by.J:230808 창고 슬롯
public class StarageSlot : MonoBehaviour
{
    //public Text itemNameText;
    public Image itemImage;
    public TextMeshProUGUI itemCountText;
    

    public void SetItem(IItem item, int count)
    {
        itemImage.sprite = item.ItemImage[0];
        itemCountText.text = count.ToString();
        //itemNameText.text = item.ItemName[0]; // 처음 아이템의 이름을 사용

    }
}


