using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewScript : MonoBehaviour
{
    public TextMeshProUGUI txtDisplay;
    public Button ClickMe;
    private int isOn = 0;


    // This method will be called when the button is clicked
    public void onButtonClick()
    {
        // Assuming ClickMe is a Button type, checking if it has been clicked
        if (isOn == 0)
        {
            txtDisplay.SetText("abc");
        }
        else
        {
            txtDisplay.SetText("def");
        }
        isOn = 1 - isOn;
    }
}