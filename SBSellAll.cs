using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBSellAll: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBSellAll() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{  
			}
		}

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
//SHIPWRIGHT
				//Add( new GenericBuyInfo( "1041205", typeof( SmallBoatDeed ), 10177, 20, 0x14F2, 0 ) );
				//Add( new GenericBuyInfo( "1041206", typeof( SmallDragonBoatDeed ), 10177, 20, 0x14F2, 0 ) );
				//Add( new GenericBuyInfo( "1041207", typeof( MediumBoatDeed ), 11552, 20, 0x14F2, 0 ) );
				//Add( new GenericBuyInfo( "1041208", typeof( MediumDragonBoatDeed ), 11552, 20, 0x14F2, 0 ) );
				//Add( new GenericBuyInfo( "1041209", typeof( LargeBoatDeed ), 12927, 20, 0x14F2, 0 ) );
				//Add( new GenericBuyInfo( "1041210", typeof( LargeDragonBoatDeed ), 12927, 20, 0x14F2, 0 ) );
//ALCHEMIST
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ), 3 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 
				Add( typeof( Bottle ), 3 );
				Add( typeof( MortarPestle ), 4 );
				Add( typeof( HairDye ), 19 );

				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 10 );
//THEIF
				Add( typeof( Backpack ), 7 );
				Add( typeof( Pouch ), 3 );
				Add( typeof( Torch ), 3 );
				Add( typeof( Lantern ), 1 );
				//Add( typeof( OilFlask ), 4 );
				Add( typeof( Lockpick ), 6 );
				Add( typeof( WoodenBox ), 7 );
				Add( typeof( HairDye ), 19 );
//TAVERN KEEPER
				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );
				Add( typeof( BeverageBottle ), 3 );
				Add( typeof( Jug ), 6 );
				Add( typeof( Pitcher ), 5 );
				Add( typeof( GlassMug ), 1 );
				Add( typeof( BreadLoaf ), 3 );
				Add( typeof( CheeseWheel ), 12 );
				Add( typeof( Ribs ), 6 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Banana ), 1 );
				Add( typeof( Candle ), 3 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );
				Add( typeof( ContractOfEmployment ), 626 );
//TANNER
				Add( typeof( Bag ), 3 );
				Add( typeof( Pouch ), 3 );
				Add( typeof( Backpack ), 7 );

				Add( typeof( Leather ), 5 );

				Add( typeof( SkinningKnife ), 7 );
				
				Add( typeof( LeatherArms ), 18 );
				Add( typeof( LeatherChest ), 23 );
				Add( typeof( LeatherGloves ), 15 );
				Add( typeof( LeatherGorget ), 15 );
				Add( typeof( LeatherLegs ), 18 );
				Add( typeof( LeatherCap ), 5 );

				Add( typeof( StuddedArms ), 43 );
				Add( typeof( StuddedChest ), 37 );
				Add( typeof( StuddedGloves ), 39 );
				Add( typeof( StuddedGorget ), 22 );
				Add( typeof( StuddedLegs ), 33 );

				Add( typeof( FemaleStuddedChest ), 31 );
				Add( typeof( StuddedBustierArms ), 23 );
				Add( typeof( FemalePlateChest), 103 );
				Add( typeof( FemaleLeatherChest ), 18 );
				Add( typeof( LeatherBustierArms ), 12 );
				Add( typeof( LeatherShorts ), 14 );
				Add( typeof( LeatherSkirt ), 12 );
//TAILOR
				Add( typeof( Scissors ), 6 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Dyes ), 4 );
				Add( typeof( DyeTub ), 4 );

				Add( typeof( BoltOfCloth ), 50 );

				Add( typeof( FancyShirt ), 10 );
				Add( typeof( Shirt ), 6 );

				Add( typeof( ShortPants ), 3 );
				Add( typeof( LongPants ), 5 );

				Add( typeof( Cloak ), 4 );
				Add( typeof( FancyDress ), 12 );
				Add( typeof( Robe ), 9 );
				Add( typeof( PlainDress ), 7 );

				Add( typeof( Skirt ), 5 );
				Add( typeof( Kilt ), 5 );

				Add( typeof( Doublet ), 7 );
				Add( typeof( Tunic ), 9 );
				Add( typeof( JesterSuit ), 13 );

				Add( typeof( FullApron ), 5 );
				Add( typeof( HalfApron ), 5 );

				Add( typeof( JesterHat ), 6 );
				Add( typeof( FloppyHat ), 3 );
				Add( typeof( WideBrimHat ), 4 );
				Add( typeof( Cap ), 5 );
				Add( typeof( SkullCap ), 3 );
				Add( typeof( Bandana ), 3 );
				Add( typeof( TallStrawHat ), 4 );
				Add( typeof( StrawHat ), 4 );
				Add( typeof( WizardsHat ), 5 );
				Add( typeof( Bonnet ), 4 );
				Add( typeof( FeatheredHat ), 5 );
				Add( typeof( TricorneHat ), 4 );

				Add( typeof( SpoolOfThread ), 9 );

				Add( typeof( Flax ), 51 );
				Add( typeof( Cotton ), 51 );
				Add( typeof( Wool ), 31 );
