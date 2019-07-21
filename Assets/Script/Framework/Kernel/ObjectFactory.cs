using System;
using UnityEngine;

namespace ECSFrameWork{
   //类工厂
 public class ObjectFactory 
{
  public T Create<T>()
   where T:IObject{
      T obj=Inspect<T>();
      Game.Instance.KernelSystem.Awake(ref obj);
      obj.IsLife=true;
      return obj;
  }
  public T Create<T,A>(A a)
   where T:IObject{
      T obj=Inspect<T>();
      Game.Instance.KernelSystem.Awake(ref obj,a);
      obj.IsLife=true;
      return obj;
  }
  public T Create<T,A,B>(A a,B b)
   where T:IObject{
      T obj=Inspect<T>();
      Game.Instance.KernelSystem.Awake(ref obj,a,b);
      obj.IsLife=true;
      return obj;
  }
  public T Create<T,A,B,C>(A a,B b,C c)
   where T:IObject{
      T obj=Inspect<T>();
      Game.Instance.KernelSystem.Awake(ref obj,a,b,c);
      obj.IsLife=true;
      return obj;
  }
  public T Create<T,A,B,C,D>(A a,B b,C c,D d)
   where T:IObject{
      T obj=Inspect<T>();
      Game.Instance.KernelSystem.Awake(ref obj,a,b,c,d);
      obj.IsLife=true;
      return obj;
  }

  public T CreateWithParent<T>(Main parent)
   where T:Component{
      T obj=Inspect<T>();
      obj.Parent=parent;
      Game.Instance.KernelSystem.Awake(ref obj);
      obj.IsLife=true;
      return obj;
  }
  public T CreateWithParent<T,A>(Main parent,A a)
    where T:Component{
      T obj=Inspect<T>();
      obj.Parent=parent;
      Game.Instance.KernelSystem.Awake(ref obj,a);
      obj.IsLife=true;
      return obj;
  }
  public T CreateWithParent<T,A,B>(Main parent,A a,B b)
   where T:Component{
      T obj=Inspect<T>();
      obj.Parent=parent;
      Game.Instance.KernelSystem.Awake(ref obj,a,b);
      obj.IsLife=true;
      return obj;
  }
   public T CreateWithParent<T,A,B,C>(Main parent,A a,B b,C c)
    where T:Component{
      T obj=Inspect<T>();
      obj.Parent=parent;
      Game.Instance.KernelSystem.Awake(ref obj,a,b,c);
      obj.IsLife=true;
      return obj;
  }
  public T CreateWithParent<T,A,B,C,D>(Main parent,A a,B b,C c,D d)
    where T:Component{
      T obj=Inspect<T>();
      obj.Parent=parent;
      Game.Instance.KernelSystem.Awake(ref obj,a,b,c,d); 
      obj.IsLife=true;
      return obj;
  }

  public T Inspect<T>()
  where T:IObject
  {
   Type type=typeof(T);
   IObject obj= Game.Instance.ObjectPoolManager.Fetch(ref type);
   Game.Instance.KernelSystem.AddSystem(ref obj);
   return obj as T;
  }
}
}

