using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Player : MonoBehaviour
{
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
        if (variables.firsttouch==1)//dokundgumuzda böyle olsun yani... (bu arada Variables değil o.Aslında dosya ismi.)
        {
            transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
            vectorforward.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
            vectorback.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
        }

        
        



            if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);//ilk dokunan parmagı aliyoruz.
            if (touch.phase==TouchPhase.Began)
            {
                variables.firsttouch = 1;
            }
            if (touch.phase==TouchPhase.Moved)
            {
               /* bak kardeşim şimdi burda transform ilerde cok buyuk hatalar alabilirm böyle yapınca kutuların içinden geçiyor geçmemesi lazim // transform.position*/
               rb.velocity=new Vector3(touch.deltaPosition.x*speed,transform.position.y,touch.deltaPosition.y*speed);
                // böyle yaparsam yukarda yazdıgım gibi küplerin içinden geçmez.
            }

            if (touch.phase==TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;// zero neydi hepsini sıfır yapıyor. hız tamamen kesilsin diye böyle yazdık.
            }

            if (touch.phase==TouchPhase.Stationary)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
