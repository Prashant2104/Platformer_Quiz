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
    public string Displaytext;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void StoreData()
    {
        Name = Name_inputField.GetComponent<Text>().text;
        Phone = Phone_inputField.GetComponent<Text>().text;

        Displaytext = "Thanks for participating \n\n" + Name + "\n\n" + Phone;

        SceneManager.LoadScene(1);
    }
}
