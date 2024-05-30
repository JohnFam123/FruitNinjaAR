using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SomethingHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI txtDisplay;
    public Button btnClicky;
    private int isOn = 0;
    
    public void onButtonClick()
    {
        if(isOn == 0)
        {
            txtDisplay.SetText("On");
        }
        else
        {
            txtDisplay.SetText("Off");
        }
        isOn = 1 - isOn;
    }
}
