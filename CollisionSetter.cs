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
                //箱の回転から弾の位置を出し、判定をとる
                if (HitBox[i].ColStayCircle(Bullets[j].SetColPos(HitBox[i].GetPosition(), HitBox[i].transform.eulerAngles.z), Bullets[j].GetScale())) 
                {
                    Debug.Log("Hit!");
                    ObjectMono bul = Bullets[j];
                    //ヒットしたらリストから除外し、オブジェクトを破棄する
                    Bullets.Remove(Bullets[j]);
                    Destroy(bul.gameObject);
                }
            }
                
        }
    }
    //各オブジェクトを保存
    public void SetBullets(ObjectMono obj)
    {
        Bullets.Add(obj);
    }
    public void SetHitBox(ObjectMono obj)
    {
        HitBox.Add(obj);
    }
}
