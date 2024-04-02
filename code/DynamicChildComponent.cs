
namespace Sandbox
{
	public class DynamicChildComponent : DynamicBaseComponent
	{
		protected override void OnStart()
		{
			base.OnStart();
			Log.Info( "DynamicChildComponent OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );
		}

		public override void CallMe()
		{
			base.CallMe();

			Log.Info( "CallMe Child - Networking.IsHost " + Networking.IsHost );
		}
	}
}
