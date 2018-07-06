using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public abstract class EnemyFSMState : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //状態遷移時、何の状態になるかの判定
        public FSMStateID GetOutputState(Transition tran)
        {
            //遷移がNullか確認

      

            return FSMStateID.None;
        }
        //状態遷移するかの意思決定
        public abstract void Reason(Transform player, Transform enm);

        //敵キャラの処理、行動、動作
        public abstract void Act(Transform player, Transform enm);

    }
}