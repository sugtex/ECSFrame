namespace ECSFrameWork{
public interface IAwake
{
    void F_Awake();
    
}
public interface IAwake<T1>{
    void F_Awake(T1 t);
}
public interface IAwake<T1,T2>{
    void F_Awake(T1 t1,T2 t2);
}
public interface IAwake<T1,T2,T3>{
    void F_Awake(T1 t1,T2 t2,T3 t3);
}
public interface IAwake<T1,T2,T3,T4>{
    void F_Awake(T1 t1,T2 t2,T3 t3,T4 t4);
}
}
