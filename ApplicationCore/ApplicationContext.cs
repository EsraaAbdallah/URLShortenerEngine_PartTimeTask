using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
  public class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{
		}
		public ApplicationContext() : base()
		{ }
		public virtual DbSet<URLShortener> URLShortener { get; set; }
	}

}
