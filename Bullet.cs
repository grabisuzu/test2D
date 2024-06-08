using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ObjectMono
{
    Vector2 speed = new Vector2(0.0f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���t���[�����[�v������
        //Debug.Log(transform.name+speed.ToString());
        transform.position = new Vector2(transform.position.x + speed.x, transform.position.y + speed.y);
        GetAngle();
    }

    public void SetSpeed(Vector2 _speed) 
    {
        speed = _speed;
        Debug.Log("���x��ύX���܂��� : "+speed.y.ToString());
    }
    
}
