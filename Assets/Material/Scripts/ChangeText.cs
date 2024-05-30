using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOn = false;
    public TextMeshProUGUI Text;
    void Start()
    {

    }

    public void ToggleButtonText()
    {

        isOn = !isOn;
        Text.text = isOn ? "HELLO WORLD" : "UPDATE TEST";
        //Text.SetText("Hi");

    }
    // Update is called once per frame
    void Update()
    {

    }
}