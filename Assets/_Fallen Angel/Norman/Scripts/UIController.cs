using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public TMP_Text genderText;

    // Start is called before the first frame update
    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIController>();
                // �����Ȼ�Ҳ���ʵ�����򴴽�һ���µ���Ϸ���󲢸��ӽű�
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("UIController");
                    instance = singletonObject.AddComponent<UIController>();
                }
                // �ڳ����л�ʱ����ʵ����������
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    private void Awake()
    {
        // �������������ͬ���͵�ʵ�����������Լ���ȷ������
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void ChangeGenderText()
    {
        if(GenderController.s_GenderType==GenderController.GenderType.Female)       genderText.text = "FEMALE";
        else        genderText.text = "MALE";
    }
}
