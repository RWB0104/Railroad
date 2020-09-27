using System;
using System.ComponentModel;
using System.Windows;

namespace Railroad
{
	/// <summary>
	/// Splash.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class Splash : Window
	{
		/// <summary>
		/// Splash 생성자 함수
		/// </summary>
		/// 
		/// <returns>[void] Form 초기화</returns>
		public Splash()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Splash 로딩 완료 이벤트 함수
		/// </summary>
		/// 
		/// <returns>[void] 로딩 완료 후 동작 수행</returns>
		private void SplashForm_Loaded(object sender, RoutedEventArgs e)
		{
			new GetStationList(new BackgroundWorker());
		}

		/// <summary>
		/// FadeOut 애니메이션 종료 이벤트 함수
		/// </summary>
		/// 
		/// <returns>[void] 폼 종료</returns>
		private void FormFadeOut_Completed(object sender, EventArgs e)
		{
			Close();
		}
	}
}