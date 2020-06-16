using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;

    private GameController gameController;

    public int difficulty;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameController = GameObject.Find("Game Manager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {

        gameController.StartGame(difficulty);
    }
}
