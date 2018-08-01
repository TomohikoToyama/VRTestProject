using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class EnemyData : MonoBehaviour
    {

        private List<string[]> _enmData;             //敵情報
        public List<string[]> enmData
        {
            get { return this._enmData; }
            set { this._enmData = value; }
        }

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