//STONE CRAFTER
				Add( typeof( MasonryBook ), 5000 );
				Add( typeof( StoneMiningBook ), 5000 );
				Add( typeof( MalletAndChisel ), 1 );

				Add( typeof( WoodenBox ), 7 );
				Add( typeof( SmallCrate ), 5 );
				Add( typeof( MediumCrate ), 6 );
				Add( typeof( LargeCrate ), 7 );
				Add( typeof( WoodenChest ), 15 );
              
				Add( typeof( LargeTable ), 10 );
				Add( typeof( Nightstand ), 7 );
				Add( typeof( YewWoodTable ), 10 );

				Add( typeof( Throne ), 24 );
				Add( typeof( WoodenThrone ), 6 );
				Add( typeof( Stool ), 6 );
				Add( typeof( FootStool ), 6 );

				Add( typeof( FancyWoodenChairCushion ), 12 );
				Add( typeof( WoodenChairCushion ), 10 );
				Add( typeof( WoodenChair ), 8 );
				Add( typeof( BambooChair ), 6 );
				Add( typeof( WoodenBench ), 6 );

				Add( typeof( Saw ), 9 );
				Add( typeof( Scorp ), 6 );
				Add( typeof( SmoothingPlane ), 6 );
				Add( typeof( DrawKnife ), 6 );
				Add( typeof( Froe ), 6 );
				Add( typeof( Hammer ), 14 );
				Add( typeof( Inshave ), 6 );
				Add( typeof( JointingPlane ), 6 );
				Add( typeof( MouldingPlane ), 6 );
				Add( typeof( DovetailSaw ), 7 );
				Add( typeof( Board ), 2 );
				Add( typeof( Axle ), 1 );

				Add( typeof( WoodenShield ), 31 );
				Add( typeof( BlackStaff ), 24 );
				Add( typeof( GnarledStaff ), 12 );
				Add( typeof( QuarterStaff ), 15 );
				Add( typeof( ShepherdsCrook ), 12 );
				Add( typeof( Club ), 13 );

				Add( typeof( Log ), 1 );
//SMITHTOOLS
				Add( typeof( Tongs ), 7 ); 
				Add( typeof( IronIngot ), 4 ); 
//SE HATS
				Add( typeof( Kasa ), 15 );
				Add( typeof( LeatherJingasa ), 5 );
				Add( typeof( ClothNinjaHood ), 16 );
//SE COOK 
				Add( typeof( Wasabi ), 1 );
				Add( typeof( BentoBox ), 3 );
				Add( typeof( GreenTea ), 1 );
				Add( typeof( SushiRolls ), 1 );
				Add( typeof( SushiPlatter ), 2 );
				Add( typeof( MisoSoup ), 1 );
				Add( typeof( RedMisoSoup ), 1 );
				Add( typeof( WhiteMisoSoup ), 1 );
				Add( typeof( AwaseMisoSoup ), 1 );
//SCRIBE
				Add( typeof( ScribesPen ), 4 );
				Add( typeof( BrownBook ), 7 );
				Add( typeof( TanBook ), 7 );
				Add( typeof( BlueBook ), 7 );
				Add( typeof( BlankScroll ), 3 );
//REAL ESTATE BROKER
				Add( typeof( ScribesPen ), 4 );
				Add( typeof( BrownBook ), 7 );
				Add( typeof( TanBook ), 7 );
				Add( typeof( BlueBook ), 7 );
				Add( typeof( BlankScroll ), 3 );
