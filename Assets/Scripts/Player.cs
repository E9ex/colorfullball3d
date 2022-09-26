using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("STATUS")] 
    [SerializeField] private bool isSaglam = true; // STATE
    
    //STATES
    //IDLE
    //MOVE/WALK
    //RUN
    
    //FULLHEALTH = 100
    //INJURED    <0 && <100
    //DIED = 0

    [Space] [Header("INIT")] 
    [SerializeField] private Collider selfCollider;
    [SerializeField] private GameObject selfModel;
    [Space]
    
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
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(isSaglam)
        {
            if (variables.firsttouch ==
                1) //dokundgumuzda böyle olsun yani... (bu arada Variables değil o.Aslında dosya ismi.)
            {
                transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
                // cam.transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
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
                    rb.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y,
                        touch.deltaPosition.y * speed * Time.deltaTime);
                    // böyle yaparsam yukarda yazdıgım gibi küplerin içinden geçmez.
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity =
                        Vector3.zero; // zero neydi hepsini sıfır yapıyor. hız tamamen kesilsin diye böyle yazdık.
                }

                if (touch.phase == TouchPhase.Stationary)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }

    public GameObject[] fractureItems;
    public void OnCollisionEnter(Collision hit)
    {
        // if(isCrashed)
        //     return;
        
       if(isSaglam == true)
       {
           if (hit.gameObject.CompareTag("obstacles1"))
           {
               isSaglam = false;
               rb.isKinematic = true;
               selfCollider.enabled = false;
               selfModel.SetActive(false);

               gameObject.transform.GetChild(0).gameObject.SetActive(false);
               camesahake.camerashakecall();
               uimanager.StartCoroutine("whiteeffect");

               foreach (GameObject item in fractureItems)
               {
                   item.GetComponent<Collider>().enabled = true;

                   item.GetComponent<Rigidbody>().isKinematic = false;

                   item.transform.SetParent(null);
               }
           }
       }
    }
}














