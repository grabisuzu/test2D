using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : ObjectMono
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float jumpPower = 1.0f;
    [SerializeField] GameObject[] floorObjs;
    [SerializeField] GameObject footCol;
    
    [SerializeField]float gravity = 0.05f;
    float gravityLimit = -0.1f;
    bool isFloorCross = false;
    bool isFootCol = false;

    Vector3 preFootPos = new Vector3(0.0f, 0.0f, 0.0f);
    int colCount = 10; // フレーム間の当たり判定を補完する回数

    Vector3 nowSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // 床の当たり判定取得用,1フレーム間の補完分も計算してすり抜け防止
        for(int i = 0; i < colCount; i++)
        {
            foreach (var obj in floorObjs)
            {
                
                Vector2 lerpPos = footCol.transform.position;
                lerpPos.y = Mathf.Lerp(preFootPos.y, footCol.transform.position.y, ((float)i + 1.0f) / (float)colCount); //前フレームからの補完値を保存
                isFootCol = base.ColStay_other(lerpPos, footCol.transform.localScale, obj.transform.position, obj.transform.localScale);
                if (isFootCol) break;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed);
        //}
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }

        Gravity(isFootCol);
    }

    void Jump()
    {
        //地面についているとき
        if (isFootCol)
        {
            //加速度を加算する
            nowSpeed.y = jumpPower;
            Debug.Log("JUMP!");
        }
        
    }
    void Gravity(bool isGround)
    {
        if (isGround && nowSpeed.y <= 0.0f) return; //地面についた&落下中なら計算をやめる,上加速時は着地判定をしないためすり抜け床方式となる
        nowSpeed.y -= gravity; //毎フレーム重力加速度を加算
        //落下速度を制限する
        if (nowSpeed.y < gravityLimit)
        {
            nowSpeed.y = gravityLimit;
        }
        Debug.Log(nowSpeed);
        transform.position = transform.position + nowSpeed;

    }
}
