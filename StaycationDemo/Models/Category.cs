using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace StaycationDemo.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
	}
}