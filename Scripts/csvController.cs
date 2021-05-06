using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class csvController : MonoBehaviour
{
    static csvController csv;
    public List<string[]> arrayData;

    static string questext= "question#a#b#c#answer#explanation\n中国花样滑冰在冬奥会实现金牌“零的突破”是在哪一次冬奥会上？#A.俄罗斯索契第22届冬奥会#B.加拿大温哥华第21届冬奥会#C.日本长野第18届冬奥会#2#2010年在加拿大温哥华第21届冬奥会上,申雪/赵宏博获得双人滑项目的金牌,实现了中国花样滑冰在冬奥会金牌“零的突破” 。\n跳台滑雪最科学的滑翔姿势是哪一种姿势？#A.A字形#B.平行形#C.V字形#3#1985年,瑞典运动员扬·伯克洛夫在滑翔过程中率先将两个滑雪板的板尖向外分开形成“V”形。最初,人们对这种姿势很不理解,有的甚至嘲笑,裁判员的评分对他也很不利。然而,当1989年扬·伯克洛夫获得世界杯冠军之后,空气动力学风洞试验结果证明, “V”形提供的提升力要比传统的两雪板平行姿势大28%, 1992年,所有奖牌获得者采用的都是“V”形姿势。\n冬奥会竞赛跳台滑雪女子项目设项是哪一项呢？#A.个人标准台#B.个人大跳台#C.团体大跳台#1#冬奥会跳台滑雪项目设项中，男子项目有个人标准台、个人大跳台、团体大跳台，女子项目有个人标准台。\n冰壶竞赛为保证冰面质量的稳定,赛道冰面的温度必须保持在多少度呢？#A.-6℃-0℃#B. -4℃-6℃#C.-5℃-5℃#2#冰面的清洁和温度对冰壶的运行速度和准确性产生直接的影响,不同的冰情况,对运动员技战术的选取和实施影响巨大。为保证冰面质量的稳定,赛道冰面必须保持-4℃-6℃,馆内空气湿度必须为35%，场地必须有排风和除湿设备。\n制造冰壶的原石产自于哪个国家呢？#A.冰岛#B.加拿大#C.苏格兰#3#冰壶为圆壶状,由不含云母的苏格兰天然花岗岩制成,世界上所有的制造优质冰壶用的天然花岗岩均产自苏格兰近海的一个小岛。加拿大人目前掌握着制作世界顶尖水平冰壶的技术。\n2022年北京-张家口冬奥会上，北京赛区将举办哪些冰上项目呢？#A.速度滑冰、花样滑冰、短道速滑、冰壶#B.短道速滑、速度滑冰、冬季两项、冰壶#C. 单板滑雪、花样滑冰、冰球、冰壶#1#2022年北京-张家口冬奥会北京赛区将举办短道速滑、速度滑冰、花样滑冰、冰球、冰壶等所有冰上项目，以及自由式滑雪大跳台1个雪上项目。而冬季两项和单板滑雪都是雪上项目。\n哪一种运动不是中国古代冬季运动呢？#A.抢等#B.骑木而行#C.冰嬉#3#《隋书·北狄传》有记载：“南室韦北行十一日至北室韦，分为九部落，绕吐纥山而居……地多积雪，惧陷坑阱，骑木而行，俗皆捕貂为业，冠以狐狢，衣以鱼皮。”冰嬉并不止是一种冬季运动，而是一个冬季活动，几种冰雪运动如“掷球”“抢等”“抢球”“较射”“打滑挞”等统称“冰嬉。抢等 即速度滑冰。\n拖冰床这项古代冬季运动在民间流行，是由于哪种职业呢？#A.纤夫#B.渔夫#C.猎人#1#由于隆冬时河流封冻，漕运停驶，纤夫为了生计，自制简易冰床做起拖冰床生意。他们的冰床大约像单人床大小，四周围有布帷或有伞盖，床内可坐二三人。乘冰床者多是富贵子弟或文人墨客，多为欣赏京城冬日的冰雪风光。文昭在《京师竹枝词》中称：“城下长河冻已坚，冰床仍着缆绳牵；浑如倒拽飞鸢去，稳便江南鸭嘴船。”\n北京冬奥会和冬残奥会的吉祥物不包括哪一个？#A.雪融融#B.铁憨憨（火辣辣）或许还能换点别的🐎#C.冰墩墩#3#北京冬奥会吉祥物是冰墩墩，以熊猫为原型进行设计创作；冬残奥会吉祥物为雪融融，”以灯笼为原型进行设计创作。\n哪一种雪在滑雪的时候更好立刃呢?#A.面条雪#B.天然雪#C.人造雪#1#雪造出来了之后，压雪车就要开始工作了。压雪车把所有造好的雪包都摊平，后面的雪犁把摊平的雪块碾碎，碾碎后的雪通过车后的制雪器拉平，拉过后雪道就像梳子梳过一样，也就是我们说的面条雪。为什么要压成这样的形状呢？第一是为了把冰面打掉，第二就是人滑起来很舒服。平坦的雪是没有办法滑的，只有“面条雪”，才好立刃。\n2014 年冬奥会中国在奖牌榜的名次是多少名呢? #A. 第 10#B. 第 12#C. 第 15#2#详解：无\n第一届冬奥会的举办地点是? #A. 伦敦#B. 巴黎#C. 夏蒙尼#3#第一届冬季奥林匹克运动会于1924年1月25日在法国的夏慕尼举行。\n2022年冬奥会之前，上一次冬奥会是哪一届冬奥会呢？#A.韩国平昌冬奥会#B.俄罗斯索契冬奥会#C.加拿大温哥华冬奥会#1#第23届冬季奥林匹克运动会，简称“平昌冬奥会”，2018年2月9日~25日在韩国平昌郡举行";

    private csvController()   //单例，构造方法为私有
    {
        arrayData = new List<string[]>();
    }

    private void Awake()
    {
        csv = GetInstance();
    }
    public static csvController GetInstance()   //单例方法获取对象
    {
        if (csv == null)
        {
            csv = new csvController();
        }
        return csv;
    }
    
    /*string questionLoad(string filePath)
    {

        WWW www = new WWW(filePath);

        string url = filePath;
        #if UNITY_EDITOR
        return File.ReadAllText(url);
        #elif UNITY_ANDROID
        Debug.Log(url);
        while (!www.isDone) { 
        Debug.Log(www.text.Length);}
        return www.text;
        //#endif
    }

    public static void CopyFileFromStreamingAsset(string file_name)
    {
        string from_path;
        if (Application.platform == RuntimePlatform.Android)
            from_path = "jar:file://" + Application.dataPath + "!/assets/" + file_name;
        else
            from_path = Application.streamingAssetsPath + file_name;

        string to_path = Application.persistentDataPath + "/documents/" + file_name;
        WWW www = new WWW(from_path);
        while (!www.isDone) { }
        if (www.error == null)
            //这里也可以加个判断文件是否已经存在再进行写入
            File.WriteAllBytes(to_path, www.bytes);
    }*/


    public void loadFile(string path, string fileName)
    {
        #if UNITY_EDITOR

        StreamReader sr = null;
        //Debug.Log(questionLoad("file://"+Application.streamingAssetsPath + @"/question.txt").Length);
        try
        {
            string file_url = path + "//" + fileName;    //根据路径打开文件
            sr = File.OpenText(file_url);Resources.Load(file_url);
            Debug.Log("File Find in " + file_url);
        }
        catch
        {
            Debug.Log("File cannot find ! ");
            return;
        }

        string line;
        while ((line = sr.ReadLine()) != null)   //按行读取
        {
            arrayData.Add(line.Split('#'));   //每行#号分隔,split()方法返回 string[]
        }
        sr.Close();
        sr.Dispose();
        /*
        for(int i=0;i<=arrayData.Count;i++)
        {
            for (int j = 0; j < 4; j++)
                Debug.Log(i.ToString()+" "+j.ToString()+" "+arrayData[i][j]);
        }*/
        Debug.Log("success");
        #elif UNITY_ANDROID
      
        string[] eachText = questext.Split('\n');
        for (int i = 0; i < eachText.Length; i++)
            arrayData.Add(eachText[i].Split('#'));

       
        #endif
        for (int i = 0; i < arrayData.Count; i++)
            Debug.Log(arrayData[i][0]+arrayData[i][1]+ arrayData[i][2]+ arrayData[i][3]+ arrayData[i][4]);
        /* string from_path = Application.streamingAssetsPath + fileName;
        string to_path = Application.persistentDataPath + "/" + fileName;
        WWW www = new WWW(from_path);
        while (!www.isDone) { }
        File.WriteAllBytes(to_path, www.bytes);*/ 
        // string allText=questionLoad(Application.streamingAssetsPath + "/question.txt") ;
}

public int getListSize()
    {
        return arrayData.Count;
    }

    public string getString(int row, int col)
    {
        //Debug.Log(row.ToString() + "string " + col.ToString());
        return arrayData[row][col];
    }
    public int getInt(int row, int col)
    {
        //Debug.Log(row.ToString()+" int "+ col.ToString());
        return int.Parse(arrayData[row][col]);
    }

    public float getFloat(int row, int col)
    {
        //Debug.Log(row.ToString() + " float " + col.ToString());
        return float.Parse(arrayData[row][col]);
    }
}
