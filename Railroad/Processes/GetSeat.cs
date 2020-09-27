using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using HtmlAgilityPack;
using MahApps.Metro.Controls;
using Railroad.Beans;

namespace Railroad.Processes
{
	/// <summary>
	/// 주요 기차역 리스트 상호작용 클래스
	/// </summary>
	class GetSeat : Threader
	{
		List<ResultBean> result;

		/// <summary>
		/// GetSeat 생성자 함수
		/// </summary>
		/// 
		/// <param name="worker" type="BackgroundWorker">BackgroundWorker 객체</param>
		/// <param name="list" type="List<SeatBean>">List<SeatBean> 객체</param>
		///
		/// <returns>[void] 파라미터 객체 할당</returns>
		public GetSeat(MainWindow main, BackgroundWorker worker, List<SeatBean> list) : base(main, worker)
		{
			worker.WorkerSupportsCancellation = true;
			worker.RunWorkerAsync(list);
		}

		/// <summary>
		/// 백그라운드 실행 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="DoWorkEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 자리 확인 동작 수행</returns>
		public override void OnWork(object sender, DoWorkEventArgs e)
		{
			List<SeatBean> list = (List<SeatBean>)e.Argument;

			while (!worker.CancellationPending)
			{
				result = new List<ResultBean>();

				foreach (SeatBean bean in list)
				{
					Process(bean);
				}
			}

			Thread.Sleep(2000);
		}

		/// <summary>
		/// 진행률 갱신 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="ProgressChangedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		public override void OnChanged(object sender, ProgressChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 백그라운드 종료 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RunWorkerCompletedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		public override void OnCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			
		}

