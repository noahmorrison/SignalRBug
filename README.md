# SignalRBug
Bug might be a strong term, I probably just don't know what I'm doing


Building
--------

Should just work &trade; with VSCode

Issue
-----

Sending complex types (in this case the class PingClass) sends with null fields.

Output
~~~
Ping type Ping: Hello
Ping type None: 
Ping (Hello) == None (): False
~~~

Expected Outout
~~~
Ping type Ping: Hello
Ping type Ping: Hello
Ping (Hello) == Ping (Hello): True
~~~


Sending happens in [Startup.cs](./SignalRBug/Startup.cs#L40)
