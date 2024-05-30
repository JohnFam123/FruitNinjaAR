using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliceScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject blade;
    public TextMeshProUGUI scoreText;
    public int RemainingBombs = StaticData.BombCount;
    void Start()
    {
        RemainingBombs = StaticData.BombCount;
    }
    public void Slice (){
        RaycastHit hit;
        FindObjectOfType<AudioBladeXR>().PlayBladeSound();
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
            //Debug.Log(hit.transform.tag);
            if (hit.transform.name == "BombXR(Clone)"){
                Destroy(hit.transform.gameObject);
                RemainingBombs--;
                scoreText.text = RemainingBombs.ToString();
                if (RemainingBombs == 0){
                    FindObjectOfType<GameManagerAr>().SuccessEnd();
                }
            }
        }

    }
}
