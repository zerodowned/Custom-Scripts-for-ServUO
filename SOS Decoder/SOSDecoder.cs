using System;
using Server.Multis;
using Server.Targeting;
using System.Linq;
using Server.Mobiles;
using Server.Items;


namespace Server.Items
{
    public class SOSDecoder : Item
    {
        private bool requiresCharges;
        private int charges;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool RequiresCharges
        {
            get => requiresCharges;
            set
            {
                requiresCharges = value;
                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get => charges;
            set
            {
                charges = value;
                InvalidateProperties();
            }
        }

        [Constructable]
        public SOSDecoder() : base(22398)
        {
            Movable = true;
            Hue = 1366;
            Weight = 0.0;
            Name = "SOS Instant Transporter";
            LootType = LootType.Blessed;

            RequiresCharges = false;
        }

        public SOSDecoder(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("Creates a gateway directly to the<br>location of a SOS");

            if (RequiresCharges)
                list.Add(string.Format("Uses Remaining: {0}", Charges));
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.Player)
                return;

            if( from.Ring is WaterRing  )
            {
                if(from.InRange(GetWorldLocation(), 1))
                {
                    UseBook(from, false);
                    return;
                }
                else
                    from.SendLocalizedMessage(500446); // That is too far away. 
            }

            else
            {
                BaseBoat boat = BaseBoat.FindBoatAt(from, from.Map);

                if(boat == null)
                {
                    from.SendMessage("You must be on a boat or a Sea Horse before using this");
                    return;
                }
                
                else if(boat != null && boat.IsMoving)
                {
                    from.SendMessage("Stop the boat before using this.");
                    return;
                }
                
            
                if (from.InRange(GetWorldLocation(), 1))
                    UseBook(from, true );
                else
                    from.SendLocalizedMessage(500446); // That is too far away. 
            }
        }

        public bool UseBook(Mobile m, bool hasBoat)
        {

            if (m.Criminal)
            {
                m.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily. 
                return false;
            }
            else if (Server.Spells.SpellHelper.CheckCombat(m))
            {
                m.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle?? 
                return false;
            }
            else if (Server.Misc.WeightOverloading.IsOverloaded(m))
            {
                m.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
                return false;
            }
            else if (m.Region is Server.Regions.Jail)
            {
                m.SendLocalizedMessage(1041530, "", 0x35); // You'll need a better jailbreak plan then that!
                return false;
            }

            else if (m.Spell != null)
            {
                m.SendLocalizedMessage(1049616); // You are too busy to do that at the moment. 
                return false;
            }

            else if (RequiresCharges & Charges < 1)
            {
                m.SendMessage("This book does not have any uses remaining.");
                return false;
            }

            else
            {
                m.Target = new SOSTarget(this, hasBoat);
                m.SendMessage("Target a SOS");
                return true;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 

            writer.Write(requiresCharges);
            writer.Write(charges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            requiresCharges = reader.ReadBool();
            charges = reader.ReadInt();
        }
    }

    public class SOSTarget : Target // Create our targeting class (which we derive from the base target class)
    {
        private readonly SOSDecoder _sos;
        private bool HasBoat; 

        public SOSTarget(SOSDecoder sos, bool hasBoat) : base(1, false, TargetFlags.None)
        {
            _sos = sos;
            HasBoat = hasBoat;
        }

        protected override void OnTarget(Mobile from, object target) // Override the protected OnTarget() for our feature
        {
            if (target is SOS)
            {
                Item item = (Item)target;
                int newX = 0;
                int newY = 0;

                if (item.Deleted || item.RootParent != from)
                    return;

                SOS sos = (SOS)target;
                Map map = sos.TargetMap;

                bool ring = false;

                if( from.Ring is WaterRing  )
                {
                    ring = true;
                }

                BaseBoat boat = BaseBoat.FindBoatAt(from, from.Map);

                if(boat == null && !ring)
                {
                    from.SendMessage("You must be on a boat or a Sea Horse before using this");
                    return;
                }
                
                else if(!ring && boat != null && boat.IsMoving)
                {
                    from.SendMessage("Stop the boat before using this.");
                    return;
                }

                if(!ring && boat != null)
                {
                    //BaseBoat boat = BaseBoat.FindBoatAt(from, map);

                    for (int i = 0; i < 5; i++) // Try 5 times
                    {
                        int x = Utility.Random(sos.TargetLocation.X, 20);
                        int y = Utility.Random(sos.TargetLocation.Y, 20);
                        int z = map.GetAverageZ(x, y);

                        Point3D dest = new Point3D(x, y, z);

                        if (boat.CanFit(dest, map, boat.ItemID))
                        {
                            int xOffset = x - boat.X;
                            int yOffset = y - boat.Y;
                            int zOffset = z - boat.Z;

                            boat.Teleport(xOffset, yOffset, zOffset);

                            if (boat.Facing == Direction.North || boat.Facing == Direction.South)
                            {
                                Point3D pLeft = new Point3D(boat.X - 3, boat.Y, 1);
                                Effects.SendLocationEffect(pLeft, boat.Map, 8104, 20, 10);

                                Point3D pRight = new Point3D(boat.X + 3, boat.Y, 1);
                                Effects.SendLocationEffect(pRight, boat.Map, 8109, 20, 10);
                            }

                            if (boat.Facing == Direction.East || boat.Facing == Direction.West)
                            {
                                Point3D pLeft = new Point3D(boat.X, boat.Y - 3, 1);
                                Effects.SendLocationEffect(pLeft, boat.Map, 8099, 20, 10);

                                Point3D pRight = new Point3D(boat.X, boat.Y + 3, 1);
                                Effects.SendLocationEffect(pRight, boat.Map, 8114, 20, 10);
                            }
                            return;
                        }
                    }
                }
                else
                {
                    from.MoveToWorld(new Point3D(sos.TargetLocation.X, sos.TargetLocation.Y, map.GetAverageZ(sos.TargetLocation.X, sos.TargetLocation.Y)), map);
                }

                if (_sos.RequiresCharges)
                    _sos.Charges--;
            
            }
            else
            {
                from.SendMessage("You can only use this on a SOS!");
            }
        }
    }
}
