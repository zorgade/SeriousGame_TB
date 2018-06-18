using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData  {

    public string name;
    public int timeLimitSeconds;
    public int pointAddedForCorrectAnswer;
    public QuestionData[] questions;
}
