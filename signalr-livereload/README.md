# SignalR Live Reload #

## Setup

In *your* project that uses SignalR, add the following hub:

    [HubName("liveReload")]
    public class LiveReloadHub : Hub
    {
        public void ReloadAllClients()
        {
            Clients.Others.reload();
        }
    }

Then, add the relevant markup to your Razor layout:

    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/Scripts/jquery.signalR-1.0.1.min.js"></script>
    <script src="/signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {
            var hub = $.connection.liveReload;

            hub.client.reload = function () {
                document.location.reload(true);
            };

            $.connection.hub.start().done(function () {
                console.log("live reload ready");
            });
        });
    </script>

## Running the sample
* Make sure scriptcs is [installed](https://github.com/scriptcs/scriptcs-samples/blob/master/README.md)
* Install packages `scriptcs -install`
* Run `scriptcs start.csx`
* Edit `config.json` and fill in the blanks.
* Run `scriptcs start.csx` again.
