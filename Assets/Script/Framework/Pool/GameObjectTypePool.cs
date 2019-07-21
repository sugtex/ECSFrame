using System.Collections.Generic;
using UnityEngine;
using System;

namespace ECSFrameWork{
public class GameObjectTypePool 
{
    public string Name{get;private set;}
    private Queue<GameObject> Prefabs=new Queue<GameObject>();
    public GameObjectTypePool(string name){
        Name=name;
    }
 
    public GameObject Fetch(ref string path){
        GameObject obj=null;
        if(Prefabs.Count==0){
            obj=GameObject.Instantiate(Resources.Load<GameObject>(path));
        }else{
            obj=Prefabs.Dequeue();
        }
        obj.SetActive(true);
        return obj;
    }
    public bool Recycle(ref GameObject obj){
       if(obj.name==Name){
        obj.SetActive(false);
        Prefabs.Enqueue(obj);
        return true;
       }
      return false;
    }
    public void Clear(){
        Prefabs=new Queue<GameObject>();
    }
}

}
