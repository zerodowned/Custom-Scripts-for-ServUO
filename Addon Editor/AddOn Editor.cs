using System;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Items;
using Server.Targeting;
using Server.Engines.XmlSpawner2;

using Server.Commands;

namespace Server.Gumps
{
	public class AddOnEditor : Gump
	{
		private AddOnEditor_Att _AddOnAtt;
		

		
		public AddOnEditor( Mobile from, AddOnEditor_Att att ) : base( 100, 100 )
		{
			_AddOnAtt = att;
			
			Closable=true; Disposable=true; Dragable=true; Resizable=false;
			AddPage(0);
			
			// Buttons hidden behind the background, but are still functional
			AddButton(27, 80, 1042, 248, (int)Buttons.Select, GumpButtonType.Reply, 0);
			AddButton(27, 117, 1042, 248, (int)Buttons.AddItem, GumpButtonType.Reply, 0);
			AddButton(27, 154, 1042, 248, (int)Buttons.RemoveItem, GumpButtonType.Reply, 0);
			AddButton(27, 191, 1042, 248, (int)Buttons.DeleteItem, GumpButtonType.Reply, 0);
			AddButton(27, 228, 1042, 248, (int)Buttons.InspectItem, GumpButtonType.Reply, 0);
			
			AddBackground(0, 0, 241, 287, 9270);
			AddBackground(15, 15, 211, 257, 9200);
			AddHtml( 21, 18, 196, 18, @"<BASEFONT COLOR=#FFFFFF><center><big>Addon Editor", (bool)false, (bool)false);
		
			string TypeName;
			
			if( att.SelectedAddon != null )
				 TypeName = att.SelectedAddon.GetType().ToString();
			else { TypeName = "An Addon has not been selected"; }
			
			AddHtml( 17, 32, 207, 41, String.Format( @"Link: {0}", TypeName ), (bool)false, (bool)false);
			
			// Backgrounds used to represent the buttons
			AddBackground(30, 80, 175, 27, 9500);
			AddHtml( 34, 86, 165, 17, @"<BASEFONT COLOR=#FFFFFF><center>Select AddOn", (bool)false, (bool)false);
			
			AddBackground(30, 117, 175, 27, 9500);
			AddHtml( 34, 123, 165, 17, @"<BASEFONT COLOR=#FFFFFF><center>Add Item", (bool)false, (bool)false);
			
			AddBackground(30, 154, 175, 27, 9500);
			AddHtml( 34, 160, 165, 17, @"<BASEFONT COLOR=#FFFFFF><center>Remove Item", (bool)false, (bool)false);
			
			AddBackground(30, 191, 175, 27, 9500);
			AddHtml( 34, 197, 165, 17, @"<BASEFONT COLOR=#FFFFFF><center>Delete Item", (bool)false, (bool)false);
			
			/* 
			// Removed from planned implementation, can't think of any real use for this
			AddBackground(30, 228, 175, 27, 9500);
			AddHtml( 34, 234, 165, 17, @"<BASEFONT COLOR=#FFFFFF><center>Inspect Item", (bool)false, (bool)false);
			*/
		}
		
		public enum Buttons { Select, AddItem, RemoveItem, DeleteItem, InspectItem }
		
		public void Resend( Mobile from )
		{
			AddOnEditor_Att addoneditor = (AddOnEditor_Att)XmlAttach.FindAttachment(from, typeof(AddOnEditor_Att));
			
			if( from.HasGump(typeof(AddOnEditor)) ) {
				from.CloseGump(typeof(AddOnEditor));
			}
			from.SendGump( new AddOnEditor( from, addoneditor) );
		}
	
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			
			AddOnEditor_Att addoneditor = (AddOnEditor_Att)XmlAttach.FindAttachment(from, typeof(AddOnEditor_Att));
			
			if ( info.ButtonID == (int)Buttons.Select ) {
				from.Target = new Select_Target(from);
				Resend(from);
			}
			if( addoneditor.SelectedAddon != null )
			{
				if ( info.ButtonID == (int)Buttons.AddItem ) {
					from.Target = new Add_Target(from);
				}
				else if ( info.ButtonID == (int)Buttons.RemoveItem ) {
					from.Target = new Remove_Target(from, false);
				}
				else if ( info.ButtonID == (int)Buttons.DeleteItem ) {
					from.Target = new Remove_Target(from, true);
				}
				else if ( info.ButtonID == (int)Buttons.InspectItem ) {
				
				}
				Resend(from);
			}
			else { from.SendMessage("You must select an Addon first!"); }
		}
		
		private class Select_Target : Target
        {
			private Mobile _From;
				
            public Select_Target(Mobile from) : base(10, false, TargetFlags.None)
			{
				_From = from;
            }

			protected override void OnTarget(Mobile from, object targ)
			{
				AddOnEditor_Att addoneditor = (AddOnEditor_Att)XmlAttach.FindAttachment(from, typeof(AddOnEditor_Att));
				  
				if( targ is AddonComponent ) {
					AddonComponent component = (AddonComponent)targ;
					addoneditor.SelectedAddon = component.Addon;
					addoneditor.Resend(from);
				}
				else 
				{
					from.SendMessage("That is not an Addon.");
					from.Target = new Select_Target(from);
				}
			}
         }
		 
		private class Add_Target : Target
        {
			private Mobile _From;
				
            public Add_Target(Mobile from) : base(10, false, TargetFlags.None)
			{
				_From = from;
            }

			protected override void OnTarget(Mobile from, object targ)
			{
				AddOnEditor_Att addoneditor = (AddOnEditor_Att)XmlAttach.FindAttachment(from, typeof(AddOnEditor_Att));
				
				BaseAddon addon = addoneditor.SelectedAddon;
				
				AddonComponent component = (AddonComponent)targ;
				
				if( component.Addon ==  addon )
				{
					from.SendMessage("You cannot add an Addon to itself");
					from.Target = new Add_Target(from);
				}
			
				else if( targ is Item ) {
					Item item = (Item)targ;
					
					addon.AddComponent(new AddonComponent(item.ItemID),  item.X - addon.X , item.Y - addon.Y, addon.Z);
					
					item.Delete();
				}
				else 
				{
					from.SendMessage("That is not an Item.");
					from.Target = new Add_Target(from);
				}
			}
         }
		 
		private class Remove_Target : Target
        {
			private Mobile _From;
			private bool _delete;
				
            public Remove_Target(Mobile from, bool delete) : base(10, false, TargetFlags.None)
			{
				_From = from;
				_delete = delete;
            }

			protected override void OnTarget(Mobile from, object targ)
			{
				AddOnEditor_Att addoneditor = (AddOnEditor_Att)XmlAttach.FindAttachment(from, typeof(AddOnEditor_Att));
				
				BaseAddon addon = addoneditor.SelectedAddon;
				AddonComponent component = (AddonComponent)targ;
				  
				if( targ is AddonComponent ) {
					addon.Components.Remove(component);
					component.Addon = null;
					
					if( _delete == true ){ 
						component.Delete();  
					}
				}
				else {
					from.SendMessage("That is not an Addon.");
					from.Target = new Remove_Target(from, _delete);
				}
			}
         }
		
	}
}