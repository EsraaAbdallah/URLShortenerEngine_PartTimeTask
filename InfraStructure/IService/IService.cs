using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.IService
{
	public interface IService
	{
		string AddURL(string url);
		IEnumerable<URLShortener> GetAllURL();
		string IsURLExist(string url);
	}
}
