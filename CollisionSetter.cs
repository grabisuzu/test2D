using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSetter : MonoBehaviour
{
    List<ObjectMono> Bullets = new List<ObjectMono>();
    List<ObjectMono> HitBox = new List<ObjectMono>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i< HitBox.Count; i++)
        {
            for (int j = 0; j < Bullets.Count; j++)
            {
                //���̉�]����e�̈ʒu���o���A������Ƃ�
                if (HitBox[i].ColStayCircle(Bullets[j].SetColPos(HitBox[i].GetPosition(), HitBox[i].transform.eulerAngles.z), Bullets[j].GetScale())) 
                {
                    Debug.Log("Hit!");
                    ObjectMono bul = Bullets[j];
                    //�q�b�g�����烊�X�g���珜�O���A�I�u�W�F�N�g��j������
                    Bullets.Remove(Bullets[j]);
                    Destroy(bul.gameObject);
                }
            }
                
        }
    }
    //�e�I�u�W�F�N�g��ۑ�
    public void SetBullets(ObjectMono obj)
    {
        Bullets.Add(obj);
    }
    public void SetHitBox(ObjectMono obj)
    {
        HitBox.Add(obj);
    }
}
