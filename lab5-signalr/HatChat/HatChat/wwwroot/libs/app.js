(function() {
    var btnSend = $('#btnSend');
    var tbxMsg = $('#tbxMsg');
    var username = $('#username').val();
    var listChat = $('#listChat');

    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    $(btnSend).click(function() {
        sendMsg();
    });

    $('.form-control').keypress(function (e) {
        if (e.which == 13) {
            sendMsg();
            return false;
        }
    });

    function sendMsg() {
        var msg = $(tbxMsg).val();
        connection.invoke('SendMessage',
            {
                username: username,
                message: msg
            });
        $(tbxMsg).val('');
    }

    connection.on('ReceivedMessage',
        function (obj) {
            var chatRow = '<li>'
                + '<span class="text-success">'+ '[' + obj.formattedTimeStamp + ']' + '</span>'
                + '<span class="text-danger font-weight-bold"> '+ obj.username +':' + '</span>'
                + '   ' + obj.message
                + '</li>';
            $(listChat).prepend(chatRow);
        });

    connection.on('UserSignedIn',
        function (obj) {
            var chatRow = '<li>' + '<span class="text-success font-weight-bold">' + obj + ' is logged in' + '</span>';
            $(listChat).prepend(chatRow);
        });

    connection.start().then(function() {
        console.log("connected");
        connection.invoke('SignInUser', username);
    });

})();