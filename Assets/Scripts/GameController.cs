using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> targets;
    private int spawnRate = 1;
    public TextMeshProUGUI scoreText;
    public int score;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameActive = true;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTargets());
        score = 0;
        spawnRate /= difficulty;
        UpdateScore(0);
        scoreText.gameObject.SetActive(true);
        isGameActive = true;
        titleScreen.SetActive(false);
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
