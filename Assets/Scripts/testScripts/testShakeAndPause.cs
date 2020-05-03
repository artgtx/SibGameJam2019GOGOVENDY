using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShakeAndPause : MonoBehaviour
{
  public void shake()
  {
    CameraShake.ShakeOnce(1,1);
  }

  public void pause()
  {
    globalMD.gamePause();
  }
}
