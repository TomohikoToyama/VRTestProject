using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public enum Transition
    {
        None = 0,
        SawPlayer,  //発見
        ReachPlayer,//戦闘距離
        LostPlayer, //戦闘圏外
        NoHealth,  //体力尽きる

    }

    public enum FSMStateID
    {
        None = 0,
        Faraway,    //離れてる
        Attacking, //攻撃
        Dead,       //死亡
        Pullout,    //撤退

    }
    public class EnemyAIFSM : EnemyFSM
    {
        private List<EnemyFSMState> EFS;

        // 現在のfsmState
        private FSMStateID CSID;
        public FSMStateID CurrentStateID { get { return CSID; } }

        private EnemyFSMState CS;
        public EnemyFSMState CurrentState { get { return CS; } }

        public EnemyAIFSM()
        {
            EFS = new List<EnemyFSMState>();
        
        }

        //状態の追加
        public void AddFSMState(EnemyFSMState fsmState)
        {
            //引数の確認
            if(fsmState == null)
            {
                Debug.LogError("FSMエラー:nullはあかんよ");
            }

            //状態がない場合の条件式
            if(EFS.Count == 0)
            {
                EFS.Add(fsmState);
                CS = fsmState;
                CSID = fsmState.ID;
                return;

            }

            //状態がある場合の条件式
            foreach (EnemyFSMState state in EFS)
            {
                if(state.ID == fsmState.ID)
                {
                    Debug.LogError("FSM エラー:すでに存在する状態をリストに追加しようとしてます");
                    return;
                }

            }
            //状態をリストに追加
            EFS.Add(fsmState);
        }

        //状態の削除
        public void DeleteState(FSMStateID fsmState)
        {

            //状態削除前に空か確認
            if ( fsmState == FSMStateID.None)
            {
                Debug.LogError("FSMエラー:不正なID");
                return;
            }

            //状態を削除
            foreach(EnemyFSMState state in EFS)
            {
                if(state.ID == fsmState)
                {
                    EFS.Remove(state);
                    return;
                }
            }

            //指定の状態がない場合
            Debug.LogError("FSMエラー: 指定された状態が存在しません。");
        }

        //状態の遷移メソッド
        public void PerformTransition(Transition tran)
        {
            //引数の確認
            if(tran == Transition.None)
            {
                Debug.LogError("FSMエラー: Null遷移は不正");
                return;
            }

            //CS(currenState)が指定の遷移についての状態を持つか
            FSMStateID id = CS.GetOutputState(tran);
            if(id == FSMStateID.None)
            {
                Debug.LogError("FSMエラー: 現在の状態は遷移が指定する状態を持たない");
                return;
            }

            //currentStateIDとcurrentStateを更新
            CSID = id;
            foreach(EnemyFSMState state in EFS)
            {

                if(state.ID == CSID)
                {

                    CS = state;
                    break;
                }
            }
        }


    }
}
