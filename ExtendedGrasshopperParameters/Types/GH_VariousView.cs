using System;

using Rhino.Display;

using Grasshopper.Kernel.Types;
using ExtendedGrasshopperParameters.Common;

namespace ExtendedGrasshopperParameters.Types
{
    public class GH_VariousView : GH_Goo<VariousView>
    {
        public GH_VariousView() { }
        public GH_VariousView(VariousView view) : base(view) { }
        public GH_VariousView(GH_VariousView other) : base(other) { }

        public override bool IsValid => throw new System.NotImplementedException();
        public override string TypeDescription => throw new NotImplementedException();
        public override string TypeName => throw new NotImplementedException();
        public override IGH_Goo Duplicate()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            if (Value.IsReferenced)
                return $"Referenced {Value.ToString()}";
            else
                return Value.ToString();
        }
    }
}
