using System.Collections.Generic;
using app.web.application.models;

namespace app.web.application.catalogbrowsing
{
	public class ViewProductsInDepartmentRequest
	{
		public IEnumerable<Product> products { get; set; }
	}
}