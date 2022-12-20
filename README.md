# WinterDevCamp

## 프로젝트에 대한 개요
0.  URLshortener 
알고리즘 구현 </br>
1. URL의 결과값이 8글자 이내, 도메인은 localhost로 처리
2. URL Shortening URL을 입력하면 원래 URL로 리다이렉트
3. 데이터베이스에 저장된 정수 ID를 사용하고 정수를 최대 6자 길이의 문자열로 변환하는 것입니다. 이 문제는 기본적으로 10자리 입력 숫자가 있고 이를 6자 길이의 문자열로 변환하려는 기본 변환 문제로 볼 수 있습니다. 

구현 했던 방법 </br>
방법 :  짧은 6자로 변환하는 시스템을 설계하는 방법.
긴 URL도 짧은 URL에서 고유하게 식별할 수 있어야한다. ->  Bijective Function (일대일 대응 함수)

여기서 문제, 
-> 긴 URL == 짧은 URL 동일할 경우가 분명히 발생
-> 데이터베이스에 저장된 정수 ID를 사용해서, 그 정수로 해시를 진행

URL 문자는
1. 소문자 [‘a’~’z’], 총 26자
2. 영문 대문자 [‘A’~’Z’], 총 26자
3. 숫자 [‘0’~’9’], 총 10자

즉, 26+26+10=62 글자를 이용해 문자를 구현.
10진수를 62진수로 변환하는 방법

-> 즉 base62 기법을 이용한 알고리즘 작성 법 !
</br>

1. 회원가입
<img width="500" alt="스크린샷 2022-12-20 오후 2 31 19" src="https://user-images.githubusercontent.com/81684148/208592575-8ba45f48-4f03-4cdd-9e4b-0a90a8e1e058.png">


2. 로그인
<img width="500" alt="스크린샷 2022-12-20 오후 2 34 53" src="https://user-images.githubusercontent.com/81684148/208592644-e63916f1-1367-467d-8989-49657ca7b2c8.png">


3. URL Shortener
<img width="500" alt="스크린샷 2022-12-20 오후 2 42 26" src="https://user-images.githubusercontent.com/81684148/208592692-46ecaa95-6424-437d-9fbd-d49a1b6aa84b.png">
<img width="500" alt="스크린샷 2022-12-20 오후 2 42 36" src="https://user-images.githubusercontent.com/81684148/208592697-7d9a9d1f-c399-4453-bf43-7809e86f8df4.png">


## 기술 스택
Unity - c# </br>
Apache - Php </br>
Mysql 

## 코드 중 확인받고 싶은 부분
0. URL Shortener 을 구현하기 위해서 Base62 알고리즘을 사용했는데, 이 알고리즘 사용하는 것이 맞는지 (TransformerController.cs 파일)
1. 

## 개발관련 과정에서 궁금했던 부분
0. 실제 게임회사에서 데이터 보관 방법, php파일을 이용해 mysql로 데이터를 이동시키면 해킹 당할 확률이 높지 않나요?
1. 
