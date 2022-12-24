using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetAllUrlController : MonoBehaviour
{    
    DBLoader db; //DB삽입을 위함.
    // Start is called before the first frame update
    void Start()
    {
        db=GameObject.FindObjectOfType<DBLoader>(); //DB스크립트 가져오기
        StartCoroutine(db.GetAllUrls(PlayerPrefs.GetInt("id").ToString()));
        Debug.Log("현재 id: "+PlayerPrefs.GetInt("id").ToString());
    }

    public void Settings(string text){

        this.gameObject.GetComponent<TMP_Text>().text=text;

    }

}
