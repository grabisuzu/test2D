using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    [SerializeField] GameObject targetObj;
    Vector2 myPos;
    Vector2 targetPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myPos = transform.position;
        targetPos = targetObj.transform.position;
        //底辺と高さからradianを取得
        float radian = Mathf.Atan2(myPos.y - targetPos.y, myPos.x - targetPos.x);
        //Angleへ変換
        double degree = -(radian * 180d / Mathf.PI);
        if (degree > 0) Debug.Log("表");
        else if (degree <= 0) Debug.Log("裏");
    }
}
