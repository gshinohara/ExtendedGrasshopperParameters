using System;

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
        public override string TypeName => "View";
        public override IGH_Goo Duplicate()
        {
            return new GH_VariousView(this);
        }
        public override string ToString()
        {
            if (Value.IsReferenced)
                return $"Referenced {Value.ToString()}";
            else
                return Value.ToString();
        }

        public override bool CastTo<Q>(ref Q target)
        {
            if (typeof(Q).IsAssignableFrom(typeof(GH_Guid)))
            {
                if (this.Value == null)
                    target = default(Q);
                else
                    target = (Q)(object)new GH_Guid(Value.ReferenceID);
                return true;
            }
            target = default(Q);
            return false;
        }
    }
}