//PROVISIONER
				Add( typeof( Arrow ), 1 );
				Add( typeof( Bolt ), 2 );
				Add( typeof( Backpack ), 7 );
				Add( typeof( Pouch ), 3 );
				Add( typeof( Bag ), 3 );
				Add( typeof( Candle ), 3 );
				Add( typeof( Torch ), 4 );
				Add( typeof( Lantern ), 1 );
				Add( typeof( Lockpick ), 6 );
				Add( typeof( FloppyHat ), 3 );
				Add( typeof( WideBrimHat ), 4 );
				Add( typeof( Cap ), 5 );
				Add( typeof( TallStrawHat ), 4 );
				Add( typeof( StrawHat ), 3 );
				Add( typeof( WizardsHat ), 5 );
				Add( typeof( LeatherCap ), 5 );
				Add( typeof( FeatheredHat ), 5 );
				Add( typeof( TricorneHat ), 4 );
				Add( typeof( Bandana ), 3 );
				Add( typeof( SkullCap ), 3 );
				Add( typeof( Bottle ), 3 );
				Add( typeof( RedBook ), 7 );
				Add( typeof( BlueBook ), 7 );
				Add( typeof( TanBook ), 7 );
				Add( typeof( WoodenBox ), 7 );
				Add( typeof( Kindling ), 1 );
				Add( typeof( HairDye ), 30 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );

				Add( typeof( Beeswax ), 1 );

				Add( typeof( Amber ), 25 );
				Add( typeof( Amethyst ), 50 );
				Add( typeof( Citrine ), 25 );
				Add( typeof( Diamond ), 100 );
				Add( typeof( Emerald ), 50 );
				Add( typeof( Ruby ), 37 );
				Add( typeof( Sapphire ), 50 );
				Add( typeof( StarSapphire ), 62 );
				Add( typeof( Tourmaline ), 47 );
				Add( typeof( GoldRing ), 13 );
				Add( typeof( SilverRing ), 10 );
				Add( typeof( Necklace ), 13 );
				Add( typeof( GoldNecklace ), 13 );
				Add( typeof( GoldBeadNecklace ), 13 );
				Add( typeof( SilverNecklace ), 10 );
				Add( typeof( SilverBeadNecklace ), 10 );
				Add( typeof( Beads ), 13 );
				Add( typeof( GoldBracelet ), 13 );
				Add( typeof( SilverBracelet ), 10 );
				Add( typeof( GoldEarrings ), 13 );
				Add( typeof( SilverEarrings ), 10 );
				
				//if( !Guild.NewGuildSystem )
				//	Add( typeof( GuildDeed ), 6225 );
//MINER
				Add( typeof( Pickaxe ), 12 );
				Add( typeof( Shovel ), 6 );
				Add( typeof( Lantern ), 1 );
				//Add( typeof( OilFlask ), 4 );
				Add( typeof( Torch ), 3 );
				Add( typeof( Bag ), 3 );
				Add( typeof( Candle ), 3 );
//MILLER
				Add( typeof( SackFlour ), 1 );
				Add( typeof( SheafOfHay ), 1 );
//MAPMAKER
				Add( typeof( BlankScroll ), 6 );
				Add( typeof( MapmakersPen ), 4 );
				Add( typeof( BlankMap ), 2 );
				Add( typeof( CityMap ), 3 );
				Add( typeof( LocalMap ), 3 );
				Add( typeof( WorldMap ), 3 );
				Add( typeof( PresetMapEntry ), 3 );
