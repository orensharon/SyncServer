KeepItSafe SyncServer
==========

The server is providing login and IP sync services.<br/><br/>
The first sevice is <a href="https://github.com/orensharon/SyncServer/tree/master/UserLogin">Login service</a> - waits for clients to login.<br />
The second <a href="https://github.com/orensharon/SyncServer/blob/master/SyncService/IPSync.cs">service</a> waits for messages from PC clients and store the IP of the sender.<br/>
The last <a href="https://github.com/orensharon/SyncServer/blob/master/SyncService/IPGetter.cs">service</a> waiting for a connection from Android clients and sends the IP address to them.
