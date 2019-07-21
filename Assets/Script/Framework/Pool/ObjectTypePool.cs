using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ECSFrameWork{
public class ObjectTypePool 
{
   private Queue<IObject> Objects=new Queue<IObject>();

    public IObject Fetch(ref Type type){
        IObject obj=null;
        if(Objects.Count==0){
         obj=(IObject)Activator.CreateInstance(type);
        }else{
        obj=Objects.Dequeue();
        }
        return obj;
    }
    public void Recycle(ref IObject obj){
        Objects.Enqueue(obj);
    }
    public void Clear(){
        Objects=new  Queue<IObject>();
    }
}
}

