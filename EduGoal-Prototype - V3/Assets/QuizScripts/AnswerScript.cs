using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizmanager;
    //public Quizpop quizpop;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            //quizpop.ResetChance();
            quizmanager.reset = true;
            quizmanager.Correct();
            //quizpop.HideCanvas();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizmanager.reset = false;
            quizmanager.Correct();
        }
    }

}
