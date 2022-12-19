using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System;
public class DBLoader : MonoBehaviour
{

    TransformerController TransContrl;

    void Start(){
        TransContrl=GameObject.FindObjectOfType<TransformerController>();
    }

    //shortener url 넘기기
    public IEnumerator SetHashUrls(string url,long id){
        string serverPath = "http://127.0.0.1/PhpFile/SetUrls.php"; //PHP 파일의 위치를 저장
        WWWForm form = new WWWForm(); //웹에 입력을 위함.
        form.AddField("HashUrl",url);
        form.AddField("urlid",id.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(serverPath,form)) //웹 서버에 요청
        {
            yield return www.SendWebRequest(); //요청이 끝날 때까지 대기 

            if(www.isNetworkError || www.isHttpError){ //서버 에러시 
                Debug.Log(www.error+" : 서버 에러입니다.");
            }

            Debug.Log(www.downloadHandler.text);
        }
    }

    
    //연결 Php파일 
    public IEnumerator GetURLs(string url)
    {
        string serverPath = "http://127.0.0.1/PhpFile/GetUrls.php"; //PHP 파일의 위치를 저장
        WWWForm form = new WWWForm(); //웹에 입력을 위함.
        if(url.Contains("localhost")){ //해쉬 값일때 원래 originalURL 던지기!
            form.AddField("HashUrl",url);
        }else{
            form.AddField("OriginalUrl",url);
        }
       
        using (UnityWebRequest www = UnityWebRequest.Post(serverPath,form)) //웹 서버에 요청
        {
            yield return www.SendWebRequest(); //요청이 끝날 때까지 대기 

            if(www.isNetworkError || www.isHttpError){ //서버 에러시 
                Debug.Log(www.error+" : 서버 에러입니다.");
            }else{
                try{
                    var input=long.Parse(Regex.Replace(www.downloadHandler.text, @"\D", ""));
                    TransContrl.encodeBase62(input);
                }catch(FormatException e){
                    TransContrl.ShowShortenUrls(www.downloadHandler.text);
                }
                
            }
        }
    }
    
}
