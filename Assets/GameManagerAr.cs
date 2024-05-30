using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManagerAr : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI RemainingBombsCount;
    public float TimeLeft = 15f;
    public bool TimerOn = false;
    public TextMeshProUGUI TimeLeftText;
    public GameObject mainCamera;
    void Start()
    {
        mainCamera.SetActive(true);
        TimerOn = true;
        int BombCount = StaticData.BombCount;
        RemainingBombsCount.text = BombCount.ToString();
        StartGameXR(BombCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn){
            if (TimeLeft > 0){
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else{
                TimerOn = false;
                FailEnd();
            }
        }
    }
    private void updateTimer(float currentTime){
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimeLeftText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void StartGameXR(int BombCount){
        Debug.Log("Game Started with " + BombCount + " bombs");
        FindObjectOfType<BombXR>().SpawnBombs(BombCount);
    }

    public void SuccessEnd(){
        mainCamera.SetActive(false);
        TimerOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void FailEnd(){
        mainCamera.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
