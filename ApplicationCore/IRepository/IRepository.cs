using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.IRepository
{
	public interface IRepository 
	{
		string IsURLExist(string url);
		void AddURL(URLShortener URLShortener);
		IEnumerable<URLShortener> GetAllURL();
	}
}
