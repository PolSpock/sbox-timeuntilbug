
namespace TimeUntilBug.BaseComponent
{
	public enum RoundState
	{
		Started,
		InProgress,
		Paused,
		Ended
	}

	public abstract class DynamicBaseComponent : Component, Component.INetworkListener
	{
		protected override void OnStart()
		{
			Log.Info( "DynamicBaseComponent OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );
			if ( !Networking.IsHost ) { return; }

			Transform.Position = Vector3.Random * 100f;

			Network.Refresh();
		}

		public virtual void OnBecameHost( Connection client )
		{
			Log.Info( "DynamicBaseComponent OnBecameHost " + client + " " + this + " Networking.IsHost " + Networking.IsHost );
			Log.Info( "GetType()" + GetType() );
			Log.Info( "GetType().Name " + GetType().Name );
			Log.Info( this );
			Log.Info( "-----" );
			Log.Info( "GameObject.Id " + GameObject.Id );
			Log.Info( "GameObject.Network.OwnerId " + GameObject.Network.OwnerId );
			Log.Info( "-----" );
			Log.Info( "Is DynamicBaseComponent " + (this is DynamicBaseComponent) );
			Log.Info( "Is One.DynamicChildComponent " + (this is TimeUntilBug.One.ChildComponent.DynamicChildComponent) );
			Log.Info( "Is Two.DynamicChildComponent " + (this is TimeUntilBug.Two.ChildComponent.DynamicChildComponent) );
		}

	}
}
