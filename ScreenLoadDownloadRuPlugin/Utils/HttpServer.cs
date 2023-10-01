using System;
using System.Net;
using System.Reactive.Linq;
using System.Threading;

namespace ScreenLoadDownloadRuPlugin.Utils
{
	internal sealed class HttpServer : IDisposable
	{
		private static readonly object Anchor = new object();
		private readonly HttpListener _listener;

		public HttpServer(string url)
		{
			if (null == url)
				throw new ArgumentNullException(nameof(url));

			var listener = new HttpListener();

			listener.Prefixes.Add(url);
			listener.Start();

			_listener = listener;
		}

		public IObservable<HttpListenerContext> Listen()
		{
			return Observable.Create<HttpListenerContext>(observer =>
			{
				new Thread(() =>
				{
					var autoResetEvent = new AutoResetEvent(false);

					void Callback(IAsyncResult ar)
					{
						HttpListenerContext context;

						lock (Anchor)
						{
							if (!_listener.IsListening)
							{
								autoResetEvent.Set();
								observer.OnCompleted();
								return;
							}

							context = _listener.EndGetContext(ar);
						}

						autoResetEvent.Set();
						observer.OnNext(context);
					}

					while (true)
					{
						lock (Anchor)
						{
							if (!_listener.IsListening)
								break;

							_listener.BeginGetContext(Callback, null);
						}

						autoResetEvent.WaitOne();
					}
				}) {IsBackground = true}.Start();

				return Dispose;
			});
		}

		public void Dispose()
		{
			lock (Anchor)
			{
				((IDisposable) _listener).Dispose();
			}
		}
	}
}