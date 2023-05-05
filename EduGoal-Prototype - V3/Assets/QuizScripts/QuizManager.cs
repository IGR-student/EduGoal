using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] Options;
    public int CurrentQuestion;
    public Text QuestionText;
    //public Quizpop quizpop;
    public bool reset = false;
    public GameManager gameManager;

    private void Start()
    {
        GenerateQuestion();
    }

    public void Correct()
    {
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
        //reset = true;
    }
    public void Answer()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Options[i].GetComponent<AnswerScript>().isCorrect = false;
            Options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];

            if (QnA[CurrentQuestion].CorrectAnswer == i+1)
            {
                Options[i].GetComponent<AnswerScript>().isCorrect = true;
                /*if (Options[i].GetComponent<AnswerScript>().isCorrect)
                {
                    reset = true;
                }*/
            }
        }
    }

    public void GenerateQuestion()
    {
        CurrentQuestion = Random.Range(0, QnA.Count);
        QuestionText.text = QnA[CurrentQuestion].Question;

        Answer();
    }
}
