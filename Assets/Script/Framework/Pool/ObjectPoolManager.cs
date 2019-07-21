using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECSFrameWork{
    //类对象池
public class ObjectPoolManager 
{
   private Dictionary<Type,ObjectTypePool> _pools=new Dictionary<Type, ObjectTypePool>();

 
   public IObject Fetch(ref Type type){
       IObject obj=null;
       ObjectTypePool pool;
       if(!_pools.TryGetValue(type,out pool)){
        obj=(IObject)Activator.CreateInstance(type);
        pool=new ObjectTypePool();
        _pools.Add(type,pool);
       }else{
        obj=_pools[type].Fetch(ref type);
       }
      return obj;
   }

   public void Recycle(IObject obj){
    Type type=obj.GetType();
    _pools[type].Recycle(ref obj);
   }
   //手动清理某个池子
   public void DeletePool<T>()
   where T:IObject
   {
      Type type=typeof(T);
      if(_pools.ContainsKey(type)){
          _pools[type].Clear();
          _pools.Remove(type); 
      }
   }

   public void Clear(){
       foreach(ObjectTypePool o in _pools.Values){
           o.Clear();
       }
       _pools.Clear();
   }


}

}
