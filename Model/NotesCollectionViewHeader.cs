using System;
using UIKit;
using Foundation;

namespace NotesApp
{
    public class NotesCollectionViewHeader : UICollectionReusableView
    {
        static public NSString HeaderID { get { return new NSString("NotesHeader"); } }
        UILabel titleLabel;

        public string Text
        {
            get
            {
                return titleLabel.Text;
            }
            set
            {
                titleLabel.Text = value;
                SetNeedsDisplay();
            }
        }

        [Export("initWithFrame:")]
        public NotesCollectionViewHeader(CoreGraphics.CGRect frame) : base(frame)
        {
            titleLabel = new UILabel()
            {
                BackgroundColor = UIColor.Clear,
                Font = UIFont.BoldSystemFontOfSize(25)
            };
            BackgroundColor = UIColor.White;
            
            titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(titleLabel);
            setUpViews();
        }
        private void setUpViews()
        {
            titleLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 10).Active = true;
            titleLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 10).Active = true;
            titleLabel.WidthAnchor.ConstraintEqualTo(100).Active = true;
            titleLabel.HeightAnchor.ConstraintEqualTo(100).Active = true;

        }
    }
}
