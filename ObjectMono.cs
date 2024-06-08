using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ObjectMono : MonoBehaviour
{
    private GameObject omakeObj = null;
    public struct rect
    {
        public float top;
        public float bottom;
        public float left;
        public float right;
    }
    public struct circle
    {
        public float x;
        public float y;
        public float radius;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetPosition()
    {
        return this.transform.position;
    }
    public Vector2 GetScale()
    {
        return this.transform.localScale;
    }

    //引数増やしてCollisionSetterに移してもいいかも
    /// <summary>
    /// 矩形同士の当たり判定を取得
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public bool ColStay(Vector2 pos, Vector2 scale)
    {
        rect myRect = SetRect(transform.position, transform.localScale);
        rect otherRect = SetRect(pos, scale);
        if ((myRect.right > otherRect.left) &&
        (myRect.left < otherRect.right))
        {
            if ((myRect.bottom > otherRect.top) &&
                (myRect.top < otherRect.bottom))
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 矩形と正円の当たり判定を取得,引数側が正円
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public bool ColStayCircle(Vector2 pos, Vector2 scale)
    {
        rect myRect = SetRect(transform.position, transform.localScale);
        circle otherCircle = SetCircle(pos, scale);
        // 矩形の各辺に円の中心からの半径を足して接触していないならfalse
        if (myRect.left - otherCircle.radius > otherCircle.x || myRect.right + otherCircle.radius < otherCircle.x ||
            myRect.top - otherCircle.radius > otherCircle.y || myRect.bottom + otherCircle.radius < otherCircle.y)
        {
            return false;
        }
        //円の方程式分角の面積を減らす
        if (myRect.left > otherCircle.x && myRect.top > otherCircle.y && 
            !(Mathf.Pow(myRect.left - otherCircle.x, 2) + Mathf.Pow(myRect.top - otherCircle.y, 2) < Mathf.Pow(otherCircle.radius, 2)))
        {
            return false;
        }
        if (myRect.right < otherCircle.x && myRect.top > otherCircle.y &&
            !(Mathf.Pow(myRect.right - otherCircle.x, 2) + Mathf.Pow(myRect.top - otherCircle.y, 2) < Mathf.Pow(otherCircle.radius, 2)))
        {
            return false;
        }
        if (myRect.left > otherCircle.x && myRect.bottom < otherCircle.y &&
            !(Mathf.Pow(myRect.left - otherCircle.x, 2) + Mathf.Pow(myRect.bottom - otherCircle.y, 2) < Mathf.Pow(otherCircle.radius, 2)))
        {
            return false;
        }
        if (myRect.right < otherCircle.x && myRect.bottom < otherCircle.y &&
            !(Mathf.Pow(myRect.right - otherCircle.x, 2) + Mathf.Pow(myRect.bottom - otherCircle.y, 2) < Mathf.Pow(otherCircle.radius, 2)))
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// 相手の回転分自身のcollisionの位置を変更する(弾側に使用予定)
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public Vector2 SetColPos(Vector2 pos, float angle)
    {
        //元の座標を保存
        Vector2 myColPos = transform.position;
        //矩形の回転分角度を戻すためマイナス
        float targetRadian = -AngleToRadian(angle);
        float x = transform.position.x - pos.x;
        float y = transform.position.y - pos.y;
        myColPos.x = x * Mathf.Cos(targetRadian) - y * Mathf.Sin(targetRadian) + pos.x;
        myColPos.y = y * Mathf.Cos(targetRadian) + x * Mathf.Sin(targetRadian) + pos.y;

        //TODO:原点が0のとき用
        //Vector2 colNewPos = new Vector2();
        //colNewPos.x = (myColPos.x * Mathf.Cos(targetRadian)) - (myColPos.y * Mathf.Sin(targetRadian));
        //colNewPos.y = (myColPos.x * Mathf.Sin(targetRadian)) + (myColPos.y * Mathf.Cos(targetRadian));
        
        //当たり判定がどこにあるかを表示
        if (omakeObj)
        {
            SetOmakePos(myColPos);
        }
        return myColPos;
    }
    public float GetAngle()
    {
        return transform.eulerAngles.z;
    }
    /// <summary>
    /// 渡された矩形オブジェクトの角の座標を返す
    /// </summary>
    /// <param name="pos">座標</param>
    /// <param name="scale">サイズ</param>
    /// <returns></returns>
    rect SetRect(Vector2 pos, Vector2 scale)
    {
        rect _rect = new rect();
        _rect.top = pos.y - scale.y * 0.5f;
        _rect.bottom = pos.y + scale.y * 0.5f;
        _rect.left = pos.x - scale.x * 0.5f;
        _rect.right = pos.x + scale.x * 0.5f;

        return _rect;
    }
    circle SetCircle(Vector2 pos, Vector2 scale)
    {
        circle _circle = new circle();
        _circle.x = pos.x;
        _circle.y = pos.y;
        _circle.radius = scale.x * 0.5f; // 正円限定
        return _circle;
    }
    /// <summary>
    /// 角度をラジアンに変換する
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    float AngleToRadian(float angle) { return angle * Mathf.PI / 180f; }
    public void SetOmake(GameObject obj) { omakeObj = obj; }
    public void SetOmakePos(Vector2 pos)
    {
        omakeObj.transform.position = pos;
    }

}
