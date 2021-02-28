using System;
using Foundation;
using UIKit;

namespace NotesApp
{
    public class CollectionGridFlowLayout : UICollectionViewFlowLayout
    {

       
        public CollectionGridFlowLayout()
        {
            this.ItemSize = new CoreGraphics.CGSize(UIScreen.MainScreen.Bounds.Width / 2.2, UIScreen.MainScreen.Bounds.Height / 5 - 10);
            this.MinimumInteritemSpacing = 5;
            this.MinimumLineSpacing = 10;
            this.SectionInset = new UIEdgeInsets(10, 5, 5, 5);
            this.HeaderReferenceSize = new CoreGraphics.CGSize(300, 100);
        }
        

        public override bool ShouldInvalidateLayoutForBoundsChange(CoreGraphics.CGRect newBounds)
        {
            return true;
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath path)
        {
            return base.LayoutAttributesForItem(path);
        }

        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CoreGraphics.CGRect rect)
        {
            return base.LayoutAttributesForElementsInRect(rect);
        }
    }
}
