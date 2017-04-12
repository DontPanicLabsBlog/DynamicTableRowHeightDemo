// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DynamicTableRowHeightDemo
{
	[Register ("MyTableViewCell")]
	partial class MyTableViewCell
	{
		[Outlet]
		UIKit.UIButton AddNotes { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint NotesHeightConstraint { get; set; }

		[Outlet]
		UIKit.UITextView NotesTextView { get; set; }

		[Action ("AddNotesTouchUpInside:")]
		partial void AddNotesTouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AddNotes != null) {
				AddNotes.Dispose ();
				AddNotes = null;
			}

			if (NotesHeightConstraint != null) {
				NotesHeightConstraint.Dispose ();
				NotesHeightConstraint = null;
			}

			if (NotesTextView != null) {
				NotesTextView.Dispose ();
				NotesTextView = null;
			}
		}
	}
}
