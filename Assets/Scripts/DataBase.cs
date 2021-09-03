using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public string Name;
    public string Phone;
    public string Displaytext;

    private Menu menu;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        menu = FindObjectOfType<Menu>();
    }
    private void Update()
    {
        Name = menu.Name;
        Phone = menu.Phone;

        Displaytext = "THANKS FOR PLAYING\n\n" + Name + "\n\n" + Phone;
    }
}
