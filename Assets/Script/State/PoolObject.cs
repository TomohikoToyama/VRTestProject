using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VR
{
    public abstract class PoolObject : MonoBehaviour
    {

        // Start()が呼べないのでInitを実装。
        public abstract void Init();
        
    }
}