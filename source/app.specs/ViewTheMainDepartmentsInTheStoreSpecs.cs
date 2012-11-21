﻿using Machine.Specifications;
using app.web;
using app.web.application;
using app.web.application.catalogbrowsing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        department_repository = depends.on<IDepartmentRepository>();
      };

      Because b = () =>
        sut.run(request);

      It should_get_the_list_of_departments = () =>
        department_repository.received(x => x.get_the_main_departments());

      static IContainRequestDetails request;
      static IDepartmentRepository department_repository;
    }
  }
}