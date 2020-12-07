using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading;

namespace Dark_Spammer
{
	class Program
	{
		static bool spam;
		static string url;
		static string avatar;
		static string username;
		static string msg;

		static void Main(string[] args)
		{
			string hour = DateTime.Now.Hour.ToString();
			string minute = DateTime.Now.Minute.ToString();
			string second = DateTime.Now.Second.ToString();

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("[Dark-Spammer by YaBoiDark]\n");

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("[" + hour + "." + minute + "." + second + "]" + ">");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(" Input webhook url : ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			url = Console.ReadLine();

			Console.Write("\n[" + hour + "." + minute + "." + second + "]" + ">");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(" Input avatar picture url : ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			avatar = Console.ReadLine();

			Console.Write("\n[" + hour + "." + minute + "." + second + "]" + ">");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(" Input username : ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			username = Console.ReadLine();

			Console.Write("\n[" + hour + "." + minute + "." + second + "]" + ">");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(" Input message : ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			msg = Console.ReadLine();

			Console.Clear();
			SendMessage(url, username, msg, avatar);
		}

		static void SendMessage(string url, string username, string msg, string avatar)
		{
			spam = true;
			while (spam == true)
			{
				try
				{
					Http.Post(url, new NameValueCollection()
					{
						{
							"username",
							username
						},
						{
							"content",
							msg
						},
						{
							"avatar_url",
							avatar
						}
					});

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("[" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + "]" + ">");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(" Message sent succesfully");
				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("[" + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString() + "]" + ">");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(" " + ex.Message.ToString());
				}
			}
		}

		class Http
		{
			public static byte[] Post(string url, NameValueCollection pairs)
			{
				using (WebClient webClient = new WebClient())
				{
					return webClient.UploadValues(url, pairs);
				}
			}
		}
	}
}
