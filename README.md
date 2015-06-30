KeepItSafe SyncServer
==========

At this point, the server is providing IP sync <a href="https://github.com/orensharon/SyncServer/tree/master/SyncService">services</a>.<br/>
The first sevice is <a href="https://github.com/orensharon/SyncServer/tree/master/UserLogin">Login service</a> - waits for clients to login.<br />
The second <a href="https://github.com/orensharon/SyncServer/blob/master/SyncService/IPSync.cs">service</a> waits for messages from PC clients and store the IP of the sender.
and another <a href="https://github.com/orensharon/SyncServer/blob/master/SyncService/IPGetter.cs">service</a> will waiting for a connection from Android clients. 
The server sending the IP address to the Android clients.
