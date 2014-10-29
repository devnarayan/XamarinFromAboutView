using System;

namespace TestApp3
{
	public enum MenuType
	{
		About,
		Blog,
		Twitter
	}
	public class HomeMenuItem : BaseModel
	{
		public HomeMenuItem ()
		{
			MenuType = MenuType.About;
		}
		public string Icon {get;set;}
		public MenuType MenuType { get; set; }
	}
}

