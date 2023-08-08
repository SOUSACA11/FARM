using UnityEngine;

//by.J:230720 생산품 인터페이스(규격) -> 프로퍼티로 읽기전용
//by.J:230808 이미지 추가
public interface IItem
{
    string[] ItemName { get; }    //이름
    int[] ItemCost { get; }       //가격
    Sprite[] ItemImage { get; }   //이미지

}
