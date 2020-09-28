# Railroad

<p align="center">
	<img src="https://user-images.githubusercontent.com/50317129/94445356-4f52df80-01e2-11eb-987a-55172f78d769.png" width="256" height="256" alt="EasyReport" title="EasyReport">
</p>

<p align="center">
	Icons made by <a href="https://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>
</p>

<br />
<br />
<br />

<p align="center">
	코레일 열차 자리확인 프로그램
</p>

<p align="center">
	<i>Follow the cancelled Trail</i>
</p>

<p align="center">
	<a href="https://github.com/RWB0104/Railroad/releases">최신버전 다운로드</a>
</p>

# INFO

개발언어 : `C#`

#### 지원 OS
+ Microsoft **Windows10**

#### Framework
+ **.NET Framework 4.7.2**
+ **MahApps.Metro**
+ **MahApps.Metro.IconPacks**
+ **Fody**
+ **HtmlAgilityPack**

<br />
<br />

# RELEASE

## Ubitor 1.0.0 RELEASE

:calendar: 2020.09.28 금요일

+ 지정한 조건에 일치하는 열차의 자리 확인 및 알림 기능
+ 출발, 도착역, 시간, 좌석 등 코레일 열차 조회 시스템과 유사한 조건 검색 지원
+ 직통 열차 방식만 지원
+ 코레일에서 제공하는 주요역에 대한 리스트 기본 제공
+ 다수의 조건에 대한 자리확인 지원
+ DLL 포함 빌드

<br />
<br />

# 사용 방법

<p align="center">
	<img src="https://user-images.githubusercontent.com/50317129/94446879-27fd1200-01e4-11eb-9322-9c2dda56de97.png" width="80%" alt="EasyReport" title="EasyReport">
</p>

1. 역 정보 지정 (리스트에 없을 경우 수기 입력도 가능)
2. 열차 정보 및 시간 지정
3. 좌석 정보 지정
4. 인원 수 지정 (최대 9명)
5. [+] 버튼을 클릭하여 해당 조건 추가 (다수 조건 추가 가능)
6. 우측 하단의 실행 버튼을 클릭하여 자리확인 동작 수행
7. 저리가 있을 경우 하단의 리스트에 해당 열차의 정보 출력
8. 해당 정보를 더블클릭하면 Korail 승차권 조회 페이지로 이동

<br />
<br />

# 여담

MahApps를 이용한 토이 프로젝트 두 번째. MahApps는 할 때마다 느끼지만, 관련 래퍼런스가 너무 부실하다. 옆 동네 웹의 Bootstrap이나 Semantic UI 처럼 래퍼런스와 예제 좀 제대로 줄 순 없는건가. 공식 홈페이지에서 구한 샘플 프로그램을 이용하여 원하는 컨트롤이 있을 때마다 분석하여 적용하고 있다. WPF도 웹처럼 커스터마이징의 여지가 많은 것 같은데, XAML이 하도 난해해서 뭘 하기가 좀 꺼려진다. 원리를 이해하면 원하는 방식으로 컨트롤를 커스텀하기 용이할 것 같긴 한데...
<br />
명절땐 기차는 경쟁률이 너무 빡세서, 보통 고속버스를 애용한다. 도로의 변수 유발 확률과 명절이라는 이벤트가 겹쳐서 제 시간에 도착하길 바라는 건 사실 사치에 가깝다. 성격 상 그려려니 하곤 하는데, 저번 설날엔 설 전날 저녁에 갔다가 버스 전용차로 끊김 + 신입 기사님의 크리로 원래 걸리던 시간의 3배가 걸려서야 겨우 도착했었다. 터미널 앞에서 주차장 위치를 몰라 20분 가까이를 뱅뱅 돌던걸 보면서 비상용 망치로 차 창문을 깨고 탈출하고 싶다는 생각이 간절했다. 아님 쉽고 빠르게 그냥 내 머리를 깨던가.
<br />

이번엔 그 고생하기 싫어서 만들었다. 예전에 KorCham 매크로 만들었을 땐, 괜히 JAVA로 했다가 UX 개판난게 못내 아쉬워서 요번에는 C#으로 짰다. Mahapp이라는 좋은 장난감이 있기도 했고. 확실히 컨트롤이다 스레드다 UI다 뭐다 해서 배보다 배꼽이 더 커지는 건 어쩔 수 없는 것 같다.
<br />
이런 프로그램이 으레 그렇듯이 저번처럼 여기저기 배포해봤자 딱히 좋을 것도 없을 것 같고. 그냥 나만 조용히 쓸 생각이다. 확실히 표는 쉽게 잡았다. 사람들 경쟁이 치열하다는 걸 알 수 있기도 했고. 표가 생긴지 10초도 안 돼서 나가더라. 나처럼 이런걸 만든 사람이 또 있는건가?
<br />

혹시라도 기차표가 간절한데 이 글을 보고 있다면, 축하한다. 이 프로그램은 네게 많은 도움이 될 것이다. **부디 제발 악용만 하지 말기를.**


<br />
<br />

그나저나 코레일의 열차 페이지 조회 로직은 정말 처참한 것 같다. 덕분에 고생 좀 했다. 해당하는 조건의 열차 전체를 API로 받아와서 AJAX 처리하는 게 더 낫지 않나? 뭐, 외부인은 모르는 나름의 사정이 있겠지...