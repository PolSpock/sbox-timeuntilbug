namespace Sandbox
{
	public class DynamicBaseComponent : Component, Component.INetworkListener
	{
		public TimeSince SimeSinceTick { get; set; }

		protected override void OnStart()
		{
			Log.Info( "DynamicBaseComponent OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );
			if ( !Networking.IsHost ) { return; }

			Transform.Position = Vector3.Random * 100f;

			Network.Refresh();
		}

		protected override void OnFixedUpdate()
		{
			base.OnFixedUpdate();

			if ( SimeSinceTick < 1f ) { return; }
			SimeSinceTick = 0f;
		}

		public virtual void OnBecameHost( Connection client )
		{
			Log.Info( "DynamicBaseComponent OnBecameHost " + client + " " + this + " Networking.IsHost " + Networking.IsHost );
			Log.Info( "GetType().Name " + GetType().Name );
			Log.Info( this );
			Log.Info( "-----" );
			Log.Info( "GameObject.Id " + GameObject.Id );
			Log.Info( "GameObject.Network.OwnerId " + GameObject.Network.OwnerId );
			Log.Info( "-----" );
			Log.Info( "Is DynamicBaseComponent " + (this is DynamicBaseComponent) );
			Log.Info( "Is DynamicChildComponent " + (this is DynamicChildComponent) );

			CallMe();

		}

		public virtual void CallMe()
		{
			Log.Info( "CallMe Mother - Networking.IsHost " + Networking.IsHost );
		}
	}
}
