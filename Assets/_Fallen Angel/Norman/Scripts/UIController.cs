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
                // 如果仍然找不到实例，则创建一个新的游戏对象并附加脚本
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("UIController");
                    instance = singletonObject.AddComponent<UIController>();
                }
                // 在场景切换时保持实例不被销毁
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    private void Awake()
    {
        // 如果存在其他相同类型的实例，则销毁自己以确保单例
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
