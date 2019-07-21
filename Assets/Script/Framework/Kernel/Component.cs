namespace ECSFrameWork{
 //组件
public class Component :IObject
{
   public IObject Parent{get; set;}
   public  override void F_Dispose()
   {
     Parent=null;
     base.F_Dispose();
   }
}
}

