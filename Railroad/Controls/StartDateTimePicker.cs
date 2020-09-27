using MahApps.Metro.Controls;

namespace Railroad.Controls
{
	/// <summary>
	/// DateTimePicker 커스텀 컨트롤 클래스
	/// </summary>
	class StartDateTimePicker : DateTimePicker
	{
		/// <summary>
		/// 텍스트 반환 오버라이딩 함수
		/// </summary>
		/// 
		/// <returns>[string] yyyy-MM-dd HH:mm 형식의 시간 문자열</returns>
		protected override string GetValueForTextBox()
		{
			return SelectedDateTime?.ToString("yyyy-MM-dd HH:mm");
		}
	}
}