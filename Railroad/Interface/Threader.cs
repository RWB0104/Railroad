using System.ComponentModel;

namespace Railroad
{
	/// <summary>
	/// 스레드 클래스
	/// </summary>
	abstract class Threader
	{
		protected MainWindow main;
		protected BackgroundWorker worker;

		/// <summary>
		/// Threader 생성자 함수
		/// </summary>
		/// 
		/// <param name="worker" type="BackgroundWorker">BackgroundWorker 객체</param>
		/// 
		/// <returns>[void] Threader 초기화</returns>
		public Threader(BackgroundWorker worker)
		{
			this.worker = worker;

			worker.DoWork += new DoWorkEventHandler(DoWork);
			worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
		}

		/// <summary>
		/// Threader 생성자 함수
		/// </summary>
		/// 
		/// <param name="main" type="MainWindow">MetroWindow 객체</param>
		/// <param name="worker" type="BackgroundWorker">BackgroundWorker 객체</param>
		/// 
		/// <returns>[void] Threader 초기화</returns>
		public Threader(MainWindow main, BackgroundWorker worker)
		{
			this.main = main;
			this.worker = worker;

			worker.DoWork += new DoWorkEventHandler(DoWork);
			worker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
		}

		/// <summary>
		/// 백그라운드 실행 추상 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="DoWorkEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		public abstract void OnWork(object sender, DoWorkEventArgs e);

		/// <summary>
		/// 진행률 갱신 추상 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="ProgressChangedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		public abstract void OnChanged(object sender, ProgressChangedEventArgs e);

		/// <summary>
		/// 백그라운드 종료 추상 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RunWorkerCompletedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] 내부 함수 수행</returns>
		public abstract void OnCompleted(object sender, RunWorkerCompletedEventArgs e);

		/// <summary>
		/// 백그라운드 실행 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="DoWorkEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] onWork 함수 실행</returns>
		private void DoWork(object sender, DoWorkEventArgs e)
		{
			OnWork(sender, e);
		}

		/// <summary>
		/// 진행률 갱신 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="ProgressChangedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] onChanged 함수 실행</returns>
		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			OnChanged(sender, e);
		}

		/// <summary>
		/// 백그라운드 종료 함수
		/// </summary>
		/// 
		/// <param name="sender" type="object">이벤트 발생 객체</param>
		/// <param name="e" type="RunWorkerCompletedEventArgs">이벤트 객체</param>
		/// 
		/// <returns>[void] onCompleted 함수 실행</returns>
		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			OnCompleted(sender, e);
		}
	}
}