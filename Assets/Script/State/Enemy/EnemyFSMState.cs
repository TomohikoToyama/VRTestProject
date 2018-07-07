using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public abstract class EnemyFSMState : MonoBehaviour
    {
        protected Dictionary<Transition, FSMStateID> map = new Dictionary<Transition, FSMStateID>;
        protected FSMStateID stateID;
        public FSMStateID ID {  get { return stateID; } }
        protected Vector3 destPos;
        protected Transform[] qaypoints;
        protected float curRotSpeed;
        protected float curSpedd;
        

        //状態遷移時、何の状態になるかの判定
        public FSMStateID GetOutputState(Transition tran)
        {
            //遷移がNullか確認
            if(tran == Transition.None)
            {
                return FSMStateID.None;
            }
            
            //mapが遷移を持つか確認
            //if()

            return FSMStateID.None;
        }
        //状態遷移するかの意思決定
        public abstract void Reason(Transform player, Transform enm);

        //敵キャラの処理、行動、動作
        public abstract void Act(Transform player, Transform enm);

    }
}