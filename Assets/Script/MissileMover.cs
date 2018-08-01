using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour {

   

    float shotSpeed = 20.0f;

    bool shotLimit;
    GameObject muzzle;
    GameObject target;
    public float Speed;
    [SerializeField]
    private int power = 10; //ショットの攻撃力
    public int Power { get { return power; } set { power = value; } }


    //テスト用
    [SerializeField]
    GameObject playerRight;

    // Use this for initialization
    void Start()
    {
        muzzle = GameObject.FindGameObjectWithTag("PlayerMuzzle");
       // target = GameObject.FindGameObjectWithTag("target");

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), shotSpeed * Time.deltaTime);
        
        if(target == null)
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;


    }
    private void OnTriggerEnter(Collider other)
    {
       // if (other.gameObject.tag == "Enemy")
         //   Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RangeArea")
            Destroy(gameObject);
    }

}
