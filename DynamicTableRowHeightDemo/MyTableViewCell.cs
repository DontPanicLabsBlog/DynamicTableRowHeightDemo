using System;

using Foundation;
using UIKit;

namespace DynamicTableRowHeightDemo
{
    public partial class MyTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("MyTableViewCell");

        public static readonly UINib Nib;

        public static readonly int ExpandedHeight = 210;

        public static readonly int NormalHeight = 45;

        private CellModel model;

        private Action reloadParentRow { get; set; }
        
        static MyTableViewCell()
        {
            Nib = UINib.FromName("MyTableViewCell", NSBundle.MainBundle);
        }

        protected MyTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void SetupCell(CellModel model, Action reloadParentRow)
        {
            this.model = model;
            this.reloadParentRow = reloadParentRow;

            NotesTextView.Text = model.Notes;

            if (model.ShouldDisplayNotes)
            {
                ShowNotes();
            }
            else
            {
                HideNotes();
            }
        }

        public void HideNotes()
        {
            NotesHeightConstraint.Constant = 0;
            AddNotes.SetTitle("Add Notes", UIControlState.Normal);
        }

        public void ShowNotes()
        {
            NotesHeightConstraint.Constant = 150;
            AddNotes.SetTitle("Hide Notes", UIControlState.Normal);
        }

        partial void AddNotesTouchUpInside(NSObject sender)
        {
            if (NotesHeightConstraint.Constant == 0)
            {
                ShowNotes();
                model.ShouldDisplayNotes = true;
            }
            else
            {
                HideNotes();
                model.ShouldDisplayNotes = false;
            }

            LayoutSubviews();
            reloadParentRow();
        }
    }
}
