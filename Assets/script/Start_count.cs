using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Start_count : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Count_dawn_text;
    [SerializeField]
    int count;
    [SerializeField]
    GameObject Count_Panel;
    Vector3 Base_scale;
    [SerializeField]
    float POP_scale=2;
    
    // Start is called before the first frame update
    void Start()
    {
        Base_scale = Count_dawn_text.rectTransform.localScale;
        StartCoroutine(Count_dwan());

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Count_dwan()
    {
        Count_Panel.SetActive(true);
        Time.timeScale=0f;
        yield return new WaitForSecondsRealtime(0.5f);
        Count_dawn_text.text = count.ToString();
        StartCoroutine(POP_animation());
        for (int I = count; I > 0; I--)
        {
            Count_dawn_text.text = I.ToString();
            StartCoroutine(POP_animation());
            yield return new WaitForSecondsRealtime(1f);
        }
        Count_dawn_text.text = "GO";
        yield return new WaitForSecondsRealtime(0.8f);
        Time.timeScale = 1f;
        Count_Panel.SetActive(false);
    }
    IEnumerator POP_animation()
    {
        RectTransform RT=Count_dawn_text.rectTransform;
        RT.localScale = Base_scale * POP_scale;
        float T = 0;
        while (T <= 0.25f)
        {
            T += Time.unscaledDeltaTime;
            float P = Mathf.Clamp01(T / 0.25f);
            RT.localScale = Vector3.Lerp(Base_scale * POP_scale, Base_scale, P);
            yield return null;
        }
        RT.localScale = Base_scale;
    }
}
