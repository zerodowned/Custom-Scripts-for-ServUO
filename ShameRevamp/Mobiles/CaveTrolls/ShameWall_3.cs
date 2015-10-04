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
    public class ShameWall_3 : BaseAddon
    {
	
		private CaveTroll3 mCaveTroll3;
		
		private Timer m_SummonTroll;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public CaveTroll3 Link
		{
			get
			{
				return mCaveTroll3;
			}
		}
		
		private static int[,] m_AddOnComplexComponents = new int[,] {
			  {1059, 0, 0, 0}, {1059, 1, 0, 0}, {1059, 2, 0, 0}
		};
	
        [Constructable]
        public ShameWall_3() : base( ) 
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
			new CaveTroll3(this).MoveToWorld( new Point3D( 5619, 43, 0), this.Map );
			
			Teleporter first = new Teleporter( new Point3D( 5619, 43, 0), this.Map); // destination
            first.MoveToWorld(new Point3D(5618, 52, 0), this.Map); // location
			
			Teleporter second = new Teleporter( new Point3D( 5619, 43, 0), this.Map); // destination
            second.MoveToWorld(new Point3D(5619, 52, 0), this.Map); // location
			
			Teleporter third = new Teleporter( new Point3D( 5619, 43, 0), this.Map); // destination
            third.MoveToWorld(new Point3D(5620, 52, 0), this.Map); // location
			
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
			mCaveTroll3.Delete();
			this.Delete();
			return;
		}
*/
        public ShameWall_3(Serial serial) : base(serial)
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
			
			writer.Write( ( Mobile )mCaveTroll3 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
			
			mCaveTroll3 = ( CaveTroll3 )reader.ReadMobile( );
        }
		
		///////////////////////		
		private class SummonTroll  : Timer
		{
			private ShameWall_3 m_wall;
			
		
			public SummonTroll ( ShameWall_3 wall ) : base( TimeSpan.Zero )
			{
				m_wall = wall;
			}
			
			public void Summon()
			{
				CaveTroll3 Idam = new CaveTroll3( m_wall );
				
				m_wall.mCaveTroll3 = Idam;
				
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