using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STAGESLECT : MonoBehaviour
{
    public List<GameObject> Stage;
    [SerializeField]
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stage_index(int plus)
    {
        index += plus;
        if (index <= 0)
        {
            index =0;
        }
        if (index >= Stage.Count-1)
        {
            index = Stage.Count-1;
        }
        Show_panel();
    }
    public void Show_panel()
    {
        for(int i = 0; i < Stage.Count; i++)
        {
            Stage[i].SetActive(i == index);
        }
    }
    public void Stage_select_Botton()
    {
        int S_I = index + 1;
        string scenename = "stage"+S_I ;
        Debug.Log(scenename);
        SceneManager.LoadScene(scenename);
    }

}
