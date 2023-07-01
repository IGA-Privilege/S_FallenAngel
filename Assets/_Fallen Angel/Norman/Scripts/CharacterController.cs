using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Image characterImage;
    public string answerFemale;
    public string answerMale;
    public Image dialogBoxImage;
    public TMP_Text answerTip;
    public TMP_Text answer;

    public float textSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GenderController.s_GenderType == GenderController.GenderType.Female)
        {
            answerTip.text = answerFemale;
        }
        else
        {
            answerTip.text = answerMale;
        }
        
        //
    }   
}
