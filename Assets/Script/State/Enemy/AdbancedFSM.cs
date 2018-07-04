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
    public class AdbancedFSM : EnemyFSM
    {
        private List<>
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
