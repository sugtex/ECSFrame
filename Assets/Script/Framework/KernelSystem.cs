using System.Collections.Generic;
using UnityEngine;

namespace ECSFrameWork{

    //模拟unity生命周期系统
public class KernelSystem 
{
  private Dictionary<long,IObject> _objects=new Dictionary<long, IObject>();
  private Dictionary<long,IUpdate> _updates=new Dictionary<long, IUpdate> ();
  private Dictionary<long,IFixedUpdate> _fixedUpdates=new Dictionary<long, IFixedUpdate>();
  private Dictionary<long,ILateUpdate> _lateUpdates=new Dictionary<long, ILateUpdate>();

  private Queue<long> _startEnter=new Queue<long>();
  private Queue<long> _updateEnter=new Queue<long>();
  private Queue<long> _updateExit=new Queue<long>();
  private Queue<long> _fixedUpdateEnter=new Queue<long>();
  private Queue<long> _fixedUpdateExit=new Queue<long>();
  private Queue<long> _lateUpdateEnter=new Queue<long>();
  private Queue<long> _lateUpdateExit=new Queue<long>();


  public void AddSystem(ref IObject obj){
      long id=obj.ID;
      if(_objects.ContainsKey(id)) return;
      _objects.Add(id,obj);
      if(obj is IStart) _startEnter.Enqueue(id);
      if(obj is IUpdate) _updateEnter.Enqueue(id);
      if(obj is IFixedUpdate) _fixedUpdateEnter.Enqueue(id);
      if(obj is ILateUpdate) _lateUpdateEnter.Enqueue(id);
  }
  public void RemoveSystem(IObject obj){
      long id=obj.ID;
      if(!_objects.ContainsKey(id)) return;
      _objects.Remove(id);
      if(obj is IUpdate) _updateExit.Enqueue(id);
      if(obj is IFixedUpdate) _fixedUpdateExit.Enqueue(id);
      if(obj is ILateUpdate) _lateUpdateExit.Enqueue(id);   
  }

  public void Awake<T>(ref T t)
   where T:IObject{
   if(t is IAwake){
       ((IAwake)t).F_Awake();
   }
  }
  public void Awake<T,A>(ref T t,A a)
   where T:IObject{
      if(t is IAwake<A>){
           ((IAwake<A>)t).F_Awake(a);
      }
  }
  public void Awake<T,A,B>(ref T t,A a,B b)
   where T:IObject{
      if(t is IAwake<A,B>){
           ((IAwake<A,B>)t).F_Awake(a,b);
      }
  }
   public void Awake<T,A,B,C>(ref T t,A a,B b,C c)
   where T:IObject{
      if(t is IAwake<A,B,C>){
           ((IAwake<A,B,C>)t).F_Awake(a,b,c);
      }
  }
  public void Awake<T,A,B,C,D>(ref T t,A a,B b,C c,D d)
   where T:IObject{
      if(t is IAwake<A,B,C,D>){
           ((IAwake<A,B,C,D>)t).F_Awake(a,b,c,d);
      }
  }

  private void Start(){
      while(_startEnter.Count>0){
         long id =_startEnter.Dequeue();
         IObject obj;
         if(!_objects.TryGetValue(id,out obj)) return;
         ((IStart)obj).F_Start();
      }
  }
  
  public void Update(){
      Start();
      while(_updateEnter.Count>0){
          long id=_updateEnter.Dequeue();
          IObject obj;
          if(_objects.TryGetValue(id,out obj)){
               if(_updates.ContainsKey(id)) continue;
               _updates.Add(id,(IUpdate)obj);
          }
      }
      while(_updateExit.Count>0){
          long id=_updateExit.Dequeue();
          if(_updates.ContainsKey(id)){
              _updates.Remove(id);
          }
      }
      if(_updates.Count>0){
          foreach(IUpdate u in _updates.Values){
              u.F_Update();
          }
      }
  }

  public void FixedUpdate(){
      while(_fixedUpdateEnter.Count>0){
          long id =_fixedUpdateEnter.Dequeue();
          IObject obj;
          if(_objects.TryGetValue(id,out obj)){
              if(_fixedUpdates.ContainsKey(id)) continue;
              _fixedUpdates.Add(id,(IFixedUpdate)obj);
          }
      }
      while(_fixedUpdateExit.Count>0){
          long id=_fixedUpdateExit.Dequeue();
          if(_fixedUpdates.ContainsKey(id)){
              _fixedUpdates.Remove(id);
          }
      }
      if(_fixedUpdates.Count>0){
          foreach(IFixedUpdate f in _fixedUpdates.Values){
              f.F_FixedUpdate();
          }
      }
  }

   public void LateUpdate(){
      while(_lateUpdateEnter.Count>0){
          long id =_lateUpdateEnter.Dequeue();
          IObject obj;
          if(_objects.TryGetValue(id,out obj)){
              if(_lateUpdates.ContainsKey(id)) continue;
              _lateUpdates.Add(id,(ILateUpdate)obj);
          }
      }
      while(_lateUpdateExit.Count>0){
          long id=_lateUpdateExit.Dequeue();
          if(_lateUpdates.ContainsKey(id)){
              _lateUpdates.Remove(id);
          }
      }
      if(_lateUpdates.Count>0){
          foreach(ILateUpdate l in _lateUpdates.Values){
              l.F_LateUpdate();
          }
      }
  }
}
}
