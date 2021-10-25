using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Image Timer;
    public float MaxTime;

    public Quiz_Manager QM;

    [SerializeField] private float TimeRemaining;

    void Start()
    {
        TimeRemaining = MaxTime;
        Timer.fillAmount = 1;
    }

    void FixedUpdate()
    {
        if (TimeRemaining >= 0.1f)
        {
            TimeRemaining -= Time.deltaTime;
        }

        Timer.fillAmount = TimeRemaining / MaxTime;

        if(TimeRemaining <= 0.1f)
        {
            QM.GameOver();
        }
    }
}