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
    List<GroundData> groundDatas = new List<GroundData>(); //�\���̊i�[�p���X�g
    int nowLine = 0; //���ݓǂݍ���ł���ł���s,�ǂݍ��ނƂ��͈�s�ڂ𖳎�����
    TextAsset csvFile = Resources.Load("../csv/GroundData.csv") as TextAsset;


    // Start is called before the first frame update
    void Start()
    {
        //�������@
        // for�ō\���̂̃��X�g���珇�ԂɎ��o��
        // Instantiate(GameObj(�Ώۂ̕�), pos, angle)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
