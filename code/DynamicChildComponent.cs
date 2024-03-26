namespace Sandbox
{
	public class DynamicChildComponent : Component
	{

		[Sync] public TimeUntil MyDynamicTimeUntil { get; set; }
		public TimeSince SimeSinceTick { get; set; }

		protected override void OnStart()
		{
			Log.Info( "DynamicChildComponent OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );
			if ( !Networking.IsHost ) { return; }
			if ( IsProxy ) { return; }

			MyDynamicTimeUntil = 120f;

		}

		protected override void OnFixedUpdate()
		{
			base.OnFixedUpdate();

			if ( SimeSinceTick < 1f ) { return; }
			SimeSinceTick = 0f;

			Log.Info( "--------" );
			Log.Info( "MyDynamicTimeUntil " + MyDynamicTimeUntil );
		}


	}
}
