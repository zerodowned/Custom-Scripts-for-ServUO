#region References
using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Commands;
#endregion

namespace Server.Items
{
    public class ShameWall_2 : BaseAddon
    {
	
		private CaveTroll2 mCaveTroll2;
		
		private Timer m_SummonTroll;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public CaveTroll2 Link
		{
			get
			{
				return mCaveTroll2;
			}
		}
		
		private static int[,] m_AddOnComplexComponents = new int[,] {
			  {2272, 0, 0, 0}, {2272, 0, 1, 0}, {2272, 0, 2, 0}
			, {2272, 0, 3, 0}
		};
	
        [Constructable]
        public ShameWall_2() : base( ) 
        {
			Movable = false;
			
			this.m_SummonTroll = new SummonTroll (this);
				this.m_SummonTroll.Start();
		
			for (int i = 0; i < m_AddOnComplexComponents.Length / 4; i++)
			
                AddComponent( new AddonComponent( m_AddOnComplexComponents[i,0] ), m_AddOnComplexComponents[i,1], m_AddOnComplexComponents[i,2], m_AddOnComplexComponents[i,3]  );
			
		
            Hue = 0;
            
        }
		
		private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
		{
			AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null);
		}

		private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name)
		{
			AddonComponent ac;
			ac = new AddonComponent(item);
			if (name != null) ac.Name = name;
			if (hue != 0) ac.Hue = hue;
			if (lightsource != -1) ac.Light = (LightType) lightsource;
			addon.AddComponent(ac, xoffset, yoffset, zoffset);
		}

		
		public void Update( )
		{
			new CaveTroll2(this).MoveToWorld( new Point3D( 5473, 26, -30), this.Map );
			
			Teleporter first = new Teleporter( new Point3D(5473, 26, -30), this.Map); // destination
            first.MoveToWorld(new Point3D(5464, 25, -10), this.Map); // location
			
			Teleporter second = new Teleporter( new Point3D(5473, 26, -30), this.Map); // destination
            second.MoveToWorld(new Point3D(5464, 26, -10), this.Map); // location
			
			Teleporter third = new Teleporter( new Point3D(5473, 26, -30), this.Map); // destination
            third.MoveToWorld(new Point3D(5464, 27, -10), this.Map); // location
			
			Teleporter fourth = new Teleporter( new Point3D(5473, 26, -30), this.Map); // destination
            fourth.MoveToWorld(new Point3D(5464, 28, -10), this.Map); // location
		}
		
		public void RemoveTele()
		{
			List<Item> list = new List<Item>();
			foreach( Item item in this.GetItemsInRange( 5 ) ) 
			{
				if (item is Teleporter)
				list.Add(item);
			}
			
			foreach (Item item in list)
			item.Delete();
		}
		
	/*	
		public void Remove()
		{
			//base.Delete();
			mCaveTroll2.Delete();
			this.Delete();
			return;
		}
*/
        public ShameWall_2(Serial serial) : base(serial)
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
			
			writer.Write( ( Mobile )mCaveTroll2 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
			
			mCaveTroll2 = ( CaveTroll2 )reader.ReadMobile( );
        }
		
		///////////////////////		
		private class SummonTroll  : Timer
		{
			private ShameWall_2 m_wall;
			
		
			public SummonTroll ( ShameWall_2 wall ) : base( TimeSpan.Zero )
			{
				m_wall = wall;
			}
			
			public void Summon()
			{
				CaveTroll2 Idam = new CaveTroll2( m_wall );
				
				m_wall.mCaveTroll2 = Idam;
				
				m_wall.Update( );
			}

			protected override void OnTick()
			{
				Summon();
				Stop();
				
			
			}
		}
		

    }
}