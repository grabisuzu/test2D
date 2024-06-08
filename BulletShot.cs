using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    [SerializeField] GameObject bulletObj;
    [SerializeField] GameObject omakeObj;
    [SerializeField] Vector2 bulletSpeed = new Vector2(0.0f, 0.0f);
    CollisionSetter _CollisionSetter;
    // Start is called before the first frame update
    void Start()
    {
        _CollisionSetter = this.gameObject.GetComponent<CollisionSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.Euler(transform.localEulerAngles));
            bullet.GetComponent<Bullet>().SetSpeed(bulletSpeed);
            GameObject omake = Instantiate(omakeObj, transform.position, Quaternion.Euler(transform.localEulerAngles));
            bullet.GetComponent<Bullet>().SetOmake(omake);
            _CollisionSetter.SetBullets(bullet.GetComponent<Bullet>());
        }
    }
}
