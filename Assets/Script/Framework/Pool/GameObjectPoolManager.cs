using System.Collections.Generic;
using UnityEngine;
using System;

namespace ECSFrameWork{
    //实体对象池
public class GameObjectPoolManager 
{
    private Dictionary<string,GameObjectTypePool> _pools=new Dictionary<string, GameObjectTypePool>();

    public GameObject Fetch(ref string path){
        GameObject obj=null;
        GameObjectTypePool pool;
        if(!_pools.TryGetValue(path,out pool)){
          obj=GameObject.Instantiate(Resources.Load<GameObject>(path));
          pool=new GameObjectTypePool(obj.name);
          _pools.Add(path,pool);
        }else{
          obj=pool.Fetch(ref path);
        }
        obj.SetActive(true);
        return obj;
    }

    public void Recycle(GameObject obj){
        foreach(GameObjectTypePool p in _pools.Values){
            if(p.Recycle(ref obj)){
                break;
            }
        }
    }
    public void DeletePool(ref string name){
          foreach(string s in _pools.Keys){
           if(_pools[s].Name==name){
               _pools[s].Clear();
           }
        }
            _pools.Clear();
    }

    public void Clear(){
        foreach(GameObjectTypePool p in _pools.Values){
            p.Clear();
        }
        _pools.Clear();
    }
}

}
