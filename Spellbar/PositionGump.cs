using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Xml;
using Server.Engines.XmlSpawner2;

namespace Server.Gumps
{
	public class PositionGump : Gump
	{	
	
		public SpellBarScroll m_Scroll;
		
		public void Refresh(Mobile from)
        {
		
			SpellBarScroll scroll = (SpellBarScroll)XmlAttach.FindAttachment(from, typeof(SpellBarScroll));
			
			if ( scroll == null )
			{
				XmlAttach.AttachTo(from, new SpellBarScroll());
				//e.Mobile.SendGump(new Test_Gump(attachment));
				return;
			
			}
			
			int xo = scroll.Xo;
			int yo = scroll.Yo;
					  
			if ( from.HasGump(typeof(SpellBarGump.SpellBar_BarGump)) )
			{
				from.CloseGump(typeof(SpellBarGump.SpellBar_BarGump));
			}
			
			from.SendGump( new SpellBarGump.SpellBar_BarGump ( from, scroll, xo, yo ) );  
        }
	
		public PositionGump(Mobile from, SpellBarScroll scroll  ) : base( 0, 0 )
		{
			 m_Scroll = scroll;
			 
			 int xo;
			 int yo;

			Closable=true;
			Disposable=true;
			Dragable=false;
			Resizable=false;

			AddPage(0);

			AddImageTiled(0, 0, 3000, 3000, 2624);
			AddAlphaRegion(0, 0, 3000, 3000);
			
			//AddLabel(124, 35, 1153, @"Select a button to the left where you would like the hotbar to open");
			
			AddHtml( 320, 215, 350, 85, @"Select a button where you would like the hotbar to open. This position will also be used if you enable auto-open on login.<br>If you have maually moved the hotbar since logging in you may have to logout and  login again for this to work", (bool)true, (bool)true);    
			
			AddButton(700, 230, 241, 242, 0, GumpButtonType.Reply, 0); // cancel
			AddButton(700, 260, 247, 248, 0, GumpButtonType.Reply, 0); // options

		///////////////
			//AddPage(1);
			AddButton(0, 0, 1210, 248, 1, GumpButtonType.Reply, 0);
			
			AddButton(100, 0, 1210, 248, 2, GumpButtonType.Reply, 0);
			AddButton(200, 0, 1210, 248, 3, GumpButtonType.Reply, 0);
			AddButton(300, 0, 1210, 248, 4, GumpButtonType.Reply, 0);
			AddButton(400, 0, 1210, 248, 5, GumpButtonType.Reply, 0);
			AddButton(500, 0, 1210, 248, 6, GumpButtonType.Reply, 0);
			AddButton(600, 0, 1210, 248, 7, GumpButtonType.Reply, 0);
			AddButton(700, 0, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(800, 0, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(900, 0, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1000, 0, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1100, 0, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1200, 0, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1300, 0, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1400, 0, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1500, 0, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1600, 0, 1210, 248, 17, GumpButtonType.Reply, 0);
			AddButton(1700, 0, 1210, 248, 18, GumpButtonType.Reply, 0);
			AddButton(1800, 0, 1210, 248, 19, GumpButtonType.Reply, 0);
			AddButton(1900, 0, 1210, 248, 20, GumpButtonType.Reply, 0);
			AddButton(2000, 0, 1210, 248, 21, GumpButtonType.Reply, 0);
			
			// #22 is a copy of 21 because of a typo
			AddButton(2000, 0, 1210, 248, 22, GumpButtonType.Reply, 0);

			//AddPage(2);
			AddButton(0, 100, 2224, 248, 23, GumpButtonType.Page, 1);
			
			AddButton(100, 100, 1210, 248, 24, GumpButtonType.Reply, 0);
			AddButton(200, 100, 1210, 248, 25, GumpButtonType.Reply, 0);
			AddButton(300, 100, 1210, 248, 26, GumpButtonType.Reply, 0);
			AddButton(400, 100, 1210, 248, 27, GumpButtonType.Reply, 0);
			AddButton(500, 100, 1210, 248, 28, GumpButtonType.Reply, 0);
			AddButton(600, 100, 1210, 248, 29, GumpButtonType.Reply, 0);
			AddButton(700, 100, 1210, 248, 30, GumpButtonType.Reply, 0);
			AddButton(800, 100, 1210, 248, 31, GumpButtonType.Reply, 0);
			AddButton(900, 100, 1210, 248, 32, GumpButtonType.Reply, 0);
			AddButton(1000, 100, 1210, 248, 33, GumpButtonType.Reply, 0);
			AddButton(1100, 100, 1210, 248, 34, GumpButtonType.Reply, 0);
			AddButton(1200, 100, 1210, 248, 35, GumpButtonType.Reply, 0);
			AddButton(1300, 100, 1210, 248, 36, GumpButtonType.Reply, 0);
			AddButton(1400, 100, 1210, 248, 37, GumpButtonType.Reply, 0);
			AddButton(1500, 100, 1210, 248, 38, GumpButtonType.Reply, 0);
			AddButton(1600, 100, 1210, 248, 39, GumpButtonType.Reply, 0);
			AddButton(1700, 100, 1210, 248, 40, GumpButtonType.Reply, 0);
			AddButton(1800, 100, 1210, 248, 41, GumpButtonType.Reply, 0);
			AddButton(1900, 100, 1210, 248, 42, GumpButtonType.Reply, 0);
			AddButton(2000, 100, 1210, 248, 43, GumpButtonType.Reply, 0);
			
			//AddPage(3);
			
			AddButton(0, 200, 2224, 248, 44, GumpButtonType.Reply, 0);
			
			AddButton(100, 200, 1210, 248, 45, GumpButtonType.Reply, 0);
			AddButton(200, 200, 1210, 248, 46, GumpButtonType.Reply, 0);
			AddButton(300, 200, 1210, 248, 47, GumpButtonType.Reply, 0);
			AddButton(400, 200, 1210, 248, 48, GumpButtonType.Reply, 0);
			AddButton(500, 200, 1210, 248, 49, GumpButtonType.Reply, 0);
			AddButton(600, 200, 1210, 248, 50, GumpButtonType.Reply, 0);
			AddButton(700, 200, 1210, 248, 51, GumpButtonType.Reply, 0);
			AddButton(800, 200, 1210, 248, 52, GumpButtonType.Reply, 0);
			AddButton(900, 200, 1210, 248, 53, GumpButtonType.Reply, 0);
			AddButton(1000, 200, 1210, 248, 54, GumpButtonType.Reply, 0);
			AddButton(1100, 200, 1210, 248, 55, GumpButtonType.Reply, 0);
			AddButton(1200, 200, 1210, 248, 56, GumpButtonType.Reply, 0);
			AddButton(1300, 200, 1210, 248, 57, GumpButtonType.Reply, 0);
			AddButton(1400, 200, 1210, 248, 58, GumpButtonType.Reply, 0);
			AddButton(1500, 200, 1210, 248, 59, GumpButtonType.Reply, 0);
			AddButton(1600, 200, 1210, 248, 60, GumpButtonType.Reply, 0);
			AddButton(1700, 200, 1210, 248, 61, GumpButtonType.Reply, 0);
			AddButton(1800, 200, 1210, 248, 62, GumpButtonType.Reply, 0);
			AddButton(1900, 200, 1210, 248, 63, GumpButtonType.Reply, 0);
			AddButton(2000, 200, 1210, 248, 64, GumpButtonType.Reply, 0);
			
			//AddPage(4);
			
			AddButton(0, 300, 2224, 248, 65, GumpButtonType.Reply, 0);
			
			AddButton(100, 300, 1210, 248, 66, GumpButtonType.Reply, 0);
			AddButton(200, 300, 1210, 248, 67, GumpButtonType.Reply, 0);
			AddButton(300, 300, 1210, 248, 68, GumpButtonType.Reply, 0);
			AddButton(400, 300, 1210, 248, 69, GumpButtonType.Reply, 0);
			AddButton(500, 300, 1210, 248, 70, GumpButtonType.Reply, 0);
			AddButton(600, 300, 1210, 248, 71, GumpButtonType.Reply, 0);
			AddButton(700, 300, 1210, 248, 72, GumpButtonType.Reply, 0);
			AddButton(800, 300, 1210, 248, 73, GumpButtonType.Reply, 0);
			AddButton(900, 300, 1210, 248, 74, GumpButtonType.Reply, 0);
			AddButton(1000, 300, 1210, 248, 75, GumpButtonType.Reply, 0);
			AddButton(1100, 300, 1210, 248, 76, GumpButtonType.Reply, 0);
			AddButton(1200, 300, 1210, 248, 77, GumpButtonType.Reply, 0);
			AddButton(1300, 300, 1210, 248, 78, GumpButtonType.Reply, 0);
			AddButton(1400, 300, 1210, 248, 79, GumpButtonType.Reply, 0);
			AddButton(1500, 300, 1210, 248, 80, GumpButtonType.Reply, 0);
			AddButton(1600, 300, 1210, 248, 81, GumpButtonType.Reply, 0);
			AddButton(1700, 300, 1210, 248, 82, GumpButtonType.Reply, 0);
			AddButton(1800, 300, 1210, 248, 83, GumpButtonType.Reply, 0);
			AddButton(1900, 300, 1210, 248, 84, GumpButtonType.Reply, 0);
			AddButton(2000, 300, 1210, 248, 85, GumpButtonType.Reply, 0);
			
			//AddPage(5);
			
			AddButton(0, 400, 2224, 248, 86, GumpButtonType.Reply, 0);
			
			AddButton(100, 400, 1210, 248, 87, GumpButtonType.Reply, 0);
			AddButton(200, 400, 1210, 248, 88, GumpButtonType.Reply, 0);
			AddButton(300, 400, 1210, 248, 89, GumpButtonType.Reply, 0);
			AddButton(400, 400, 1210, 248, 90, GumpButtonType.Reply, 0);
			AddButton(500, 400, 1210, 248, 91, GumpButtonType.Reply, 0);
			AddButton(600, 400, 1210, 248, 92, GumpButtonType.Reply, 0);
			AddButton(700, 400, 1210, 248, 93, GumpButtonType.Reply, 0);
			AddButton(800, 400, 1210, 248, 94, GumpButtonType.Reply, 0);
			AddButton(900, 400, 1210, 248, 95, GumpButtonType.Reply, 0);
			AddButton(1000, 400, 1210, 248, 96, GumpButtonType.Reply, 0);
			AddButton(1100, 400, 1210, 248, 97, GumpButtonType.Reply, 0);
			AddButton(1200, 400, 1210, 248, 98, GumpButtonType.Reply, 0);
			
			// copy of 98
			
			AddButton(1200, 400, 1210, 248, 99, GumpButtonType.Reply, 0);
			
			AddButton(1300, 400, 1210, 248, 100, GumpButtonType.Reply, 0);
			AddButton(1400, 400, 1210, 248, 101, GumpButtonType.Reply, 0);
			AddButton(1500, 400, 1210, 248, 102, GumpButtonType.Reply, 0);
			AddButton(1600, 400, 1210, 248, 103, GumpButtonType.Reply, 0);
			AddButton(1700, 400, 1210, 248, 104, GumpButtonType.Reply, 0);
			AddButton(1800, 400, 1210, 248, 105, GumpButtonType.Reply, 0);
			AddButton(1900, 400, 1210, 248, 106, GumpButtonType.Reply, 0);
			AddButton(2000, 400, 1210, 248, 107, GumpButtonType.Reply, 0);
			
			//AddPage(6);
			
			AddButton(0, 500, 2224, 248, 108, GumpButtonType.Reply, 0);
			
			AddButton(100, 500, 1210, 248, 109, GumpButtonType.Reply, 0);
			AddButton(200, 500, 1210, 248, 110, GumpButtonType.Reply, 0);
			AddButton(300, 500, 1210, 248, 111, GumpButtonType.Reply, 0);
			AddButton(400, 500, 1210, 248, 112, GumpButtonType.Reply, 0);
			AddButton(500, 500, 1210, 248, 113, GumpButtonType.Reply, 0);
			AddButton(600, 500, 1210, 248, 114, GumpButtonType.Reply, 0);
			AddButton(700, 500, 1210, 248, 115, GumpButtonType.Reply, 0);
			AddButton(800, 500, 1210, 248, 116, GumpButtonType.Reply, 0);
			AddButton(900, 500, 1210, 248, 117, GumpButtonType.Reply, 0);
			AddButton(1000, 500, 1210, 248, 118, GumpButtonType.Reply, 0);
			AddButton(1100, 500, 1210, 248, 119, GumpButtonType.Reply, 0);
			AddButton(1200, 500, 1210, 248, 120, GumpButtonType.Reply, 0);
			AddButton(1300, 500, 1210, 248, 121, GumpButtonType.Reply, 0);
			AddButton(1400, 500, 1210, 248, 122, GumpButtonType.Reply, 0);
			AddButton(1500, 500, 1210, 248, 123, GumpButtonType.Reply, 0);
			AddButton(1600, 500, 1210, 248, 124, GumpButtonType.Reply, 0);
			AddButton(1700, 500, 1210, 248, 125, GumpButtonType.Reply, 0);
			AddButton(1800, 500, 1210, 248, 126, GumpButtonType.Reply, 0);
			AddButton(1900, 500, 1210, 248, 127, GumpButtonType.Reply, 0);
			AddButton(2000, 500, 1210, 248, 128, GumpButtonType.Reply, 0);
			
			//AddPage(7);
			
			AddButton(0, 600, 2224, 248, 129, GumpButtonType.Reply, 0);
			
			AddButton(100, 600, 1210, 248, 130, GumpButtonType.Reply, 0);
			AddButton(200, 600, 1210, 248, 131, GumpButtonType.Reply, 0);
			AddButton(300, 600, 1210, 248, 132, GumpButtonType.Reply, 0);
			AddButton(400, 600, 1210, 248, 133, GumpButtonType.Reply, 0);
			AddButton(500, 600, 1210, 248, 134, GumpButtonType.Reply, 0);
			AddButton(600, 600, 1210, 248, 135, GumpButtonType.Reply, 0);
			AddButton(700, 600, 1210, 248, 136, GumpButtonType.Reply, 0);
			AddButton(800, 600, 1210, 248, 137, GumpButtonType.Reply, 0);
			AddButton(900, 600, 1210, 248, 138, GumpButtonType.Reply, 0);
			AddButton(1000, 600, 1210, 248, 139, GumpButtonType.Reply, 0);
			AddButton(1100, 600, 1210, 248, 140, GumpButtonType.Reply, 0);
			AddButton(1200, 600, 1210, 248, 141, GumpButtonType.Reply, 0);
			AddButton(1300, 600, 1210, 248, 142, GumpButtonType.Reply, 0);
			AddButton(1400, 600, 1210, 248, 143, GumpButtonType.Reply, 0);
			AddButton(1500, 600, 1210, 248, 144, GumpButtonType.Reply, 0);
			AddButton(1600, 600, 1210, 248, 145, GumpButtonType.Reply, 0);
			AddButton(1700, 600, 1210, 248, 146, GumpButtonType.Reply, 0);
			AddButton(1800, 600, 1210, 248, 147, GumpButtonType.Reply, 0);
			AddButton(1900, 600, 1210, 248, 148, GumpButtonType.Reply, 0);
			AddButton(2000, 600, 1210, 248, 149, GumpButtonType.Reply, 0);
			
			//AddPage(8);
			
			AddButton(0, 700, 2224, 248, 150, GumpButtonType.Reply, 0);
			
			AddButton(100, 700, 1210, 248, 151, GumpButtonType.Reply, 0);
			AddButton(200, 700, 1210, 248, 152, GumpButtonType.Reply, 0);
			AddButton(300, 700, 1210, 248, 153, GumpButtonType.Reply, 0);
			AddButton(400, 700, 1210, 248, 154, GumpButtonType.Reply, 0);
			AddButton(500, 700, 1210, 248, 155, GumpButtonType.Reply, 0);
			AddButton(600, 700, 1210, 248, 156, GumpButtonType.Reply, 0);
			AddButton(700, 700, 1210, 248, 157, GumpButtonType.Reply, 0);
			AddButton(800, 700, 1210, 248, 158, GumpButtonType.Reply, 0);
			AddButton(900, 700, 1210, 248, 159, GumpButtonType.Reply, 0);
			AddButton(1000, 700, 1210, 248, 160, GumpButtonType.Reply, 0);
			AddButton(1100, 700, 1210, 248, 161, GumpButtonType.Reply, 0);
			AddButton(1200, 700, 1210, 248, 162, GumpButtonType.Reply, 0);
			AddButton(1300, 700, 1210, 248, 163, GumpButtonType.Reply, 0);
			AddButton(1400, 700, 1210, 248, 164, GumpButtonType.Reply, 0);
			AddButton(1500, 700, 1210, 248, 165, GumpButtonType.Reply, 0);
			AddButton(1600, 700, 1210, 248, 166, GumpButtonType.Reply, 0);
			AddButton(1700, 700, 1210, 248, 167, GumpButtonType.Reply, 0);
			AddButton(1800, 700, 1210, 248, 168, GumpButtonType.Reply, 0);
			AddButton(1900, 700, 1210, 248, 169, GumpButtonType.Reply, 0);
			AddButton(2000, 700, 1210, 248, 170, GumpButtonType.Reply, 0);
			
			//AddPage(9);
			
			AddButton(0, 800, 2224, 248, 171, GumpButtonType.Page, 1);
			
			AddButton(100, 800, 1210, 248, 172, GumpButtonType.Reply, 0);
			AddButton(200, 800, 1210, 248, 173, GumpButtonType.Reply, 0);
			AddButton(300, 800, 1210, 248, 174, GumpButtonType.Reply, 0);
			AddButton(400, 800, 1210, 248, 175, GumpButtonType.Reply, 0);
			AddButton(500, 800, 1210, 248, 176, GumpButtonType.Reply, 0);
			AddButton(600, 800, 1210, 248, 177, GumpButtonType.Reply, 0);
			AddButton(700, 800, 1210, 248, 178, GumpButtonType.Reply, 0);
			AddButton(800, 800, 1210, 248, 179, GumpButtonType.Reply, 0);
			AddButton(900, 800, 1210, 248, 180, GumpButtonType.Reply, 0);
			AddButton(1000, 800, 1210, 248, 181, GumpButtonType.Reply, 0);
			AddButton(1100, 800, 1210, 248, 182, GumpButtonType.Reply, 0);
			AddButton(1200, 800, 1210, 248, 183, GumpButtonType.Reply, 0);
			AddButton(1300, 800, 1210, 248, 184, GumpButtonType.Reply, 0);
			AddButton(1400, 800, 1210, 248, 185, GumpButtonType.Reply, 0);
			AddButton(1500, 800, 1210, 248, 186, GumpButtonType.Reply, 0);
			AddButton(1600, 800, 1210, 248, 187, GumpButtonType.Reply, 0);
			AddButton(1700, 800, 1210, 248, 188, GumpButtonType.Reply, 0);
			AddButton(1800, 800, 1210, 248, 189, GumpButtonType.Reply, 0);
			AddButton(1900, 800, 1210, 248, 190, GumpButtonType.Reply, 0);
			AddButton(2000, 800, 1210, 248, 191, GumpButtonType.Reply, 0);
			
			//AddPage(10);
			
			AddButton(0, 900, 2224, 248, 192, GumpButtonType.Reply, 0);
			
			AddButton(100, 900, 1210, 248, 193, GumpButtonType.Reply, 0);
			AddButton(200, 900, 1210, 248, 194, GumpButtonType.Reply, 0);
			AddButton(300, 900, 1210, 248, 195, GumpButtonType.Reply, 0);
			AddButton(400, 900, 1210, 248, 196, GumpButtonType.Reply, 0);
			AddButton(500, 900, 1210, 248, 197, GumpButtonType.Reply, 0);
			AddButton(600, 900, 1210, 248, 198, GumpButtonType.Reply, 0);
			AddButton(700, 900, 1210, 248, 199, GumpButtonType.Reply, 0);
			AddButton(800, 900, 1210, 248, 200, GumpButtonType.Reply, 0);
			AddButton(900, 900, 1210, 248, 201, GumpButtonType.Reply, 0);
			AddButton(1000, 900, 1210, 248, 202, GumpButtonType.Reply, 0);
			AddButton(1100, 900, 1210, 248, 203, GumpButtonType.Reply, 0);
			AddButton(1200, 900, 1210, 248, 204, GumpButtonType.Reply, 0);
			AddButton(1300, 900, 1210, 248, 205, GumpButtonType.Reply, 0);
			AddButton(1400, 900, 1210, 248, 206, GumpButtonType.Reply, 0);
			AddButton(1500, 900, 1210, 248, 207, GumpButtonType.Reply, 0);
			AddButton(1600, 900, 1210, 248, 208, GumpButtonType.Reply, 0);
			AddButton(1700, 900, 1210, 248, 209, GumpButtonType.Reply, 0);
			AddButton(1800, 900, 1210, 248, 210, GumpButtonType.Reply, 0);
			AddButton(1900, 900, 1210, 248, 211, GumpButtonType.Reply, 0);
			AddButton(2000, 900, 1210, 248, 212, GumpButtonType.Reply, 0);
			
			//AddPage(11);
			
			AddButton(0, 1000, 2224, 248, 213, GumpButtonType.Reply, 0);
			
			AddButton(100, 1000, 1210, 248, 214, GumpButtonType.Reply, 0);
			AddButton(200, 1000, 1210, 248, 215, GumpButtonType.Reply, 0);
			AddButton(300, 1000, 1210, 248, 216, GumpButtonType.Reply, 0);
			AddButton(400, 1000, 1210, 248, 217, GumpButtonType.Reply, 0);
			AddButton(500, 1000, 1210, 248, 218, GumpButtonType.Reply, 0);
			AddButton(600, 1000, 1210, 248, 219, GumpButtonType.Reply, 0);
			AddButton(700, 1000, 1210, 248, 220, GumpButtonType.Reply, 0);
			AddButton(800, 1000, 1210, 248, 221, GumpButtonType.Reply, 0);
			AddButton(900, 1000, 1210, 248, 222, GumpButtonType.Reply, 0);
			AddButton(1000, 1000, 1210, 248, 223, GumpButtonType.Reply, 0);
			AddButton(1100, 1000, 1210, 248, 224, GumpButtonType.Reply, 0);
			AddButton(1200, 1000, 1210, 248, 225, GumpButtonType.Reply, 0);
			AddButton(1300, 1000, 1210, 248, 226, GumpButtonType.Reply, 0);
			AddButton(1400, 1000, 1210, 248, 227, GumpButtonType.Reply, 0);
			AddButton(1500, 1000, 1210, 248, 228, GumpButtonType.Reply, 0);
			AddButton(1600, 1000, 1210, 248, 229, GumpButtonType.Reply, 0);
			AddButton(1700, 1000, 1210, 248, 230, GumpButtonType.Reply, 0);
			AddButton(1800, 1000, 1210, 248, 231, GumpButtonType.Reply, 0);
			AddButton(1900, 1000, 1210, 248, 232, GumpButtonType.Reply, 0);
			AddButton(2000, 1000, 1210, 248, 233, GumpButtonType.Reply, 0);
			
			//AddPage(12);
			
			AddButton(0, 1100, 2224, 248, 234, GumpButtonType.Reply, 0);
			
			AddButton(100, 1100, 1210, 248, 235, GumpButtonType.Reply, 0);
			AddButton(200, 1100, 1210, 248, 236, GumpButtonType.Reply, 0);
			AddButton(300, 1100, 1210, 248, 237, GumpButtonType.Reply, 0);
			AddButton(400, 1100, 1210, 248, 238, GumpButtonType.Reply, 0);
			AddButton(500, 1100, 1210, 248, 239, GumpButtonType.Reply, 0);
			AddButton(600, 1100, 1210, 248, 240, GumpButtonType.Reply, 0);
			AddButton(700, 1100, 1210, 248, 241, GumpButtonType.Reply, 0);
			AddButton(800, 1100, 1210, 248, 242, GumpButtonType.Reply, 0);
			AddButton(900, 1100, 1210, 248, 243, GumpButtonType.Reply, 0);
			AddButton(1000, 1100, 1210, 248, 244, GumpButtonType.Reply, 0);
			AddButton(1100, 1100, 1210, 248, 245, GumpButtonType.Reply, 0);
			AddButton(1200, 1100, 1210, 248, 246, GumpButtonType.Reply, 0);
			AddButton(1300, 1100, 1210, 248, 247, GumpButtonType.Reply, 0);
			AddButton(1400, 1100, 1210, 248, 248, GumpButtonType.Reply, 0);
			AddButton(1500, 1100, 1210, 248, 249, GumpButtonType.Reply, 0);
			AddButton(1600, 1100, 1210, 248, 250, GumpButtonType.Reply, 0);
			AddButton(1700, 1100, 1210, 248, 251, GumpButtonType.Reply, 0);
			AddButton(1800, 1100, 1210, 248, 252, GumpButtonType.Reply, 0);
			AddButton(1900, 1100, 1210, 248, 253, GumpButtonType.Reply, 0);
			AddButton(2000, 1100, 1210, 248, 254, GumpButtonType.Reply, 0);
		
	/*
			//AddPage(13);
			
			AddButton(0, 1200, 2224, 248, 6, GumpButtonType.Reply, 0);
			
			AddButton(100, 1200, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1200, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1200, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1200, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1200, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1200, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1200, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1200, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1200, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1200, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1200, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1200, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1200, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1200, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1200, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1200, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1200, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1200, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1200, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1200, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(14);
			
			AddButton(0, 1300, 2224, 248, 7, GumpButtonType.Reply, 0);
			
			AddButton(100, 1300, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1300, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1300, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1300, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1300, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1300, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1300, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1300, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1300, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1300, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1300, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1300, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1300, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1300, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1300, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1300, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1300, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1300, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1300, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1300, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(15);
			
			AddButton(0, 1400, 2224, 248, 1, GumpButtonType.Reply, 0);
			
			AddButton(100, 1400, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1400, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1400, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1400, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1400, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1400, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1400, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1400, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1400, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1400, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1400, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1400, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1400, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1400, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1400, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1400, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1400, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1400, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1400, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1400, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(16);
			
			AddButton(0, 1500, 2224, 248, 2, GumpButtonType.Page, 1);
			
			AddButton(100, 1500, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1500, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1500, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1500, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1500, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1500, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1500, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1500, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1500, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1500, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1500, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1500, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1500, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1500, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1500, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1500, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1500, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1500, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1500, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1500, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(17);
			
			AddButton(0, 1600, 2224, 248, 3, GumpButtonType.Reply, 0);
			
			AddButton(100, 1600, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1600, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1600, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1600, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1600, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1600, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1600, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1600, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1600, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1600, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1600, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1600, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1600, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1600, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1600, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1600, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1600, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1600, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1600, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1600, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(18);
			
			AddButton(0, 1700, 2224, 248, 4, GumpButtonType.Reply, 0);
			
			AddButton(100, 1700, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1700, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1700, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1700, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1700, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1700, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1700, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1700, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1700, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1700, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1700, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1700, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1700, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1700, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1700, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1700, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1700, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1700, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1700, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1700, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(19);
			
			AddButton(0, 1800, 2224, 248, 5, GumpButtonType.Reply, 0);
			
			AddButton(100, 1800, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1800, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1800, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1800, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1800, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1800, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1800, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1800, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1800, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1800, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1800, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1800, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1800, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1800, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1800, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1800, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1800, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1800, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1800, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1800, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(20);
			
			AddButton(0, 1900, 2224, 248, 6, GumpButtonType.Reply, 0);
			
			AddButton(100, 1900, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 1900, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 1900, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 1900, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 1900, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 1900, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 1900, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 1900, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 1900, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 1900, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 1900, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 1900, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 1900, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 1900, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 1900, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 1900, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 1900, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 1900, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 1900, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 1900, 1210, 248, 16, GumpButtonType.Reply, 0);
			
			//AddPage(21);
			
			AddButton(0, 2000, 2224, 248, 7, GumpButtonType.Reply, 0);
			
			AddButton(100, 2000, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(200, 2000, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(300, 2000, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(400, 2000, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(500, 2000, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(600, 2000, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(700, 2000, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(800, 2000, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(900, 2000, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1000, 2000, 1210, 248, 8, GumpButtonType.Reply, 0);
			AddButton(1100, 2000, 1210, 248, 9, GumpButtonType.Reply, 0);
			AddButton(1200, 2000, 1210, 248, 10, GumpButtonType.Reply, 0);
			AddButton(1300, 2000, 1210, 248, 11, GumpButtonType.Reply, 0);
			AddButton(1400, 2000, 1210, 248, 12, GumpButtonType.Reply, 0);
			AddButton(1500, 2000, 1210, 248, 13, GumpButtonType.Reply, 0);
			AddButton(1600, 2000, 1210, 248, 14, GumpButtonType.Reply, 0);
			AddButton(1700, 2000, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(1800, 2000, 1210, 248, 16, GumpButtonType.Reply, 0);
			AddButton(1900, 2000, 1210, 248, 15, GumpButtonType.Reply, 0);
			AddButton(2000, 2000, 1210, 248, 16, GumpButtonType.Reply, 0);
	*/
		}
		
		public override void OnResponse( NetState sender, RelayInfo info )
        {
			// public Testscroll m_Scroll;
            Mobile from = sender.Mobile;
			//m_Scroll = attachment;
			
			SpellBarScroll scroll = (SpellBarScroll)XmlAttach.FindAttachment(from, typeof(SpellBarScroll));
			
			int m_Xo = m_Scroll.Xo;
			  int m_Yo = m_Scroll.Yo;
			
            switch(info.ButtonID)
            {
				case 0:
                {
					from.CloseGump( typeof( PositionGump ) );     
					 
                    break;
				}
				case 1:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 2:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 3:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 4:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 5:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					
					break;
				}
				case 6:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 7:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 8:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 9:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 10:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 11:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 12:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 13:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 14:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 15:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 16:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 17:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 18:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 19:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 20:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 21:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
				// #22 is a copy of 21 because of a typo
				case 22:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 0;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
	///////////////////////////////////////////////////////
	
				case 23:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 24:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 25:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 26:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 27:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 28:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 29:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 30:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 31:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 32:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 33:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 34:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 35:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 36:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 37:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 38:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 39:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 40:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 41:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 42:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 43:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
////////////////////////////////////////////////////

				case 44:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 45:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 46:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 47:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 48:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 49:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 50:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 51:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 52:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 53:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 54:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 55:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 56:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 57:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 58:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 59:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 60:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 61:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 62:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 63:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 64:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 200;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
	//////////////////////////////////////////////
				
				case 65:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 66:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 67:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 68:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 69:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 70:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 71:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 72:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 73:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 74:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 75:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 76:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 77:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 78:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 79:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 80:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 81:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 82:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 83:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 84:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 85:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 300;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
	///////////////////////////////////////////////////////
	
				
				case 86:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 87:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 88:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 89:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 90:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 91:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 92:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 93:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 94:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 95:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 96:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 97:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 98:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
				// copy of 98
				case 99:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				//////////
				case 100:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 101:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 102:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 103:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 104:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 105:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 106:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 107:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 400;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
	///////////////////////////////////////////////////////////
				
				
				case 108:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 109:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 110:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 111:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 112:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 113:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 114:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 115:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 116:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 117:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 118:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 119:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 120:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 121:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 122:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 123:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 124:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 125:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 126:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 127:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 128:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 500;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
	/////////////////////////////////////////////////////////////////
	
				
				
				case 129:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 130:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 131:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 132:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 133:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 134:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 135:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 136:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 137:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 138:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 139:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 140:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 141:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 142:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 143:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 144:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 145:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 146:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 147:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 148:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 149:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 600;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
	/////////////////////////////////////////////////////////////////
	
				
				
				case 150:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 151:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 152:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 153:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 154:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 155:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 156:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 157:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 158:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 159:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 160:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 161:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 162:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 163:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 164:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 165:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 166:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 167:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 168:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 169:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 170:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 700;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
		/////////////////////////////////////////////////////////////////
	
				
				
				case 171:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 172:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 173:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 174:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 175:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 176:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 177:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 178:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 179:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 180:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 181:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 182:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 183:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 184:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 185:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 186:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 187:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 188:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 189:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 190:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 191:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 800;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
		/////////////////////////////////////////////////////////////////
	
				
				
				case 192:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 193:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 194:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 195:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 196:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 197:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 198:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 199:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 200:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 201:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 202:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 203:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 204:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 205:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 206:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 207:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 208:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 209:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 210:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 211:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 212:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 900;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
		/////////////////////////////////////////////////////////////////
	
				
				
				case 213:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 214:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 215:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 216:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 217:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 218:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 219:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 220:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 221:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 222:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 223:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 224:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 225:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 226:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 227:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 228:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 229:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 230:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 231:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 232:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 233:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 1000;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
		/////////////////////////////////////////////////////////////////
	
				
				
				case 234:
                {
					m_Scroll.Xo = 0; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 235:
                {
					m_Scroll.Xo = 100; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 236:
                {
					m_Scroll.Xo = 200; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 237:
                {
					m_Scroll.Xo = 300; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 238:
                {
					m_Scroll.Xo = 400; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 239:
                {
					m_Scroll.Xo = 500; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 240:
                {
					m_Scroll.Xo = 600; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 241:
                {
					m_Scroll.Xo = 700; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 242:
                {
					m_Scroll.Xo = 800; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 243:
                {
					m_Scroll.Xo = 900; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 244:
                {
					m_Scroll.Xo = 1000; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 245:
                {
					m_Scroll.Xo = 1100; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 246:
                {
					m_Scroll.Xo = 1200; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 247:
                {
					m_Scroll.Xo = 1300; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 248:
                {
					m_Scroll.Xo = 1400; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 249:
                {
					m_Scroll.Xo = 1500; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 250:
                {
					m_Scroll.Xo = 1600; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 251:
                {
					m_Scroll.Xo = 1700; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 252:
                {
					m_Scroll.Xo = 1800; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 253:
                {
					m_Scroll.Xo = 1900; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				case 254:
                {
					m_Scroll.Xo = 2000; m_Scroll.Yo = 1100;
					from.SendGump( new PositionGump ( from, m_Scroll ) );     Refresh(from); 
					break;
				}
				
								
				
				
			}
		

		}
		
		
	}
}
