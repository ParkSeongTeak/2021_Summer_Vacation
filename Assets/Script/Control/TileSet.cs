using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSet : MonoBehaviour
{
    int num = 0;
   public void TileReSet()
   {
        num = GameManager.InGameData.RoomNum;

   }
}
