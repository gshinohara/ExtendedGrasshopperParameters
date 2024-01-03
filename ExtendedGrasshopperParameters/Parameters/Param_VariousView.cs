using System;
using System.Collections.Generic;

using Rhino.Input;
using Rhino.Input.Custom;

using Grasshopper.Kernel;

using ExtendedGrasshopperParameters.Types;
using ExtendedGrasshopperParameters.Common;

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
            GetOption go = new GetOption();
            VariousView view;
            go.SetCommandPrompt("Choose a view type to select.");
            go.AddOptionEnumList("Selected", ViewType.None);
            switch (go.Get())
            {
                case GetResult.Option:
                    switch ((ViewType)go.Option().CurrentListOptionIndex)
                    {
                        case ViewType.RhinoView:
                            view = new VariousView(ViewType.RhinoView, go.View().ActiveViewportID);
                            break;
                        default:
                            return GH_GetterResult.cancel;
                    }
                    value = new GH_VariousView(view);
                    return GH_GetterResult.success;
                default:
                    return GH_GetterResult.cancel;
            }
            
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_VariousView> values)
        {
            throw new System.NotImplementedException();
        }
    }
}
