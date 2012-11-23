using System.Collections.Generic;
using app.web.application.models;

namespace app.web.application.catalogbrowsing
{
	public class ViewSubDepartmentsRequest
	{
		public IEnumerable<Department> departments { get; set; }
	}
}