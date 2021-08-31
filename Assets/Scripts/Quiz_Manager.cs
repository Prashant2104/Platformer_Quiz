﻿using System.Collections;
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

    private Gate gate;
    private void Awake()
    {
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

            Options[i].transform.GetChild(1).GetComponent<Text>().text = Questions[QuestionIndex].Answers[i];

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

    void GameOver()
    {
        QuestionText.text = "Exit through the open gate to finish and submit the quiz";

        gate.OpenGate();
    }

    public void OnStartbuttonClick()
    {
        InstructionsPanel.SetActive(false);
        QuizPanel.SetActive(true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
