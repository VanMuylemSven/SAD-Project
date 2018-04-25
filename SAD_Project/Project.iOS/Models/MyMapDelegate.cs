using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MapKit;
using UIKit;

namespace Project.iOS.Models
{
    public class MyMapDelegate : MKMapViewDelegate
    {
        string pId = "PinAnnotation";
        string mId = "MonkeyAnnotation";

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView anView;

            if (annotation is MKUserLocation)
                return null;

            //Speciale annotaties zelf maken ....
            /*if (annotation is MonkeyAnnotation)
            {

                // show monkey annotation
                anView = mapView.DequeueReusableAnnotation(mId);

                if (anView == null)
                    anView = new MKAnnotationView(annotation, mId);

                anView.Image = UIImage.FromFile("monkey.png");
                anView.CanShowCallout = true;
                anView.Draggable = true;
                anView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);

            }else {...}*/

            // show pin annotation
            anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);

            if (anView == null)
                anView = new MKPinAnnotationView(annotation, pId);

            ((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Red;
            anView.CanShowCallout = true;

            return anView;
        }

    }
}