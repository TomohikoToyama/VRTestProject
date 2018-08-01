using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR { 
public class EnemyDataLoader : MonoBehaviour {
    EnemyData ED;     //BMSデータ臨時保存用のデータスクリプト
    private string sName { set; get; }       // 敵名
    private string iHealth { set; get; }     // 体力
    private string iPattern { set; get; }    // 攻撃パターン
    private string fPosx { set; get; }       // 座標x
    private string fPosy { set; get; }       // 座標y
    private string fPosz { set; get; }       // 座標z
    private string iWeapon { set; get; }     // 武器
    private string iScore { set; get; }      // スコア
    private string iItem { set; get; }       // 落下アイテム

    // Use this for initialization
    void Start()
    {
            ED = GetComponent<EnemyData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadEnemyData()
    {
   
        ED.enmData = new List<string[]>();

            // StreamReader の新しいインスタンスを生成する
            // csvファイルを開く
                System.IO.StreamReader enmf = (
            new System.IO.StreamReader(@"testEnemy.csv", System.Text.Encoding.Default)
            );

            if (enmf != null)
            {
                while (enmf.Peek() >= 0)
                {
                    string enmTxt = enmf.ReadLine();
                    ED.enmData.Add(enmTxt.Split(','));
                }
            }
        enmf.Close();
        

    }

}

}
