using System.Collections.Generic;
using System;
using UnityEngine;

namespace ECSFrameWork{
   //主体
public class Main : IObject
{
    private Dictionary<Type,Component> _components=new Dictionary<Type, Component>();

    public T AddComponent<T>()
     where T:Component
    {
      Type type=typeof(T);
      if(_components.ContainsKey(type)){
          return null;
      }
      T component= Game.Instance.ObjectFactory.CreateWithParent<T>(this);
      _components.Add(type,component);
      return component;
    }
  public T AddComponent<T,A>(A a)
    where T:Component
    {
      Type type=typeof(T);
      if(_components.ContainsKey(type)){
          return null;
      }
      T component= Game.Instance.ObjectFactory.CreateWithParent<T,A>(this,a);
      _components.Add(type,component);
      return component;
    }
  public T AddComponent<T,A,B>(A a,B b)
    where T:Component
    {
      Type type=typeof(T);
      if(_components.ContainsKey(type)){
          return null;
      }
      T component= Game.Instance.ObjectFactory.CreateWithParent<T,A,B>(this,a,b);
      _components.Add(type,component);
      return component;
    }
    public T AddComponent<T,A,B,C>(A a,B b,C c)
    where T:Component
    {
      Type type=typeof(T);
      if(_components.ContainsKey(type)){
          return null;
      }
      T component= Game.Instance.ObjectFactory.CreateWithParent<T,A,B,C>(this,a,b,c);
      _components.Add(type,component);
      return component;
    }
  
  public T GetComponent<T>()
  where T:Component{
    Type type=typeof(T);
    Component component;
    if(_components.TryGetValue(type,out component)){
      return component as T;
    }
    return null;
  }

  public void RemoveComponent<T>()
  where T:Component
  {
     Type type=typeof(T);
     Component component;
     if(!_components.TryGetValue(type,out component))return;
     component.F_Dispose();
     _components.Remove(type);
  }

 public override void F_Dispose(){
   Clear();
   base.F_Dispose();
 }

 private void Clear(){
  foreach(Type t in _components.Keys){
     _components[t].F_Dispose();
  }
  _components.Clear();
 }
}

}

