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


    public void Sequence_ShowCharacterImage()//���ֽ�ɫͷ��
    {
        chracterList[0].characterImage.DOColor(Color.black, 0.75f).OnComplete(Sequence_AskQuestions);
    }
    public void Sequence_AskQuestions()//NPC������
    {
        interviewerList[0].interviewerImage.DOColor(Color.white, 0.75f).OnComplete(   //����ͷ��
            ()=> interviewerList[0].dialogBoxImage.DOColor(Color.white,0.75f).OnComplete(
            () =>StartCoroutine(ShowQuestionText())
                )        //���ֶԻ���                                                                              
            );
    }
    IEnumerator ShowQuestionText()//�����ı�����
    {
        int i = 0;
        while (i < interviewerList[0].question.Length - 1)
        {
            interviewerList[0].questionText.text += interviewerList[0].question[i];
            i += 1;
            yield return new WaitForSeconds(0.05f);
        }
        interviewerList[0].questionText.text = interviewerList[0].question;
        //npc����       
        //���ֽ�ɫ�ĶԻ���
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
            //npc�ش�
            interviewerList.RemoveAt(0);
            interviewerList[0].interviewerImage.DOColor(Color.white, 0.75f).OnComplete(   //����ͷ��
            () => interviewerList[0].dialogBoxImage.DOColor(Color.white, 0.75f).OnComplete(
            () => StartCoroutine(NPCReplyAnswer())
                )        //���ֶԻ���                                                                              
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
            interviewerList[0].interviewerImage.DOColor(Color.white, 0.75f).OnComplete(   //����ͷ��
            () => interviewerList[0].dialogBoxImage.DOColor(Color.white, 0.75f).OnComplete(
            () => StartCoroutine(NPCReplyAnswer())
                )        //���ֶԻ���                                                                              
            );
        }
    }
    IEnumerator NPCReplyAnswer()//�����ı�����
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
        //npc����       
        //���ֽ�ɫ�ĶԻ���       

    }
}
