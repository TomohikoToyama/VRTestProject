using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {

    private float limitTime = 2.0f;
    private float shotSpeed = 30.0f;
    private int power = 1; //ショットの攻撃力
    public int Power { get { return power; } set { power = value; } }
    private bool remain;
    public bool Remain { get { return remain; } set { remain = value; } }

    // Use this for initialization
    void Start () {
        Remain = true;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
        if (Remain)
            StartCoroutine(ShootBulletAndDestroyCoroutine());
    }

    //ショットの非同期処理
    private IEnumerator ShootBulletAndDestroyCoroutine()
    {
        //2秒経ったら破棄
        yield return new WaitForSeconds(limitTime);
        //ショット管理クラスに弾の残存を判定させるための処理を追加予定
        Remain = false;    
        Destroy(gameObject);


    }

    //敵ショットのあたり判定
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            //Remain = false; 
            Destroy(gameObject);
        }

    }
}
