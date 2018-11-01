using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class BossController : BossStatus
    {
        enum currentState
        {
            None = 0,
            Act = 1,
            Escape = 2,
            Death = 3
        }

        enum currentPhase
        {
            One = 1,
            Two = 2,
            Three = 3
        }

        
        public GameObject shot;
        public bool bShot;
        GameObject ESobj;
        [SerializeField]
        public GameObject Target;
        [SerializeField]
        ParticleSystem explode;
        [SerializeField]
        ParticleSystem fire;
        public int dif;
        string PlayerUnit = "PlayerUnit";

        GameObject LockField;   //ロックオン画像

        private int roadState = 1;
        private int bossState = 2;
        EnemyObjectManager EnemyOM;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Phase == (int)currentPhase.One)
            {
                if (Health <= Health/2)
                    PhaseChange();
            }else if(Phase == (int)currentPhase.Two)
            {

            }else if(Phase == (int)currentPhase.Three)
            {


            }
        }


        private void PhaseChange()
        {
            
        }
    }
}