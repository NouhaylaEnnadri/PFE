var editor = document.getElementById("editor");

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/text")
    .build();
connection.start().catch(err => console.error(err));

connection.on("ReceiveText", (text) => {
    editor.value = text;
    editor.focus();
   editor.setSelectionRange(editor.value.length, editor.value.length);
});

function change() {
    connection.invoke("BroadcastText", editor.value).catch(err => console.error(err));
}

