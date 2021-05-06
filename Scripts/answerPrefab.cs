using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answerPrefab : MonoBehaviour
{
    public Text answertext;
    public Image answerImage;
    public bool if_select = false;
    public Sprite selectimage;
    public questionPrefab ques;
    public Sprite notSelectImage;
    public int answerid;
    public void setAnswer(string answer,int id)
    {
        answertext.text = answer;
        answerid = id;
        answerImage.sprite = notSelectImage;
    }
    public void click()
    {
        if (if_select==false)
        {
            if_select = true;
            ques.playerAnswer = answerid;
            answerImage.sprite = notSelectImage;
        }
        else
        {
            answerImage.sprite = selectimage;
            if_select = false;
        }
    }
}