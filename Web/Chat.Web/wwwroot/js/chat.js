var connection =
    new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

connection.on("NewMessage",
    function (message) {
        var chatInfo = `<div>[${message.user}] ${message.text}</div>`;
        $("#messages-list").append(chatInfo);
    });

$("#send-button").click(function () {
    var message = $("#message-input").val();
    console.log(message);
    connection.invoke("Send", message);
    $("#message-input").val('');
});

connection.start()
    .catch(function (err) {
        return console.error(err.toString());
    });