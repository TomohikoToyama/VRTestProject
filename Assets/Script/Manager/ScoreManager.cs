using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        Material[] scoreImg = new Material[10];
        [SerializeField]
        GameObject[] numObj = new GameObject[8];
        private int scorePoint = 0;
        public int ScorePoint { get { return scorePoint; } set { scorePoint = value; } }
        private string changeDigit = "D8";    //スコア8桁表示
        private int digit = 8;    //8桁表示
        protected static ScoreManager instance;

        public static ScoreManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (ScoreManager)FindObjectOfType(typeof(ScoreManager));

                    if (instance == null)
                    {
                        Debug.LogError("SoundManager Instance Error");
                    }
                }

                return instance;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

       public void ScoreChange(int point)
        {
            /*
             * スコア加点の際に処理が走る
             * 8桁で0詰めで一度文字列化する
             * 8桁目から順に先頭の文字列を1字ずつ抽出して、数字化しその数字に合わせて格納された画像に変更する
             * 　　
             */
            ScorePoint += point;
            var score = ScorePoint.ToString(changeDigit);
            for (int i = 0; i < digit; i++)
            {
                numObj[i].GetComponent<MeshRenderer>().material = scoreImg[int.Parse(score.Substring(i,1))];
            }

        }

        
    }
}