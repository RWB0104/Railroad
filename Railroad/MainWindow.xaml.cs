using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Railroad.Beans;
using Railroad.Processes;

namespace Railroad
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		List<SeatBean> list = new List<SeatBean>();
		BackgroundWorker worker;

		/// <summary>
		/// MainWindow 생성자 함수
		/// </summary>
		/// 
		/// <returns>[void] Form 초기화</returns>
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// MainWindow 로딩 후 이벤트 함수
		/// </summary>
		/// 
		/// <param name="e" type="object">이벤트 발생 객체</param>
		/// <param name="sender" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] Form 초기화</returns>
		private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
		{
			StationList stationList = StationList.GetInstance();

			List<StationBean> list = stationList.List;

			// 리스트가 유효하지 않을 경우
			if (list == null)
			{
				this.ShowModalMessageExternal("Error", "주요역 리스트를 불러올 수 없습니다.\n코레일 홈페이지 서버가 응답하지 않거나 네트워크 문제일 수 있습니다.");

				Close();
			}

			// 리스트가 유효할 경우
			else
			{
				foreach (StationBean bean in list)
				{
					Start.Items.Add(bean);
					End.Items.Add(bean);
				}
			}

			StartDate.SelectedDateTime = DateTime.Now;
		}

		/// <summary>
		/// Github 버튼 클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] Github 홈페이지 리다이렉트</returns>
		private void GitHub_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("https://github.com/RWB0104/Railroad");
		}

		/// <summary>
		/// 출발역 선택 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="SelectionChangedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 출발역 코드에 코드 입력</returns>
		private void Start_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			StationBean bean = (StationBean)Start.SelectedItem;

			// 임의의 값을 입력할 경우
			if (bean == null)
			{
				StartCode.Text = "";
			}

			// 정해진 값을 선택할 경우
			else
			{
				StartCode.Text = bean.Number;
			}
		}

		/// <summary>
		/// 도착역 선택 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="SelectionChangedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 도착역 코드에 코드 입력</returns>
		private void End_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			StationBean bean = (StationBean)End.SelectedItem;

			// 임의의 값을 입력할 경우
			if (bean == null)
			{
				EndCode.Text = "";
			}

			// 정해진 값을 선택할 경우
			else
			{
				EndCode.Text = bean.Number;
			}
		}

		/// <summary>
		/// 매크로 실행 버튼 클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 매크로 동작</returns>
		private void Execute_Click(object sender, RoutedEventArgs e)
		{
			// 리스트에 데이터가 없을 경우
			if (list.Count <= 0)
			{
				this.ShowModalMessageExternal("Error", "하나 이상의 타겟을 지정해주세요.");
			}

			// 리스트에 데이터가 있을 경우
			else
			{
				Result.ItemsSource = null;
				Result.Items.Refresh();

				List<SeatBean> list = this.list.ToList();

				worker = new BackgroundWorker();

				new GetSeat(this, worker, list);

				Execute.Visibility = Visibility.Collapsed;
				Stop.Visibility = Visibility.Visible;
			}
		}

		/// <summary>
		/// 매크로 동작 종료 버튼 클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 매크로 동작 종료</returns>
		private void Stop_Click(object sender, RoutedEventArgs e)
		{
			worker.CancelAsync();
			worker = null;

			Execute.Visibility = Visibility.Visible;
			Stop.Visibility = Visibility.Collapsed;
		}

		/// <summary>
		/// 매크로 확인 대상 추가 버튼 클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 대상 추가</returns>
		private void Add_Click(object sender, RoutedEventArgs e)
		{
			int count = (int)(Psg1.Value + Psg2.Value + Psg3.Value + Psg4.Value + Psg5.Value + Psg8.Value);

			// 총 인원이 9명을 초과할 경우
			if (count > 9)
			{
				this.ShowModalMessageExternal("Error", "최대 9명의 좌석까지만 조회됩니다.\n(코레일 정책)");
			}

			// 총 인원이 1명 미만일 경우
			else if (count < 1)
			{
				this.ShowModalMessageExternal("Error", "최소 한 명의 인원이 필요합니다.");
			}

			// 모든 조건을 만족할 경우
			else
			{
				int year = StartDate.SelectedDateTime.GetValueOrDefault().Year;
				int month = StartDate.SelectedDateTime.GetValueOrDefault().Month;
				int day = StartDate.SelectedDateTime.GetValueOrDefault().Day;

				int startHour = StartDate.SelectedDateTime.GetValueOrDefault().Hour;
				int startMinute = StartDate.SelectedDateTime.GetValueOrDefault().Minute;

				int endHour = EndTime.SelectedDateTime.GetValueOrDefault().Hour;
				int endMinute = EndTime.SelectedDateTime.GetValueOrDefault().Minute;

				SeatBean bean = new SeatBean();
				bean.SetDateTime(year, month, day, startHour, startMinute, endHour, endMinute);
				bean.SetStation(Start.Text, StartCode.Text, End.Text, EndCode.Text);
				bean.SetTrainOption("05", "1", Near.IsChecked.GetValueOrDefault());
				bean.SetPassenger((int)Psg1.Value, (int)Psg2.Value, (int)Psg3.Value, (int)Psg4.Value, (int)Psg5.Value, (int)Psg8.Value);

				list.Add(bean);
				Target.ItemsSource = list;
				Target.Items.Refresh();
			}
		}

		/// <summary>
		/// 매크로 확인 대상 제거 버튼 클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 선택한 대상 제거</returns>
		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			// 현재 선택된 리스트 요소가 유효할 경우
			if (Target.SelectedIndex > -1)
			{
				list.RemoveAt(Target.SelectedIndex);

				Target.ItemsSource = list;
				Target.Items.Refresh();
			}
		}

		/// <summary>
		/// 매크로 확인 대상 전체 제거 버튼 클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RoutedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 선택한 대상 전체 제거</returns>
		private void Clean_Click(object sender, RoutedEventArgs e)
		{
			list.Clear();

			Target.ItemsSource = list;
			Target.Items.Refresh();
		}

		/// <summary>
		/// 결과 행 더블클릭 이벤트 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="MouseButtonEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 해당하는 웹페이지 출력</returns>
		private void Result_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// 선택한 대상이 하나일 경우
			if (Result.SelectedItems.Count == 1)
			{
				Process.Start(((ResultBean)Result.SelectedItem).Url);
			}
		}
	}
}