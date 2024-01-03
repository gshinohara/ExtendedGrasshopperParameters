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
        internal VariousView(ViewType type, Guid id)
        {
            _type = type;
            _guid = id;
        }

        internal Guid ReferenceID => _guid;
        internal bool IsReferenced => ReferenceID != Guid.Empty;
        internal string Name
        {
            get
            {
                if (IsReferenced)
                    return _viewInfo.Name;
                else
                {
                    switch (_type)
                    {
                        case ViewType.RhinoView:
                            return RhinoDoc.ActiveDoc.Views.Find(ReferenceID).ActiveViewport.Name;
                        case ViewType.RhinoPageView:
                            return RhinoDoc.ActiveDoc.Views.Find(ReferenceID).ActiveViewport.Name;
                        default:
                            return null;
                    }
                }
            }
        }
        internal DefinedViewportProjection Projection
        {
            get
            {
                if (IsReferenced)
                    return _projection;
                else
                    switch (_type)
                    {
                        case ViewType.RhinoView:
                            var viewport = RhinoDoc.ActiveDoc.Views.Find(ReferenceID).ActiveViewport;
                            if (viewport.IsPlanView)
                                return DefinedViewportProjection.Top;
                            else if (viewport.IsPerspectiveProjection)
                                return DefinedViewportProjection.Perspective;
                            else if (viewport.IsTwoPointPerspectiveProjection)
                                return DefinedViewportProjection.TwoPointPerspective;
                            else
                                return DefinedViewportProjection.None;
                        case ViewType.RhinoPageView:
                            return DefinedViewportProjection.None;
                        default:
                            return DefinedViewportProjection.None;
                    }
            }
        }
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
            var view = views.Add(Name, _projection, default, false);
            view.Maximized = true;
        }
        private void PushNamedView(RhinoDoc doc)
        {
            doc.NamedViews.Add(_viewInfo);
        }
    }
    internal enum ViewType
    {
        None,
        RhinoView,
        RhinoPageView,
        DetailView,
        NamedView,
    }
}
