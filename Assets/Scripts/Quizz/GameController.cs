using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplayCorrect;
    public GameObject roundEndDisplayWrong;


    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitSeconds;
        UpdateTimeRemainingDisplay();
        playerScore = 0;
        var rndQuestion = 0;
        for (int i = 0; i < 20; i++)
        {
            rndQuestion = Random.Range(1, questionPool.Length);
        }
        questionIndex = rndQuestion;

        ShowQuestion();
        isRoundActive = true;

    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;


        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            EndRound(true);

        }

        else
        {
            //GameBoardScript.score = GameBoardScript.oldScore;
            EndRound(false);
        }

    }
    /*
     *End round manager, if ansewer is correct: show green display and set oldscore to current score 
     * else show red display and set score to oldscore to the GameBoardScript public stativ int score and oldScore
     */
    public void EndRound(bool answer)
    {
        isRoundActive = false;
        questionDisplay.SetActive(false);

        if (answer)
        {
            roundEndDisplayWrong.SetActive(false);
            roundEndDisplayCorrect.SetActive(true);

            SoloBoardScript.oldScore = SoloBoardScript.score;
            DiceGB.oldScore = DiceGB.scorePlayer;

        }
        else
        {
            roundEndDisplayWrong.SetActive(true);
            roundEndDisplayCorrect.SetActive(false);

            SoloBoardScript.score = SoloBoardScript.oldScore;
            DiceGB.scorePlayer = DiceGB.oldScore;



        }

    }

    public void ReturnToMenu()
    {

        if (SelectNbrePlayer.nbrePlayer != 1)
        {
            //SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);

            SceneManager.LoadScene("07.BoardGame");
            //SceneManager.LoadScene("07Bis.SoloBoard");

        }
        else
        {
            SceneManager.LoadScene("07Bis.SoloBoard");
        }
    }

    /*
     * Show time
     */
    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    /*
     * If time < 0 -> the player lost the round and set EndRound to false
     */
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                SoloBoardScript.score = SoloBoardScript.oldScore;
                EndRound(false);
            }

        }
    }
}