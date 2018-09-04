using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyAttackPattern : MonoBehaviour
    {

        GameObject Target;
        string PlayerUnit = "PlayerUnit";
        GameObject EnemyShot;
        // Use this for initialization
        void Start()
        {
            //敵ショットのオブジェクト読み込み
            //リソース読み込みはステージ開始前に専用読み込みクラスを作成し一元化予定
            EnemyShot = (GameObject)Resources.Load("Prefabs/EnemyShot");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void EnemyShotPattern3(int i)
        {
            Target = GameObject.FindGameObjectWithTag(PlayerUnit);
            Instantiate(EnemyShot, this.transform.position, Target.transform.rotation);

            /*
            for (int j = 0; j < 10; j++)
            {//計１０発撃つ
                if (EnemyShot[i].counter == 20 * j)
                {//20カウントごとに撃つ
                    EnemyShot[i].EnemyShots[j].flag = 1;//発射フラグをたてる
                    EnemyShot[i].EnemyShots[j].x = EnemyShot[i].mem_ex;//初期座標を敵の値に
                    EnemyShot[i].EnemyShots[j].y = EnemyShot[i].mem_ey;
                    //現在のプレイヤーの座標と、弾の初期座標からそれぞれ角度を計算する。

                    //敵機とプレイヤーの座標を取得

                    EnemyShot[i].Angle[j] = atan2(Player.y - EnemyShot[i].mem_ey, Player.x - EnemyShot[i].mem_ex);
                    StopSoundMem(sound_enemy_shot[0]);
                    PlaySoundMem(sound_enemy_shot[0], DX_PLAYTYPE_BACK);
                }
                EnemyShot[i].EnemyShots[j].x += PATTERN1SPEED * cos(EnemyShot[i].Angle[j]);//それぞれの角度を使って
                EnemyShot[i].EnemyShots[j].y += PATTERN1SPEED * sin(EnemyShot[i].Angle[j]);//座標を計算し、増加
            }
            */
        }
    }
}
