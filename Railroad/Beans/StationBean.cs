namespace Railroad
{
	/// <summary>
	/// 주요 기차역 객체 클래스
	/// </summary>
	class StationBean : object
	{
		/// <summary>
		/// 역 이름 get/set 함수
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 역 번호 get/set 함수
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// ToString() 메서드 오버라이딩 함수
		/// </summary>
		/// 
		/// <returns>[string] name 객체 반환</returns>
		public override string ToString()
		{
			return Name;
		}
	}
}