using System;

using Rhino;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.Geometry;

namespace ExtendedGrasshopperParameters.Common
{
    public class VariousView
    {
        private Guid _guid = Guid.Empty;
        private readonly ViewType _type;
        private readonly ViewInfo _viewInfo;
        private readonly DefinedViewportProjection _projection;
        private readonly DisplayMode _mode;

        internal VariousView(ViewType type, string name, Line camera)
        {
            _type = type;
            RhinoViewport vp = new RhinoViewport();
            vp.SetCameraLocations(camera.To, camera.To);
            _viewInfo = new ViewInfo(vp) { Name = name };
        }

        internal Guid ReferenceID => _guid;
        internal bool IsReferenced => ReferenceID != Guid.Empty;
        public override string ToString() => _type.ToString();

        internal void Push(RhinoDoc doc)
        {
            switch (_type)
            {
                case ViewType.RhinoView:
                    PushRhinoView(doc);
                    break;
                case ViewType.NamedView:
                    PushNamedView(doc);
                    break;
                default:
                    throw new Exception();
            }
        }
        private void PushRhinoView(RhinoDoc doc)
        {
            var views = doc.Views;
            var view = views.Add(_viewInfo.Name, _projection, default, false);
            view.Maximized = true;
        }
        private void PushNamedView(RhinoDoc doc)
        {
            doc.NamedViews.Add(_viewInfo);
        }
    }
    internal enum ViewType
    {
        RhinoView,
        RhinoPageView,
        DetailView,
        NamedView,
    }
}
