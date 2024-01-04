using System;

using Grasshopper.Kernel;

using ExtendedGrasshopperParameters.Types;
using ExtendedGrasshopperParameters.Parameters;

namespace ExtendedGrasshopperParameters.Component
{
    public class DeconstructView : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public DeconstructView()
          : base("Deconstruct View", "DeconView",
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
            pManager.AddTextParameter("View Type", "V", "", GH_ParamAccess.item);
            pManager.AddTextParameter("Name", "N", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_VariousView input_view = default;
            DA.GetData("View", ref input_view);

            DA.SetData("View Type", input_view.Value.ViewTypeDescription);
            DA.SetData("Name", input_view.Value.Name);
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
            get { return new Guid("4208D6D1-C457-43A1-8324-EDEE0925C118"); }
        }
    }
}