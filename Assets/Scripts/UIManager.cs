using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
   public Image whiteeffectimage;
   private int effectcontrol = 0;
   public Image fillrateimage;
   public GameObject player;
   public GameObject finishlane;

   public Animator layoutanimator;
   public Text Coin_Text;

   //butonlar
   public GameObject setttings_open;
   public GameObject setttings_close;
   public GameObject layoutbackground;
   public GameObject sound_on;
   public GameObject sound_off;
   public GameObject vibration_on;
   public GameObject vibration_off;
   public GameObject iap;
   public GameObject information;

   public GameObject intro_hand;
   public GameObject noAds;
   public GameObject shop_button;

   public GameObject restart_Screen;

   public GameObject achievedcoin;
   public GameObject nextlevel;
   public Text achievedtext;
  

   //oyun sonu ekranı
   public GameObject finishscreenn;
   public GameObject background;
   public GameObject complete;
   public GameObject rewarded;
   public GameObject nothanks;
   public GameObject coin;







   public void Start()
   {
      if (PlayerPrefs.HasKey("Sound") == false)
      {
         PlayerPrefs.SetInt("Sound", 1);
      }

      if (!PlayerPrefs.HasKey("Vibration"))
      {
         PlayerPrefs.SetInt("Vibration", 1);
      }

      cointextupdate();

   }
   public IEnumerator afterRewardedButton()
   {

      achievedcoin.SetActive(true);
      achievedtext.gameObject.SetActive(true);
      rewarded.SetActive(false);
      nothanks.SetActive(false);
      
      for (int i = 0; i <= 400; i+=4)
      {
         achievedtext.text = "+" + i.ToString();
         yield return new WaitForSecondsRealtime(0.0001f);
      }
    
      yield return new WaitForSecondsRealtime(0.8f);
      nextlevel.SetActive(true);


      for (int i = 0; i < 400; i+=4)
      {
         achievedtext.text = "+" + i.ToString();
         yield return new WaitForSecondsRealtime(0.0001f);
      }
      
     
      
   }



   public void FirstTouchD()
   {
      intro_hand.SetActive(false);
      noAds.SetActive(false);
      shop_button.SetActive(false);
      setttings_open.SetActive(false);
      setttings_close.SetActive(false);
      layoutbackground.SetActive(false);
      sound_on.SetActive(false);
      sound_off.SetActive(false);
      vibration_on.SetActive(false);
      vibration_off.SetActive(false);
      iap.SetActive(false);
      information.SetActive(false);

   }


   public void Update()
   {
      fillrateimage.fillAmount = ((player.transform.position.z * 100) / (finishlane.transform.position.z)) / 100;
   }

   public void cointextupdate()
   {
      Coin_Text.text = PlayerPrefs.GetInt("moneyy").ToString();
   }


   public void restart_buttonactive()
   {
      restart_Screen.SetActive(true);

   }

   public void restartscene()
   {
      variables.firsttouch = 0;
      Time.timeScale = 1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //buradaki aktif sahneyi resetliyecektir.
   }

   public void nextscene()
   {
      variables.firsttouch = 0;
      Time.timeScale = 1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

   public void finishscreen()
   {
      StartCoroutine("finishlaunch");



   }

   public IEnumerator finishlaunch()
   {
      Time.timeScale = 0.3f;
      finishscreenn.SetActive(true);
      background.SetActive(true);
      yield return new WaitForSecondsRealtime(0.8f);
      complete.SetActive(true);
      coin.SetActive(true);
      yield return new WaitForSecondsRealtime(0.2f);
      rewarded.SetActive(true);
      yield return new WaitForSecondsRealtime(3f);
      nothanks.SetActive(true);



   }




   //buton fonks
   public void settings_open()
   {
      setttings_open.SetActive(false);
      setttings_close.SetActive(true);
      layoutanimator.SetTrigger("slide_in");
      if (PlayerPrefs.GetInt("Sound") == 1)
      {
         sound_on.SetActive(true);
         sound_off.SetActive(false);
         AudioListener.volume = 1;
      }
      else if (PlayerPrefs.GetInt("Sound") == 2)
      {
         sound_on.SetActive(false);
         sound_off.SetActive(true);
         AudioListener.volume = 0;
      }
      else if (PlayerPrefs.GetInt("Vibration") == 1)
      {
         vibration_on.SetActive(true);
         vibration_off.SetActive(false);
         PlayerPrefs.SetInt("Vibration", 2);
      }
      else if (PlayerPrefs.GetInt("Vibration") == 2)
      {
         vibration_on.SetActive(false);
         vibration_off.SetActive(true);
         PlayerPrefs.SetInt("Vibration", 1);
      }


   }

   public void settings_close()
   {
      setttings_open.SetActive(true);
      setttings_close.SetActive(false);
      layoutanimator.SetTrigger("slide_out");

   }

   public void Sound_On()
   {

      sound_on.SetActive(false);
      sound_off.SetActive(true);
      AudioListener.volume = 0;
      PlayerPrefs.SetInt("Sound", 2);

   }

   public void Sound_Off()
   {

      sound_on.SetActive(true);
      sound_off.SetActive(false);
      AudioListener.volume = 1;
      PlayerPrefs.SetInt("Sound", 1);


   }

   public void Vibration_On()
   {
      vibration_on.SetActive(false);
      vibration_off.SetActive(true);

   }

   public void Vibration_Off()
   {
      vibration_on.SetActive(true);
      vibration_off.SetActive(false);

   }

   





public IEnumerator whiteeffect()
   {
      whiteeffectimage.gameObject.SetActive(true);

      while (effectcontrol == 0)
      {
         yield return new WaitForSeconds(0.001f); // 0.1 saniyede hep donucek.
         whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
         if (whiteeffectimage.color ==
             new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
         {
            effectcontrol = 1;
         }

      }

      while (effectcontrol == 1)
      {
         yield return new WaitForSeconds(0.001f);
         whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
         if (whiteeffectimage.color ==
             new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
         {
            effectcontrol = 2;
         }
      }

      if (effectcontrol == 2)
      {
         Debug.Log("effect bitti.");
      }

   }

}


