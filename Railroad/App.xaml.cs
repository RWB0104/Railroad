using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Railroad
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// 프로그램 시작 오버라이딩 함수
		/// </summary>
		/// 
		/// <returns>[void] 프로그램 시작</returns>
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Splash splash = new Splash();

			MainWindow = splash;
			splash.Show();

			Task.Factory.StartNew(() =>
			{
				new GetStationList(new BackgroundWorker());

				Thread.Sleep(2000);

				Dispatcher.Invoke(() =>
				{
					MainWindow mainWindow = new MainWindow();

					MainWindow = mainWindow;
					mainWindow.Show();

					splash.Close();
				});
			});
		}
	}
}