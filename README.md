SyncServer
==========

At this point, the server is providing IP sync <a href="https://github.com/orensharon/SyncServer/tree/master/SyncService">services</a>.
The first <a href="https://github.com/orensharon/SyncServer/blob/master/SyncService/IPSync.cs">servicee</a> waits for messages from PC clients and store the IP of the sender.
Another <a href="https://github.com/orensharon/SyncServer/blob/master/SyncService/IPGetter.cs">service</a> will waiting for a connection from Android clients. 
The server will send the IP address  to the Android clients.
