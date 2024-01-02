using System;

using Rhino.Display;
using Rhino.Geometry;

using Grasshopper.Kernel;

using ExtendedGrasshopperParameters.Types;
using ExtendedGrasshopperParameters.Parameters;
using Rhino.DocObjects;
using ExtendedGrasshopperParameters.Common;

namespace ExtendedGrasshopperParameters.Component
{
    public class ConstructViewport : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public ConstructViewport()
          : base("Construct Viewport", "ConView",
              "",
              "EGP", "View")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Title", "T", "", GH_ParamAccess.item);
            pManager.AddTextParameter("Viewport Projection", "P", "", GH_ParamAccess.item);
            pManager.AddTextParameter("Display Mode", "M", "", GH_ParamAccess.item);
            pManager.AddLineParameter("Camera", "C", "Line directing from a camera location to a target location.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param_VariousView(), "Viewport", "V", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string input_title = default;
            string input_projection = default;
            string input_mode = default;
            Line input_camera = default;

            DA.GetData("Title", ref input_title);
            DA.GetData("Viewport Projection", ref input_projection);
            DA.GetData("Display Mode", ref input_mode);
            DA.GetData("Camera", ref input_camera);

            Enum.TryParse(input_projection, out DefinedViewportProjection projection);
            DisplayModeDescription mode = DisplayModeDescription.FindByName(input_mode);

            VariousView view = new VariousView(ViewType.RhinoView, input_title, input_camera);

            DA.SetData("Viewport",new GH_VariousView(view));
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
            get { return new Guid("90762229-2766-4C38-8E0B-E0AF96422829"); }
        }
    }
}