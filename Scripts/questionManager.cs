using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class questionManager : MonoBehaviour
{
    public GameObject questionPrefab;
    public questionInventory quInven;
    public Inventory playerbag;
    public int playeranswer;
    int nowQuestion = 1;

    private csvController csvload = csvController.GetInstance();
   
    private void Awake()
    {
        string filepath = Application.dataPath+"/Resources/";
        string filename = "questions.txt";
        csvload.loadFile(filepath, filename);
        Debug.Log(1);
    }
    public void getQuestion()
    {
        questionPrefab.SetActive(true);
        bool flag = false;
        int quesId=1,randomtimes=0;
        while (flag == false&&randomtimes < csvload.arrayData.Count)
        {
            randomtimes++;
            quesId = Mathf.FloorToInt(Random.Range(1, csvload.arrayData.Count-0.1f));
            if (quInven.questions[quesId] == false) { flag = true;quInven.questions[quesId] = true; }
        }
        questionPrefab.GetComponent<questionPrefab>().setQuestion(quesId);
    }
}
