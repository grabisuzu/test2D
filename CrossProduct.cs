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
        //��ӂƍ�������radian���擾
        float radian = Mathf.Atan2(myPos.y - targetPos.y, myPos.x - targetPos.x);
        //Angle�֕ϊ�
        double degree = -(radian * 180d / Mathf.PI);
        if (degree > 0) Debug.Log("�\");
        else if (degree <= 0) Debug.Log("��");
    }
}
