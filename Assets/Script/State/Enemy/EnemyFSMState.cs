using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public abstract class EnemyFSMState : MonoBehaviour
    {
        protected Dictionary<Transition, FSMStateID> map = new Dictionary<Transition, FSMStateID>();
        protected FSMStateID stateID;
        public FSMStateID ID {  get { return stateID; } }
        protected Vector3 destPos;
        protected Transform[] waypoints;
        protected float curRotSpeed;
        protected float curSpeed;
        
        public void AddTransition(Transition tran,FSMStateID id)
        {
            //引数の確認
            if(tran == Transition.None || id == FSMStateID.None)
            {
                Debug.LogWarning("FSMState Nullはアカンよ");
                return;
            }

            //現在の状態がmap(Dictionary)に存在するか確認
            if (map.ContainsKey(tran))
            {
                Debug.LogWarning("FSMStateエラー mapにtranがすでにあるよ");
                return;
            }

            map.Add(tran, id);

        }

        //不要な遷移をDirectionaryから削除
        public void DeleteTransition(Transition tran)
        {
            //null遷移か確認
            if(tran == Transition.None)
            {
                Debug.LogError("FSMStateエラー：nullからはあかん");
                return;

            }

            //ペアがmapにあるか判定
            if (map.ContainsKey(tran))
            {
                map.Remove(tran);
                return;
            }

            Debug.LogError("FSMStateエラー：指定された遷移はないよ");
        }

        //状態遷移時、何の状態になるかの判定
        public FSMStateID GetOutputState(Transition tran)
        {
            //遷移がNullか確認
            if(tran == Transition.None)
            {
                return FSMStateID.None;
            }

            //mapが遷移を持つか確認
            if (map.ContainsKey(tran))
            {
                return map[tran];
            }

            Debug.LogError(" FSMStateエラー："+ tran +"ないよ");
            return FSMStateID.None;
        }
        //状態遷移するかの意思決定
        public abstract void Reason(Transform player, Transform enm);

        //敵キャラの処理、行動、動作
        public abstract void Act(Transform player, Transform enm);



        /// 次の策敵ポイントを指定します。乱数で動作します。
        public void FindNextPoint()
        {
            //Debug.Log("Finding next point");
            int rndIndex = Random.Range(0, waypoints.Length);
            Vector3 rndPosition = Vector3.zero;
            destPos = waypoints[rndIndex].position + rndPosition;
        }

        /// 次のポジションが、現在の位置と同じかチェックします。
        protected bool IsInCurrentRange(Transform trans, Vector3 pos)
        {
            float xPos = Mathf.Abs(pos.x - trans.position.x);
            float zPos = Mathf.Abs(pos.z - trans.position.z);

            if (xPos <= 50 && zPos <= 50)
                return true;

            return false;
        }
    }
}