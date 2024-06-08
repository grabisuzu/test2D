using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCheck : ObjectMono
{
    [SerializeField] GameObject omakeHitObj;
    GameObject omakeObj = null;
    // Start is called before the first frame update
    void Start()
    {
        CollisionSetter _collisionSetter = GameObject.Find("GameManager").gameObject.GetComponent<CollisionSetter>();
        _collisionSetter.SetHitBox(this);
        omakeObj = Instantiate(omakeHitObj, transform.position, Quaternion.Euler(transform.localEulerAngles));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(((transform.localEulerAngles.z) * Mathf.PI / 180f)* Mathf.Rad2Deg);
        omakeObj.transform.position = transform.position;
    }
}
