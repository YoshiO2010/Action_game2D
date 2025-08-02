using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_scale : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    GameObject Pause_botton;
    [SerializeField]
    Vector2 Original_scale;
    [SerializeField]
    Vector2 After_scale;
    // Start is called before the first frame update
    void Start()
    {
        Pause_botton = this.gameObject;
        Original_scale = new Vector2(1, 1);
        After_scale = new Vector2(1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnPointerEnter(PointerEventData eventdata)
    {
        Pause_botton.transform.localScale =After_scale;
    }
    public void OnPointerExit(PointerEventData eventdata)
    {
        Pause_botton.transform.localScale =Original_scale;
    }
} 
