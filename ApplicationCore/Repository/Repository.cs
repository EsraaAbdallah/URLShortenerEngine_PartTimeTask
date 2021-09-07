using ApplicationCore;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Repository
{
	public class Repository : IRepository.IRepository
	{
		private readonly ApplicationContext ApplicationContext;

		public Repository(ApplicationContext _ApplicationContext)
		{
			ApplicationContext = _ApplicationContext;
		}
		public string IsURLExist(string url)
		{
			var result = ApplicationContext.URLShortener.Where(s => s.URL == url).FirstOrDefault();
			if (result == null)
				return "";
			else
				return result.Slug;
		}
		public IEnumerable<URLShortener> GetAllURL()
		{
			return ApplicationContext.URLShortener.ToList();
		}

		public void AddURL(URLShortener uRLShortener)
		{
			ApplicationContext.URLShortener.Add(uRLShortener);
			ApplicationContext.SaveChanges();
		}
	}
}
