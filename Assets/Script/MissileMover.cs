using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour {

   

    float shotSpeed = 30.0f;

    bool shotLimit;
    GameObject muzzle;
    GameObject target;
    public float Speed;
    [SerializeField]
    private int power = 10; //ショットの攻撃力
    public int Power { get { return power; } set { power = value; } }
    private float limitTime = 3.0f;
    bool Remain = true;

    //テスト用
    [SerializeField]
    GameObject playerRight;

    // Use this for initialization
    void Start()
    {
        muzzle = GameObject.FindGameObjectWithTag("PlayerMuzzle");
       // target = GameObject.FindGameObjectWithTag("target");

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
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), shotSpeed * Time.deltaTime);
            var look = Quaternion.LookRotation(transform.position - this.transform.position);
            this.transform.localRotation = look;
        }
        //ターゲット対象が着弾前に死亡などなくなった場合は2秒で破棄
        if (target == null)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;

            StartCoroutine(ShootBulletAndDestroyCoroutine());
        }

    }

    public void SetEnemy(GameObject enm)
    {
        target = enm;
    }

    public string GetEnemy()
    {
        return target.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == target.name)
            Destroy(gameObject);
    }

    

}
