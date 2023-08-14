using UnityEngine;
using JinnyProcessItem;

//by.J:230814 ����Ŭ���� / ProcessItemDataInfo �����͸� IItem �°� ����
public class ProcessItemIItem : IItem
{
    private ProcessItemDataInfo _info;
    //_info -> ���������� �����ϰ� �ִ� ���� ������ ��ü / ProcessItemDataInfoŸ���� �ν��Ͻ� ����

    public ProcessItemIItem(ProcessItemDataInfo info)
    {
        _info = info;
    }

    public string ItemName => _info.processItemName;
    public int ItemCost => _info.processItemCost;
    public Sprite ItemImage => _info.processItemImage;
    public string ItemId => _info.processItemId;
}
