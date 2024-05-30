using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Reflection;
using System.Collections;
using System.Threading;
using System;
using UnityEngine.SceneManagement;
//using System.Runtime.Remoting.Lifetime;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI scoreText2;
    public Image fadeImage;

    private int score;

    private Blade2 blade;
    private Spawner2 spawner;

    public GameObject mainCamera;

    

    private void Awake()
    {
        blade = FindObjectOfType<Blade2>();
        spawner = FindObjectOfType<Spawner2>();
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        fadeImage = FindObjectOfType<Image>();
        //mainCamera = FindObjectWithTag<MainCamera>();
    }

    private void Start()
    {
        if (StaticData.NewGamePlus == true)
        {
            NewGamePlus();
        }
        else
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        ClearScene();
    }
    private void NewGamePlus(){
        Time.timeScale = 1f;

        score = StaticData.score;
        scoreText.text = score.ToString();

        ClearScene();
    }
    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Explode(int timer)
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }
    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed/ duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
        StaticData.score = int.Parse(scoreText.text);
        StaticData.BombCount = StaticData.BombCount + 3;
        StaticData.NewGamePlus = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainCamera.SetActive(false);
        NewGame();

        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
    }

}