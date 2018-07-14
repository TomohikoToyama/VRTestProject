using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR{
public class StageManager : MonoBehaviour, IStageManagerController{


    //
    [SerializeField]
    public IStage activeStage;
    public StageManagerController smcon;
    public static StageManager instance;
    public static StageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (StageManager)FindObjectOfType(typeof(StageManager));

                    if (instance == null)
                    {
                        Debug.LogError("StageManager Instance Error");
                    }
                }

                return instance;
            }
        }
    // Use this for initialization
    void Start() {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("GameStateManager");
            if (obj.Length > 1)
            {
                //既に存在してるなら削除
                Destroy(gameObject);
            }
            else
            {
                //管理マネージャーはシーン遷移では破棄させない
                DontDestroyOnLoad(gameObject);
            }
            StageManagerInit();
        }

    void Update()
        {

        }
        //ステイト切り替え
        public string SwitchState(IStage newStage)
        {
            activeStage = newStage;
            Debug.Log("現在のシーン" + activeStage);
            return activeStage.ToString();
        }

        //ゲームステイト初期化
        public void StageManagerInit()
        {
            activeStage = new FirstStage(this);

        }
    }
}