using System;
using System.Collections;
using System.Collections.Generic;
using app.web.application.commands;

namespace app.web.core
{
    public class CommandRoutingTable : IEnumerable<IProcessOneRequest>
    {
        private readonly List<IProcessOneRequest> _commands;

        public CommandRoutingTable()
        {
            _commands = new List<IProcessOneRequest>
                {
                    new DisplayProductsRequestCommand(),
                    new DisplayMainDepartmentsCommand(),
                    new DisplaySubDepartmentsCommand()
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            return ((IEnumerable<IProcessOneRequest>) _commands).GetEnumerator();
        }

        public static ICreateTheCommandWhenOneCantBeFound command_not_found_strategy()
        {
            return () =>
                {
                    throw new ApplicationException("Command that can process request not found.");
                };
        }
    }
}