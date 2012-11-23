using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (CommandRegistry))]
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<IFindCommands,
                                            CommandRegistry>
        {
        }

        public class when_getting_the_command_that_can_run_a_request : concern
        {
            private Establish c = () =>
                {
                    request = fake.an<IContainRequestDetails>();
                    all_the_possible_commands =
                        Enumerable.Range(1, 100).Select(x => fake.an<IProcessOneRequest>()).ToList();
                    depends.on<IEnumerable<IProcessOneRequest>>(all_the_possible_commands);
                };

            private Because b = () =>
                                result = sut.get_the_command_that_can_process(request);

            public class and_it_has_the_command
            {
                private Establish c = () =>
                    {
                        the_command_that_can_process = fake.an<IProcessOneRequest>();
                        all_the_possible_commands.Add(the_command_that_can_process);

                        the_command_that_can_process.setup(x => x.can_process(request)).Return(true);
                    };

                private It should_return_the_command_to_the_caller = () =>
                                                                     result.ShouldEqual(the_command_that_can_process);

                private static IProcessOneRequest the_command_that_can_process;
            }

            public class and_it_does_not_have_the_command
            {
                private Establish c = () =>
                    {
                        the_special_case = fake.an<IProcessOneRequest>();
                        depends.on<ICreateTheCommandWhenOneCantBeFound>(() => the_special_case);
                    };

                private It should_return_the_special_case = () =>
                                                            result.ShouldEqual(the_special_case);

                private static IProcessOneRequest the_special_case;
            }

            private static IProcessOneRequest result;
            private static IContainRequestDetails request;
            private static List<IProcessOneRequest> all_the_possible_commands;
        }
    }
}