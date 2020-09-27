using System.Collections.Generic;

namespace Railroad
{
	/// <summary>
	/// StationList에 대한 상호 작용 논리
	/// </summary>
	class StationList
	{
		private static readonly StationList Instance = new StationList();

		/// <summary>
		/// 기차역 리스트 get/set 함수
		/// </summary>
		public List<StationBean> List
		{
			get;
			set;
		}

		/// <summary>
		/// StationList 객체 반환 함수
		/// </summary>
		/// 
		/// <returns>[StationList] StationList 싱글톤 인스턴스</returns>
		public static StationList GetInstance()
		{
			return Instance;
		}
	}
}