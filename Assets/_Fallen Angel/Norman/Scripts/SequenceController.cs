using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public List<SequenceDialog> Sequence = new List<SequenceDialog>();
    public static bool CanConfirm = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Sequence[0].Sequence_ShowCharacterImage();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Sequence.RemoveAt(0);
        }
    }
    public void ConfirmAnswer()
    {
        Sequence[0].CharacterAnswer();
        //Sequence.RemoveAt(0);
        CanConfirm = false;
    }

}
