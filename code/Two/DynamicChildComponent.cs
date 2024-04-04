
using TimeUntilBug.BaseComponent;

namespace TimeUntilBug.Two.OneChildComponent
{
	public class DynamicChildComponent : DynamicBaseComponent
	{
		protected override void OnStart()
		{
			base.OnStart();
			Log.Info( "Two.DynamicChildComponent OnStart IsHost " + Networking.IsHost );
		}
	}
}
