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
    int colCount = 10; // �t���[���Ԃ̓����蔻���⊮�����

    Vector3 nowSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // ���̓����蔻��擾�p,1�t���[���Ԃ̕⊮�����v�Z���Ă��蔲���h�~
        for(int i = 0; i < colCount; i++)
        {
            foreach (var obj in floorObjs)
            {
                
                Vector2 lerpPos = footCol.transform.position;
                lerpPos.y = Mathf.Lerp(preFootPos.y, footCol.transform.position.y, ((float)i + 1.0f) / (float)colCount); //�O�t���[������̕⊮�l��ۑ�
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
        //�n�ʂɂ��Ă���Ƃ�
        if (isFootCol)
        {
            //�����x�����Z����
            nowSpeed.y = jumpPower;
            Debug.Log("JUMP!");
        }
        
    }
    void Gravity(bool isGround)
    {
        if (isGround && nowSpeed.y <= 0.0f) return; //�n�ʂɂ���&�������Ȃ�v�Z����߂�,��������͒��n��������Ȃ����߂��蔲���������ƂȂ�
        nowSpeed.y -= gravity; //���t���[���d�͉����x�����Z
        //�������x�𐧌�����
        if (nowSpeed.y < gravityLimit)
        {
            nowSpeed.y = gravityLimit;
        }
        Debug.Log(nowSpeed);
        transform.position = transform.position + nowSpeed;

    }
}
