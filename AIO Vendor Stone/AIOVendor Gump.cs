using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Multis;
using Server.Regions;

namespace Server.Items
{
	public class AIOGump : Gump
	{
		private Mobile m_From;
		public AIOGump( Mobile from ) : base( 25,25 )
		{
			m_From = from;
			m_From.CloseGump( typeof( AIOGump ) );
			
			AddPage(0);
	
			AddBackground( 60, 51, 369, 512, 5054 );
			AddImageTiled( 68, 61, 350, 495, 2624 );
			AddAlphaRegion( 68, 61, 350, 495 );
	
// text hue set to 1153, should be white text unless you have custom hues	
									
			AddLabel(170, 70, 1153, "Vendor Selection");	
			
			AddButton(77, 111, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				AddLabel(112, 114, 1153, @"Alchemist");
			AddButton(77, 137, 4005, 4007, 2, GumpButtonType.Reply, 0 );
				AddLabel(112, 140, 1153, @"Animal Trainer");
			AddButton(77, 163, 4005, 4007, 3, GumpButtonType.Reply, 0 );
				AddLabel(112, 166, 1153, @"Architect");
			AddButton(77, 189, 4005, 4007, 4, GumpButtonType.Reply, 0 );
				AddLabel(112, 192, 1153, @"Armorer");
			AddButton(76, 214, 4005, 4007, 5, GumpButtonType.Reply, 0 );
				AddLabel(112, 218, 1153, @"Baker");
			AddButton(77, 241, 4005, 4007, 6, GumpButtonType.Reply, 0 );
				AddLabel(112, 244, 1153, @"Bard");
			AddButton(77, 267, 4005, 4007, 7, GumpButtonType.Reply, 0 );
				AddLabel(112, 270, 1153, @"Barkeeper");
			AddButton(77, 293, 4005, 4007, 8, GumpButtonType.Reply, 0 );
				AddLabel(112, 296, 1153, @"Beekeeper");
			AddButton(77, 319, 4005, 4007, 9, GumpButtonType.Reply, 0 );
				AddLabel(112, 322, 1153, @"Blacksmith");
			AddButton(77, 345, 4005, 4007, 10, GumpButtonType.Reply, 0 );
				AddLabel(112, 348, 1153, @"Bowyer");
			AddButton(77, 370, 4005, 4007, 11, GumpButtonType.Reply, 0 );
				AddLabel(112, 374, 1153, @"Butcher");
			AddButton(77, 397, 4005, 4007, 12, GumpButtonType.Reply, 0 );
				AddLabel(112, 400, 1153, @"Carpenter");
			AddButton(77, 422, 4005, 4007, 13, GumpButtonType.Reply, 0 );
				AddLabel(112, 425, 1153, @"Cobbler");
			AddButton(77, 447, 4005, 4007, 14, GumpButtonType.Reply, 0 );
				AddLabel(112, 450, 1153, @"Cook");
			AddButton(77, 472, 4005, 4007, 15, GumpButtonType.Reply, 0 );
				AddLabel(112, 475, 1153, @"Fisherman");
			AddButton(77, 497, 4005, 4007, 16, GumpButtonType.Reply, 0 );
				AddLabel(112, 500, 1153, @"Furtrader");
			AddButton(250, 111, 4005, 4007, 17, GumpButtonType.Reply, 0 );
				AddLabel(285, 114, 1153, @"Herbalist");
			AddButton(250, 137, 4005, 4007, 18, GumpButtonType.Reply, 0 );
				AddLabel(285, 140, 1153, @"Innkeeper");
			AddButton(250, 163, 4005, 4007, 19, GumpButtonType.Reply, 0 );
				AddLabel(285, 166, 1153, @"Jeweler");
			AddButton(250, 189, 4005, 4007, 20, GumpButtonType.Reply, 0 );
				AddLabel(285, 192, 1153, @"Leather Worker");
			AddButton(250, 214, 4005, 4007, 21, GumpButtonType.Reply, 0 );
				AddLabel(285, 217, 1153, @"Mage");
			AddButton(250, 241, 4005, 4007, 22, GumpButtonType.Reply, 0 );
				AddLabel(285, 244, 1153, @"Map Maker");
			AddButton(250, 268, 4005, 4007, 23, GumpButtonType.Reply, 0 );
				AddLabel(285, 271, 1153, @"Provisioner");
			AddButton(250, 293, 4005, 4007, 24, GumpButtonType.Reply, 0 );
				AddLabel(285, 296, 1153, @"Real Estate Broker");
			AddButton(250, 319, 4005, 4007, 25, GumpButtonType.Reply, 0 );
				AddLabel(285, 322, 1153, @"Scribe");
			AddButton(250, 345, 4005, 4007, 26, GumpButtonType.Reply, 0 );
				AddLabel(285, 348, 1153, @"Shipwright");
			AddButton(250, 370, 4005, 4007, 27, GumpButtonType.Reply, 0 );
				AddLabel(285, 373, 1153, @"Tailor");
			AddButton(250, 396, 4005, 4007, 28, GumpButtonType.Reply, 0 );
				AddLabel(285, 399, 1153, @"Tanner");
			AddButton(250, 422, 4005, 4007, 29, GumpButtonType.Reply, 0 );
				AddLabel(285, 425, 1153, @"Tinker");
			AddButton(250, 447, 4005, 4007, 30, GumpButtonType.Reply, 0 );
				AddLabel(285, 450, 1153, @"Veterinarian");
			AddButton(250, 472, 4005, 4007, 31, GumpButtonType.Reply, 0 );
				AddLabel(285, 475, 1153, @"Weaponsmith");
			AddButton(250, 497, 4005, 4007, 32, GumpButtonType.Reply, 0 );
				AddLabel(285, 500, 1153, @"Weaver");
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
			{
				Mobile AIOAlchemist = new AIOAlchemist();
				AIOAlchemist.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//AIOAlchemist.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
				//return;	
			}
			else if ( info.ButtonID == 2 )
			{
				Mobile AIOAnimalTrainer = new AIOAnimalTrainer();
				AIOAnimalTrainer.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 3 )
			{
				Mobile AIOArchitect = new AIOArchitect();
				AIOArchitect.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 4 )
			{
				Mobile AIOArmorer = new AIOArmorer();
				AIOArmorer.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 5 )
			{
				Mobile AIOBaker = new AIOBaker();
				AIOBaker.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 6 )
			{
				Mobile AIOBard = new AIOBard();
				AIOBard.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 7 )
			{
				Mobile AIOBarkeeper = new AIOBarkeeper();
				AIOBarkeeper.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 8 )
			{
				Mobile AIOBeekeeper = new AIOBeekeeper();
				AIOBeekeeper.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 9 )
			{
				Mobile AIOBlacksmith = new AIOBlacksmith();
				AIOBlacksmith.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 10 )
			{
				Mobile AIOBowyer = new AIOBowyer();
				AIOBowyer.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 11 )
			{
				Mobile AIOButcher = new AIOButcher();
				AIOButcher.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 12 )
			{
				Mobile AIOCarpenter = new AIOCarpenter();
				AIOCarpenter.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 13 )
			{
				Mobile AIOCobbler = new AIOCobbler();
				AIOCobbler.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 14 )
			{
				Mobile AIOCook = new AIOCook();
				AIOCook.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 15 )
			{
				Mobile AIOFisherman = new AIOFisherman();
				AIOFisherman.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 16 )
			{
				Mobile AIOFurtrader = new AIOFurtrader();
				AIOFurtrader.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 17 )
			{
				Mobile AIOHerbalist = new AIOHerbalist();
				AIOHerbalist.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 18 )
			{
				Mobile AIOInnKeeper = new AIOInnKeeper();
				AIOInnKeeper.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 19 )
			{
				Mobile AIOJeweler = new AIOJeweler();
				AIOJeweler.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 20 )
			{
				Mobile AIOLeatherWorker = new AIOLeatherWorker();
				AIOLeatherWorker.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 21 )
			{
				Mobile AIOMage = new AIOMage();
				AIOMage.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 22 )
			{
				Mobile AIOMapmaker = new AIOMapmaker();
				AIOMapmaker.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 23 )
			{
				Mobile AIOProvisioner = new AIOProvisioner();
				AIOProvisioner.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 24 )
			{
				Mobile AIORealEstateBroker = new AIORealEstateBroker();
				AIORealEstateBroker.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 25 )
			{
				Mobile AIOScribe = new AIOScribe();
				AIOScribe.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 26 )
			{
				Mobile AIOShipwright = new AIOShipwright();
				AIOShipwright.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 27 )
			{
				Mobile AIOTailor = new AIOTailor();
				AIOTailor.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 28 )
			{
				Mobile AIOTanner = new AIOTanner();
				AIOTanner.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 29 )
			{
				Mobile AIOTinker = new AIOTinker();
				AIOTinker.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 30 )
			{
				Mobile AIOVeterinarian = new AIOVeterinarian();
				AIOVeterinarian.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 31 )
			{
				Mobile AIOWeaponsmith = new AIOWeaponsmith();
				AIOWeaponsmith.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else if ( info.ButtonID == 32 )
			{
				Mobile AIOWeaver = new AIOWeaver();
				AIOWeaver.MoveToWorld( new Point3D( m_From.X + Utility.RandomMinMax( -1, 1 ), m_From.Y + Utility.RandomMinMax( -1, 1 ), m_From.Z ), m_From.Map );
				//m_From.SendGump( new AIOGump( m_From ) );
			}
			else
			{
				m_From.SendLocalizedMessage( 502694 ); // Cancelled action.
			}
		}

	}
}