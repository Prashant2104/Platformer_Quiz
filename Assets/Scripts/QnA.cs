﻿using UnityEngine;

[System.Serializable]
public class QnA
{
    [Multiline] public string Question;
    public string[] Answers ;
    public int CorrectAnswer;
}
