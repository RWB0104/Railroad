using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Railroad
{
	/// <summary>
	/// HTTP 통신 클래스
	/// </summary>
	class HttpIO
	{
		private string url;

		/// <summary>
		/// HttpIO 생성자 함수
		/// </summary>
		/// 
		/// <returns>[void] HttpIO 초기화</returns>
		public HttpIO(string url)
		{
			this.url = url;
		}

		/// <summary>
		/// HTTP GET 요청 함수
		/// </summary>
		/// 
		/// <returns>[string] HTTP 응답</returns>
		public string Get()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.UserAgent = "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:35.0) Gecko/20100101 Firefox/35.0";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			string result;

			// 응답코드 200
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream input = response.GetResponseStream();

				StreamReader reader = new StreamReader(input);

				result = reader.ReadToEnd();
			}

			// 그 이외의 응답코드
			else
			{
				result = null;
			}

			return result;
		}

		/// <summary>
		/// HTTP GET 요청 함수
		/// </summary>
		/// 
		/// <param name="param" type="SortedList<string, string>">파리미터 리스트</param>
		/// 
		/// <returns>[string] HTTP 응답</returns>
		public string Get(SortedList<string, string> param)
		{
			StringBuilder builder = new StringBuilder(url);
			builder.Append("?");
			builder.Append(MakeParam(param));

			url = builder.ToString();
			
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.UserAgent = "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:35.0) Gecko/20100101 Firefox/35.0";
			
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			string result;

			// 응답코드 200
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream input = response.GetResponseStream();

				StreamReader reader = new StreamReader(input);

				result = reader.ReadToEnd();
			}

			// 그 이외의 응답코드
			else
			{
				result = null;
			}

			return result;
		}

		/// <summary>
		/// HTTP POST 요청 함수
		/// </summary>
		/// 
		/// <returns>[string] HTTP 응답</returns>
		public string Post()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.UserAgent = "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:35.0) Gecko/20100101 Firefox/35.0";

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			string result;

			// 응답코드 200
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream input = response.GetResponseStream();

				StreamReader reader = new StreamReader(input);

				result = reader.ReadToEnd();
			}

			// 그 이외의 응답코드
			else
			{
				result = null;
			}

			return result;
		}

		/// <summary>
		/// HTTP POST 요청 함수
		/// </summary>
		/// 
		/// <param name="param" type="SortedList<string, string>">파리미터 리스트</param>
		/// 
		/// <returns>[string] HTTP 응답</returns>
		public string Post(SortedList<string, string> param)
		{
			byte[] paramBytes = Encoding.UTF8.GetBytes(MakeParam(param));

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = paramBytes.Length;
			request.UserAgent = "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:35.0) Gecko/20100101 Firefox/35.0";

			Stream paramStream = request.GetRequestStream();
			paramStream.Write(paramBytes, 0, paramBytes.Length);
			paramStream.Close();

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			string result;

			// 응답코드 200
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream input = response.GetResponseStream();

				StreamReader reader = new StreamReader(input);

				result = reader.ReadToEnd();
			}

			// 그 이외의 응답코드
			else
			{
				result = null;
			}

			return result;
		}

		/// <summary>
		/// 파라미터 URL 문자열 변환 함수
		/// </summary>
		/// 
		/// <param name="param" type="SortedList<string, string>">파리미터 리스트</param>
		/// 
		/// <returns>[string] URL 파라미터 형식 문자열</returns>
		public string MakeParam(SortedList<string, string> param)
		{
			StringBuilder builder = new StringBuilder();

			foreach (KeyValuePair<string, string> key in param)
			{
				builder.Append("&");
				builder.Append(key.Key);
				builder.Append("=");
				builder.Append(key.Value);
			}

			string url = builder.ToString().Substring(1, builder.ToString().Length - 1);

			return url;
		}
	}
}