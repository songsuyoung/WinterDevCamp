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
    public IEnumerator SetHashUrls(string url,long id,long userid){
        string serverPath = "http://127.0.0.1/PhpFile/SetUrls.php"; //PHP 파일의 위치를 저장
        WWWForm form = new WWWForm(); //웹에 입력을 위함.
        form.AddField("HashUrl",url);
        form.AddField("urlid",id.ToString());
        form.AddField("userid",userid.ToString());
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

                    string text = www.downloadHandler.text;

                    if(text.Contains("https")){
                        TransContrl.ShowShortenUrls(www.downloadHandler.text);
                    }else{
                        var input=long.Parse(Regex.Replace(www.downloadHandler.text, @"\D", ""));
                        TransContrl.encodeBase62(input);

                    }
                    
                }catch(FormatException e){
                    TransContrl.ShowShortenUrls(www.downloadHandler.text);
                }
                
            }
        }
    }

    /*아이디 관련 php파일 연결*/
    public IEnumerator GetUser(string id,string passwd)
    {
        string serverPath = "http://127.0.0.1/PhpFile/GetUsers.php"; //PHP 파일의 위치를 저장
        WWWForm form = new WWWForm(); //웹에 입력을 위함.
        
        form.AddField("id",id);
        form.AddField("passwd",passwd);
        using (UnityWebRequest www = UnityWebRequest.Post(serverPath,form)) //웹 서버에 요청
        {
            yield return www.SendWebRequest(); //요청이 끝날 때까지 대기 

            if(www.isNetworkError || www.isHttpError){ //서버 에러시 
                Debug.Log(www.error+" : 서버 에러입니다.");
            }else{

                string text=www.downloadHandler.text;

                if(text.Contains("없음")){
                    LogInController.Option=0;
                    Debug.Log(0);
                }else if(text.Contains("오류")){
                    Debug.Log(1);
                    LogInController.Option=2;
                }else{
                    LogInController.Option=1;
                    var input=int.Parse(Regex.Replace(text, @"\D", ""));
                    PlayerPrefs.SetInt("id", input); //마이페이지에서 지금까지 적은 url을 보여주기 위해서 사용.
                }
                Debug.Log(text);
            }
        }
    }

        /*아이디 관련 php파일 연결*/
    public IEnumerator SetUser(string id,string password,string email)
    {
        string serverPath = "http://127.0.0.1/PhpFile/SetUsers.php"; //PHP 파일의 위치를 저장
        WWWForm form = new WWWForm(); //웹에 입력을 위함.
        
        form.AddField("id",id);
        form.AddField("password",password);
        form.AddField("email",email);

        using (UnityWebRequest www = UnityWebRequest.Post(serverPath,form)) //웹 서버에 요청
        {
            yield return www.SendWebRequest(); //요청이 끝날 때까지 대기 

            if(www.isNetworkError || www.isHttpError){ //서버 에러시 
                Debug.Log(www.error+" : 서버 에러입니다.");
            }else{
                if(www.downloadHandler.text.Contains("없음")){
                    SignUpController.isFailed=false;
                }else{
                    //회원 가입 불가함 !
                    var input=int.Parse(Regex.Replace(www.downloadHandler.text, @"\D", ""));
                    PlayerPrefs.SetInt("id", input);
                    SignUpController.isFailed=true;
                }
                Debug.Log(www.downloadHandler.text);
            }
        }
    }


    //Get URL

    public IEnumerator GetAllUrls(string urlid,string userid)
    {
        string serverPath = "http://127.0.0.1/PhpFile/GetAllUrls.php"; //PHP 파일의 위치를 저장
        WWWForm form = new WWWForm(); //웹에 입력을 위함.
        
        form.AddField("urlid",urlid);
        form.AddField("userid",userid);

        using (UnityWebRequest www = UnityWebRequest.Post(serverPath,form)) //웹 서버에 요청
        {
            yield return www.SendWebRequest(); //요청이 끝날 때까지 대기 

            if(www.isNetworkError || www.isHttpError){ //서버 에러시 
                Debug.Log(www.error+" : 서버 에러입니다.");
            }else{
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
