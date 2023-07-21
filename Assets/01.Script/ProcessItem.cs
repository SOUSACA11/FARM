using UnityEngine;
using System.Collections.Generic; //by.J:230721 List ����ȭ

//by.J:230720 ����ǰ (����ǰ) ������Ʈ 
namespace JinnyProcessItem
{
    //by.J:230720 ����ü ����
    [System.Serializable]
    public struct ProcessItemDataInfo
    {
        public string processItemName; //�̸�
        public int processItemCost;    //����
    }

    //by.J:230720 IItem �������̽� ����
    public class ProcessItem : MonoBehaviour, IItem
    {
        [SerializeField] private List<ProcessItemDataInfo> processitemDataInfoList = new List<ProcessItemDataInfo>();

        public string[] ItemName
        {
            get
            {
                string[] names = new string[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    names[i] = processitemDataInfoList[i].processItemName;
                }
                return names;
            }
        }

        public int[] ItemCost
        {
            get
            {
                int[] costs = new int[processitemDataInfoList.Count];
                for (int i = 0; i < processitemDataInfoList.Count; i++)
                {
                    costs[i] = processitemDataInfoList[i].processItemCost;
                }
                return costs;
            }
        }


        ////by.J:230720 ���۽� �ʱ�ȭ ��� ����
        private void Start()
        {
            InitializeBuildings();
        }

        //by.J:230720 �ʱ�ȭ ���
        private void InitializeBuildings()
        {
            //�Ļ�
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�Ļ�",
                processItemCost = 10
            });

            //�ٰ�Ʈ
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�ٰ�Ʈ",
                processItemCost = 10
            });

            //ũ��ͻ�
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "ũ��ͻ�",
                processItemCost = 10
            });

            //�а���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�а���",
                processItemCost = 10
            });

            //�� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�� ���",
                processItemCost = 10
            });

            //���� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "���� ���",
                processItemCost = 10
            });

            //�� ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�� ���",
                processItemCost = 10
            });

            //����Ķ���
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�Զ��Ķ���",
                processItemCost = 10
            });

            //������
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "������",
                processItemCost = 10
            });

            //�丶�� �꽺
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "�丶�� �꽺",
                processItemCost = 10
            });

            //��� �꽺
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "��� �꽺",
                processItemCost = 10
            });

            //����
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "����",
                processItemCost = 10
            });

            //ġ��
            processitemDataInfoList.Add(new ProcessItemDataInfo()
            {
                processItemName = "ġ��",
                processItemCost = 10
            });
        }
    }
}

