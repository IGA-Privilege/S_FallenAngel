using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderController : MonoBehaviour
{
    private static GenderController instance;
    public enum GenderType { Female, Male };    
    public static GenderType s_GenderType = GenderType.Female;

    public static bool s_isMale=false;
    // 获取单例实例的方法
    public static GenderController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GenderController>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GenderController");
                    instance = singletonObject.AddComponent<GenderController>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }




    public void TransitionGender()
    {
        s_GenderType = (s_GenderType == GenderType.Female ? GenderType.Male : GenderType.Female);
    }
}

