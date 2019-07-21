using UnityEngine;
namespace ECSFrameWork{
   //基层
public class IObject:IDispose
{
   public long ID{get;private set;}
   public bool IsLife{get; set;}

   public IObject(){   
    ID=IdCreator.GenerateId();
   }
   public  virtual void F_Dispose()
   {
       IsLife=false;
       Game.Instance.ObjectPoolManager.Recycle(this);
       Game.Instance.KernelSystem.RemoveSystem(this);
   }
}
}

