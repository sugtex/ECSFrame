using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECSFrameWork{
   //实体工厂
public class EntityFactroy 
{
   public T  CreatWithGameObject<T>(string path)
   where T:IObject
   { 
       Transform prefab=Game.Instance.GameObjectPoolManager.Fetch(ref path).transform;
       T t=Game.Instance.ObjectFactory.Create<T,Transform>(prefab);
       return t;
   }
   public T  CreatWithGameObject<T,A>(string path,A a)
   where T:IObject
   { 
       Transform prefab=Game.Instance.GameObjectPoolManager.Fetch(ref path).transform;
       T t=Game.Instance.ObjectFactory.Create<T,Transform,A>(prefab,a);
       return t;
   }
   public T  CreatWithGameObject<T,A,B>(string path,A a,B b)
   where T:IObject
   { 
       Transform prefab=Game.Instance.GameObjectPoolManager.Fetch(ref path).transform;
       T t=Game.Instance.ObjectFactory.Create<T,Transform,A,B>(prefab,a,b);
       return t;
   }
   public T  CreatWithGameObject<T,A,B,C>(string path,A a,B b,C c)
   where T:IObject
   { 
       Transform prefab=Game.Instance.GameObjectPoolManager.Fetch(ref path).transform;
       T t=Game.Instance.ObjectFactory.Create<T,Transform,A,B,C>(prefab,a,b,c);
       return t;
   }
}
}

