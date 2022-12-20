using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TransformerController : MonoBehaviour
{

    const string BASE62="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    string hashURL="localhost:";
    string newURL="";

    InputURLController inputUrl; //입력된 url을 가져오기 위한 스크립트
    DBLoader db; //DB삽입을 위함.
    [SerializeField]
    TMP_Text output;
    // Start is called before the first frame update

    void Start()
    {
        inputUrl=GameObject.FindObjectOfType<InputURLController>(); //스크립트 가져오기
        db=GameObject.FindObjectOfType<DBLoader>(); //DB스크립트 가져오기
    }

    public string encodeBase62(long id){ //62개의 값중 1개로 바꾼다.
        long originalId=id;
        if(newURL!="")
            newURL="";

        while(id>0){
            int value=(int)(id%62);
            newURL+=BASE62[value];
            id/=62;
        }
        //겹치는 것이 없도록하기 위해 reverse사용.
        newURL=reserve(newURL);

        hashURL+=newURL;
        StartCoroutine(db.SetHashUrls(hashURL,originalId,PlayerPrefs.GetInt("id")));
        ShowShortenUrls(hashURL);
        return newURL;
    }

    public void ShowShortenUrls(string url){
        output.text=url;
    }
    string reserve(string input){
       char []tmp=input.ToCharArray();
       System.Array.Reverse(tmp);
       string output=new string(tmp);
       return output;
    }
}