		/// <summary>
		/// 자리 확인 동작 함수
		/// </summary>
		/// 
		/// <param name="bean" type="SeatBean">SeatBean 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		private void Process(SeatBean bean)
		{
			string response = GetResponse(bean);

			// 응답이 유효할 경우
			if (response != null)
			{
				OpenResponse(bean, response);

				// UI 표현 시도
				try
				{
					main.Result.Invoke(new Action(delegate ()
					{
						main.Result.ItemsSource = result;
						main.Result.Items.Refresh();

						main.Time.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 기준";
						main.Total.Content = result.Count + "개";
					}));

					if (result.Count > 0)
					{
						SoundPlayer player = new SoundPlayer(Properties.Resources.alert);
						player.Play();
					}
				}

				// 오류
				catch (Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
		}

		/// <summary>
		/// 다음 페이지 자리 확인 동작 함수
		/// </summary>
		/// 
		/// <param name="bean" type="SeatBean">SeatBean 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		private void ProcessNext(SeatBean bean)
		{
			string response = GetResponse(bean);

			// 응답이 유효할 경우
			if (response != null)
			{
				OpenResponse(bean, response);
			}
		}

		/// <summary>
		/// 코레일 서버 통신 함수
		/// </summary>
		/// 
		/// <param name="bean" type="SeatBean">SeatBean 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		private string GetResponse(SeatBean bean)
		{
			HttpIO io = new HttpIO("http://www.letskorail.com/ebizprd/EbizPrdTicketPr21111_i1.do");

			SortedList<string, string> param = new SortedList<string, string>();
			param.Add("txtGoAbrdDt", bean.Date);
			param.Add("txtGoHour", bean.StartTime);
			param.Add("selGoYear", bean.Year.ToString("0000"));
			param.Add("selGoMonth", bean.Month.ToString("00"));
			param.Add("selGoDay", bean.Day.ToString("00"));
			param.Add("selGoHour", bean.StartHour.ToString("00"));
			param.Add("txtGoPage", "2");
			param.Add("txtGoStartCode", bean.StartCode);
			param.Add("txtGoStart", HttpUtility.UrlEncode(bean.StartStation));
			param.Add("txtGoEndCode", bean.EndCode);
			param.Add("txtGoEnd", HttpUtility.UrlEncode(bean.EndStation));
			param.Add("selGoTrain", bean.Type);
			param.Add("selGoRoom", "");
			param.Add("selGoRoom1", "");
			param.Add("txtGoTrnNo", "");
			param.Add("useSeatFlg", "");
			param.Add("useServiceFlg", "");
			param.Add("selGoSeat", "");
			param.Add("selGoService", "");
			param.Add("txtPnrNo", "");
			param.Add("hidRsvChgNo", "");
			param.Add("hidStlFlg", "");
			param.Add("radJobId", bean.Mode);
			param.Add("SeandYo", "");
			param.Add("hidRsvTpCd", "03");
			param.Add("selGoSeat1", "015");
			param.Add("selGoSeat2", "");
			param.Add("txtPsgCnt1", bean.GetPsgCount());
			param.Add("txtPsgCnt2", "0");
			param.Add("txtMenuId", "11");
			param.Add("txtPsgFlg_1", bean.Psg1.ToString());
			param.Add("txtPsgFlg_2", bean.Psg2.ToString());
			param.Add("txtPsgFlg_3", bean.Psg3.ToString());
			param.Add("txtPsgFlg_4", bean.Psg4.ToString());
			param.Add("txtPsgFlg_5", bean.Psg5.ToString());
			param.Add("txtPsgFlg_8", bean.Psg8.ToString());
			param.Add("chkCpn", "N");
			param.Add("txtSeatAttCd_4", bean.SeatOption);
			param.Add("txtSeatAttCd_3", bean.SeatType);
			param.Add("txtSeatAttCd_2", bean.SeatDirection);
			param.Add("txtGoStartCode2", "");
			param.Add("txtGoEndCode2", "");
			param.Add("hidDiscount", "");
			param.Add("hidEasyTalk", "");
			param.Add("adjcCheckYn", bean.GetNear());

			bean.Url = "http://www.letskorail.com/ebizprd/EbizPrdTicketPr21111_i1.do?" + io.MakeParam(param);

			string response = io.Get(param);

			return response;
		}

		/// <summary>
		/// 코레일 서버 응답 분석 함수
		/// </summary>
		/// 
		/// <param name="bean" type="SeatBean">SeatBean 객체</param>
		/// <param name="response" type="string">코레일 서버 응답 HTML</param>
		/// 
		/// <returns>[void] 자리 확인 결과 반영</returns>
		private void OpenResponse(SeatBean bean, string response)
		{
			HtmlDocument html = new HtmlDocument();
			html.LoadHtml(response);

			HtmlNodeCollection seats = html.DocumentNode.SelectNodes("//div[@id='divResult']/table[@id='tableResult']/tr");
			HtmlNodeCollection buttons = html.DocumentNode.SelectNodes("//div[@id='divResult']/table[@class='btn']/tr/td/a");

			// 기차역 리스트가 없을 경우
			if (seats != null)
			{
				foreach (HtmlNode seat in seats)
				{
					HtmlNodeCollection tds = seat.SelectNodes("td");
					
					// 일반실 열차의 좌석이 있을 경우
					if (tds[5].SelectSingleNode("a") != null)
					{
						// 좌석 확인 시도
						try
						{
							TimeSpan standard = new TimeSpan(bean.EndHour, bean.EndMinute, 0);
							TimeSpan target = TimeSpan.Parse(tds[2].InnerHtml.Trim().Replace("\t", "").Replace(Environment.NewLine, "").Split(new string[] { "<br>" }, StringSplitOptions.None)[1]);

							if (standard < target)
							{
								return;
							}

							ResultBean result = new ResultBean();

							result.Date = bean.Date4List;
							result.Type = tds[1].GetAttributeValue("title", "");
							result.Number = tds[1].SelectSingleNode("a").InnerText.Trim().Replace("\t", "").Replace(Environment.NewLine, "");
							result.Start = tds[2].InnerHtml.Trim().Replace("\t", "").Replace(Environment.NewLine, "").Split(new string[] { "<br>" }, StringSplitOptions.None)[0];
							result.StartTime = tds[2].InnerHtml.Trim().Replace("\t", "").Replace(Environment.NewLine, "").Split(new string[] { "<br>" }, StringSplitOptions.None)[1];
							result.End = tds[3].InnerHtml.Trim().Replace("\t", "").Replace(Environment.NewLine, "").Split(new string[] { "<br>" }, StringSplitOptions.None)[0];
							result.EndTime = tds[3].InnerHtml.Trim().Replace("\t", "").Replace(Environment.NewLine, "").Split(new string[] { "<br>" }, StringSplitOptions.None)[1];

							// 특실이 매진일 경우
							if (tds[4].SelectSingleNode("a") == null)
							{
								result.First = "매진";
							}

							// 특실이 있을 경우
							else
							{
								result.First = tds[4].SelectNodes("a")[0].SelectSingleNode("img").GetAttributeValue("alt", "");
							}

							result.Eco = tds[5].SelectNodes("a")[0].SelectSingleNode("img").GetAttributeValue("alt", "");

							// 경유지가 없을 경우
							if (tds[9].SelectSingleNode("img") == null)
							{
								result.Via = "-";
							}

							// 경유지가 있을 경우
							else
							{
								result.Via = tds[9].SelectSingleNode("img").GetAttributeValue("alt", "").Replace(Environment.NewLine, ":");
							}

							result.Time = tds[12].InnerHtml.Trim().Replace("\t", "").Replace(Environment.NewLine, "");
							result.Url = bean.Url;

							this.result.Add(result);
						}

						// 오류
						catch (Exception e)
						{
							Console.WriteLine(e.StackTrace);
						}
					}
				}

				string button = buttons[1].InnerText;

				// 다음 리스트가 있을 경우
				if (button.Equals(""))
				{
					SeatBean next = bean.Clone();

					Regex reg = new Regex(@"[']([0-9]{1,6})[']");

					MatchCollection collection = reg.Matches(buttons[1].GetAttributeValue("href", ""));

					string str = collection[0].Groups[1].Value;

					TimeSpan timeSpan = new TimeSpan(int.Parse(str.Substring(0, 2)), int.Parse(str.Substring(2, 2)) + 1, int.Parse(str.Substring(4, 2)));

					next.StartHour = timeSpan.Hours;
					next.StartMinute = timeSpan.Minutes;

					ProcessNext(next);
				}
			}
		}
	}
}