
using ApplicationCore.Entities;
using ApplicationCore.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Service
{
	public class Service : IService.IService
	{
		private readonly IRepository repo;
		public Service(IRepository _repo)
		{
			repo = _repo;
		}

		public string AddURL(string url)
		{
			var slugcharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			var Chararray = new char[10];
			var randomslug = new Random();

			for (int i = 0; i < Chararray.Length; i++)
			{
				Chararray[i] = slugcharacter[randomslug.Next(slugcharacter.Length)];
			}

			var slug = new String(Chararray);
			repo.AddURL(new URLShortener() {Slug= slug, URL=url });
			return slug;
			 
		}

		public IEnumerable<URLShortener> GetAllURL()
		{
			return repo.GetAllURL();
		}
		public string IsURLExist(string url)
		{
			return repo.IsURLExist(url);
		}
		
	}
}
