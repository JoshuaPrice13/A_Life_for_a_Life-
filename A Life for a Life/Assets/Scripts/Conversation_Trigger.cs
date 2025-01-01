using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation_Trigger : MonoBehaviour
{
    public Collider proximity;
    
    [SerializeField]
    private First_Person_Movement myPlayerScript;
    [Space]
    [SerializeField]
    private Conversation_Manager myConvoManager;


    // Start is called before the first frame update
    void Start()
    {
        myPlayerScript = GameObject.Find("Player").GetComponent<First_Person_Movement>();
        myConvoManager = GameObject.Find("Player").GetComponent<Conversation_Manager>();
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            print("entered proximity");
            myConvoManager.Display_Start_Conversation_Option(true);
            myConvoManager.setProximity(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("exited proximity");
            myConvoManager.Display_Start_Conversation_Option(false);
            myConvoManager.setProximity(false);
        }

    }
 
}
