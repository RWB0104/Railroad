using System.Text;

namespace Railroad.Beans
{
	/// <summary>
	/// 좌석 객체 클래스
	/// </summary>
	class SeatBean
	{
		/// <summary>
		/// SeatBean 객체 복제 함수
		/// </summary>
		/// 
		/// <returns>[SeatBean] 현재 SeatBean 객체</returns>
		public SeatBean Clone()
		{
			SeatBean bean = new SeatBean();
			bean.Year = Year;
			bean.Month = Month;
			bean.Day = Day;
			bean.StartHour = StartHour;
			bean.StartMinute = StartMinute;
			bean.EndHour = EndHour;
			bean.EndMinute = EndMinute;
			bean.StartStation = StartStation;
			bean.StartCode = StartCode;
			bean.EndStation = EndStation;
			bean.EndCode = EndCode;
			bean.Type = Type;
			bean.Mode = Mode;
			bean.Near = Near;
			bean.Psg1 = Psg1;
			bean.Psg2 = Psg2;
			bean.Psg3 = Psg3;
			bean.Psg4 = Psg4;
			bean.Psg5 = Psg5;
			bean.Psg8 = Psg8;
			bean.SeatType = SeatType;
			bean.SeatDirection = SeatDirection;
			bean.SeatOption = SeatOption;
			bean.Url = Url;

			return bean;
		}

		/// <summary>
		/// 년도 get/set 함수
		/// </summary>
		public int Year
		{
			get;
			set;
		}

		/// <summary>
		/// 월 get/set 함수
		/// </summary>
		public int Month
		{
			get;
			set;
		}

		/// <summary>
		/// 일 get/set 함수
		/// </summary>
		public int Day
		{
			get;
			set;
		}

		/// <summary>
		/// 구간 시작 시 get/set 함수
		/// </summary>
		public int StartHour
		{
			get;
			set;
		}

		/// <summary>
		/// 구간 시작 분 get/set 함수
		/// </summary>
		public int StartMinute
		{
			get;
			set;
		}

		/// <summary>
		/// 구간 종료 시 get/set 함수
		/// </summary>
		public int EndHour
		{
			get;
			set;
		}

		/// <summary>
		/// 구간 종료 분 get/set 함수
		/// </summary>
		public int EndMinute
		{
			get;
			set;
		}

		/// <summary>
		/// 출발역 get/set 함수
		/// </summary>
		public string StartStation
		{
			get;
			set;
		}

		/// <summary>
		/// 출발역 코드 get/set 함수
		/// </summary>
		public string StartCode
		{
			get;
			set;
		}

		/// <summary>
		/// 도착역 get/set 함수
		/// </summary>
		public string EndStation
		{
			get;
			set;
		}

		/// <summary>
		/// 도착역 코드 get/set 함수
		/// </summary>
		public string EndCode
		{
			get;
			set;
		}

		/// <summary>
		/// 열차 종류 get/set 함수
		/// </summary>
		public string Type
		{
			get;
			set;
		}

		/// <summary>
		/// 여정 종류 get/set 함수
		/// </summary>
		public string Mode
		{
			get;
			set;
		}

		/// <summary>
		/// 인접역 포함 여부 get/set 함수
		/// </summary>
		public bool Near
		{
			get;
			set;
		}

		/// <summary>
		/// 어른 get/set 함수
		/// </summary>
		public int Psg1
		{
			get;
			set;
		}

		/// <summary>
		/// 초등학생 get/set 함수
		/// </summary>
		public int Psg2
		{
			get;
			set;
		}

		/// <summary>
		/// 노약자 get/set 함수
		/// </summary>
		public int Psg3
		{
			get;
			set;
		}

		/// <summary>
		/// 중증 장애 get/set 함수
		/// </summary>
		public int Psg4
		{
			get;
			set;
		}

		/// <summary>
		/// 경증 장애 get/set 함수
		/// </summary>
		public int Psg5
		{
			get;
			set;
		}

		/// <summary>
		/// 아동 get/set 함수
		/// </summary>
		public int Psg8
		{
			get;
			set;
		}

		/// <summary>
		/// 좌석 종류 get/set 함수
		/// </summary>
		public string SeatType
		{
			get;
			set;
		}

		/// <summary>
		/// 좌석 방향 get/set 함수
		/// </summary>
		public string SeatDirection
		{
			get;
			set;
		}

		/// <summary>
		/// 좌석 옵션 get/set 함수
		/// </summary>
		public string SeatOption
		{
			get;
			set;
		}

		/// <summary>
		/// URL get/set 함수
		/// </summary>
		public string Url
		{
			get;
			set;
		}

		/// <summary>
		/// 시작 날짜 문자열 get 함수
		/// </summary>
		/// 
		/// <returns>[string] 시작 날짜 문자열</returns>
		public string Date
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(Year.ToString("0000"));
				builder.Append(Month.ToString("00"));
				builder.Append(Day.ToString("00"));

				string date = builder.ToString();

