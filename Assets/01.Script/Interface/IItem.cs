using UnityEngine;

//by.J:230720 ����ǰ �������̽�(�԰�) -> ������Ƽ�� �б�����
//by.J:230808 �̹��� �߰�
public interface IItem
{
    string[] ItemName { get; }    //�̸�
    int[] ItemCost { get; }       //����
    Sprite[] ItemImage { get; }   //�̹���

}
