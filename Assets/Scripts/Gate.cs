using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gate : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text Info;
    public Text ScoreText;

    private Animator anim;
    private Quiz_Manager quiz;
    private Menu menu;

    void Start()
    {
        anim = GetComponent<Animator>();
        quiz = FindObjectOfType<Quiz_Manager>();
        menu = FindObjectOfType<Menu>();

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        GameOverPanel.SetActive(false);
    }
    public void OpenGate()
    {
        Debug.Log("Enter");
        anim.SetTrigger("Open");


        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void GameOverScore()
    {
        GameOverPanel.SetActive(true);
        quiz.QuizPanel.SetActive(false);

        Info.text = menu.Displaytext.ToString();
        ScoreText.text = "Your Final Score: " + quiz.Score.ToString();

        if (quiz.Score <= quiz.MaxScore/2)
        {
            GameOverPanel.GetComponent<Image>().color = new Color32(255, 138, 138, 110);
        }
        else if(quiz.Score > quiz.MaxScore/2)
        {
            GameOverPanel.GetComponent<Image>().color = new Color32(138, 255, 138, 110);
        }
        Time.timeScale = 0f;
    }
}