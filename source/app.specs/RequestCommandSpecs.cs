using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (RequestCommand))]
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<IProcessOneRequest,
                                            RequestCommand>
        {
        }

        public class when_determining_if_it_can_process_a_request : concern
        {
            private Establish c = () =>
                {
                    request = fake.an<IContainRequestDetails>();
                    depends.on<IMatchARequest>(x =>
                        {
                            x.ShouldEqual(request);
                            return true;
                        });
                };

            private Because b = () =>
                                result = sut.can_process(request);

            private It should_make_its_decision_by_using_its_request_specification = () =>
                                                                                     result.ShouldBeTrue();

            private static IContainRequestDetails request;
            private static bool result;
        }

        public class when_processing_a_request : concern
        {
            private Establish c = () =>
                {
                    request = fake.an<IContainRequestDetails>();
                    feature = depends.on<ISupportAUserFeature>();
                };

            private Because b = () =>
                                sut.run(request);

            private It should_run_the_application_feature = () =>
                                                            feature.received(x => x.run(request));

            private static IContainRequestDetails request;
            private static ISupportAUserFeature feature;
        }
    }
}