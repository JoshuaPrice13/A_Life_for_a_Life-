using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHud : MonoBehaviour
{

    //UI GameObjects
    public Text InteractionHint;

    public void DisplayInteractionHint(bool b)
    {
        InteractionHint.gameObject.SetActive(b);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
