
using TimeUntilBug.BaseComponent;

namespace TimeUntilBug.One.ChildComponent
{
	public class DynamicChildComponent : DynamicBaseComponent
	{
		protected override void OnStart()
		{
			base.OnStart();
			Log.Info( "One.DynamicChildComponent OnStart IsHost " + Networking.IsHost );
		}

	}
}
