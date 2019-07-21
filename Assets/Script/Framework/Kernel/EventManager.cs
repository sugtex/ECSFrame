using System.Collections.Generic;
using System;

namespace ECSFrameWork{
   //事件管理者
    
public class EventManager 
{
    private Dictionary<EventType,Delegate> _eventsTable=new   Dictionary<EventType, Delegate>();
    
    #region 注册事件
    public void AddEvent(EventType type,Action action)
    {
     if(InspectAdd(type,action)){
         _eventsTable[type]=(Action)Delegate.Combine((Action)_eventsTable[type],action);
     }
    }
     public void AddEvent<T>(EventType type,Action<T> action)
    {
     if(InspectAdd(type,action)){
         _eventsTable[type]=(Action<T>)Delegate.Combine((Action<T>)_eventsTable[type],action);
     }
    }
     public void AddEvent<T1,T2>(EventType type,Action<T1,T2> action)
    {
     if(InspectAdd(type,action)){
         _eventsTable[type]=(Action<T1,T2>)Delegate.Combine((Action<T1,T2>)_eventsTable[type],action);
     }
    }
      public void AddEvent<T1,T2,T3>(EventType type,Action<T1,T2,T3> action)
    {
     if(InspectAdd(type,action)){
         _eventsTable[type]=(Action<T1,T2,T3>)Delegate.Combine((Action<T1,T2,T3>)_eventsTable[type],action);
     }
    }
      public void AddEvent<T1,T2,T3,T4>(EventType type,Action<T1,T2,T3,T4> action)
    {
     if(InspectAdd(type,action)){
         _eventsTable[type]=(Action<T1,T2,T3,T4>)Delegate.Combine((Action<T1,T2,T3,T4>)_eventsTable[type],action);
     }
    }


#endregion 


    #region 删除事件
public void RemoveEvent(EventType type,Action action){
    if(InspectRemove(type,action)){
        _eventsTable[type]=(Action)Delegate.Remove((Action)_eventsTable[type],action);
      }
}
public void RemoveEvent<T>(EventType type,Action<T> action){
    if(InspectRemove(type,action)){
        _eventsTable[type]=(Action<T>)Delegate.Remove((Action<T>)_eventsTable[type],action);
      }
}
public void RemoveEvent<T1,T2>(EventType type,Action<T1,T2> action){
    if(InspectRemove(type,action)){
        _eventsTable[type]=(Action<T1,T2>)Delegate.Remove((Action<T1,T2>)_eventsTable[type],action);
      }
}
public void RemoveEvent<T1,T2,T3>(EventType type,Action<T1,T2,T3> action){
    if(InspectRemove(type,action)){
        _eventsTable[type]=(Action<T1,T2,T3>)Delegate.Remove((Action<T1,T2,T3>)_eventsTable[type],action);
      }
}
public void RemoveEvent<T1,T2,T3,T4>(EventType type,Action<T1,T2,T3,T4> action){
    if(InspectRemove(type,action)){
        _eventsTable[type]=(Action<T1,T2,T3,T4>)Delegate.Remove((Action<T1,T2,T3,T4>)_eventsTable[type],action);
      }
}
#endregion


    #region 执行事件
    public void HandleEvent(EventType type){
        Delegate dg;
        if(_eventsTable.TryGetValue(type,out dg)){
            Action action=dg as Action;
            action();
        }
    }
    public void HandleEvent<T>(EventType type,T t){
        Delegate dg;
        if(_eventsTable.TryGetValue(type,out dg)){
            Action<T> action=dg as Action<T>;
            action(t);
        }
    }
    public void HandleEvent<T1,T2>(EventType type,T1 t1,T2 t2){
        Delegate dg;
        if(_eventsTable.TryGetValue(type,out dg)){
            Action<T1,T2> action=dg as Action<T1,T2>;
            action(t1,t2);
        }
    }
    public void HandleEvent<T1,T2,T3>(EventType type,T1 t1,T2 t2,T3 t3){
        Delegate dg;
        if(_eventsTable.TryGetValue(type,out dg)){
            Action<T1,T2,T3> action=dg as Action<T1,T2,T3>;
            action(t1,t2,t3);
        }
    }
    public void HandleEvent<T1,T2,T3,T4>(EventType type,T1 t1,T2 t2,T3 t3,T4 t4){
        Delegate dg;
        if(_eventsTable.TryGetValue(type,out dg)){
            Action<T1,T2,T3,T4> action=dg as Action<T1,T2,T3,T4>;
            action(t1,t2,t3,t4);
        }
    }
    #endregion
    private bool InspectAdd(EventType type,Delegate action){
       bool result=true;
       Delegate dg;
       if(!_eventsTable.TryGetValue(type,out dg)){
        _eventsTable[type]=null;
       }
       if(dg!=null&&dg.GetType()!=action.GetType()){
           result=false;
       }
       return result;
    }
    private bool InspectRemove(EventType type,Delegate action){
        bool result=true;
        Delegate dg;
        if(!_eventsTable.TryGetValue(type,out dg)) result=false;
        if(dg!=null&&dg.GetType()!=action.GetType()){
         result=false;
        }
        return result;
    }


}
}

