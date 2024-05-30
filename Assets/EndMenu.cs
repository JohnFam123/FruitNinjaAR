using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public void ShowScore(){
        ScoreText.text += StaticData.score.ToString();
    }
    void Start()
    {
        ShowScore();
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
