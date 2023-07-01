using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class SequenceDialog : MonoBehaviour
{
    public List<CharacterController> chracterList = new List<CharacterController>();
    public List<InterviewerChontroller> interviewerList = new List<InterviewerChontroller>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Sequence_ShowCharacterImage()//出现角色头像
    {
        chracterList[0].characterImage.DOColor(Color.black, 0.75f).OnComplete(Sequence_AskQuestions);
    }
    public void Sequence_AskQuestions()//NPC问问题
    {
        interviewerList[0].interviewerImage.DOColor(Color.white, 0.75f).OnComplete(   //出现头像
            ()=> interviewerList[0].dialogBoxImage.DOColor(Color.white,0.75f).OnComplete(
            () =>StartCoroutine(ShowQuestionText())
                )        //出现对话框                                                                              
            );
    }
    IEnumerator ShowQuestionText()//出现文本内容
    {
        int i = 0;
        while (i < interviewerList[0].question.Length - 1)
        {
            interviewerList[0].questionText.text += interviewerList[0].question[i];
            i += 1;
            yield return new WaitForSeconds(0.05f);
        }
        interviewerList[0].questionText.text = interviewerList[0].question;
        //npc提问       
        //出现角色的对话框
        chracterList[0].dialogBoxImage.DOColor(Color.white, 0.75f).OnComplete(ShowTips) ;

    }
    public void ShowTips()
    {
        chracterList[0].answerTip.DOColor(Color.grey, 0.75f);
        SequenceController.CanConfirm = true;
    }
    public void CharacterAnswer()
    {
        StartCoroutine(CharacterAnswerQuestions());
    }
    IEnumerator CharacterAnswerQuestions()
    {
        int _index = 0;
        chracterList[0].answerTip.color = Color.clear;
        if (GenderController.s_GenderType == GenderController.GenderType.Male)
        {
            while (_index < chracterList[0].answerMale.Length - 1)
            {
                chracterList[0].answer.text += chracterList[0].answerMale[_index];
                _index += 1;
                yield return new WaitForSeconds(0.05f);
            }
            chracterList[0].answer.text = chracterList[0].answerMale;
            //npc回答
            interviewerList.RemoveAt(0);
            interviewerList[0].interviewerImage.DOColor(Color.white, 0.75f).OnComplete(   //出现头像
            () => interviewerList[0].dialogBoxImage.DOColor(Color.white, 0.75f).OnComplete(
            () => StartCoroutine(NPCReplyAnswer())
                )        //出现对话框                                                                              
            );
        }
        else
        {
            while (_index < chracterList[0].answerFemale.Length - 1)
            {
                chracterList[0].answer.text += chracterList[0].answerFemale[_index];
                _index += 1;
                yield return new WaitForSeconds(0.05f);
            }
            chracterList[0].answer.text = chracterList[0].answerFemale;
            interviewerList.RemoveAt(0);
            interviewerList[0].interviewerImage.DOColor(Color.white, 0.75f).OnComplete(   //出现头像
            () => interviewerList[0].dialogBoxImage.DOColor(Color.white, 0.75f).OnComplete(
            () => StartCoroutine(NPCReplyAnswer())
                )        //出现对话框                                                                              
            );
        }
    }
    IEnumerator NPCReplyAnswer()//出现文本内容
    {
        
        int _index = 0;
        if (GenderController.s_GenderType == GenderController.GenderType.Male)
        {
            while (_index < interviewerList[0].answerMale.Length - 1)
            {
                interviewerList[0].answerText.text += interviewerList[0].answerMale[_index];
                _index += 1;
                yield return new WaitForSeconds(0.05f);
            }
            interviewerList[0].answerText.text = interviewerList[0].answerMale;
        }
        else
        {
            while (_index < interviewerList[0].question.Length - 1)
            {
                interviewerList[0].answerText.text += interviewerList[0].answerFemale[_index];
                _index += 1;
                yield return new WaitForSeconds(0.05f);
            }
            interviewerList[0].answerText.text = interviewerList[0].answerFemale;
        }
        //npc提问       
        //出现角色的对话框       

    }
}
