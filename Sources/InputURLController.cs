using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class InputURLController : MonoBehaviour
{
    [SerializeField]
    TMP_Text input;
    public string originURL{get; set;}
    DBLoader db;
    // Start is called before the first frame update
    void Start()
    {
        db=GameObject.FindObjectOfType<DBLoader>();
    }

    public void OnClick(){

        originURL=input.text;
        StartCoroutine(db.GetURLs(originURL));
        
    }

    public void OnMypageButClick(){
        SceneManager.LoadScene("MypageHome");
    }
}
