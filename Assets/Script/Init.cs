using UnityEngine;
using UnityEngine.SceneManagement;

namespace ECSFrameWork{
public class Init : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(this);
    }
  private void OnLevelWasLoaded(int level)
   {
     
   }

    void Update()
    {
        Game.Instance.KernelSystem.Update();
    }
    void FixedUpdate(){
        Game.Instance.KernelSystem.FixedUpdate();
    }
    void LateUpdate(){
        Game.Instance.KernelSystem.LateUpdate();
    }
}
}

