using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetMQ.zmq;

namespace NetMQ
{
	public class NetMQSocketEventArgs : EventArgs
	{
		public NetMQSocketEventArgs(NetMQSocket socket)
		{
			Socket = socket;
		}

		internal void Init(PollEvents events)
		{
			this.ReceiveReady = EnumFlagsHelper.HasFlag(events, PollEvents.PollIn);
			this.SendReady = EnumFlagsHelper.HasFlag(events, PollEvents.PollOut);
		}

		public NetMQSocket Socket { get; private set; }

		/// <summary>
		/// Gets a value indicating whether at least one message may be received by the socket without blocking.
		/// </summary>
		public bool ReceiveReady { get; private set; }

		/// <summary>
		/// Gets a value indicating whether at least one message may be sent by the socket without blocking.
		/// </summary>
		public bool SendReady { get; private set; }
	}
}
