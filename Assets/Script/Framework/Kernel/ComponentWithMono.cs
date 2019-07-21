using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ECSFrameWork{
    //需要mono脚本的继承于此，成为主体的一个组件
    public class ComponentWithMono : Component
    {
        protected GameObject m_prefab;
        protected void OnInit(GameObject prefab){
            m_prefab=prefab;
        }
        public T AddMono<T>()
        where T:BaseMono
        {
           T t=InSpect<T>();
           if(t is IAwake){
               ((IAwake)t).F_Awake();
           }
           t.enabled=true;
           return t;
        }
        public T AddMono<T,A>(A a)
        where T:BaseMono
        {
           T t=InSpect<T>();
           if(t is IAwake<A>){
               ((IAwake<A>)t).F_Awake(a);
           }
           t.enabled=true;
           return t;
        }
        public T AddMono<T,A,B>(A a,B b)
        where T:BaseMono
        {
           T t=InSpect<T>();
           if(t is IAwake<A,B>){
               ((IAwake<A,B>)t).F_Awake(a,b);
           }
           t.enabled=true;
           return t;
        }
        public T AddMono<T,A,B,C>(A a,B b,C c)
        where T:BaseMono
        {
           T t=InSpect<T>();
           if(t is IAwake<A,B,C>){
               ((IAwake<A,B,C>)t).F_Awake(a,b,c);
           }
           t.enabled=true;
           return t;
        }
        public T AddMono<T,A,B,C,D>(A a,B b,C c,D d)
        where T:BaseMono
        {
           T t=InSpect<T>();
           if(t is IAwake<A,B,C,D>){
               ((IAwake<A,B,C,D>)t).F_Awake(a,b,c,d);
           }
           t.enabled=true;
           return t;
        }
        private T InSpect<T>()
        where T:BaseMono{
           T t=m_prefab.GetComponent<T>();
           if(t==null){
               t=m_prefab.AddComponent<T>();
           }
           return t;
        }
    }
}

