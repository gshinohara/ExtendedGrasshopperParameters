using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;

using Grasshopper.Kernel;

using ExtendedGrasshopperParameters.Types;
using System;

namespace ExtendedGrasshopperParameters.Parameters
{
    public class Param_VariousView: GH_PersistentParam<GH_VariousView>
    {
        public Param_VariousView()
          : base("View", "View",
            "",
            "Params", "Primitive")
        { }

        public override Guid ComponentGuid => new Guid("2A6F68E7-ACC6-4174-BC37-9FCD67785A16");

        protected override GH_GetterResult Prompt_Singular(ref GH_VariousView value)
        {
            throw new System.NotImplementedException();
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_VariousView> values)
        {
            throw new System.NotImplementedException();
        }
    }
}