				return date;
			}
		}

		/// <summary>
		/// 리스트용 시작 날짜 문자열 get 함수
		/// </summary>
		/// 
		/// <returns>[string] 리스트용 시작 날짜 문자열</returns>
		public string Date4List
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(Year.ToString("0000"));
				builder.Append("-");
				builder.Append(Month.ToString("00"));
				builder.Append("-");
				builder.Append(Day.ToString("00"));

				string date = builder.ToString();

				return date;
			}
		}

		/// <summary>
		/// 시작 시간 문자열 get 함수
		/// </summary>
		/// 
		/// <returns>[string] 시작 시간 문자열</returns>
		public string StartTime
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(StartHour.ToString("00"));
				builder.Append(StartMinute.ToString("00"));
				builder.Append("00");

				string time = builder.ToString();

				return time;
			}
		}

		/// <summary>
		/// 리스트용 시작 시간 문자열 get 함수
		/// </summary>
		/// 
		/// <returns>[string] 리스트용 시작 시간 문자열</returns>
		public string StartTime4List
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(StartHour.ToString("00"));
				builder.Append(":");
				builder.Append(StartMinute.ToString("00"));

				string time = builder.ToString();

				return time;
			}
		}

		/// <summary>
		/// 리스트용 종료 시간 문자열 get 함수
		/// </summary>
		/// 
		/// <returns>[string] 리스트용 종료 시간 문자열</returns>
		public string EndTime4List
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				builder.Append(EndHour.ToString("00"));
				builder.Append(":");
				builder.Append(EndMinute.ToString("00"));

				string time = builder.ToString();

				return time;
			}
		}

		/// <summary>
		/// 시간 요소 할당 함수
		/// </summary>
		/// 
		/// <param name="Year" type="int">년</param>
		/// <param name="Month" type="int">월</param>
		/// <param name="Day" type="int">일</param>
		/// <param name="StartHour" type="int">구간 시작 시간</param>
		/// <param name="StartMinute" type="int">구간 시작 분</param>
		/// <param name="EndHour" type="int">구간 종료 시간</param>
		/// <param name="EndMinute" type="int">구간 종료 분</param>
		/// 
		/// <returns>[void] 클래스의 시간 요소들에 값 할당</returns>
		public void SetDateTime(int Year, int Month, int Day, int StartHour, int StartMinute, int EndHour, int EndMinute)
		{
			this.Year = Year;
			this.Month = Month;
			this.Day = Day;
			this.StartHour = StartHour;
			this.StartMinute = StartMinute;
			this.EndHour = EndHour;
			this.EndMinute = EndMinute;
		}

		/// <summary>
		/// 역 할당 함수
		/// </summary>
		/// 
		/// <param name="StartStation" type="string">출발역</param>
		/// <param name="StartCode" type="string">출발역 코드</param>
		/// <param name="EndStation" type="string">도착역</param>
		/// <param name="EndCode" type="string">도착역 코드</param>
		/// 
		/// <returns>[void] 클래스의 역 요소들에 값 할당</returns>
		public void SetStation(string StartStation, string StartCode, string EndStation, string EndCode)
		{
			this.StartStation = StartStation;
			this.StartCode = StartCode;
			this.EndStation = EndStation;
			this.EndCode = EndCode;
		}

		/// <summary>
		/// 기차 옵션 할당 함수
		/// </summary>
		/// 
		/// <param name="Type" type="string">기차 종류</param>
		/// <param name="Mode" type="string">여정 종류</param>
		/// <param name="Near" type="string">인접역 포함 여부</param>
		/// 
		/// <returns>[void] 클래스의 역 옵션 요소들에 값 할당</returns>
		public void SetTrainOption(string Type, string Mode, bool Near)
		{
			this.Type = Type;
			this.Mode = Mode;
			this.Near = Near;
		}

		/// <summary>
		/// 좌석 옵션 할당 함수
		/// </summary>
		/// 
		/// <param name="SeatType" type="string">좌석 종류</param>
		/// <param name="SeatDirection" type="string">좌석 방향</param>
		/// <param name="SeatOption" type="string">좌석 옵션</param>
		/// 
		/// <returns>[void] 클래스의 좌석 옵션 요소들에 값 할당</returns>
		public void SetSeatOption(string SeatType, string SeatDirection, string SeatOption)
		{
			this.SeatType = SeatType;
			this.SeatDirection = SeatDirection;
			this.SeatOption = SeatOption;
		}

		/// <summary>
		/// 승객 할당 함수
		/// </summary>
		/// 
		/// <param name="Psg1" type="int">어른</param>
		/// <param name="Psg2" type="int">초등학생</param>
		/// <param name="Psg3" type="int">노약자</param>
		/// <param name="Psg4" type="int">중증 장애</param>
		/// <param name="Psg5" type="int">경증 장애</param>
		/// <param name="Psg8" type="int">유아</param>
		/// 
		/// <returns>[void] 클래스의 승객 요소들에 값 할당</returns>
		public void SetPassenger(int Psg1, int Psg2, int Psg3, int Psg4, int Psg5, int Psg8)
		{
			this.Psg1 = Psg1;
			this.Psg2 = Psg2;
			this.Psg3 = Psg3;
			this.Psg4 = Psg4;
			this.Psg5 = Psg5;
			this.Psg8 = Psg8;
		}

		/// <summary>
		/// 승객 전체 수 반환 함수
		/// </summary>
		/// 
		/// <returns>[string] 승객 전체 수</returns>
		public string GetPsgCount()
		{
			string count = (Psg1 + Psg2 + Psg3 + Psg4 + Psg5 + Psg8).ToString();

			return count;
		}

		/// <summary>
		/// 인접역 포함 여부 문자열 반환 함수
		/// </summary>
		/// 
		/// <returns>[string] 인접역 포함 여부 문자열</returns>
		public string GetNear()
		{
			string near;

			if (Near)
			{
				near = "Y";
			}

			else
			{
				near = "N";
			}

			return near;
		}
	}
}