using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour {

   

    

    bool shotLimit;
    GameObject muzzle;
    GameObject target;
    private float speed = 30.0f;
    public float Speed { get { return speed; } set { speed = value; } }
    [SerializeField]
    private int power = 10; //ショットの攻撃力
    public int Power { get { return power; } set { power = value; } }
    private float limitTime = 2.0f;
    bool Remain = true;

    //テスト用
    [SerializeField]
    GameObject playerRight;

    // Use this for initialization
    void Start()
    {
        muzzle = GameObject.FindGameObjectWithTag("PlayerMuzzle");

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
        //ターゲット対象生存時、対象に向きながら追尾着弾
        if (target != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), Speed * Time.deltaTime);
            var look = Quaternion.LookRotation(transform.position - this.transform.position);
            this.transform.localRotation = look;
        }

        //ターゲット対象が着弾前に死亡などなくなった場合は2秒で破棄
        if (target == null)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Speed;
            StartCoroutine(ShootBulletAndDestroyCoroutine());
        }

    }

    //ターゲット対象をセット
    public void SetEnemy(GameObject enm)
    {
        target = enm;
    }

    //ターゲット対象名をゲット、着弾対象照合用
    public string GetEnemy()
    {
        return target.name;
    }
    //ターゲット対象に着弾した時、破棄する
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == target.name)
            Destroy(gameObject);
    }

    

}
