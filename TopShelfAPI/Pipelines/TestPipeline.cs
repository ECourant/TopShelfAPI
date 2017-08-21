using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
#if DEBUG
    public sealed class TestPipeline : Base.TPipeline
    {
        internal TestPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "test";

        public void Test() => this.GetPlural<Carton>();
    }
#endif
}