//MAGE
				Add( typeof( WizardsHat ), 15 );
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ),4 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 

				if ( Core.AOS )
				{
					Add( typeof( BatWing ), 1 );
					Add( typeof( DaemonBlood ), 3 );
					Add( typeof( PigIron ), 2 );
					Add( typeof( NoxCrystal ), 3 );
					Add( typeof( GraveDust ), 1 );
				}

				Add( typeof( RecallRune ), 13 );
				Add( typeof( Spellbook ), 25 );

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add(types[i], i + 3 + (i / 4));
					// This is NOT 100% OSI accurate. Two spells per circle will be off by 1gp, as OSI's math is slightly different.

				if ( Core.SE )
				{				
					Add( typeof( ExorcismScroll ), 1 );
					Add( typeof( AnimateDeadScroll ), 26 );
					Add( typeof( BloodOathScroll ), 26 );
					Add( typeof( CorpseSkinScroll ), 26 );
					Add( typeof( CurseWeaponScroll ), 26 );
					Add( typeof( EvilOmenScroll ), 26 );
					Add( typeof( PainSpikeScroll ), 26 );
					Add( typeof( SummonFamiliarScroll ), 26 );
					Add( typeof( HorrificBeastScroll ), 27 );
					Add( typeof( MindRotScroll ), 39 );
					Add( typeof( PoisonStrikeScroll ), 39 );
					Add( typeof( WraithFormScroll ), 51 );
					Add( typeof( LichFormScroll ), 64 );
					Add( typeof( StrangleScroll ), 64 );
					Add( typeof( WitherScroll ), 64 );
					Add( typeof( VampiricEmbraceScroll ), 101 );
					Add( typeof( VengefulSpiritScroll ), 114 );
//LEATHER WORKER
					Add( typeof( Hides ), 2 ); 
				    Add( typeof( ThighBoots ), 28 ); 
//JEWWEL
				Add( typeof( Amber ), 25 );
				Add( typeof( Amethyst ), 50 );
				Add( typeof( Citrine ), 25 );
				Add( typeof( Diamond ), 100 );
				Add( typeof( Emerald ), 50 );
				Add( typeof( Ruby ), 37 );
				Add( typeof( Sapphire ), 50 );
				Add( typeof( StarSapphire ), 62 );
				Add( typeof( Tourmaline ), 47 );
				Add( typeof( GoldRing ), 13 );
				Add( typeof( SilverRing ), 10 );
				Add( typeof( Necklace ), 13 );
				Add( typeof( GoldNecklace ), 13 );
				Add( typeof( GoldBeadNecklace ), 13 );
				Add( typeof( SilverNecklace ), 10 );
				Add( typeof( SilverBeadNecklace ), 10 );
				Add( typeof( Beads ), 13 );
				Add( typeof( GoldBracelet ), 13 );
				Add( typeof( SilverBracelet ), 10 );
				Add( typeof( GoldEarrings ), 13 );
				Add( typeof( SilverEarrings ), 10 );
				//Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ),  68, 20, 0x1ED0, 0, new object[] {  500 } ) ); // 500 charges
				//Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 131, 20, 0x1ED0, 0, new object[] { 1000 } ) ); // 1000 charges
				//Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 256, 20, 0x1ED0, 0, new object[] { 2000 } ) ); // 2000 charges

				//Add( new GenericBuyInfo( "1060740", typeof( ReceiverCrystal ), 6, 20, 0x1ED0, 0 ) );
//INNKEEPER
				Add( typeof( BeverageBottle ), 3 );
				Add( typeof( Jug ), 6 );
				Add( typeof( Pitcher ), 5 );
				Add( typeof( GlassMug ), 1 );
				Add( typeof( BreadLoaf ), 3 );
				Add( typeof( CheeseWheel ), 12 );
				Add( typeof( Ribs ), 6 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Banana ), 1 );
				Add( typeof( Torch ), 3 );
				Add( typeof( Candle ), 3 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );
				Add( typeof( ContractOfEmployment ), 626 );
				Add( typeof( Beeswax ), 1 );
				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );
				//Add( new GenericBuyInfo( typeof( CookedBird ), 17, 20, 0x9B7, 0 ) );
				//Add( new GenericBuyInfo( typeof( LambLeg ), 8, 20, 0x160A, 0 ) );
				//Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, 20, 0x1608, 0 ) );
//HOUSEDEED
				/*Add( typeof( StonePlasterHouseDeed ), 43800 );
				Add( typeof( FieldStoneHouseDeed ), 43800 );
				Add( typeof( SmallBrickHouseDeed ), 43800 );
				Add( typeof( WoodHouseDeed ), 43800 );
				Add( typeof( WoodPlasterHouseDeed ), 43800 );
				Add( typeof( ThatchedRoofCottageDeed ), 43800 );
				Add( typeof( BrickHouseDeed ), 144500 );
				Add( typeof( TwoStoryWoodPlasterHouseDeed ), 192400 );
				Add( typeof( TowerDeed ), 433200 );
				Add( typeof( KeepDeed ), 665200 );
				Add( typeof( CastleDeed ), 1022800 );
				Add( typeof( LargePatioDeed ), 152800 );
				Add( typeof( LargeMarbleDeed ), 192800 );
				Add( typeof( SmallTowerDeed ), 88500 );
				Add( typeof( LogCabinDeed ), 97800 );
				Add( typeof( SandstonePatioDeed ), 90900 );
				Add( typeof( VillaDeed ), 136500 );
				Add( typeof( StoneWorkshopDeed ), 60600 );
				Add( typeof( MarbleWorkshopDeed ), 60300 );
				Add( typeof( SmallBrickHouseDeed ), 43800 );*/
//HOLYMAGE
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ), 3 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 
				Add( typeof( RecallRune ), 8 );
				Add( typeof( Spellbook ), 9 );
				Add( typeof( BlankScroll ), 3 );

				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
//Loot.RegularScrollTypes is already used above 
/*
				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add( types[i], ((i / 8) + 2) * 5 );
*/					
//HERBALIST
				Add( typeof( Bloodmoss ), 3 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( Bottle ), 3 ); 
				Add( typeof( MortarPestle ), 4 ); 
//HEALER
				Add( typeof( Bandage ), 1 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
//HAIRSTYLIST
				Add( typeof( HairDye ), 30 ); 
				Add( typeof( SpecialBeardDye ), 250000 ); 
				Add( typeof( SpecialHairDye ), 250000 ); 
//GLASSBLOWER
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ), 3 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 
				Add( typeof( Bottle ), 3 );
				Add( typeof( MortarPestle ), 4 );

				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 10 );

				Add( typeof( GlassblowingBook ), 5000 );
				Add( typeof( SandMiningBook ), 5000 );
				Add( typeof( Blowpipe ), 10 );
