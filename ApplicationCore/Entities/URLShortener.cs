using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
	public class URLShortener
	{

		public int Id { set; get; }
		public string URL { set; get; }
		public string Slug { set; get; }
		//public string shortenedURL { set; get; }

	}
}
