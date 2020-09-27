using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Railroad
{
	/// <summary>
	/// 주요 기차역 리스트 상호작용 클래스
	/// </summary>
	class GetStationList : Threader
	{
		/// <summary>
		/// GetStationList 생성자 함수
		/// </summary>
		/// 
		/// <param name="worker" type="BackgroundWorker">BackgroundWorker 객체</param>
		/// 
		/// <returns>[void] 백그라운드 작업 실행</returns>
		public GetStationList(BackgroundWorker worker) : base(worker)
		{
			worker.RunWorkerAsync();
		}

		/// <summary>
		/// 백그라운드 동작 함수
		/// </summary>
		/// 
		/// <param name="e" type="object">이벤트 발생 객체</param>
		/// <param name="sender" type="DoWorkEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 백그라운드 동작 수행</returns>
		public override void OnWork(object sender, DoWorkEventArgs e)
		{
			HttpIO io = new HttpIO("http://www.letskorail.com/ebizprd/EbizPrdTicketPr11100/searchTnCode.do");

			SortedList<string, string> param = new SortedList<string, string>();
			param.Add("hidOpener", "txtGoStart");

			string response = io.Get(param);

			e.Result = response;
		}

		/// <summary>
		/// 백그라운드 진행 갱신 함수
		/// </summary>
		/// 
		/// <param name="e" type="object">이벤트 발생 객체</param>
		/// <param name="sender" type="ProgressChangedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 백그라운드 진행 갱신</returns>
		public override void OnChanged(object sender, ProgressChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 백그라운드 종료 함수
		/// </summary>
		/// 
		/// <param name="e" type="object">이벤트 발생 객체</param>
		/// <param name="sender" type="RunWorkerCompletedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 백그라운드 종료</returns>
		public override void OnCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// 에러가 없을 경우
			if (e.Error == null)
			{
				string result = e.Result.ToString();

				HtmlDocument html = new HtmlDocument();
				html.LoadHtml(result);

				HtmlNodeCollection stations = html.DocumentNode.SelectNodes("//div[@class='cont']/table[@class='tbl_b_no']/tbody/tr");

				// 기차역 리스트가 없을 경우
				if (stations != null)
				{
					List<StationBean> list = new List<StationBean>();

					foreach (HtmlNode station in stations)
					{
						HtmlNodeCollection tds = station.SelectNodes("td");

						foreach (HtmlNode td in tds)
						{
							string href = td.SelectSingleNode("a").GetAttributeValue("href", "").Trim();

							Regex reg = new Regex(@"['](.*?)[']");

							MatchCollection collection = reg.Matches(href);

							StationBean bean = new StationBean();
							bean.Name = collection[0].Groups[1].Value;
							bean.Number = collection[1].Groups[1].Value;

							list.Add(bean);
						}
					}

					StationList stationList = StationList.GetInstance();
					stationList.List = list;
				}
			}
		}
	}
}