//FURTRADER
				Add( typeof( Hides ), 2 );
//FORTUNE TELLER
				Add( typeof( Bandage ), 1 );
				
//FISHERMAN
				Add( typeof( RawFishSteak ), 1 );
				Add( typeof( Fish ), 1 );
				//TODO: Add( typeof( SmallFish ), 1 );
				Add( typeof( FishingPole ), 7 );
//FARMER
				Add( typeof( Pitcher ), 5 );
				Add( typeof( Eggs ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Watermelon ), 3 );
				Add( typeof( YellowGourd ), 1 );
				Add( typeof( GreenGourd ), 1 );
				Add( typeof( Pumpkin ), 5 );
				Add( typeof( Onion ), 1 );
				Add( typeof( Lettuce ), 2 );
				Add( typeof( Squash ), 1 );
				Add( typeof( Carrot ), 1 );
				Add( typeof( HoneydewMelon ), 3 );
				Add( typeof( Cantaloupe ), 3 );
				Add( typeof( Cabbage ), 2 );
				Add( typeof( Lemon ), 1 );
				Add( typeof( Lime ), 1 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( SheafOfHay ), 1 );
//COOK 
				Add( typeof( CheeseWheel ), 12 );
				Add( typeof( CookedBird ), 8 );
				Add( typeof( RoastPig ), 53 );
				Add( typeof( Cake ), 5 );
				Add( typeof( JarHoney ), 1 );
				Add( typeof( SackFlour ), 1 );
				Add( typeof( BreadLoaf ), 2 );
				Add( typeof( ChickenLeg ), 3 );
				Add( typeof( LambLeg ), 4 );
				Add( typeof( Skillet ), 1 );
				Add( typeof( FlourSifter ), 1 );
				Add( typeof( RollingPin ), 1 );
				Add( typeof( Muffins ), 1 );
				Add( typeof( ApplePie ), 3 );

				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );
//COBBLER
				Add( typeof( Shoes ), 4 ); 
				Add( typeof( Boots ), 5 ); 
				Add( typeof( ThighBoots ), 7 ); 
				Add( typeof( Sandals ), 2 ); 
//CARPENTER
				Add( typeof( WoodenBox ), 7 );
				Add( typeof( SmallCrate ), 5 );
				Add( typeof( MediumCrate ), 6 );
				Add( typeof( LargeCrate ), 7 );
				Add( typeof( WoodenChest ), 15 );
              
				Add( typeof( LargeTable ), 10 );
				Add( typeof( Nightstand ), 7 );
				Add( typeof( YewWoodTable ), 10 );

				Add( typeof( Throne ), 24 );
				Add( typeof( WoodenThrone ), 6 );
				Add( typeof( Stool ), 6 );
				Add( typeof( FootStool ), 6 );

				Add( typeof( FancyWoodenChairCushion ), 12 );
				Add( typeof( WoodenChairCushion ), 10 );
				Add( typeof( WoodenChair ), 8 );
				Add( typeof( BambooChair ), 6 );
				Add( typeof( WoodenBench ), 6 );

				Add( typeof( Saw ), 9 );
				Add( typeof( Scorp ), 6 );
				Add( typeof( SmoothingPlane ), 6 );
				Add( typeof( DrawKnife ), 6 );
				Add( typeof( Froe ), 6 );
				Add( typeof( Hammer ), 14 );
				Add( typeof( Inshave ), 6 );
				Add( typeof( JointingPlane ), 6 );
				Add( typeof( MouldingPlane ), 6 );
				Add( typeof( DovetailSaw ), 7 );
				Add( typeof( Board ), 2 );
				Add( typeof( Axle ), 1 );

				Add( typeof( Club ), 13 );

				Add( typeof( Lute ), 10 );
				Add( typeof( LapHarp ), 10 );
				Add( typeof( Tambourine ), 10 );
				Add( typeof( Drums ), 10 );

				Add( typeof( Log ), 1 );
//BUTCHER
				Add( typeof( RawRibs ), 8 ); 
				Add( typeof( RawLambLeg ), 4 ); 
				Add( typeof( RawChickenLeg ), 3 ); 
				Add( typeof( RawBird ), 4 ); 
				Add( typeof( Bacon ), 3 ); 
				Add( typeof( Sausage ), 9 ); 
				Add( typeof( Ham ), 13 ); 
				Add( typeof( ButcherKnife ), 7 ); 
				Add( typeof( Cleaver ), 7 ); 
				Add( typeof( SkinningKnife ), 7 ); 
//BOWYER
				Add( typeof( FletcherTools ), 1 );
