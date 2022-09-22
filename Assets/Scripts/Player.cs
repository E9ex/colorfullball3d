using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Player : MonoBehaviour
{
    public UIManager uimanager;
    public camerashake camesahake;
    public GameObject cam;
    public GameObject vectorforward;
    public GameObject vectorback;
    public Rigidbody rb;
    private Touch touch;
    [Range(20,40)]// böyle yaparsak slider geliyor.
    public int speed;

    public int forwardspeed;
    // Start is called before the first frame update
    public void FixedUpdate()
    {
        if (variables.firsttouch ==
            1) //dokundgumuzda böyle olsun yani... (bu arada Variables değil o.Aslında dosya ismi.)
        {
            transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
            vectorforward.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
            vectorback.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
        }






        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0); //ilk dokunan parmagı aliyoruz.
            if (touch.phase == TouchPhase.Began)
            {
                variables.firsttouch = 1;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                /* bak kardeşim şimdi burda transform ilerde cok buyuk hatalar alabilirm böyle yapınca kutuların içinden geçiyor geçmemesi lazim // transform.position*/
                rb.velocity = new Vector3(touch.deltaPosition.x * speed, transform.position.y,
                    touch.deltaPosition.y * speed);
                // böyle yaparsam yukarda yazdıgım gibi küplerin içinden geçmez.
            }

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero; // zero neydi hepsini sıfır yapıyor. hız tamamen kesilsin diye böyle yazdık.
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    public GameObject[] fractureItems;
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("obstacles1"))
        {
            camesahake.camerashakecall();
            uimanager.StartCoroutine("whiteeffect");
            
            foreach (GameObject item in fractureItems)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                item.GetComponentInChildren<SphereCollider>().enabled = true;
               
                item.GetComponentInChildren<Rigidbody>().isKinematic = false;
            }
        }
        
    }
}

    

    /*  public GameObject[] fractureItems;
      public void OnCollisionEnter(Collision hit)
      {
          if (hit.gameObject.CompareTag("obstacles1"))
          {
              foreach (GameObject item in fractureItems)
              {
                  
                  item.GetComponentInChildren<SphereCollider>().enabled = true;
                 
                  item.GetComponentInChildren<Rigidbody>().isKinematic = false;
              }
          }
          
      }
      */










/* public Gameobject[] fractureitems;
/* public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("obstacles1"))
        {
            gameObject.transform.GetChild(0).gameobject.setactive(false);
        }
        3d shattered sphere bulamadıgım için top kareye degdiğin parçalanması gerekmesi gerekirken böyle olmayacak malesef 
        ben gene de kodları yazim.
        
        
        
        
    shattered sphere ile iç içe koyulup eşitliyoruz. tüm parçaları sphere içine atiyoz child oluyorlar. playerin mesh renderınnı silebiliriz.tum fracturelara rigidboy ekleyip massına ekleme yapıyoruz.
    
    sphere collider veya capsule collider yda meshcollider eklioz.3unden biri.
    radiuslarını küçültmemiz lazim.fractureları kinematic yapıyoruz. sonra;;fractureların hepsini sırasıyla koyuyoruz unitydeki liste.
    foreach(GameObject item in fractureitems)
    {
        item.getcomponent<spherecollider>().enabled=true;
        item.getcomponent<rigidbody>().iskinematic=false;
    
    }
    
    
    
       */

