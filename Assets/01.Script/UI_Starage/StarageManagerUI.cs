using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//by.J:230808 â�� â Ŭ���� Ȱ��ȭ / �޴� ��ư ��Ȱ��ȭ / �ݱ� ��ư 
public class StarageManagerUI : MonoBehaviour
{
    public Image image; //������ �̹���
    public Vector3 endPosition; //������ �̵� ��ġ
    public float speed; //�̵� �ӵ�

    public Button closeButton; //�ݱ� ��ư

    public Button inviButton1;      //��Ȱ��ȭ �� ��ư 1��
    public Button inviButton2;      //��Ȱ��ȭ �� ��ư 2��
    public Button inviButton3;      //��Ȱ��ȭ �� ��ư 3��

    private Vector3 startPosition; //���� ��ġ

    private void Start()
    {
        Debug.Log(image.rectTransform.position.x);
        Debug.Log(image.rectTransform.position.y);

        closeButton.onClick.AddListener(CloseButtonOnClick);    //�ݱ� ��ư Ŭ��
        startPosition = image.transform.position;               //���� ��ġ ����
    }

    public void CloseButtonOnClick()
    {
        //�޴� ��ư ��Ȱ��ȭ, �ݱ� ��ư Ȱ��ȭ
        image.transform.position = startPosition;
        inviButton1.gameObject.SetActive(true);
        inviButton2.gameObject.SetActive(true);
        inviButton3.gameObject.SetActive(true);
    }

    public void StarageButton_Click()
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

        //ó�� y��    : 
        //������ y��  : 

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
}
