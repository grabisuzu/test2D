using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    struct GroundData
    {
        char type;
        float posX;
        float posY;
        float scaleX;
    }
    List<GroundData> groundDatas = new List<GroundData>(); //構造体格納用リスト
    int nowLine = 0; //現在読み込んでいるでいる行,読み込むときは一行目を無視する
    TextAsset csvFile = Resources.Load("../csv/GroundData.csv") as TextAsset;


    // Start is called before the first frame update
    void Start()
    {
        //生成方法
        // forで構造体のリストから順番に取り出す
        // Instantiate(GameObj(対象の方), pos, angle)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
