using Server.Engines.VeteranRewards;
using Server.Multis;
using Server.Network;
using System;
using Server.Targeting;
using Server.Accounting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
    public class MapCharter : Item
    {
        public Timer m_Timer;
        private bool _isActive;
		private string _Account;

		[CommandProperty(AccessLevel.GameMaster)]
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

       [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem { get; set; } = false;

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextResourceCount { get; set; }

        public override bool ForceShowProperties => true;

        [Constructable]
        public MapCharter() : base(43059)
        {
            Weight = 0;
            Name = "Map Charter";
            IsActive = false;

            /* m_Timer = new InternalTimer(this);
            m_Timer.Start(); */
        }

        public MapCharter(Serial serial)
            : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add($"Treasure Maps Created {ResourceCount.ToString()}" ); 

            list.Add( IsActive ? "Active" : "Inactive" ); 
        }

        private int m_ResourceCount;

        [CommandProperty(AccessLevel.GameMaster)]
        public int ResourceCount 
        { 
            get => m_ResourceCount; 
            set 
            { 
                m_ResourceCount = value; 
            
                InvalidateProperties(); 
            } 
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            BaseHouse house = BaseHouse.GetHouseRegion( this );
            Account acct = from.Account as Account;
            int charters = Convert.ToInt32(acct.GetTag("MapCharters")); // Acct tag

            
            if(house == null)
            {
                if (charters >= 6) 
                {    
                    from.SendMessage($"You have already placed {charters} Map Charters, the max is 6");
                    return;
                }
                else 
                {
                    if ( IsChildOf( from.Backpack ) )
                        from.Target = new MapCharterTarget(from, this);
                }
            }
            else
            {
                
                if(!_isActive)
                {
                    from.SendMessage("----------------------------");
                    from.SendMessage("This Map Charter has not been activated yet.");
                    from.SendMessage("To activate it please place in your backpack and double click to place it inside your house.");
                    from.SendMessage("----------------------------");
                    return;
                }
                if( _Account != acct.Username )
                {    
                    from.SendMessage("This does not belong to your account");
                    return;
                }

                if (!from.InRange(GetWorldLocation(), 2) || !from.InLOS(this) )
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                }
                else if (house != null && (house.IsOwner(from) || house.LockDowns.ContainsKey(this) && house.LockDowns[this] == from))
                {
                    if (m_ResourceCount > 0)
                    {
                        Map map;

                        switch (Utility.Random(8))
                        {
                            default:
                            case 0:  map = Map.Trammel; break;
                            case 1:  map = Map.Felucca; break;
                            case 2:
                            case 3:  map = Map.Ilshenar; break;
                            case 4:
                            case 5:  map = Map.Malas; break;
                            case 6:
                            case 7:  map = Map.Tokuno; break;
                        }

                        TreasureMap tmap = new TreasureMap(Utility.RandomMinMax(0, 4), map);

                        if (tmap != null)
                        {
                            ResourceCount--;
                            from.SendMessage("A treasure map has been placed into your backpack");
                            from.AddToBackpack(tmap);
                        }

                        if(ResourceCount < 5 && !m_Timer.Running ) // Enabled = Timer is Running
                        {    
                            m_Timer.Start();

                            Console.WriteLine("Timer has been started via dbl click");
                            Console.WriteLine("  ");
                        }
                    }
                    else
                    {
                        from.SendMessage("There are currently no treasure maps to collect."); // There are currently no resources to collect.
                    }
                }
            }

            /* BaseHouse house = BaseHouse.GetHouseRegion( this );

            if (!from.InRange(GetWorldLocation(), 2) || !from.InLOS(this) )
            {
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
            }
            else if (house != null && (house.IsOwner(from) || house.LockDowns.ContainsKey(this) && house.LockDowns[this] == from))
            {
                if (m_ResourceCount > 0)
                {
                    Map map;

                    switch (Utility.Random(8))
                    {
                        default:
                        case 0:  map = Map.Trammel; break;
                        case 1:  map = Map.Felucca; break;
                        case 2:
                        case 3:  map = Map.Ilshenar; break;
                        case 4:
                        case 5:  map = Map.Malas; break;
                        case 6:
                        case 7:  map = Map.Tokuno; break;
                    }

                    TreasureMap tmap = new TreasureMap(Utility.RandomMinMax(0, 4), map);

                    if (tmap != null)
                    {
                        ResourceCount--;
                        from.SendMessage("A treasure map has been placed into your backpack");
                        from.AddToBackpack(tmap);
                    }

                    if(ResourceCount < 5 && !m_Timer.Running ) // Enabled = Timer is Running
                    {    
                        m_Timer.Start();

                        Console.WriteLine("Timer has been started via dbl click");
                        Console.WriteLine("  ");
                    }
                }
                else
                {
                    from.SendMessage("There are currently no treasure maps to collect."); // There are currently no resources to collect.
                }
            }
            else
            {
                from.SendLocalizedMessage(502092); // You must be in your house to do this.
            } */
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

           BaseHouse house = BaseHouse.GetHouseRegion( this );

            if(house != null && house.IsCoOwner(from))
                list.Add(new RedeedEntry(from, this));
        }

        private class RedeedEntry : ContextMenuEntry
        {
            private readonly Mobile _From;
            private readonly MapCharter _Charter;

            public RedeedEntry(Mobile from, MapCharter m) : base(1153880, 2)
            {
                _From = from;
                _Charter = m;
            }

            public override void OnClick()
            {
                int resourcecount = _Charter.ResourceCount;

                if(_Charter.IsActive && !_Charter.Movable)
                {
                    Account acct = _From.Account as Account;
                    int charters = Convert.ToInt32(acct.GetTag("MapCharters")); // Acct tag
                   
                    acct.SetTag("MapCharters", (charters - 1).ToString()); 

                    //_From.SendMessage($"{charters}");
                }

                

                _Charter.Delete();
                MapCharter charter = new MapCharter();
                charter.ResourceCount = resourcecount;

                _From.AddToBackpack(charter);
            }
        }

        public class MapCharterTarget : Target
		{
			private Mobile m_From;
			private MapCharter m_Deed;
			
			public MapCharterTarget( Mobile from, MapCharter deed ) :  base ( 10, false, TargetFlags.None )
			{
				m_Deed = deed;
				m_From = from;
				//from.SendMessage("Select an animal to bond");
			}
            protected override void OnTarget( Mobile from, object targeted )
            {
               	IPoint3D p = targeted as IPoint3D;
                Map map = from.Map;

                BaseHouse house = BaseHouse.GetHouseRegion( from );

                if( house == null )
                {    
                    from.SendLocalizedMessage(502092); // You must be in your house to do this.
                }
                else if( house != null && !(house.IsOwner(from) ) )
                {    
                    from.SendLocalizedMessage(502092); // You must be in your house to do this.
                }
                else if ( !from.InLOS(p) )
                {
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                }
                if(targeted is Item)
                {
                    return;
                }
                else
                {
                    Account acct = from.Account as Account;
                    int charters = Convert.ToInt32(acct.GetTag("MapCharters")); // Acct tag

                    MapCharter mc = new MapCharter();
                    mc.ResourceCount = m_Deed.ResourceCount;
                    mc.IsActive = true;
                    mc.MoveToWorld(new Point3D(p), from.Map);
                    mc.Account = acct.Username;
                    mc.Movable = false;
                    
                    m_Deed.Delete();

                    if(mc.IsActive && mc.m_Timer == null )
                    {
                        mc.m_Timer = new InternalTimer(mc);
                        mc.m_Timer.Start();
                    }

                    if (charters < 1) 
                        acct.SetTag("MapCharters", "1"); 
                    else 
                        acct.SetTag("MapCharters", (charters + 1).ToString()); // Bump up - Set to default 2 if 0

                }
                
                
                	
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(2);

            //2
            writer.Write((bool)_isActive);

            //1
            writer.Write(_Account);

            //0
            writer.Write(IsRewardItem);
            writer.Write(m_ResourceCount);

             
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch( version )
			{
                case 2:
                    {
                        _isActive = reader.ReadBool();
                        goto case 1;
                    }
                case 1:
                    {
                        _Account = reader.ReadString();
                        goto case 0;
                    }
				case 0:
					{
						IsRewardItem = reader.ReadBool();
                        m_ResourceCount = reader.ReadInt();
						break;
					}
			}


            if(IsActive)
            {
                m_Timer = new InternalTimer(this);
                m_Timer.Start();
            }
            
        }

        private class InternalTimer : Timer
        {
            private readonly MapCharter charter;

            public InternalTimer(MapCharter m_charter) : base(TimeSpan.FromHours(8.0), TimeSpan.FromHours(8.0))
            {
                charter = m_charter;
            }

            protected override void OnTick()
            {
                if(!charter.IsActive && charter.m_Timer != null && charter.m_Timer.Running)
                    charter.m_Timer.Stop();

                if(charter.ResourceCount < 5)
                    charter.ResourceCount++;

                charter.InvalidateProperties(); 

                /* Console.WriteLine("Timer tick");
                Console.WriteLine("  "); */

                if(charter.ResourceCount >= 5 && charter.m_Timer != null && charter.m_Timer.Running ) // Enabled = Timer is Running
                {    
                    charter.m_Timer.Stop();
                    /* Console.WriteLine("Timer has been stopped");
                    Console.WriteLine("  "); */
                }
            }
        }
    }
}
