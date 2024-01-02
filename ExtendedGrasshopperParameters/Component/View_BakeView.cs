using System;
using System.Linq;

using Rhino;
using Rhino.Display;
using Rhino.Geometry;

using Grasshopper.Kernel;

using ExtendedGrasshopperParameters.Types;
using ExtendedGrasshopperParameters.Parameters;

namespace ExtendedGrasshopperParameters.Component
{
    public class BakeView : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public BakeView()
          : base("Bake View", "Bake",
              "",
              "EGP", "View")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param_VariousView(), "View", "V", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_VariousView input_view = default;
            DA.GetData("View", ref input_view);

            input_view.Value.Push(RhinoDoc.ActiveDoc);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("377DE473-C3DF-4B3E-9C40-9520F41154C4"); }
        }
    }
}