//BLACKSMITH
				Add( typeof( Tongs ), 7 ); 
				Add( typeof( IronIngot ), 4 ); 

				Add( typeof( Buckler ), 25 );
				Add( typeof( BronzeShield ), 33 );
				Add( typeof( MetalShield ), 60 );
				Add( typeof( MetalKiteShield ), 62 );
				Add( typeof( HeaterShield ), 115 );
				Add( typeof( WoodenKiteShield ), 35 );

				Add( typeof( WoodenShield ), 15 );

				Add( typeof( PlateArms ), 94 );
				Add( typeof( PlateChest ), 121 );
				Add( typeof( PlateGloves ), 72 );
				Add( typeof( PlateGorget ), 52 );
				Add( typeof( PlateLegs ), 109 );

				Add( typeof( FemalePlateChest ), 113 );
				Add( typeof( FemaleLeatherChest ), 18 );
				Add( typeof( FemaleStuddedChest ), 25 );
				Add( typeof( LeatherShorts ), 14 );
				Add( typeof( LeatherSkirt ), 11 );
				Add( typeof( LeatherBustierArms ), 11 );
				Add( typeof( StuddedBustierArms ), 27 );

				Add( typeof( Bascinet ), 9 );
				Add( typeof( CloseHelm ), 9 );
				Add( typeof( Helmet ), 9 );
				Add( typeof( NorseHelm ), 9 );
				Add( typeof( PlateHelm ), 10 );

				Add( typeof( ChainCoif ), 6 );
				Add( typeof( ChainChest ), 71 );
				Add( typeof( ChainLegs ), 74 );

				Add( typeof( RingmailArms ), 42 );
				Add( typeof( RingmailChest ), 60 );
				Add( typeof( RingmailGloves ), 26 );
				Add( typeof( RingmailLegs ), 45 );

				Add( typeof( BattleAxe ), 13 );
				Add( typeof( DoubleAxe ), 26 );
				Add( typeof( ExecutionersAxe ), 15 );
				Add( typeof( LargeBattleAxe ),16 );
				Add( typeof( Pickaxe ), 11 );
				Add( typeof( TwoHandedAxe ), 16 );
				Add( typeof( WarAxe ), 14 );
				Add( typeof( Axe ), 20 );

				Add( typeof( Bardiche ), 30 );
				Add( typeof( Halberd ), 21 );

				Add( typeof( ButcherKnife ), 7 );
				Add( typeof( Cleaver ), 7 );
				Add( typeof( Dagger ), 10 );
				Add( typeof( SkinningKnife ), 7 );

				Add( typeof( Club ), 8 );
				Add( typeof( HammerPick ), 13 );
				Add( typeof( Mace ), 14 );
				Add( typeof( Maul ), 10 );
				Add( typeof( WarHammer ), 12 );
				Add( typeof( WarMace ), 15 );

				Add( typeof( HeavyCrossbow ), 27 );
				Add( typeof( Bow ), 17 );
				Add( typeof( Crossbow ), 23 ); 

				if( Core.AOS )
				{
					Add( typeof( CompositeBow ), 25 );
					Add( typeof( RepeatingCrossbow ), 28 );
					Add( typeof( Scepter ), 20 );
					Add( typeof( BladedStaff ), 20 );
					Add( typeof( Scythe ), 19 );
					Add( typeof( BoneHarvester ), 17 );
					Add( typeof( Scepter ), 18 );
					Add( typeof( BladedStaff ), 16 );
					Add( typeof( Pike ), 19 );
					Add( typeof( DoubleBladedStaff ), 17 );
					Add( typeof( Lance ), 17 );
					Add( typeof( CrescentBlade ), 18 );
				}

				Add( typeof( Spear ), 15 );
				Add( typeof( Pitchfork ), 9 );
				Add( typeof( ShortSpear ), 11 );

				Add( typeof( BlackStaff ), 11 );
				Add( typeof( GnarledStaff ), 8 );
				Add( typeof( QuarterStaff ), 9 );
				Add( typeof( ShepherdsCrook ), 10 );

				Add( typeof( SmithHammer ), 10 );

				Add( typeof( Broadsword ), 17 );
				Add( typeof( Cutlass ), 12 );
				Add( typeof( Katana ), 16 );
				Add( typeof( Kryss ), 16 );
				Add( typeof( Longsword ), 27 );
				Add( typeof( Scimitar ), 18 );
				Add( typeof( ThinLongsword ), 13 );
				Add( typeof( VikingSword ), 27 );
//BEEKEEPER
				Add( typeof( JarHoney ), 1 );
				Add( typeof( Beeswax ), 1 );
