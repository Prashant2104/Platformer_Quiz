using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz_Manager : MonoBehaviour
{
    public List<QnA> Questions;
    public GameObject[] Options;
    public int QuestionIndex;
    public Text QuestionText;
    public Text ScoreText;
    public GameObject InstructionsPanel, QuizPanel;

    public int Score = 0;
    public int MaxScore = 0;
    public Player player;
    public bool Instructions, InstruxtionsEnabled;

    private Gate gate;
    private void Awake()
    {
        Instructions = true;
        InstruxtionsEnabled = false;
        InstructionsPanel.SetActive(true);
        QuizPanel.SetActive(false);
    }
    private void Start()
    {
        gate = FindObjectOfType<Gate>();

        DisplayQuestion();
    }
    private void Update()
    {
        ScoreText.text = "Score = " + Score.ToString();

        if(InstruxtionsEnabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Instructions = !Instructions;
            InstructionsPanel.SetActive(Instructions);
        }
    }

    public void Correct()
    {
        Score++;

        Questions.RemoveAt(QuestionIndex);
        DisplayQuestion();

        Debug.Log("Correct is called");
    }
    public void Wrong()
    {
        Questions.RemoveAt(QuestionIndex);
        DisplayQuestion();

        Debug.Log("Wrong is called");
    }

    void SetAnswers()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].GetComponent<Answers>().isCorrect = false;

            Options[i].transform.GetChild(0).GetComponent<Text>().text = Questions[QuestionIndex].Answers[i];

            if (Questions[QuestionIndex].CorrectAnswer == i + 1)
            {
                Options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
        player.Answered = false;
    }

    void DisplayQuestion()
    {
        if(Questions.Count > 0)
        {
            QuestionIndex = Random.Range(0, Questions.Count);
            QuestionText.text = Questions[QuestionIndex].Question;

            SetAnswers();
        }
        
        else if(Questions.Count == 0)
        {
            Debug.Log("End of questions");
            GameOver();
        }
    }

    public void GameOver()
    {
        QuestionText.text = "Exit through the open gate to finish and submit the quiz";
        for(int i = 0; i < 4; i++)
        {
            Options[i].transform.GetChild(0).GetComponent<Text>().text = "The open space on the right ->";
        }

        gate.OpenGate();
    }

    public void OnStartbuttonClick()
    {
        InstruxtionsEnabled = true;
        InstructionsPanel.SetActive(false);
        Instructions = false;
        QuizPanel.SetActive(true);
        Cursor.visible = false;
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void OnGoogleButtonClick()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLScXwXRCC5GTxPuq3iMAjuw-eWm9VtGn96REEOI_QfpQZBl9Eg/viewform?usp=sf_link");
    }
    public void Prashant()
    {
        Application.OpenURL("https://www.linkedin.com/in/prashant-gupta-3465b61a3/");
    }
}