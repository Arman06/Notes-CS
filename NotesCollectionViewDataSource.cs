using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace NotesApp
{
    public class NotesCollectionViewDataSource : UICollectionViewDataSource
    {
        private List<Note> notes;

        public void onDeletedItem(object source, DataServiceArgs e)
        {
            Console.WriteLine("Deleteee data source");
            foreach (var s in DataService.sharedInstance.notes)
            {
                Console.WriteLine("okay delete" + s.Title);
            }
            notes = DataService.sharedInstance.notes;


        }

        public void onAddedItem(object source, DataServiceArgs e)
        {
            Console.WriteLine("Add data source");
            foreach (var s in DataService.sharedInstance.notes)
            {
                Console.WriteLine("okay add " + s.Title);
            }
            notes = DataService.sharedInstance.notes;


        }

        public NotesCollectionViewDataSource()
        {
            DataService.sharedInstance.ItemDeleted += onDeletedItem;
            DataService.sharedInstance.ItemAdded += onAddedItem;
            this.notes = DataService.sharedInstance.notes;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return notes.Count;
        }

        

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var noteCell = (NoteCell)collectionView.DequeueReusableCell(NoteCell.NoteCellID, indexPath);

            var note = notes[indexPath.Row];

            noteCell.Data = note;

            return noteCell;
        }

        [Export("collectionView:viewForSupplementaryElementOfKind:atIndexPath:")]
        public UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
        {
            var header = (NotesCollectionViewHeader)collectionView.DequeueReusableSupplementaryView(elementKind, NotesCollectionViewHeader.HeaderID, indexPath);
            header.Text = "Notes";
            return header;
        }

    }
}
