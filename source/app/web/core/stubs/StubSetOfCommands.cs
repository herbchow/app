﻿using System.Collections;
using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.application.stubs;

namespace app.web.core.stubs
{
	public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<IProcessOneRequest> GetEnumerator()
		{
		  yield return new RequestCommand(x => true,
		                                  new ViewAReport<IEnumerable<Department>>(new GetTheMainDepartments()));
		}

	  public class GetTheMainDepartments : IFetchAReport<IEnumerable<Department>>
	  {
	    public IEnumerable<Department> fetch_using(IContainRequestDetails request)
	    {
	      return new StubCatalog().get_the_main_departments();
	    }
	  }
	}
}