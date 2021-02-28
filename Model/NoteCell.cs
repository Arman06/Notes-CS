using System;
using UIKit;
using Foundation;

namespace NotesApp
{
    public class NoteCell : UICollectionViewCell
    {

        static public NSString NoteCellID { get { return new NSString("NoteCell"); } }
        UILabel titleLabel;

        public Note Data
        {
            get
            {
                return Data;
            }

            set
            {
                titleLabel.Text = value.Title;
                SetNeedsDisplay();
            }
        }

        public string Title
        {
            set
            {
                titleLabel.Text = value;
                SetNeedsDisplay();
            }
        }

        [Export("initWithFrame:")]
        public NoteCell(CoreGraphics.CGRect frame) : base(frame)
        {

            makeShadow();

            ContentView.Layer.CornerRadius = 12.0f;
            ContentView.Layer.MasksToBounds = true;
            ContentView.BackgroundColor = UIColor.White;

            titleLabel = new UILabel { Text = "Note" };
            titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(titleLabel);
            setUpViews();

            
            
        }

        private void makeShadow()
        {
            Layer.MasksToBounds = false;
            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOpacity = 0.2f;
            Layer.ShadowOffset = new CoreGraphics.CGSize(0, 0);
            Layer.ShadowRadius = 3f;

        }

        private void setUpViews()
        {
            titleLabel.CenterXAnchor.ConstraintEqualTo(CenterXAnchor).Active = true;
            titleLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
            titleLabel.WidthAnchor.ConstraintEqualTo(100).Active = true;
            titleLabel.HeightAnchor.ConstraintEqualTo(100).Active = true;

        }

        

        //[Export("custom")]
        //void Custom()
        //{
        //    // Put all your custom menu behavior code here
        //    Console.WriteLine("custom in the cell");
        //}


        //public override bool CanPerform(Selector action, NSObject withSender)
        //{
        //    if (action == new Selector("custom"))
        //        return true;
        //    else
        //        return false;
        //}
    }
}
