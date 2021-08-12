using System.Runtime.InteropServices;

internal static class GrpcWebApi
{
    /// <summary>
    /// Registers this unity instance to allow the code to connect
    /// This will async return in OnInstanceRegistered
    /// </summary>
    /// <returns>the gameobject name that JS is expecting to use to communicate with this script</returns>
    [DllImport("__Internal")]
    internal static extern string RegisterInstance();

    /// <summary>
    /// Registers a channel to allow repeated calls to the same target
    /// </summary>
    /// <returns>A channel key. This channel key need to be passed for calls </returns>
    internal static int RegisterChannel(int instanceKey, string target) => 0;
    
    /// <summary>
    /// Starts a unary request on the channel.
    /// </summary>
    /// <returns>A call key. This key be used to map responses and allow cancellations.</returns>
    internal static int UnaryRequest( int instanceKey, int channelKey,
        string serviceName, string methodName, string headers, string base64Message, long deadlineTimestampSecs) => 0;


    /// <summary>
    /// Starts a server streaming request on the channel.
    /// </summary>
    /// <returns>A call key. This key be used to map responses and allow cancellations.</returns>
    internal static  int ServerStreamingRequest(int instanceKey, int channelKey,
        string serviceName, string methodName, string headers, string base64Message, long deadlineTimestampSecs) => 0;


    /// <summary>
    /// Starts a server streaming request on the channel.
    /// </summary>
    /// <returns>A call key. This key be used to map responses and allow cancellations.</returns>
    internal static void CancelCall(int instanceKey, int channelKey, int callKey) {}


}
