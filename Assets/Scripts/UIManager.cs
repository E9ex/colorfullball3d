using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public Image whiteeffectimage;
   private int effectcontrol = 0;
  
   public IEnumerator whiteeffect()
   {
      whiteeffectimage.gameObject.SetActive(true);

      while (effectcontrol==0)
      {
         yield return new WaitForSeconds(0.001f);// 0.1 saniyede hep donucek.
         whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
         if (whiteeffectimage.color==new Color(whiteeffectimage.color.r,whiteeffectimage.color.g,whiteeffectimage.color.b,1))
         {
            effectcontrol = 1;
         }

      }

      while (effectcontrol==1)
      {
         yield return new WaitForSeconds(0.001f);
         whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
         if (whiteeffectimage.color==new Color(whiteeffectimage.color.r,whiteeffectimage.color.g,whiteeffectimage.color.b,0))
         {
            effectcontrol = 2;
         }
      }

      if (effectcontrol==2)
      {
         Debug.Log("effect bitti.");
      }
      
   }
}
