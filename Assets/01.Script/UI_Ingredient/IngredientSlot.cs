using UnityEngine;
using UnityEngine.UI;

//by.J:230817 건물 원재료 슬롯 설정
public class IngredientSlot : MonoBehaviour
{
    public Image ingredientImage;
    //public TextMeshProUGUI ingredientName;

    public void SetIngredient(IItem production)
    {
        ingredientImage.sprite = production.ItemImage;
        //ingredientName.text = ingredient.ItemName();
    }
}
