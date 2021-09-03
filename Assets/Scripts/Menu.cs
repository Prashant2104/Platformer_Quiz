using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Name;
    public string Phone;
    public GameObject Name_inputField;
    public GameObject Phone_inputField;
    public GameObject StartQuiz;
    public GameObject EnterData;

   /* private void Start()
    {
        Phone_inputField.characterValidation = InputField.CharacterValidation.Integer;    
    }*/
    private void Update()
    {
        if(!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone))
        {
            StartQuiz.SetActive(true);
            EnterData.SetActive(false);
        }
        else
        {
            StartQuiz.SetActive(false);
        }
    }
    public void StoreData()
    {
        Name = Name_inputField.GetComponent<Text>().text;
        Phone = Phone_inputField.GetComponent<Text>().text;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}