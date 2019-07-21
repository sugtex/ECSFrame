using UnityEngine;

namespace ECSFrameWork
{
    //本框架Mono脚本的需要继承的类
    public abstract  class BaseMono : MonoBehaviour, IDispose
    {
        public virtual  void F_Dispose(){
            enabled=false;
        }
    
    }
}

