using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MsgReceiver
{
  private static int level;
  public static int currentLevel 
  {
     get
     {
        return level;
     } 
     
     set
     {
       level = value;
     }
     
  }

}
