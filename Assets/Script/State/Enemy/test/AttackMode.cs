using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class AttackMode : EnemyFSMState
    {
        //範囲
        private float near = 10.0f;     
        private float faraway = 30.0f;

        public AttackMode(Transform[] wp)
        {
            waypoints = wp;
            stateID = FSMStateID.Attacking;
            curRotSpeed = 1.0f;
            curSpeed = 10.0f;
            FindNextPoint();
        }

        public override void Reason(Transform player, Transform enm)
        {
            //プレイヤーとの距離を確認
            float dist = Vector3.Distance(enm.position, player.position);
            if(near <= dist && dist < faraway)
            {
                //ターゲット地点に開店
                Quaternion targetRotation = Quaternion.LookRotation(destPos - enm.position);
                enm.rotation = Quaternion.Slerp(enm.rotation, targetRotation, Time.deltaTime * curRotSpeed);

                //前進
                enm.Translate(Vector3.forward * Time.deltaTime * curSpeed);


            }
            //距離が離れた場合
            else if(dist >= faraway ){

                Debug.Log("State変化");
                enm.GetComponent<TestEnemyContrroler>          
            }
        }
    }
}