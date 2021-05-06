using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionPrefab : MonoBehaviour
{
    public int id;
    public GameObject playerAns;
    public GameObject explain;
    public questionManager qMana;

    public List<GameObject> itemprefabs = new List<GameObject>();
    public List<GameObject> answers = new List<GameObject>();
    public GameObject answersPrefab;
    public GameObject answerGrid;
    public int playerAnswer;
    public int riAns = -1;

    public Text result;
    public Text itemGet;
    public Text questionText;

    public Image ItemImage;

    public Inventory mybag;

    public GameObject AnswerRight;
    public GameObject AnswerWrong;

    public GameObject checkMenu;
    public GameObject AnsMenu;
    public GameObject getAllItem;
    public GameObject notGetAllItem;

    csvController csvLoad = csvController.GetInstance();
    private void Awake()
    {
        string filepath = Application.dataPath + "/Resources/";
        string filename = "questions.txt";
        csvLoad.loadFile(filepath, filename);
        Debug.Log(345);
    }
    public void setQuestion(int id_set)
    {
        AnswerWrong.SetActive(false);
        AnswerRight.SetActive(false);
        checkMenu.SetActive(false);
        AnsMenu.SetActive(true);
        getAllItem.SetActive(false);
        notGetAllItem.SetActive(false);
        id = id_set; Debug.Log("csvload");
        Debug.Log(csvLoad.arrayData.Count);
        if (answers.Count < 3)
        {
            int tempcount = answers.Count;
            for (int i = 0; i < 3 - tempcount; i++)
            {
                GameObject tempanswer = Instantiate(answersPrefab,answerGrid.transform) as GameObject;
                tempanswer.transform.localScale = new Vector3(1, 1, 1);
                answers.Add(tempanswer);
                tempanswer.transform.SetParent(answerGrid.transform);
                Debug.Log(i);
            }
        }
        Debug.Log(id); Debug.Log(answers.Count);
        explain.SetActive(false);
        questionText.text = csvLoad.getString(id, 0);
        riAns = csvLoad.getInt(id, 4);
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
            string tempstring = csvLoad.getString(id, i + 1);
            answers[i].GetComponent<answerPrefab>().setAnswer(tempstring, i + 1);
            answers[i].GetComponent<answerPrefab>().ques = this;
            Debug.Log(tempstring);
        }
    }
    public Item getItem()
    {
        int itemid = Mathf.FloorToInt(Random.Range(0, itemprefabs.Count - 0.1f));
        for(int i=0;i<itemprefabs.Count;i++)
        {
            if (mybag.itemlist[mybag.itemlist.IndexOf(itemprefabs[i].GetComponent<ItemOnWorld>().thisItem)].itemHeld==0)
                itemid = i;
        }
        Debug.Log(itemid);
        Debug.Log(itemprefabs.Count);
        itemprefabs[itemid].GetComponent<ItemOnWorld>().addNewItem();
        return itemprefabs[itemid].GetComponent<ItemOnWorld>().thisItem;
    }
    public void check()
    {
        notGetAllItem.SetActive(false);
        getAllItem.SetActive(false);
        playerAns.SetActive(false);
        checkMenu.SetActive(true);
        explain.SetActive(true);
        explain.GetComponent<Text>().text = "答案详解：\n" + csvLoad.getString(id, 5);

        if (playerAnswer == riAns)
        {
            AnswerRight.SetActive(true);
            var tempItem = getItem();
            itemGet.text = "恭喜你获得[" + tempItem.itemName + "]碎片";
            ItemImage.sprite = tempItem.itemImage;

            bool flag = true;
            for (int i = 0; i < itemprefabs.Count; i++)
                if (mybag.itemlist.Contains(itemprefabs[i].GetComponent<ItemOnWorld>().thisItem) == false)
                {
                    flag = false;
                    break;
                }
            if (flag == true)
            {
                getAllItem.SetActive(true);
                result.text = "集齐啦！";
            }
            else 
            {
                notGetAllItem.SetActive(true);
                result.text = "答对啦！"; 
            }
        }
        else
        {
            AnswerWrong.SetActive(true);
            result.text = "答错咯！";
            itemGet.text = "很遗憾，您没有获得任何碎片";
            ItemImage.sprite = null;
        }
    }
    private void Update()
    {
        for (int i = 0; i < 3; i++)
            if (playerAnswer - 1 != i) answers[i].GetComponent<answerPrefab>().answerImage.sprite = answers[i].GetComponent<answerPrefab>().selectimage;
    }
    public void exitAns()
    {
        this.gameObject.SetActive(false);
    }
}