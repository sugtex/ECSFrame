using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECSFrameWork{
   //unity中的UI+Main
public class MainWithUI : MainWithGameObject
{
   protected override void OnInit(Transform prefab){
       base.OnInit(prefab);
       Transform canvas=GameObject.Find("Canvas").transform;
       Prefab.SetParent(canvas);
       Prefab.localPosition=Vector2.zero;
   }
}
}