//BARKEEPER
				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );
				Add( typeof( BeverageBottle ), 3 );
				Add( typeof( Jug ), 6 );
				Add( typeof( Pitcher ), 5 );
				Add( typeof( GlassMug ), 1 );
				Add( typeof( BreadLoaf ), 3 );
				Add( typeof( CheeseWheel ), 12 );
				Add( typeof( Ribs ), 6 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Banana ), 1 );
				Add( typeof( Candle ), 3 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );
				Add( typeof( ContractOfEmployment ), 626 );
//BARD
				Add( typeof( LapHarp ), 10 ); 
				Add( typeof( Lute ), 10 ); 
				Add( typeof( Drums ), 10 ); 
				Add( typeof( Harp ), 10 ); 
				Add( typeof( Tambourine ), 10 ); 
//BAKER
				Add( typeof( BreadLoaf ), 3 ); 
				Add( typeof( FrenchBread ), 1 ); 
				Add( typeof( Cake ), 5 ); 
				Add( typeof( Cookies ), 3 ); 
				Add( typeof( Muffins ), 2 ); 
				Add( typeof( CheesePizza ), 4 ); 
				Add( typeof( ApplePie ), 5 ); 
				Add( typeof( PeachCobbler ), 5 ); 
				Add( typeof( Quiche ), 6 ); 
				Add( typeof( Dough ), 4 ); 
				Add( typeof( JarHoney ), 1 ); 
				Add( typeof( Pitcher ), 5 );
				Add( typeof( SackFlour ), 1 ); 
				Add( typeof( Eggs ), 1 ); 
//ARCHITECT
				Add( typeof( InteriorDecorator ), 5000 );

				if ( Core.AOS )
					Add( typeof( HousePlacementTool ), 301 );
//ANIMAL TRAINER
				/*Add( new AnimalBuyInfo( 1, typeof( Cat ), 132, 10, 201, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Dog ), 170, 10, 217, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Horse ), 550, 10, 204, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 631, 10, 291, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 565, 10, 292, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Rabbit ), 106, 10, 205, 0 ) );

				if( !Core.AOS )
				{
					Add( new AnimalBuyInfo( 1, typeof( Eagle ), 402, 10, 5, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( BrownBear ), 855, 10, 167, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( GrizzlyBear ), 1767, 10, 212, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( Panther ), 1271, 10, 214, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( TimberWolf ), 768, 10, 225, 0 ) );
					Add( new AnimalBuyInfo( 1, typeof( Rat ), 107, 10, 238, 0 ) );*/
//WEAVER
				Add( typeof( Scissors ), 6 ); 
				Add( typeof( Dyes ), 4 ); 
				Add( typeof( DyeTub ), 4 ); 
				Add( typeof( UncutCloth ), 1 );
				Add( typeof( BoltOfCloth ), 50 ); 
				Add( typeof( LightYarnUnraveled ), 9 );
				Add( typeof( LightYarn ), 9 );
				Add( typeof( DarkYarn ), 9 );
//WEAPON SMITH
				Add( typeof( BattleAxe ), 13 );
				Add( typeof( DoubleAxe ), 26 );
				Add( typeof( ExecutionersAxe ), 15 );
				Add( typeof( LargeBattleAxe ),16 );
				Add( typeof( Pickaxe ), 11 );
				Add( typeof( TwoHandedAxe ), 16 );
				Add( typeof( WarAxe ), 14 );
				Add( typeof( Axe ), 20 );

				Add( typeof( Bardiche ), 30 );
				Add( typeof( Halberd ), 21 );

				Add( typeof( ButcherKnife ), 7 );
				Add( typeof( Cleaver ), 7 );
				Add( typeof( Dagger ), 10 );
				Add( typeof( SkinningKnife ), 7 );

				Add( typeof( Club ), 8 );
				Add( typeof( HammerPick ), 13 );
				Add( typeof( Mace ), 14 );
				Add( typeof( Maul ), 10 );
				Add( typeof( WarHammer ), 12 );
				Add( typeof( WarMace ), 15 );

				Add( typeof( HeavyCrossbow ), 27 );
				Add( typeof( Bow ), 17 );
				Add( typeof( Crossbow ), 23 ); 

				if( Core.AOS )
				{
					Add( typeof( CompositeBow ), 25 );
					Add( typeof( RepeatingCrossbow ), 28 );
					Add( typeof( Scepter ), 20 );
					Add( typeof( BladedStaff ), 20 );
					Add( typeof( Scythe ), 19 );
					Add( typeof( BoneHarvester ), 17 );
					Add( typeof( Scepter ), 18 );
					Add( typeof( BladedStaff ), 16 );
					Add( typeof( Pike ), 19 );
					Add( typeof( DoubleBladedStaff ), 17 );
					Add( typeof( Lance ), 17 );
					Add( typeof( CrescentBlade ), 18 );
				}

				Add( typeof( Spear ), 15 );
				Add( typeof( Pitchfork ), 9 );
				Add( typeof( ShortSpear ), 11 );

				Add( typeof( BlackStaff ), 11 );
				Add( typeof( GnarledStaff ), 8 );
				Add( typeof( QuarterStaff ), 9 );
				Add( typeof( ShepherdsCrook ), 10 );

				Add( typeof( SmithHammer ), 10 );

				Add( typeof( Broadsword ), 17 );
				Add( typeof( Cutlass ), 12 );
				Add( typeof( Katana ), 16 );
				Add( typeof( Kryss ), 16 );
				Add( typeof( Longsword ), 27 );
				Add( typeof( Scimitar ), 18 );
				Add( typeof( ThinLongsword ), 13 );
				Add( typeof( VikingSword ), 27 );

				Add( typeof( Hatchet ), 13 );
				Add( typeof( WarFork ), 16 );
