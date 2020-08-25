// 
// OpenImagesPad.cs
//  
// Author:
//       Cameron White <cameronwhite91@gmail.com>
// 
// Copyright (c) 2011 Cameron White
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using Pinta.Docking;
using Gtk;
using Pinta.Core;
using Pinta.Gui.Widgets;

namespace Pinta
{
	public class OpenImagesPad : IDockPad
	{
		public void Initialize (Dock workspace, Application app, GLib.Menu padMenu)
		{
			DockItem open_images_item = new DockItem(new OpenImagesListWidget(), "Images")
			{
				Label = Translations.GetString("Images")
			};

			// TODO-GTK3 (docking)
#if false
			open_images_item.DefaultLocation = "Layers/Bottom";
			open_images_item.Content = new OpenImagesListWidget ();
			open_images_item.Icon = PintaCore.Resources.GetIcon ("Menu.Effects.Default.png");
            open_images_item.DefaultVisible = false;
            open_images_item.DefaultWidth = 100;
			open_images_item.Behavior |= DockItemBehavior.CantClose;
#endif

			var show_open_images = new ToggleCommand ("images", Translations.GetString ("Images"), null, null);
			app.AddAction(show_open_images);
			padMenu.AppendItem(show_open_images.CreateMenuItem());

			show_open_images.Toggled += (val) => {
				open_images_item.Visible = val;
			};

			// TODO-GTK3 (docking)
#if false
			open_images_item.VisibleChanged += (o, args) => {
				show_open_images.Value = open_images_item.Visible;
			};
#endif
		}
	}
}

