using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
   public class GameOver : BasePanel
   {
      private event Reborn _reborn;
      public void SubscribeReborn(Reborn reborn)
      {
         _reborn += reborn;
      }

      protected override void OnContinue()
      {
         _reborn?.Invoke();
      }
   }
}