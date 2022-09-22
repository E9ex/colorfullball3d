using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    private bool shakecontrol = false;
    public IEnumerator camerashakes (float duration, float magnitude)//magnittude titreşimin buyuklüyü bunu dısardan vereceğiz.
    {
        Vector3 originalpos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed< duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalpos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalpos;
    }

    public void camerashakecall()
    {
        if (shakecontrol==false)// false ise bir daha döndürmesin kamera sadece bir kere sallansın istedik.
        {
            StartCoroutine(camerashakes(0.22f, 0.04f));
            shakecontrol = true;
        }
        
    }
}
