using UnityEngine;
using UnityEngine.UI;
using TMPro;

//by.J:230817 건물 원재료 슬롯 설정
public class IngredientSlot : MonoBehaviour
{
    public Image ingredientImage; //원재료 이미지
    public TextMeshProUGUI ingredientQuantity; //원재료 수량

    public void SetIngredient(IItem production, int quantity)
    {
        ingredientImage.sprite = production.ItemImage;
        ingredientQuantity.text = quantity.ToString();

        //Debug.Log("Setting ingredient: " + production.ItemName());
    }
}
