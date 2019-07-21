namespace ECSFrameWork{
    //总管理（单例）
public class Game :Singleton<Game>
{
    //管理生命周期
   private KernelSystem kernelSystem;
   public KernelSystem KernelSystem{
       get{
           if(kernelSystem==null){
               kernelSystem=new KernelSystem();
           }
           return kernelSystem;
       }
   }
   
   //类的对象池
   private ObjectPoolManager objectPoolManager;
   public ObjectPoolManager ObjectPoolManager{
       get{
           if(objectPoolManager==null){
               objectPoolManager=new ObjectPoolManager();
           }
           return objectPoolManager;
       }
   }
   //实例化类的工厂
   private ObjectFactory objectFactory;
   public ObjectFactory ObjectFactory{
       get{
           if(objectFactory==null){
               objectFactory=new ObjectFactory();
           }
           return objectFactory;
       }
   }
   //实体对象池
   private GameObjectPoolManager gameObjectPoolManager;
   public GameObjectPoolManager GameObjectPoolManager{
       get{
           if(gameObjectPoolManager==null){
               gameObjectPoolManager=new GameObjectPoolManager();
           }
           return gameObjectPoolManager;
       }
   }
   //消息机制
   private  EventManager   eventManager  ;
   public  EventManager   EventManager  {
       get{
           if(eventManager ==null){
               eventManager =new  EventManager();
           }
           return eventManager ;
       }
   }
   //实体工厂
   private  EntityFactroy   gWOFactroy  ;
   public  EntityFactroy   GWOFactroy  {
       get{
           if(gWOFactroy  ==null){
               gWOFactroy  =new  EntityFactroy();
           }
           return gWOFactroy  ;
       }
   }
}

}
