#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace Tao.Sdl
{
	#region Class Documentation
	/// <summary>
	/// SDL_net is a portable network library for use with SDL.
	/// </summary>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public static class SdlNet
	{
		#region Private Constants
		#region string SDL_NET_NATIVE_LIBRARY
		/// <summary>
		///     Specifies SdlNet's native library archive.
		/// </summary>
		/// <remarks>
		///     Specifies SDL_net.dll everywhere; will be mapped via 
		///     .config for mono.
		/// </remarks>
		private const string SDL_NET_NATIVE_LIBRARY = "SDL_net.dll";
		#endregion string SDL_NET_NATIVE_LIBRARY

		#region CallingConvention CALLING_CONVENTION
		/// <summary>
		///     Specifies the calling convention.
		/// </summary>
		/// <remarks>
		///     Specifies <see cref="CallingConvention.Cdecl" /> 
		///     for Windows and Linux.
		/// </remarks>
		private const CallingConvention CALLING_CONVENTION = 
			CallingConvention.Cdecl;
		#endregion CallingConvention CALLING_CONVENTION
		#endregion Private Constants
		
		#region Public Constants
		/// <summary>
		/// Major Version
		/// </summary>
		public const int SDL_NET_MAJOR_VERSION = 1;
		/// <summary>
		/// Minor Version
		/// </summary>
		public const int SDL_NET_MINOR_VERSION = 2;
		/// <summary>
		/// Patch Version
		/// </summary>
		public const int SDL_NET_PATCHLEVEL = 6;
		/// <summary>
		/// Used for listening on all network interfaces.
		/// </summary>
		public const byte INADDR_ANY = unchecked((byte)0x00000000);
		/// <summary>
		/// Which has limited applications.
		/// </summary>
		public const byte INADDR_NONE = unchecked((byte)0xFFFFFFFF);
		/// <summary>
		/// Used as destination when sending a message to all clients on 
		/// a subnet that allows broadcasts.
		/// </summary>
		public const byte INADDR_BROADCAST = unchecked((byte)0xFFFFFFFF);
		/// <summary>
		/// The maximum number of channels on a UDP socket.
		/// </summary>
		public const byte SDLNET_MAX_UDPCHANNELS = 32;
		/// <summary>
		/// The maximum number of addresses bound to a single UDP socket
		///  channel.
		/// </summary>
		public const byte SDLNET_MAX_UDPADDRESSES = 4;
		#endregion Public Constants
		
		#region Public Structs
		#region IPAddress
		/// <summary>
		/// IP Address and Port number
		/// </summary>
		/// <remarks>
		/// This type contains the information used to 
		/// form network connections and sockets.
		/// <p>Binds to C-function call in SDL_net.h:
		/// <code>
		/// typedef struct {
		///		Uint32 host;
		///		Uint16 port;
		/// } IPaddress;
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="SDLNet_TCP_Open"/>
		/// <seealso cref="SDLNet_ResolveHost"/>
		/// <seealso cref="SDLNet_ResolveIP"/>
		public struct IPaddress  
		{
			/// <summary>
			/// The 32-bit IPv4 address of a host, encoded in Network Byte
			///  Order.
			/// </summary>
			public int host;
			/// <summary>
			/// The 16-bit IPv4 port number of a socket, 
			/// encoded in Network Byte Order.
			/// </summary>
			public	short port;
		}
		#endregion IPAddress
		
		#region UDPpacket
		/// <summary>
		/// UDP packet data encapsulation
		/// </summary>
		/// <remarks>
		/// This struct is used with UDPsockets to send and receive data. 
		/// It also helps keep track of a packets sending/receiving 
		/// settings and status. The channels concept helps prioritize,
		///  or segregate differring types of data packets.
		/// <p>Binds to C-function call in SDL_net.h:
		/// <code>
		/// typedef struct {
		/// 	int channel;
		/// 	Uint8 *data;
		/// 	int len;
		/// 	int maxlen;
		/// 	int status;
		/// 	IPaddress address;
		/// } UDPpacket;
		/// </code>
		/// </p>
		/// </remarks>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="IPaddress"/>
		/// <seealso cref="SDLNet_AllocPacket"/>
		/// <seealso cref="SDLNet_ResizePacket"/>
		/// <seealso cref="SDLNet_FreePacket"/>
		/// <seealso cref="SDLNet_AllocPacketV"/>
		/// <seealso cref="SDLNet_FreePacketV"/>
		public struct UDPpacket
		{
			/// <summary>
			/// The (software) channel number for this packet. 
			/// This can also be used as a priority value for the packet.
			///  If no channel is assigned, the value is -1.
			/// </summary>
			public int channel;
			/// <summary>
			/// The data contained in this packet, this is the meat.
			/// </summary>
			public IntPtr data;
			/// <summary>
			/// This is the meaningful length of the data in bytes.
			/// </summary>
			public int len;
			/// <summary>
			/// This is size of the data buffer, which may be larger 
			/// than the meaningful length. This is only used for 
			/// packet creation on the senders side.
			/// </summary>
			public int maxlen;
			/// <summary>
			/// This contains the number of bytes sent, or a -1 on errors,
			///  after sending. This is useless for a received packet.
			/// </summary>
			public int status;
			/// <summary>
			/// This is the resolved IPaddress to be used when sending, 
			/// or it is the remote source of a received packet.
			/// </summary>
			public IPaddress address;
		}
		#endregion UDPpacket
		
		#region TCPsocket
		/// <summary>
		/// TCP socket type (opaque)
		/// </summary>
		/// <remarks>
		/// This is an opaque data type used for TCP connections. 
		/// This is a pointer, and so it could be NULL at times. 
		/// NULL would indicate no socket has been established.
		/// <code>
		/// typedef struct _TCPsocket *TCPsocket
		/// </code>
		/// </remarks>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="SDLNet_GenericSocket"/>
		public struct TCPsocket
		{
		}
		#endregion TCPsocket
		
		#region UDPsocket
		/// <summary>
		/// UDP socket type (opaque)
		/// </summary>
		/// <remarks>
		/// This is an opaque data type used for UDP sockets. 
		/// This is a pointer, and so it could be NULL at times. 
		/// NULL would indicate no socket has been established.
		/// <code>
		/// typedef struct _UDPsocket *UDPsocket
		/// </code>
		/// </remarks>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="TCPsocket"/>
		/// <seealso cref="SDLNet_GenericSocket"/>
		public struct UDPsocket
		{
		}
		#endregion UDPsocket
		
		#region SDLNet_SocketSet
		/// <summary>
		/// Socket Set type (opaque)
		/// </summary>
		/// <remarks>
		/// This is an opaque data type used for socket sets. 
		/// This is a pointer, and so it could be NULL at times. 
		/// NULL would indicate no socket set has been created.
		/// <code>
		/// typedef struct _SDLNet_SocketSet *SDLNet_SocketSet
		/// </code>
		/// </remarks>
		/// <seealso cref="TCPsocket"/>
		/// <seealso cref="UDPsocket"/>
		public struct SDLNet_SocketSet
		{
		}
		#endregion SDLNet_SocketSet
		
		#region SDLNet_GenericSocket
		/// <summary>
		/// A generic type for UDP and TCP sockets
		/// </summary>
		/// <remarks>
		/// This data type is able to be used for both UDPsocket 
		/// and TCPsocket types.
		/// After calling SDLNet_CheckSockets, 
		/// if this socket is in SDLNet_SocketSet used, 
		/// the ready will be set according to activity on the socket. 
		/// This is the only real use for this type, as it doesn't 
		/// help you know what type of socket it is.
		/// <code>
		/// typedef struct {
		///     int ready;
		/// } *SDLNet_GenericSocket;
		/// </code>
		/// </remarks>
		/// <seealso cref="TCPsocket"/>
		/// <seealso cref="UDPsocket"/>
		public struct SDLNet_GenericSocket
		{
			/// <summary>
			/// Non-zero when data is ready to be read, 
			/// or a server socket has a connection attempt 
			/// ready to be accepted.
			/// </summary>
			public int ready;
		}
		#endregion SDLNet_GenericSocket
		#endregion Public Structs
		
		#region SdlNet Methods
		#region General
		#region SDL_version SDL_NET_VERSION() 
		/// <summary>
		/// This method can be used to fill a version structure with the compile-time
		/// version of the SDL_net library.
		/// </summary>
		/// <returns>
		///     This function returns a <see cref="Sdl.SDL_version"/> struct containing the
		///     compiled version number
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_net.h:
		///     <code>#define SDL_NET_VERSION(X)
		/// {
		/// (X)->major = SDL_NET_MAJOR_VERSION;
		/// (X)->minor = SDL_NET_MINOR_VERSION;
		/// (X)->patch = SDL_NET_PATCHLEVEL;
		/// }</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version SDL_NET_VERSION() 
		{ 
			Sdl.SDL_version sdlVersion = new Sdl.SDL_version();
			sdlVersion.major = SDL_NET_MAJOR_VERSION;
			sdlVersion.minor = SDL_NET_MINOR_VERSION;
			sdlVersion.patch = SDL_NET_PATCHLEVEL;
			return sdlVersion;
		} 
		#endregion SDL_version SDL_NET_VERSION() 

		#region IntPtr SDLNet_Linked_VersionInternal()
		//     const SDL_version * SDLNet_Linked_Version(void)
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="SDLNet_Linked_Version"), SuppressUnmanagedCodeSecurity]
		private static extern IntPtr SDLNet_Linked_VersionInternal();
		#endregion IntPtr SDLNet_Linked_VersionInternal()

		#region SDL_version SDLNet_Linked_Version() 
		/// <summary>
		///     Using this you can compare the runtime version to the 
		/// version that you compiled with.
		/// </summary>
		/// <returns>
		///     This function gets the version of the dynamically 
		/// linked SDL_net library in an <see cref="Sdl.SDL_version"/> struct.
		/// </returns>
		/// <remarks>
		///     <p>
		///     Binds to C-function call in SDL_net.h:
		///     <code>const SDL_version * SDLNet_Linked_Version(void)</code>
		///     </p>
		/// </remarks>
		public static Sdl.SDL_version SDLNet_Linked_Version() 
		{ 
			return (Sdl.SDL_version)Marshal.PtrToStructure(
				SDLNet_Linked_VersionInternal(), 
				typeof(Sdl.SDL_version)); 
		} 
		#endregion SDL_version SDLNet_Linked_Version()

		#region int SDLNet_Init()
		/// <summary>
		/// Initialize the network API.
		/// </summary>
		/// <remarks>
		/// This must be called before using other functions in this library.
		/// SDL must be initialized before this call because this 
		/// library uses utility functions from the SDL library.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>extern DECLSPEC int  SDLCALL SDLNet_Init(void);</code>
		/// </p>
		/// </remarks>
		/// <returns>0 on success, -1 on errors</returns>
		/// <example>
		/// <code>
		/// if(SDL_Init(0)==-1) {
		///     printf("SDL_Init: %s\n", SDL_GetError());
		///     exit(1);
		/// }
		/// if(SDLNet_Init()==-1) {
		///     printf("SDLNet_Init: %s\n", SDLNet_GetError());
		///		exit(2);
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_Quit"/>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_Init();
		#endregion int SDLNet_Init()
		
		#region void SDLNet_Quit()
		
		/// <summary>
		/// Shutdown and cleanup the network API.
		/// </summary>
		/// <remarks>
		/// After calling this all sockets are closed, and the SDL_net 
		/// functions should not be used. You may, of course, use SDLNet_Init
		/// to use the functionality again.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>extern DECLSPEC void SDLCALL SDLNet_Quit(void);</code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// SDLNet_Quit();
		/// // you could SDL_Quit(); here...or not.
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_Init"/>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_Quit();
		#endregion void SDLNet_Quit()
		
		#region string SDLNet_GetError()
		/// <summary>
		/// Get the current error string
		/// </summary>
		/// <remarks>
		/// This is the same as SDL_GetError, which returns the 
		/// last error set as a string which you may use to tell 
		/// the user what happened when an error status has been returned 
		/// from an SDLNet_function.
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>#define SDLNet_GetError	SDL_GetError</code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// A string containing a human readable version 
		/// or the reason for the last error that occured.
		/// </returns>
		/// <example>
		/// <code>
		/// printf("Oh My Goodness, an error : %s", SDLNet_GetError());
		/// </code>
		/// </example>
		public static string SDLNet_GetError()
		{
			return Sdl.SDL_GetError();
		}
		#endregion string SDLNet_GetError()

		#region void SDLNet_SetError(string message)
		/// <summary>
		/// This is the same as SDL_SetError, which sets an SDL error message
		/// </summary>
		/// <remarks>
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>#define SDLNet_SetError	SDL_SetError</code>
		/// </p>
		/// </remarks>
		/// <param name="message">
		/// The error message to set.
		/// </param>
		public static void SDLNet_SetError(string message)
		{
			Sdl.SDL_SetError(message);
		}
		#endregion void SDLNet_SetError(string message)
		
		#region void SDLNet_Write16(short value, IntPtr area)
		/// <summary>
		/// Put the 16bit (a short on 32bit systems) value 
		/// into the data buffer area in network byte order.
		/// </summary>
		/// <remarks>
		/// This helps avoid byte order differences 
		/// between two systems that are talking over the network.
		///  The value can be a signed number, the unsigned parameter 
		///  type doesn't affect the data. The area pointer need not 
		///  be at the beginning of a buffer, but must have at 
		///  least 2 bytes of space left, 
		///  including the byte currently pointed at.
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>extern DECLSPEC void SDLCALL SDLNet_Write16(Uint16 value, void *area)</code>
		/// </p>
		///  </remarks>
		/// <example>
		/// <code>
		/// // put my number into a data buffer to prepare for 
		/// // sending to a remote host
		/// char data[1024];
		/// Sint16 number=12345;
		/// SDLNet_Write16((Uint16)number,data);
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_Write32"/>
		/// <seealso cref="SDLNet_Read16"/>
		/// <param name="value">
		/// The 16bit number to put into the 
		/// area buffer.
		/// </param>
		/// <param name="area">
		/// The pointer into a data buffer, at which to put the number.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_Write16(short value, IntPtr area);
		#endregion void SDLNet_Write16(short value, IntPtr area)
		
		#region void SDLNet_Write32(int value, IntPtr area)
		/// <summary>
		/// Put the 32bit (a long on 32bit systems) value into 
		/// the data buffer area in network byte order.
		/// </summary>
		/// <remarks>
		/// This helps avoid byte order differences between two 
		/// systems that are talking over the network. 
		/// The value can be a signed number, the unsigned 
		/// parameter type doesn't affect the data. 
		/// The area pointer need not be at the beginning of a buffer,
		/// but must have at least 4 bytes of space left, 
		/// including the byte currently pointed at.
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>extern DECLSPEC void SDLCALL SDLNet_Write32(Uint32 value, void *area)</code>
		/// </p>
		///  </remarks>
		/// <example>
		/// <code>
		/// // put my number into a data buffer to prepare 
		/// // for sending to a remote host
		/// char data[1024];
		/// Uint32 number=0xDEADBEEF;
		/// SDLNet_Write32(number,data);
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_Write16"/>
		/// <seealso cref="SDLNet_Read32"/>
		/// <param name="value">
		/// The 32bit number to put into the area buffer.
		/// </param>
		/// <param name="area">
		/// The pointer into a data buffer, at which to put the number.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_Write32(int value, IntPtr area);
		#endregion void SDLNet_Write32(int value, IntPtr area)
		
		#region short SDLNet_Read16(IntPtr area)
		/// <summary>
		/// Get a 16bit (a short on 32bit systems) value from 
		/// the data buffer area which is in network byte order.
		/// </summary>
		/// <remarks>
		/// This helps avoid byte order differences between 
		/// two systems that are talking over the network. 
		/// The returned value can be a signed number, 
		/// the unsigned parameter type doesn't affect the data. 
		/// The area pointer need not be at the beginning of a buffer,
		/// but must have at least 2 bytes of space left, 
		/// including the byte currently pointed at.
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>extern DECLSPEC Uint16 SDLCALL SDLNet_Read16(void *area)</code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // get a number from a data buffer to use on this host
		/// //char *ptr; //this points into a previously received data buffer
		/// Sint16 number;
		/// number=(Sint16) SDLNet_Read16(ptr);
		/// // number is now in your hosts byte order, ready to use.
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_Write16"/>
		/// <seealso cref="SDLNet_Read32"/>
		/// <param name="area">The pointer into a data buffer, at which to get the number from.</param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern short SDLNet_Read16(IntPtr area);
		#endregion short SDLNet_Read16(IntPtr area)
		
		#region int SDLNet_Read32(IntPtr area)
		/// <summary>
		/// Get a 32bit (a long on 32bit systems) value from the data buffer area which is in network byte order.
		/// </summary>
		/// <remarks>
		/// This helps avoid byte order differences between two 
		/// systems that are talking over the network. The 
		/// returned value can be a signed number, the unsigned
		/// parameter type doesn't affect the data. The area 
		/// pointer need not be at the beginning of a buffer,
		/// but must have at least 4 bytes of space left,
		/// including the byte currently pointed at.
		/// <p>Binds to C-function call in SDL_error.h:
		///     <code>extern DECLSPEC Uint32 SDLCALL SDLNet_Read32(void *area)</code>
		/// </p>
		/// </remarks>
		/// <example>
		/// <code>
		/// // get a number from a data buffer to use on this host
		/// //char *ptr; //this points into a previously received data buffer
		/// Uint32 number;
		/// number=SDLNet_Read32(ptr);
		/// // number is now in your hosts byte order, ready to use.
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_Write32"/>
		/// <seealso cref="SDLNet_Read16"/>
		/// <param name="area">The pointer into a data buffer, at which to get the number from.</param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_Read32(IntPtr area);
		#endregion int SDLNet_Read32(IntPtr area)
		#endregion General
		
		#region Name Resolution
		#region int SDLNet_ResolveHost(ref IPaddress address, string host, short port)
		/// <summary>
		/// Resolve the string host, and fill in the IPaddress pointed to by address with the resolved IP and the port number passed in through port.
		/// </summary>
		/// <remarks>
		/// This is the best way to fill in the IPaddress struct for later use. This function does not actually open any sockets, it is used to prepare the arguments for the socket opening functions.
		/// WARNING: this function will put the host and port into Network Byte Order into the address fields, so make sure you pass in the data in your hosts byte order. (normally not an issue)
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_ResolveHost(IPaddress *address, const char *host, Uint16 port)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>0 on success. -1 on errors, plus address.host will be INADDR_NONE. An error would likely be that the address could not be resolved. If 'host' is NULL, the resolved host will be set to INADDR_ANY.</returns>
		/// <example>For a server listening on all interfaces, on port 1234:
		/// <code>
		/// // create a server type IPaddress on port 1234
		/// IPaddress ipaddress;
		/// SDLNet_ResolveHost(ipaddress, NULL, 1234);
		/// </code>
		/// For a client connecting to "host.domain.ext", at port 1234:
		/// <code>
		/// // create an IPaddress for host name "host.domain.ext" on port 1234
		/// // this is used by a client
		/// IPaddress ipaddress;
		/// SDLNet_ResolveHost(ipaddress, "host.domain.ext", 1234);
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_ResolveIP"/>
		/// <seealso cref="IPaddress"/>
		/// <param name="address">This points to the IPaddress that will be filled in. It doesn't need to be set before calling this, but it must be allocated in memory.</param>
		/// <param name="host">For connecting to a server, this is the hostname or IP in a string. For becoming a server, this is NULL. If you do use NULL, all network interfaces would be listened to for incoming connections, using the INADDR_ANY address.</param>
		/// <param name="port">For connecting to a server, this is the the servers listening port number. For becoming a server, this is the port to listen on. If you are just doing Domain Name Resolution functions, this can be 0.</param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_ResolveHost(ref IPaddress address, string host, short port);
		#endregion int SDLNet_ResolveHost(ref IPaddress address, string host, short port)
		
		#region string SDLNet_ResolveIP(ref IPaddress address)
		/// <summary>
		/// Resolve the IPv4 numeric address in address->host, and return the hostname as a string. 
		/// </summary>
		/// <remarks>
		/// This is the best way to fill in the IPaddress struct for later use. This function does not actually open any sockets, it is used to prepare the arguments for the socket opening functions.
		/// WARNING: this function will put the host and port into Network Byte Order into the address fields, so make sure you pass in the data in your hosts byte order. (normally not an issue)
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC const char * SDLCALL SDLNet_ResolveIP(IPaddress *ip);
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>a valid char pointer (string) on success. the returned hostname will have host and domain, as in "host.domain.ext". NULL is returned on errors, such as when it's not able to resolve the host name. The returned pointer is not to be freed. Each time you call this function the previous pointer's data will change to the new value, so you may have to copy it into a local buffer to keep it around longer.</returns>
		/// <example>
		/// <code>
		/// // resolve the host name of the address in ipaddress
		/// //IPaddress ipaddress;
		/// char *host;
		/// if(!(host=SDLNet_ResolveIP(IPaddress))) {
		/// 	printf("SDLNet_ResolveIP: %s\n", SDLNet_GetError());
		///     exit(1);
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_ResolveHost"/>
		/// <seealso cref="IPaddress"/>
		/// <param name="address">This points to the IPaddress that will be resolved to a host name. The address->port is ignored.</param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern string SDLNet_ResolveIP(ref IPaddress address);
		#endregion string SDLNet_ResolveIP(ref IPaddress address)
		#endregion Name Resolution
				
		#region TCP Sockets
		#region IntPtr SDLNet_TCP_Open(ref IPaddress ip)
		/// <summary>
		/// Open a TCP client or server socket 
		/// </summary>
		/// <remarks>
		/// Connect to the host and port contained in ip using a TCP connection.
		/// If the host is INADDR_ANY, then only the port number is used, and a socket is created that can be used to later accept incoming TCP connections.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC TCPsocket SDLCALL SDLNet_TCP_Open(IPaddress *ip)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>a valid TCPsocket on success, which indicates a successful connection has been established, or a socket has been created that is valid to accept incoming TCP connections. NULL is returned on errors, such as when it's not able to create a socket, or it cannot connect to host and/or port contained in ip.</returns>
		/// <example>
		/// <code>
		/// // connect to localhost at port 9999 using TCP (client)
		/// IPaddress ip;
		/// TCPsocket tcpsock;
		/// 
		/// if(SDLNet_ResolveHost(&amp;ip,"localhost",9999)==-1) {
		///     printf("SDLNet_ResolveHost: %s\n", SDLNet_GetError());
		///     exit(1);
		/// }
		/// 
		/// tcpsock=SDLNet_TCP_Open(&amp;ip);
		/// if(!tcpsock) {
		///     printf("SDLNet_TCP_Open: %s\n", SDLNet_GetError());
		///     exit(2);
		/// }
		/// </code>
		///
		/// <code>
		/// // create a listening TCP socket on port 9999 (server)
		/// IPaddress ip;
		/// TCPsocket tcpsock;
		/// 
		/// if(SDLNet_ResolveHost(&amp;ip,NULL,9999)==-1) {
		///     printf("SDLNet_ResolveHost: %s\n", SDLNet_GetError());
		///     exit(1);
		/// }
		/// 
		/// tcpsock=SDLNet_TCP_Open(&amp;ip);
		/// if(!tcpsock) {
		///     printf("SDLNet_TCP_Open: %s\n", SDLNet_GetError());
		///     exit(2);
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_TCP_Accept"/>
		/// <seealso cref="SDLNet_TCP_Close"/>
		/// <seealso cref="IPaddress"/>
		/// <seealso cref="TCPsocket"/>
		/// 
		/// <param name="ip">This points to the IPaddress that contains the resolved IP address and port number to use.</param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_TCP_Open(ref IPaddress ip);
		#endregion IntPtr SDLNet_TCP_Open(ref IPaddress ip)

		#region IntPtr SDLNet_TCP_Accept(IntPtr server)
		/// <summary>
		/// Accept a connection on a server socket 
		/// </summary>
		/// <remarks>
		/// Accept an incoming connection on the server TCPsocket.
		/// Do not use this function on a connected socket. 
		/// Server sockets are never connected to a remote host. 
		/// What you get back is a new TCPsocket that is connected to the remote host.
		/// This is a non-blocking call, so if no connections are there to be accepted,
		/// you will get a NULL
		/// TCPsocket and the program will continue going.
		///
		/// Accept an incoming connection on the given server socket.
		/// The newly created socket is returned, or NULL if there was an error.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC TCPsocket SDLCALL SDLNet_TCP_Accept(TCPsocket server)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>a valid TCPsocket on success, which indicates a successful connection has been established. NULL is returned on errors, such as when it's not able to create a socket, or it cannot finish connecting to the originating host and port. There also may not be a connection attempt in progress, so of course you cannot accept nothing, and you get a NULL in this case as well.</returns>
		/// <example>
		/// <code>
		/// // accept a connection coming in on server_tcpsock
		/// TCPsocket new_tcpsock;
		/// 
		/// new_tcpsock=SDLNet_TCP_Accept(server_tcpsock);
		/// if(!new_tcpsock) {
		///     printf("SDLNet_TCP_Accept: %s\n", SDLNet_GetError());
		/// }
		/// else {
		///     // communicate over new_tcpsock
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_TCP_Open"/>
		/// <seealso cref="SDLNet_TCP_Close"/>
		/// <seealso cref="SDLNet_TCP_GetPeerAddress"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="server">
		/// This is the server TCPsocket which was previously created by
		/// SDLNet_TCP_Open.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_TCP_Accept(TCPsocket server);
		#endregion IntPtr SDLNet_TCP_Accept(TCPsocket server)

		#region IntPtr SDLNet_TCP_GetPeerAddress(TCPsocket sock)
		/// <summary>
		/// Get the remote host address and port number 
		/// </summary>
		/// <remarks>
		/// Get the Peer's (the other side of the connection, 
		/// the remote side, not the local side) IP address and port number.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC IPaddress * SDLCALL SDLNet_TCP_GetPeerAddress(TCPsocket sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// an IPaddress. NULL is returned on errors, or when sock is a server socket.
		/// </returns>
		/// <example>
		/// <code>
		/// // get the remote IP and port
		/// //TCPsocket new_tcpsock;
		/// IPaddress *remote_ip;
		/// 
		/// remote_ip=SDLNet_TCP_GetPeerAddress(new_tcpsock);
		/// if(!remote_ip) {
		///     printf("SDLNet_TCP_GetPeerAddress: %s\n", SDLNet_GetError());
		///     printf("This may be a server socket.\n");
		/// }
		/// else {
		///     // print the info in IPaddress or something else...
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_TCP_Open"/>
		/// <seealso cref="SDLNet_TCP_Accept"/>
		/// <seealso cref="IPaddress"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="sock">
		/// This is a valid TCPsocket.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_TCP_GetPeerAddress(TCPsocket sock);
		#endregion IntPtr SDLNet_TCP_GetPeerAddress(TCPsocket sock)

		#region int SDLNet_TCP_Send(TCPsocket sock, IntPtr data, int len)
		/// <summary>
		/// Send data over a connected socket 
		/// </summary>
		/// <remarks>
		/// Send data of length len over the socket sock.
		/// This routine is not used for server sockets.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_TCP_Send(TCPsocket sock, const void *data, int len)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of bytes sent. If the number returned is less than len,
		/// then an error occured, such as the client disconnecting.
		/// </returns>
		/// <example>
		/// <code>
		/// // send a hello over sock
		/// //TCPsocket sock;
		/// int len,result;
		/// char *msg="Hello!";
		/// 
		/// len=strlen(msg)+1; // add one for the terminating NULL
		/// result=SDLNet_TCP_Send(sock,msg,len);
		/// if(result&lt;len) {
		///     printf("SDLNet_TCP_Send: %s\n", SDLNet_GetError());
		///     // It may be good to disconnect sock because it is likely invalid now.
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_TCP_Open"/>
		/// <seealso cref="SDLNet_TCP_Close"/>
		/// <seealso cref="SDLNet_TCP_Accept"/>
		/// <seealso cref="SDLNet_TCP_Recv"/>
		/// <seealso cref="SDLNet_TCP_GetPeerAddress"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="sock">
		/// This is a valid, connected, TCPsocket.
		/// </param>
		/// <param name="data">
		/// This is a pointer to the data to send over sock.
		/// </param>
		/// <param name="len">
		/// This is the length (in bytes) of the data.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_TCP_Send(TCPsocket sock, IntPtr data, int len);
		#endregion int SDLNet_TCP_Send(TCPsocket sock, IntPtr data, int len)

		#region int SDLNet_TCP_Recv(TCPsocket sock, IntPtr data, int maxlen)
		/// <summary>
		/// Receive data from a connected socket 
		/// </summary>
		/// <remarks>Receive data of exactly length maxlen bytes from the socket sock, into the memory pointed to by data. This routine is not used for server sockets. Unless there is an error, or the connection is closed, the buffer will read maxlen bytes. If you read more than is sent from the other end, then it will wait until the full requested length is sent, or until the connection is closed from the other end. You may have to read 1 byte at a time for some applications, for instance, text applications where blocks of text are sent, but you want to read line by line. In that case you may want to find the newline characters yourself to break the lines up, instead of reading some inordinate amount of text which may contain many lines, or not even a full line of text.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_TCP_Recv(TCPsocket sock, void *data, int maxlen)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of bytes received. If the number returned is less than or equal to zero, then an error occured, or the remote host has closed the connection.
		/// </returns>
		/// <example>
		/// <code>
		/// // receive some text from sock
		/// //TCPsocket sock;
		/// #define MAXLEN 1024
		/// int result;
		/// char msg[MAXLEN];
		/// 
		/// result=SDLNet_TCP_Recv(sock,msg,MAXLEN);
		/// if(result&lt;=0) {
		///     // An error may have occured, but sometimes you can just ignore it
		///     // It may be good to disconnect sock because it is likely invalid now.
		/// }
		/// printf("Received: \"%s\"\n",msg);
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_TCP_Open"/>
		/// <seealso cref="SDLNet_TCP_Close"/>
		/// <seealso cref="SDLNet_TCP_Accept"/>
		/// <seealso cref="SDLNet_TCP_Send"/>
		/// <seealso cref="SDLNet_TCP_GetPeerAddress"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="sock">
		/// This is a valid, connected, TCPsocket.
		/// </param>
		/// <param name="data">
		/// This is a pointer to the buffer that receives the data from sock.
		/// </param>
		/// <param name="maxlen">
		/// This is the maximum length (in bytes) that will be read into data.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_TCP_Recv(TCPsocket sock, IntPtr data, int maxlen);
		#endregion int SDLNet_TCP_Recv(TCPsocket sock, IntPtr data, int maxlen)

		#region void SDLNet_TCP_Close(IntPtr sock)
		/// <summary>
		/// Close a TCP socket 
		/// </summary>
		/// <remarks>
		/// This shutsdown, disconnects, and closes the TCPsocket sock. After this, you can be assured that this socket is not in use anymore. You can reuse the sock variable after this to open a new connection with SDLNet_TCP_Open. Do not try to use any other functions on a closed socket, as it is now invalid.
		/// 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC void SDLCALL SDLNet_TCP_Close(TCPsocket sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// nothing, this always succeeds for all we need to know.
		/// </returns>
		/// <example>
		/// <code>
		/// // close the connection on sock
		/// //TCPsocket sock;
		/// 
		/// SDLNet_TCP_Close(sock);
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_TCP_Close"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="sock">
		/// A valid TCPsocket. This can be a server or client type socket.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_TCP_Close(IntPtr sock);
		#endregion void SDLNet_TCP_Close(IntPtr sock)
		#endregion TCP Sockets

		#region UDP Packets
		#region IntPtr SDLNet_AllocPacket(int size)
		/// <summary>
		/// Allocate a new UDP packet with a data buffer 
		/// </summary>
		/// <remarks>
		/// Create (via malloc) a new UDPpacket with a data buffer of size bytes. The new packet should be freed using SDLNet_FreePacket when you are done using it.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC UDPpacket * SDLCALL SDLNet_AllocPacket(int size)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a pointer to a new empty UDPpacket. NULL is returned on errors, such as out-of-memory.
		/// </returns>
		/// <example>
		/// <code>
		/// // create a new UDPpacket to hold 1024 bytes of data
		/// UDPpacket *packet;
		/// 
		/// packet=SDLNet_AllocPacket(1024);
		/// if(!packet) {
		///     printf("SDLNet_AllocPacket: %s\n", SDLNet_GetError());
		///     // perhaps do something else since you can't make this packet
		/// }
		/// else {
		///     // do stuff with this new packet
		///     // SDLNet_FreePacket this packet when finished with it
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="IPaddress"/>
		/// <seealso cref="SDLNet_AllocPacketV"/>
		/// <seealso cref="SDLNet_ResizePacket"/>
		/// <seealso cref="SDLNet_FreePacket"/>
		/// <seealso cref="SDLNet_UDP_Send"/>
		/// <seealso cref="SDLNet_UDP_SendV"/>
		/// <param name="size">
		/// Size, in bytes, of the data buffer to be allocated in the new UDPpacket. Zero is invalid.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_AllocPacket(int size);
		#endregion IntPtr SDLNet_AllocPacket(int size)

		#region IntPtr SDLNet_ResizePacket(IntPtr packet, int newsize)
		/// <summary>
		/// Resize the data buffer in a UDPpacket 
		/// </summary>
		/// <remarks>
		/// Resize a UDPpackets data buffer to size bytes. The old data buffer will not be retained, so the new buffer is invalid after this call.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_ResizePacket(UDPpacket *packet, int newsize)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the new size of the data in the packet. If the number returned is less than what you asked for, that's an error.
		/// </returns>
		/// <example>
		/// <code>
		/// // Resize a UDPpacket to hold 2048 bytes of data
		/// //UDPpacket *packet;
		/// int newsize;
		/// 
		/// newsize=SDLNet_ResizePacket(packet, 2048);
		/// if(newsize&lt;2048) {
		///     printf("SDLNet_ResizePacket: %s\n", SDLNet_GetError());
		///     // perhaps do something else since you didn't get the buffer you wanted
		/// }
		/// else {
		///     // do stuff with the resized packet
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="SDLNet_AllocPacket"/>
		/// <seealso cref="SDLNet_AllocPacketV"/>
		/// <seealso cref="SDLNet_FreePacket"/>
		/// <param name="packet">
		/// A pointer to the UDPpacket to be resized.
		/// </param>
		/// <param name="newsize">
		/// The new desired size, in bytes, of the data buffer to be allocated in the UDPpacket.
		/// Zero is invalid.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_ResizePacket(IntPtr packet, int newsize);
		#endregion IntPtr SDLNet_ResizePacket(IntPtr packet, int newsize)

		#region IntPtr SDLNet_FreePacket(IntPtr packet)
		/// <summary>
		/// Free a previously allocated UDPpacket 
		/// </summary>
		/// <remarks>
		/// Free a UDPpacket from memory. Do not use this UDPpacket after this function is called on it.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC void SDLCALL SDLNet_FreePacket(UDPpacket *packet)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// nothing, this always succeeds.
		/// </returns>
		/// <example>
		/// <code>
		/// // Free a UDPpacket
		/// //UDPpacket *packet;
		/// 
		/// SDLNet_FreePacket(packet);
		/// packet=NULL; //just to help you know that it is freed
		/// </code>
		/// </example>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="SDLNet_AllocPacket"/>
		/// <seealso cref="SDLNet_AllocPacketV"/>
		/// <seealso cref="SDLNet_FreePacketV"/>
		/// <seealso cref="SDLNet_ResizePacket"/>
		/// <param name="packet">
		/// A pointer to the UDPpacket to be freed from memory.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_FreePacket(IntPtr packet);
		#endregion IntPtr SDLNet_FreePacket(IntPtr packet)

		#region IntPtr SDLNet_AllocPacketV(int howmany, int size)
		/// <summary>
		/// Allocate a vector of UDPpackets 
		/// </summary>
		/// <remarks>
		/// Create (via malloc) a vector of new UDPpackets, each with data buffers of size bytes. The new packet vector should be freed using SDLNet_FreePacketV when you are done using it. The returned vector is one entry longer than requested, for a terminating NULL.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC UDPpacket ** SDLCALL SDLNet_AllocPacketV(int howmany, int size)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a pointer to a new empty UDPpacket vector. NULL is returned on errors, such as out-of-memory.
		/// </returns>
		/// <example>
		/// <code>
		/// // create a new UDPpacket vector to hold 1024 bytes of data in 10 packets
		/// UDPpacket **packetV;
		/// 
		/// packetV=SDLNet_AllocPacketV(10, 1024);
		/// if(!packetV) {
		///     printf("SDLNet_AllocPacketV: %s\n", SDLNet_GetError());
		///     // perhaps do something else since you can't make this packet
		/// }
		/// else {
		///     // do stuff with this new packet vector
		///     // SDLNet_FreePacketV this packet vector when finished with it
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="IPaddress"/>
		/// <seealso cref="SDLNet_AllocPacketV"/>
		/// <seealso cref="SDLNet_ResizePacket"/>
		/// <seealso cref="SDLNet_FreePacket"/>
		/// <seealso cref="SDLNet_UDP_Send"/>
		/// <seealso cref="SDLNet_UDP_SendV"/>
		/// <param name="howmany">
		/// The number of UDPpackets to allocate.
		/// </param>
		/// <param name="size">
		/// Size, in bytes, of the data buffers to be allocated in the new UDPpackets.
		/// Zero is invalid.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_AllocPacketV(int howmany, int size);
		#endregion IntPtr SDLNet_AllocPacketV(int howmany, int size)

		#region IntPtr SDLNet_FreePacketV(IntPtr packetV)
		/// <summary>
		/// Free a vector of UDPpackets 
		/// </summary>
		/// <remarks>
		/// Free a UDPpacket vector from memory. Do not use this UDPpacket vector, or any UDPpacket in it, after this function is called on it.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC void SDLCALL SDLNet_FreePacketV(UDPpacket **packetV)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// nothing, this always succeeds.
		/// </returns>
		/// <example>
		/// <code>
		/// // Free a UDPpacket vector
		/// //UDPpacket **packet;
		/// 
		/// SDLNet_FreePacketV(packetV);
		/// packetV=NULL; //just to help you know that it is freed
		/// </code>
		/// </example>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="SDLNet_AllocPacket"/>
		/// <seealso cref="SDLNet_AllocPacketV"/>
		/// <seealso cref="SDLNet_FreePacket"/>
		/// <seealso cref="SDLNet_ResizePacket"/>
		/// <param name="packetV">
		/// A pointer to the UDPpacket to be freed from memory.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_FreePacketV(IntPtr packetV);
		#endregion IntPtr SDLNet_FreePacketV(IntPtr packetV)
		#endregion UDP Packets

		#region UDP Sockets
		#region IntPtr SDLNet_UDP_Open(short port)
		/// <summary>
		/// Create a UDP socket 
		/// </summary>
		/// <remarks>Open a socket to be used for UDP packet sending and/or receiving. 
		/// If a non-zero port is given it will be used, otherwise any open port
		/// number will be used automatically. Unlike TCP sockets, this socket
		/// does not require a remote host IP to connect to, this is because UDP
		/// ports are never actually connected like TCP ports are. This socket
		/// is able to send and receive directly after this simple creation.
		///
		/// If 'port' is non-zero, the UDP socket is bound to a local port. 
		/// The 'port' should be given in native byte order, but is used
		/// internally in network (big endian) byte order, in addresses, etc.
		/// This allows other systems to send to this socket via a known port.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC UDPsocket SDLCALL SDLNet_UDP_Open(Uint16 port)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a valid UDPsocket on success. NULL is returned on errors, 
		/// such as when it's not able to create a socket,
		/// or it cannot assign the non-zero port as requested.
		/// </returns>
		/// <example>
		/// Note that below I say server, but clients may also open
		/// a specific port, though it is prefered that a client be
		/// more flexible, given that the port may be already allocated
		/// by another process, such as a server. In such a case you 
		/// will not be able to open the socket, and your program 
		/// will be stuck, so it is better to just use whatever port
		/// you are given by using a specified port of zero. 
		/// Then the client will always work. The client can inform 
		/// the server what port to talk back to, or the server can
		/// just look at the source of the packets it is receiving 
		/// to know where to respond to.
		/// <code>
		/// // create a UDPsocket on port 6666 (server)
		/// UDPsocket udpsock;
		/// 
		/// udpsock=SDLNet_UDP_Open(6666);
		/// if(!udpsock) {
		///     printf("SDLNet_UDP_Open: %s\n", SDLNet_GetError());
		///     exit(2);
		/// }
		/// </code>
		///
		/// <code>
		/// // create a UDPsocket on any available port (client)
		/// UDPsocket udpsock;
		/// 
		/// udpsock=SDLNet_UDP_Open(0);
		/// if(!udpsock) {
		///     printf("SDLNet_UDP_Open: %s\n", SDLNet_GetError());
		///     exit(2);
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Close"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="port">
		/// This is the port number (in native byte order) on which to receive UDP
		/// packets. Most servers will want to use a known port number here so that
		/// clients can easily communicate with the server. This can also be zero,
		/// which then opens an anonymous unused port number, to most likely be
		/// used to send UDP packets from.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_UDP_Open(short port);
		#endregion IntPtr SDLNet_UDP_Open(short port)

		#region int SDLNet_UDP_Bind(IntPtr sock, int channel, ref IPaddress address)
		/// <summary>
		/// Assign an IP address number to a socket channel 
		/// </summary> 
		/// <remarks>
		/// Bind an address to a channel on a socket. 
		/// Incoming packets are only allowed from bound addresses for the socket channel.
		/// All outgoing packets on that channel,
		/// regardless of the packets internal address, 
		/// will attempt to send once on each bound address on that channel.
		/// You may assign up to SDLNET_MAX_UDPADDRESSES to each channel. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC int SDLCALL SDLNet_UDP_Bind(UDPsocket sock, int channel, IPaddress *address)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// The channel number that was bound. -1 is returned on errors, such as no free channels, or this channel has SDLNET_MAX_UDPADDRESSES already assigned to it, or you have used a channel higher or equal to SDLNET_MAX_UDPCHANNELS, or lower than -1.
		/// </returns>
		/// <example>
		/// <code>
		/// // Bind address to the first free channel
		/// //UDPsocket udpsock;
		/// //IPaddress *address;
		/// int channel;
		/// 
		/// channel=SDLNet_UDP_Bind(udpsock, -1, address);
		/// if(channel==-1) {
		///     printf("SDLNet_UDP_Bind: %s\n", SDLNet_GetError());
		///     // do something because we failed to bind
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Unbind"/>
		/// <seealso cref="SDLNet_UDP_GetPeerAddress"/>
		/// <seealso cref="SDLNet_UDP_Open"/>
		/// <seealso cref="IPaddress"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// the UDPsocket on which to assign the address.
		/// </param>
		/// <param name="channel">The channel to assign address to. This should be less than SDLNET_MAX_UDPCHANNELS. If -1 is used, then the first unbound channel will be used, this should only be used for incomming packet filtering, as it will find the first channel with less than SDLNET_MAX_UDPADDRESSES assigned to it and use that one.
		/// </param>
		/// <param name="address">
		/// The resolved IPaddress to assign to the socket's channel. 
		/// The host and port are both used. 
		/// It is not helpful to bind 0.0.0.0 to a channel.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_UDP_Bind(IntPtr sock, int channel, ref IPaddress address);
		#endregion int SDLNet_UDP_Bind(IntPtr sock, int channel, ref IPaddress address)

		#region void SDLNet_UDP_Unbind(IntPtr sock, int channel)
		/// <summary>
		/// Remove all assigned IP addresses from a socket channel 
		/// </summary> 
		/// <remarks>
		/// This removes all previously assigned (bound) addresses 
		/// from a socket channel.
		/// After this you may bind new addresses to the socket 
		/// channel.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC void SDLCALL SDLNet_UDP_Unbind(UDPsocket sock, int channel)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// nothing, this always succeeds.
		/// </returns>
		/// <example>
		/// <code>
		/// // unbind all addresses on the UDPsocket channel 0
		/// //UDPsocket udpsock;
		/// 
		/// SDLNet_UDP_Unbind(udpsock, 0);
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Bind"/>
		/// <seealso cref="SDLNet_UDP_Close"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket to unbind addresses from.
		/// </param>
		/// <param name="channel">
		/// The channel to unbind the addresses from in the UDPsocket.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_UDP_Unbind(IntPtr sock, int channel);
		#endregion void SDLNet_UDP_Unbind(IntPtr sock, int channel)

		#region IntPtr SDLNet_UDP_GetPeerAddress(IntPtr sock, int channel)
		/// <summary>
		/// Get the assigned IP address for a socket channel or get 
		/// the port you opened the socket with 
		/// </summary> 
		/// <remarks>
		/// Get the primary address assigned to this channel. 
		/// Only the first bound address is returned.
		/// When channel is -1, get the port that this socket 
		/// is bound to on the local computer, 
		/// this only means something if you opened the socket 
		/// with a specific port number.
		/// Do not free the returned IPaddress pointer.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC IPaddress * SDLCALL SDLNet_UDP_GetPeerAddress(UDPsocket sock, int channel)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// a pointer to an IPaddress. 
		/// NULL is returned for unbound channels and on any errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // get the primary address bound to UDPsocket channel 0
		/// 
		/// //UDPsocket udpsock;
		/// //IPaddress *address;
		/// 
		/// address=SDLNet_UDP_GetPeerAddress(udpsock, 0);
		/// if(!address) {
		///     printf("SDLNet_UDP_GetPeerAddress: %s\n", SDLNet_GetError());
		///     // do something because we failed to get the address
		/// }
		/// else {
		///     // perhaps print out address->host and address->port
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Unbind"/>
		/// <seealso cref="SDLNet_UDP_Bind"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket that probably has an address assigned to the channel.
		/// </param>
		/// <param name="channel">
		/// The channel to get the primary address from in the socket. 
		/// This may also be -1 to get the port which this socket is 
		/// bound to on the local computer.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr SDLNet_UDP_GetPeerAddress(IntPtr sock, int channel);
		#endregion IntPtr SDLNet_UDP_GetPeerAddress(IntPtr sock, int channel)

		#region int SDLNet_UDP_SendV(IntPtr sock, IntPtr packets, int npackets)
		/// <summary>
		/// Send a UDPpacket vector 
		/// </summary> 
		/// <remarks>
		/// Send npackets of packetV using the specified sock socket. 
		/// Each packet is sent in the same way as in SDLNet_UDP_Send
		/// (see section 3.4.6 SDLNet_UDP_Send).
		/// Don't forget to set the length of the packets in the len
		/// element of the packets you are sending!
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC int SDLCALL SDLNet_UDP_SendV(UDPsocket sock, UDPpacket **packets, int npackets)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// The number of destinations sent to that worked, 
		/// for each packet in the vector, all summed up. 
		/// 0 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // send a vector of 10 packets using UDPsocket
		/// //UDPsocket udpsock;
		/// //UDPpacket **packetV;
		/// int numsent;
		/// 
		/// numsent=SDLNet_UDP_SendV(udpsock, packetV, 10);
		/// if(!numsent) {
		///     printf("SDLNet_UDP_SendV: %s\n", SDLNet_GetError());
		///     // do something because we failed to send
		///     // this may just be because no addresses are bound to the channels...
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Bind"/>
		/// <seealso cref="SDLNet_UDP_Send"/>
		/// <seealso cref="SDLNet_UDP_Recv"/>
		/// <seealso cref="SDLNet_UDP_RecvV"/>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket.
		/// </param>
		/// <param name="packets">
		/// The vector of packets to send.
		/// </param>
		/// <param name="npackets">
		/// number of packets in the packetV vector to send.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_UDP_SendV(IntPtr sock, IntPtr packets, int npackets);
		#endregion int SDLNet_UDP_SendV(IntPtr sock, IntPtr packets, int npackets)

		#region int SDLNet_UDP_Send(IntPtr sock, int channel, IntPtr packet)
		/// <summary>
		/// Send a UDPpacket
		/// </summary> 
		/// <remarks>
		/// Send packet using the specified socket sock, using the 
		/// specified channel or else the packet's address.
		/// If channel is not -1 then the packet is sent to all the 
		/// socket channels bound addresses. If socket sock's channel 
		/// is not bound to any destinations, then the packet is not 
		/// sent at all!
		/// If the channel is -1, then the packet's address is used 
		/// as the destination.
		/// Don't forget to set the length of the packet in the len 
		/// element of the packet you are sending! NOTE: the packet->channel 
		/// will be set to the channel passed in to this function.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC int SDLCALL SDLNet_UDP_Send(UDPsocket sock, int channel, UDPpacket *packet)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// The number of destinations sent to that worked. 
		/// 0 is returned on errors.Note that since a channel can 
		/// point to multiple destinations, there should be just as
		/// many packets sent, so dont assume it will always return 1 
		/// on success. Unfortunately there's no way to get the number
		/// of destinations bound to a channel, so either you have to
		/// remember the number bound, or just test for the zero 
		/// return value indicating all channels failed.
		/// </returns>
		/// <example>
		/// <code>
		/// // send a packet using a UDPsocket, using the packet's channel as the channel
		/// //UDPsocket udpsock;
		/// //UDPpacket *packet;
		/// int numsent;
		/// 
		/// numsent=SDLNet_UDP_Send(udpsock, packet->channel, packet);
		/// if(!numsent) {
		///     printf("SDLNet_UDP_Send: %s\n", SDLNet_GetError());
		///     // do something because we failed to send
		///     // this may just be because no addresses are bound to the channel...
		/// }
		/// </code>
		/// Here's a way of sending one packet using it's internal channel setting.
		/// This is actually what SDLNet_UDP_Send ends up calling for you.
		/// <code>
		/// // send a packet using a UDPsocket, using the packet's channel as the channel
		/// //UDPsocket udpsock;
		/// //UDPpacket *packet;
		/// int numsent;
		/// 
		/// numsent=SDLNet_UDP_SendV(sock, &amp;packet, 1);
		/// if(!numsent) {
		///     printf("SDLNet_UDP_SendV: %s\n", SDLNet_GetError());
		///     // do something because we failed to send
		///     // this may just be because no addresses are bound to the channel...
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Bind"/>
		/// <seealso cref="SDLNet_UDP_SendV"/>
		/// <seealso cref="SDLNet_UDP_Recv"/>
		/// <seealso cref="SDLNet_UDP_RecvV"/>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket.
		/// </param>
		/// <param name="channel">
		/// what channel to send packet on.
		/// </param>
		/// <param name="packet">
		/// The packet to send.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_UDP_Send(IntPtr sock, int channel, IntPtr packet);
		#endregion int SDLNet_UDP_Send(IntPtr sock, int channel, IntPtr packet)

		#region int SDLNet_UDP_RecvV(IntPtr sock, IntPtr packets)
		/// <summary>
		/// Receive into a UDPpacket vector 
		/// </summary> 
		/// <remarks>
		/// Receive into a packet vector on the specified socket sock.
		/// packetV is a NULL terminated array. Packets will be 
		/// received until the NULL is reached, or there are none
		/// ready to be received.
		/// This call is otherwise the same as SDLNet_UDP_Recv 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC int SDLCALL SDLNet_UDP_RecvV(UDPsocket sock, UDPpacket **packets)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of packets received. 
		/// 0 is returned when no packets are received.
		/// -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // try to receive some waiting udp packets
		/// //UDPsocket udpsock;
		/// //UDPpacket **packetV;
		/// int numrecv, i;
		/// 
		/// numrecv=SDLNet_UDP_RecvV(udpsock, &amp;packetV);
		/// if(numrecv==-1) {
		///     // handle error, perhaps just print out the SDL_GetError string.
		/// }
		/// for(i=0; i&lt;numrecv; i++) {
		///     // do something with packetV[i]
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Bind"/>
		/// <seealso cref="SDLNet_UDP_Send"/>
		/// <seealso cref="SDLNet_UDP_SendV"/>
		/// <seealso cref="SDLNet_UDP_Recv"/>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket.
		/// </param>
		/// <param name="packets">
		/// The packet vector to receive into.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_UDP_RecvV(IntPtr sock, IntPtr packets);
		#endregion int SDLNet_UDP_RecvV(IntPtr sock, IntPtr packets)

		#region int SDLNet_UDP_Recv(IntPtr sock, IntPtr packet)
		/// <summary>
		/// Receive into a UDPpacket 
		/// </summary> 
		/// <remarks>
		/// Receive a packet on the specified sock socket.
		/// The packet you pass in must have enough of a data size 
		/// allocated for the incoming packet data to fit into. 
		/// This means you should have knowledge of your size needs
		/// before trying to receive UDP packets.
		/// The packet will have it's address set to the remote 
		/// sender's address.
		/// The socket's channels are checked in highest to lowest 
		/// order, so if an address is bound to multiple channels,
		/// the highest channel with the source address bound will 
		/// be retreived before the lower bound channels. So, the 
		/// packets channel will also be set to the highest numbered
		/// channel that has the remote address and port assigned to
		/// it. Otherwise the channel will -1, which you can filter 
		/// out easily if you want to ignore unbound source address.
		/// Note that the local and remote channel numbers do not have
		/// to, and probably won't, match, as they are only local
		/// settings, they are not sent in the packet.
		/// This is a non-blocking call, meaning if there's no data
		/// ready to be received the function will return.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///    	extern DECLSPEC int SDLCALL SDLNet_UDP_Recv(UDPsocket sock, UDPpacket *packet)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// 1 is returned when a packet is received.
		/// 0 is returned when no packets are received.
		/// -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // try to receive some waiting udp packets
		/// //UDPsocket udpsock;
		/// //UDPpacket packet;
		/// int numrecv;
		/// 
		/// numrecv=SDLNet_UDP_Recv(udpsock, &amp;packet);
		/// if(numrecv) {
		///     // do something with packet
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Bind"/>
		/// <seealso cref="SDLNet_UDP_Send"/>
		/// <seealso cref="SDLNet_UDP_SendV"/>
		/// <seealso cref="SDLNet_UDP_RecvV"/>
		/// <seealso cref="UDPpacket"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket.
		/// </param>
		/// <param name="packet">
		/// The packet to receive into.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_UDP_Recv(IntPtr sock, IntPtr packet);
		#endregion int SDLNet_UDP_Recv(IntPtr sock, IntPtr packet)

		#region void SDLNet_UDP_Close(IntPtr sock)
		/// <summary>
		/// Close and free a UDP socket 
		/// </summary>
		/// <remarks>
		/// Shutdown, close, and free a UDPsocket.
		/// Don't use the UDPsocket after calling this, 
		/// except to open a new one.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC void SDLCALL SDLNet_UDP_Close(UDPsocket sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// nothing, this always succeeds.
		/// </returns>
		/// <example>
		/// <code>
		/// // unbind all addresses on the UDPsocket channel 0
		/// //UDPsocket udpsock;
		/// 
		/// SDLNet_UDP_Close(udpsock);
		/// udpsock=NULL; //this helps us know that this UDPsocket is not valid anymore
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_UDP_Open"/>
		/// <seealso cref="UDPsocket"/>
		/// <param name="sock">
		/// A valid UDPsocket to shutdown, close, and free.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_UDP_Close(IntPtr sock);
		#endregion void SDLNet_UDP_Close(IntPtr sock)
		#endregion UDP Sockets
		
		#region Socket Sets
		#region SDLNet_SocketSet SDLNet_AllocSocketSet(int maxsockets)
		/// <summary>
		/// Create a new socket set 
		/// </summary>
		/// <remarks>
		/// Create a socket set that will be able to watch up to 
		/// maxsockets number of sockets. The same socket set can 
		/// be used for both UDP and TCP sockets.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC SDLNet_SocketSet SDLCALL SDLNet_AllocSocketSet(int maxsockets)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// A new, empty, SDLNet_SocketSet. NULL is returned on errors, such as out-of-memory.
		/// </returns>
		/// <example>
		/// <code>
		/// // Create a socket set to handle up to 16 sockets
		/// SDLNet_SocketSet set;
		/// 
		/// set=SDLNet_AllocSocketSet(16);
		/// if(!set) {
		///     printf("SDLNet_AllocSocketSet: %s\n", SDLNet_GetError());
		///     exit(1); //most of the time this is a major error, but do what you want.
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_FreeSocketSet"/>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="maxsockets">
		/// The maximum number of sockets you will want to watch.
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern SDLNet_SocketSet SDLNet_AllocSocketSet(int maxsockets);
		#endregion SDLNet_SocketSet SDLNet_AllocSocketSet(int maxsockets)

		#region int SDLNet_AddSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock)
		/// <summary>
		/// Add a socket to a socket set 
		/// </summary>
		/// <remarks>
		/// Add a socket to a socket set that will be watched. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_AddSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets used in the set on success. -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // add two sockets to a socket set
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //TCPsocket tcpsock;
		/// int numused;
		/// 
		/// numused=SDLNet_UDP_AddSocket(set,udpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_AddSocket: %s\n", SDLNet_GetError());
		///     // perhaps you need to restart the set and make it bigger...
		/// }
		/// numused=SDLNet_TCP_AddSocket(set,tcpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_AddSocket: %s\n", SDLNet_GetError());
		///     // perhaps you need to restart the set and make it bigger...
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AllocSocketSet"/>
		/// <seealso cref="SDLNet_DelSocket"/>
		/// <seealso cref="SDLNet_CheckSockets"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to add this socket to
		/// </param>
		/// <param name="sock">
		/// The socket to add to the socket set
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_AddSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock);
		#endregion int SDLNet_AddSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock)

		#region int SDLNet_TCP_AddSocket(SDLNet_SocketSet set, IntPtr sock)
		/// <summary>
		/// Add a socket to a socket set 
		/// </summary>
		/// <remarks>
		/// Add a socket to a socket set that will be watched. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     #define SDLNet_TCP_AddSocket(set, sock) SDLNet_AddSocket(set, (SDLNet_GenericSocket)sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets used in the set on success. -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // add two sockets to a socket set
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //TCPsocket tcpsock;
		/// int numused;
		/// 
		/// numused=SDLNet_UDP_AddSocket(set,udpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_AddSocket: %s\n", SDLNet_GetError());
		///     // perhaps you need to restart the set and make it bigger...
		/// }
		/// numused=SDLNet_TCP_AddSocket(set,tcpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_AddSocket: %s\n", SDLNet_GetError());
		///     // perhaps you need to restart the set and make it bigger...
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AllocSocketSet"/>
		/// <seealso cref="SDLNet_DelSocket"/>
		/// <seealso cref="SDLNet_CheckSockets"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to add this socket to
		/// </param>
		/// <param name="sock">
		/// The socket to add to the socket set
		/// </param>
		public static int SDLNet_TCP_AddSocket(SDLNet_SocketSet set, IntPtr sock)
		{
			SdlNet.SDLNet_GenericSocket genericSocket = (SdlNet.SDLNet_GenericSocket)Marshal.PtrToStructure(sock, typeof(SdlNet.SDLNet_GenericSocket));
			return SdlNet.SDLNet_AddSocket(set, genericSocket);
		}
		#endregion int SDLNet_TCP_AddSocket(SDLNet_SocketSet set, IntPtr sock)

		#region int SDLNet_UDP_AddSocket(SDLNet_SocketSet set, IntPtr sock)
		/// <summary>
		/// Add a socket to a socket set 
		/// </summary>
		/// <remarks>
		/// Add a socket to a socket set that will be watched. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     #define SDLNet_UDP_AddSocket(set, sock) SDLNet_AddSocket(set, (SDLNet_GenericSocket)sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets used in the set on success. -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // add two sockets to a socket set
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //TCPsocket tcpsock;
		/// int numused;
		/// 
		/// numused=SDLNet_UDP_AddSocket(set,udpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_AddSocket: %s\n", SDLNet_GetError());
		///     // perhaps you need to restart the set and make it bigger...
		/// }
		/// numused=SDLNet_TCP_AddSocket(set,tcpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_AddSocket: %s\n", SDLNet_GetError());
		///     // perhaps you need to restart the set and make it bigger...
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AllocSocketSet"/>
		/// <seealso cref="SDLNet_DelSocket"/>
		/// <seealso cref="SDLNet_CheckSockets"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to add this socket to
		/// </param>
		/// <param name="sock">
		/// The socket to add to the socket set
		/// </param>
		public static int SDLNet_UDP_AddSocket(SDLNet_SocketSet set, IntPtr sock)
		{
			SdlNet.SDLNet_GenericSocket genericSocket = (SdlNet.SDLNet_GenericSocket)Marshal.PtrToStructure(sock, typeof(SdlNet.SDLNet_GenericSocket));
			return SdlNet.SDLNet_AddSocket(set, genericSocket);
		}		
		#endregion int SDLNet_UDP_AddSocket(SDLNet_SocketSet set, IntPtr sock)

		#region int SDLNet_DelSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock)
		/// <summary>
		/// Remove a socket from a socket set 
		/// </summary>
		/// <remarks>
		/// Free the socket set from memory.
		/// Do not reference the set after this call, 
		/// except to allocate a new one. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_DelSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets used in the set on success. -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // remove two sockets from a socket set
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //TCPsocket tcpsock;
		/// int numused;
		/// 
		/// numused=SDLNet_UDP_DelSocket(set,udpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_DelSocket: %s\n", SDLNet_GetError());
		///     // perhaps the socket is not in the set
		/// }
		/// numused=SDLNet_TCP_DelSocket(set,tcpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_DelSocket: %s\n", SDLNet_GetError());
		///     // perhaps the socket is not in the set
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_FreeSocketSet"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to remove this socket from 
		/// </param>
		/// <param name="sock">
		/// the socket to remove from the socket set  
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_DelSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock);
		#endregion void SDLNet_DelSocket(SDLNet_SocketSet set, SDLNet_GenericSocket sock)

		#region int SDLNet_TCP_DelSocket(SDLNet_SocketSet set, IntPtr sock)
		/// <summary>
		/// Remove a socket from a socket set 
		/// </summary>
		/// <remarks>
		/// Free the socket set from memory.
		/// Do not reference the set after this call, 
		/// except to allocate a new one. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     #define SDLNet_TCP_DelSocket(set, sock) SDLNet_DelSocket(set, (SDLNet_GenericSocket)sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets used in the set on success. -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // remove two sockets from a socket set
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //TCPsocket tcpsock;
		/// int numused;
		/// 
		/// numused=SDLNet_UDP_DelSocket(set,udpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_DelSocket: %s\n", SDLNet_GetError());
		///     // perhaps the socket is not in the set
		/// }
		/// numused=SDLNet_TCP_DelSocket(set,tcpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_DelSocket: %s\n", SDLNet_GetError());
		///     // perhaps the socket is not in the set
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_FreeSocketSet"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to remove this socket from 
		/// </param>
		/// <param name="sock">
		/// the socket to remove from the socket set  
		/// </param>
		public static void SDLNet_TCP_DelSocket(SDLNet_SocketSet set, IntPtr sock)
		{
			SdlNet.SDLNet_GenericSocket genericSocket = (SdlNet.SDLNet_GenericSocket)Marshal.PtrToStructure(sock, typeof(SdlNet.SDLNet_GenericSocket));
			SdlNet.SDLNet_DelSocket(set, genericSocket);
		}		
		#endregion void SDLNet_TCP_DelSocket(SDLNet_SocketSet set, IntPtr sock)

		#region int SDLNet_UDP_DelSocket(SDLNet_SocketSet set, IntPtr sock)
		/// <summary>
		/// Remove a socket from a socket set 
		/// </summary>
		/// <remarks>
		/// Free the socket set from memory.
		/// Do not reference the set after this call, 
		/// except to allocate a new one. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     #define SDLNet_UDP_DelSocket(set, sock) SDLNet_DelSocket(set, (SDLNet_GenericSocket)sock)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets used in the set on success. -1 is returned on errors.
		/// </returns>
		/// <example>
		/// <code>
		/// // remove two sockets from a socket set
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //TCPsocket tcpsock;
		/// int numused;
		/// 
		/// numused=SDLNet_UDP_DelSocket(set,udpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_DelSocket: %s\n", SDLNet_GetError());
		///     // perhaps the socket is not in the set
		/// }
		/// numused=SDLNet_TCP_DelSocket(set,tcpsock);
		/// if(numused==-1) {
		///     printf("SDLNet_DelSocket: %s\n", SDLNet_GetError());
		///     // perhaps the socket is not in the set
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_FreeSocketSet"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to remove this socket from 
		/// </param>
		/// <param name="sock">
		/// the socket to remove from the socket set  
		/// </param>
		public static void SDLNet_UDP_DelSocket(SDLNet_SocketSet set, IntPtr sock)
		{
			SdlNet.SDLNet_GenericSocket genericSocket = (SdlNet.SDLNet_GenericSocket)Marshal.PtrToStructure(sock, typeof(SdlNet.SDLNet_GenericSocket));
			SdlNet.SDLNet_DelSocket(set, genericSocket);
		}		
		#endregion void SDLNet_UDP_DelSocket(SDLNet_SocketSet set, IntPtr sock)

		#region int SDLNet_CheckSockets(SDLNet_SocketSet set, int timeout)
		/// <summary>
		/// Check and wait for sockets in a set to have activity 
		/// </summary>
		/// <remarks>
		/// Check all sockets in the socket set for activity. If a non-zero timeout is given then this function will wait for activity, or else it will wait for timeout milliseconds. 
		/// NOTE: "activity" also includes disconnections and other errors, which would be determined by a failed read/write attempt.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC int SDLCALL SDLNet_CheckSockets(SDLNet_SocketSet set, Uint32 timeout)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// the number of sockets with activity. -1 is returned on errors, and you may not get a meaningful error message. -1 is also returned for an empty set (nothing to check). 
		/// </returns>
		/// <example>
		/// <code>
		/// // Wait for up to 1 second for network activity
		/// //SDLNet_SocketSet set;
		/// int numready;
		/// 
		/// numready=SDLNet_CheckSockets(set, 1000);
		/// if(numready==-1) {
		///     printf("SDLNet_CheckSockets: %s\n", SDLNet_GetError());
		///     //most of the time this is a system error, where perror might help you.
		///     perror("SDLNet_CheckSockets");
		/// }
		/// else if(numready) {
		///     printf("There are %d sockets with activity!\n",numready);
		///     // check all sockets with SDLNet_SocketReady and handle the active ones.
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_SocketReady"/>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_DelSocket"/>
		/// <seealso cref="SDLNet_AllocSocketSet"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to check
		/// </param>
		/// <param name="timeout">
		/// The amount of time (in milliseconds).
		/// 0 means no waiting.
		/// -1 means to wait over 49 days! (think about it)
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int SDLNet_CheckSockets(SDLNet_SocketSet set, int timeout);
		#endregion int SDLNet_CheckSockets(SDLNet_SocketSet set, int timeout)

		#region int SDLNet_SocketReady(IntPtr sock)
		/// <summary>
		/// See if a socket has activity 
		/// </summary>
		/// <remarks>
		/// Check whether a socket has been marked as active. This function should only be used on a socket in a socket set, and that set has to have had SDLNet_CheckSockets (see SDLNet_CheckSockets) called upon it.
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     #define SDLNet_SocketReady(sock) ((sock != NULL) &amp;&amp; ((SDLNet_GenericSocket)sock)->ready)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// non-zero for activity. zero is returned for no activity.
		/// </returns>
		/// <example>
		/// <code>
		/// // Wait forever for a connection attempt
		/// //SDLNet_SocketSet set;
		/// //TCPsocket serversock, client;
		/// int numready;
		/// 
		/// numready=SDLNet_CheckSockets(set, 1000);
		/// if(numready==-1) {
		///     printf("SDLNet_CheckSockets: %s\n", SDLNet_GetError());
		///     //most of the time this is a system error, where perror might help you.
		///     perror("SDLNet_CheckSockets");
		/// }
		/// else if(numready) {
		///     printf("There are %d sockets with activity!\n",numready);
		///     // check all sockets with SDLNet_SocketReady and handle the active ones.
		///     if(SDLNet_SocketReady(serversock)) {
		///         client=SDLNet_TCP_Accept(serversock);
		///         if(client) {
		///             // play with the client.
		///         }
		///     }
		/// }
		/// </code>
		/// To just quickly do network handling with no waiting, we do this.
		/// <code>
		/// // Check for, and handle UDP data
		/// //SDLNet_SocketSet set;
		/// //UDPsocket udpsock;
		/// //UDPpacket *packet;
		/// int numready, numpkts;
		/// 
		/// numready=SDLNet_CheckSockets(set, 0);
		/// if(numready==-1) {
		///     printf("SDLNet_CheckSockets: %s\n", SDLNet_GetError());
		///     //most of the time this is a system error, where perror might help you.
		///     perror("SDLNet_CheckSockets");
		/// }
		/// else if(numready) {
		///     printf("There are %d sockets with activity!\n",numready);
		///     // check all sockets with SDLNet_SocketReady and handle the active ones.
		///     if(SDLNet_SocketReady(udpsock)) {
		///         numpkts=SDLNet_UDP_Recv(udpsock,&amp;packet);
		///         if(numpkts) {
		///             // process the packet.
		///         }
		///     }
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_CheckSockets"/>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_DelSocket"/>
		/// <seealso cref="SDLNet_AllocSocketSet"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="sock">
		/// The socket to check for activity.
		/// Both UDPsocket and TCPsocket can be used with this function.
		/// </param>
		public static int SDLNet_SocketReady(IntPtr sock)
		{
			if (sock != IntPtr.Zero)
			{
				SdlNet.SDLNet_GenericSocket genericSocket = (SdlNet.SDLNet_GenericSocket)Marshal.PtrToStructure(sock, typeof(SdlNet.SDLNet_GenericSocket));
				return genericSocket.ready;
			}
			else
			{
				return 0;
			}
		}		
		#endregion int SDLNet_SocketReady(IntPtr sock)

		#region void SDLNet_FreeSocketSet(SDLNet_SocketSet set)
		/// <summary>
		/// Free a socket set 
		/// </summary>
		/// <remarks>
		/// Free the socket set from memory.
		/// Do not reference the set after this call, 
		/// except to allocate a new one. 
		/// <p>Binds to C-function call in SDL_net.h:
		///     <code>
		///     extern DECLSPEC void SDLCALL SDLNet_FreeSocketSet(SDLNet_SocketSet set)
		///     </code>
		/// </p>
		/// </remarks>
		/// <returns>
		/// nothing, this call always succeeds.
		/// </returns>
		/// <example>
		/// <code>
		/// // free a socket set
		/// //SDLNet_SocketSet set;
		/// 
		/// SDLNet_FreeSocketSet(set);
		/// set=NULL; //this helps us remember that this set is not allocated
		/// </code>
		/// </example>
		/// <seealso cref="SDLNet_AllocSocketSet"/>
		/// <seealso cref="SDLNet_AddSocket"/>
		/// <seealso cref="SDLNet_SocketSet"/>
		/// <seealso cref="UDPsocket"/>
		/// <seealso cref="TCPsocket"/>
		/// <param name="set">
		/// The socket set to free from memory 
		/// </param>
		[DllImport(SDL_NET_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void SDLNet_FreeSocketSet(SDLNet_SocketSet set);
		#endregion void SDLNet_FreeSocketSet(SDLNet_SocketSet set)
		#endregion Socket Sets		
		#endregion SdlNet Methods

        #region Not Yet implemented
        //		/* Inline macro functions to read/write network data */
//
//		/* Warning, some systems have data access alignment restrictions */
//#if defined(sparc) || defined(mips)
//#define SDL_DATA_ALIGNED	1
//#endif
//#ifndef SDL_DATA_ALIGNED
//#define SDL_DATA_ALIGNED	0
//#endif
//
//		/* Write a 16 bit value to network packet buffer */
//#if !SDL_DATA_ALIGNED
//#define SDLNet_Write16(value, areap)	\
//		(*(Uint16 *)(areap) = SDL_SwapBE16(value))
//#else
//#if SDL_BYTEORDER == SDL_BIG_ENDIAN
//#define SDLNet_Write16(value, areap)	\
//do 					\
//{					\
//	Uint8 *area = (Uint8 *)(areap);	\
//	area[0] = (value >>  8) & 0xFF;	\
//	area[1] =  value        & 0xFF;	\
//} while ( 0 )
//#else
//#define SDLNet_Write16(value, areap)	\
//do 					\
//{					\
//	Uint8 *area = (Uint8 *)(areap);	\
//	area[1] = (value >>  8) & 0xFF;	\
//	area[0] =  value        & 0xFF;	\
//} while ( 0 )
//#endif
//#endif /* !SDL_DATA_ALIGNED */
//
//		/* Write a 32 bit value to network packet buffer */
//#if !SDL_DATA_ALIGNED
//#define SDLNet_Write32(value, areap) 	\
//		*(Uint32 *)(areap) = SDL_SwapBE32(value);
//#else
//#if SDL_BYTEORDER == SDL_BIG_ENDIAN
//#define SDLNet_Write32(value, areap) 	\
//do					\
//{					\
//	Uint8 *area = (Uint8 *)(areap);	\
//	area[0] = (value >> 24) & 0xFF;	\
//	area[1] = (value >> 16) & 0xFF;	\
//	area[2] = (value >>  8) & 0xFF;	\
//	area[3] =  value       & 0xFF;	\
//} while ( 0 )
//#else
//#define SDLNet_Write32(value, areap) 	\
//do					\
//{					\
//	Uint8 *area = (Uint8 *)(areap);	\
//	area[3] = (value >> 24) & 0xFF;	\
//	area[2] = (value >> 16) & 0xFF;	\
//	area[1] = (value >>  8) & 0xFF;	\
//	area[0] =  value       & 0xFF;	\
//} while ( 0 )
//#endif
//#endif /* !SDL_DATA_ALIGNED */
//
//		/* Read a 16 bit value from network packet buffer */
//#if !SDL_DATA_ALIGNED
//#define SDLNet_Read16(areap) 		\
//		(SDL_SwapBE16(*(Uint16 *)(areap)))
//#else
//#if SDL_BYTEORDER == SDL_BIG_ENDIAN
//#define SDLNet_Read16(areap) 		\
//	((((Uint8 *)areap)[0] <<  8) | ((Uint8 *)areap)[1] <<  0)
//#else
//#define SDLNet_Read16(areap) 		\
//	((((Uint8 *)areap)[1] <<  8) | ((Uint8 *)areap)[0] <<  0)
//#endif
//#endif /* !SDL_DATA_ALIGNED */
//
//		/* Read a 32 bit value from network packet buffer */
//#if !SDL_DATA_ALIGNED
//#define SDLNet_Read32(areap) 		\
//		(SDL_SwapBE32(*(Uint32 *)(areap)))
//#else
//#if SDL_BYTEORDER == SDL_BIG_ENDIAN
//#define SDLNet_Read32(areap) 		\
//	((((Uint8 *)areap)[0] << 24) | (((Uint8 *)areap)[1] << 16) | \
//	 (((Uint8 *)areap)[2] <<  8) |  ((Uint8 *)areap)[3] <<  0)
//#else
//#define SDLNet_Read32(areap) 		\
//	((((Uint8 *)areap)[3] << 24) | (((Uint8 *)areap)[2] << 16) | \
//	 (((Uint8 *)areap)[1] <<  8) |  ((Uint8 *)areap)[0] <<  0)
//#endif
        //#endif /* !SDL_DATA_ALIGNED */
        #endregion Not Yet implemented
    }
}
