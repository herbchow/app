using app.utility.service_locator;

namespace app.specs
{
    public class Bar : IBar
    {
        private readonly IFoo _dependency;

        public Bar()
            : this(Dependencies.fetch.an<IFoo>())
        {
        }

        public Bar(IFoo dependency)
        {
            _dependency = dependency;
        }

        public IFoo Dependency
        {
            get { return _dependency; }
        }
    }
}