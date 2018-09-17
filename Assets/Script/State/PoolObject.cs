using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR
{
    public abstract class PoolObject : MonoBehaviour
    {

        // プールへ参照を持つ
        public PlayerObjectManager Pool { private get; set; }
        // Start()が呼べないのでInitを実装。
        public abstract void Init();

        
        protected new void Destroy(Object obj)
        {
            ReturnToPool();
        }

        /// プールに戻します。
        protected void ReturnToPool()
        {
            Pool.Return(this);
        }
    }
}