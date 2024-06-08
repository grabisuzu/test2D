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

    //�������₵��CollisionSetter�Ɉڂ��Ă���������
    /// <summary>
    /// ��`���m�̓����蔻����擾
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
    /// ��`�Ɛ��~�̓����蔻����擾,�����������~
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public bool ColStayCircle(Vector2 pos, Vector2 scale)
    {
        rect myRect = SetRect(transform.position, transform.localScale);
        circle otherCircle = SetCircle(pos, scale);
        // ��`�̊e�ӂɉ~�̒��S����̔��a�𑫂��ĐڐG���Ă��Ȃ��Ȃ�false
        if (myRect.left - otherCircle.radius > otherCircle.x || myRect.right + otherCircle.radius < otherCircle.x ||
            myRect.top - otherCircle.radius > otherCircle.y || myRect.bottom + otherCircle.radius < otherCircle.y)
        {
            return false;
        }
        //�~�̕��������p�̖ʐς����炷
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
    /// ����̉�]�����g��collision�̈ʒu��ύX����(�e���Ɏg�p�\��)
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public Vector2 SetColPos(Vector2 pos, float angle)
    {
        //���̍��W��ۑ�
        Vector2 myColPos = transform.position;
        //��`�̉�]���p�x��߂����߃}�C�i�X
        float targetRadian = -AngleToRadian(angle);
        float x = transform.position.x - pos.x;
        float y = transform.position.y - pos.y;
        myColPos.x = x * Mathf.Cos(targetRadian) - y * Mathf.Sin(targetRadian) + pos.x;
        myColPos.y = y * Mathf.Cos(targetRadian) + x * Mathf.Sin(targetRadian) + pos.y;

        //TODO:���_��0�̂Ƃ��p
        //Vector2 colNewPos = new Vector2();
        //colNewPos.x = (myColPos.x * Mathf.Cos(targetRadian)) - (myColPos.y * Mathf.Sin(targetRadian));
        //colNewPos.y = (myColPos.x * Mathf.Sin(targetRadian)) + (myColPos.y * Mathf.Cos(targetRadian));
        
        //�����蔻�肪�ǂ��ɂ��邩��\��
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
    /// �n���ꂽ��`�I�u�W�F�N�g�̊p�̍��W��Ԃ�
    /// </summary>
    /// <param name="pos">���W</param>
    /// <param name="scale">�T�C�Y</param>
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
        _circle.radius = scale.x * 0.5f; // ���~����
        return _circle;
    }
    /// <summary>
    /// �p�x�����W�A���ɕϊ�����
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
