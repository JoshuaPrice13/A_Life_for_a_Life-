using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation_Manager : MonoBehaviour
{
    private bool inProximity;


    //Other Scripts
    [SerializeField]
    private InGameHud myHUD;

    public void Display_Start_Conversation_Option(bool b)
    {
        myHUD.DisplayInteractionHint(b);
    }

    public void setProximity(bool b)
    {
        inProximity = b;
    }

    // Update is called once per frame
    void Update()
    {
        if (inProximity)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("Start Convo");
            }
        }
    }
}