//VARIETY DEALER
				Add( typeof( Bandage ), 1 );

				Add( typeof( BlankScroll ), 3 );

				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 10 );

				Add( typeof( Bolt ), 3 );
				Add( typeof( Arrow ), 2 );

				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 2 );

				Add( typeof( BreadLoaf ), 3 );
				Add( typeof( Backpack ), 7 );
				Add( typeof( RecallRune ), 8 );
				Add( typeof( Spellbook ), 9 );
				Add( typeof( BlankScroll ), 3 );

				if ( Core.AOS )
				{
					Add( typeof( BatWing ), 2 );
					Add( typeof( GraveDust ), 2 );
					Add( typeof( DaemonBlood ), 3 );
					Add( typeof( NoxCrystal ), 3 );
					Add( typeof( PigIron ), 3 );
				}

//VAGABOND
				Add( typeof( Board ), 1 );
				Add( typeof( IronIngot ), 3 );

				Add( typeof( Amber ), 25 );
				Add( typeof( Amethyst ), 50 );
				Add( typeof( Citrine ), 25 );
				Add( typeof( Diamond ), 100 );
				Add( typeof( Emerald ), 50 );
				Add( typeof( Ruby ), 37 );
				Add( typeof( Sapphire ), 50 );
				Add( typeof( StarSapphire ), 62 );
				Add( typeof( Tourmaline ), 47 );
				Add( typeof( GoldRing ), 13 );
				Add( typeof( SilverRing ), 10 );
				Add( typeof( Necklace ), 13 );
				Add( typeof( GoldNecklace ), 13 );
				Add( typeof( GoldBeadNecklace ), 13 );
				Add( typeof( SilverNecklace ), 10 );
				Add( typeof( SilverBeadNecklace ), 10 );
				Add( typeof( Beads ), 13 );
				Add( typeof( GoldBracelet ), 13 );
				Add( typeof( SilverBracelet ), 10 );
				Add( typeof( GoldEarrings ), 13 );
				Add( typeof( SilverEarrings ), 10 );
//TINKER
				Add( typeof( Drums ), 10 );
				Add( typeof( Tambourine ), 10 );
				Add( typeof( LapHarp ), 10 );
				Add( typeof( Lute ), 10 );

				Add( typeof( Shovel ), 6 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Scissors ), 6 );
				Add( typeof( Tongs ), 7 );
				Add( typeof( Key ), 1 );

				Add( typeof( DovetailSaw ), 6 );
				Add( typeof( MouldingPlane ), 6 );
				Add( typeof( Nails ), 1 );
				Add( typeof( JointingPlane ), 6 );
				Add( typeof( SmoothingPlane ), 6 );
				Add( typeof( Saw ), 7 );

				Add( typeof( Clock ), 11 );
				Add( typeof( ClockParts ), 1 );
				Add( typeof( AxleGears ), 1 );
				Add( typeof( Gears ), 1 );
				Add( typeof( Hinge ), 1 );
				Add( typeof( Sextant ), 6 );
				Add( typeof( SextantParts ), 2 );
				Add( typeof( Axle ), 1 );
				Add( typeof( Springs ), 1 );

				Add( typeof( DrawKnife ), 5 );
				Add( typeof( Froe ), 5 );
				Add( typeof( Inshave ), 5 );
				Add( typeof( Scorp ), 5 );

				Add( typeof( Lockpick ), 6 );
				Add( typeof( TinkerTools ), 3 );

				Add( typeof( Board ), 1 );
				Add( typeof( Log ), 1 );

				Add( typeof( Pickaxe ), 16 );
				Add( typeof( Hammer ), 3 );
				Add( typeof( SmithHammer ), 11 );
				Add( typeof( ButcherKnife ), 6 );
			} 
		}
	}
}}