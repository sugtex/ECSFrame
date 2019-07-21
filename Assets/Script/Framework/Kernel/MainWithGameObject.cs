using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECSFrameWork{
   //unity中的GameObject+Main
public class MainWithGameObject : Main
{
    protected Transform Prefab;
    protected virtual void OnInit(Transform prefab){
     Prefab=prefab;
    }
    public override void F_Dispose(){
        Game.Instance.GameObjectPoolManager.Recycle(Prefab.gameObject);
        Prefab=null;
        base.F_Dispose();
    }
}
}
