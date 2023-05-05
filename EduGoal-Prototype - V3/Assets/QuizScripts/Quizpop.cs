using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quizpop : MonoBehaviour
{
    public GameObject QuestionTemplate;
    public GameManager gameManager;
    public QuizManager quizManager;
    //public QuestionAndAnswer QnA;
    //public AnswerScript AS;
    //public bool reset = false;

    public void ShowCanvas(bool show)
    {
        QuestionTemplate.SetActive(show);
    }

    public void HideCanvas(bool hide)
    {
        QuestionTemplate.SetActive(!hide);
    }
    
    public void CheckChance()
    {
        if (gameManager.chance)
        {
            ShowCanvas(true);
            ResetChance();
            /*if (AS.correct == 1)
            {
                HideCanvas(true);
                gameManager.chance = 0;
                AS.correct = 0;
            }*/
        }
        else
        {
            HideCanvas(true);
        }
    }

    public void ResetChance()
    {
        if (quizManager.reset)
        {
            gameManager.chance = false;
            quizManager.reset = false;
        }
    }

    public void Update()
    {
        CheckChance();
    }


}

