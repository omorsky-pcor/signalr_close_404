document.addEventListener("DOMContentLoaded", () => {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub/chat?x=abc", {
      transport: signalR.HttpTransportType.ServerSentEvents,
      headers: {
        "x-custom-header": "abc"
      }
    })
    .build();

  connection.on("ReceiveMessage", (data) => {
    const li = document.createElement("li");
    li.textContent = data;
    document.getElementById("messageList").appendChild(li);
  });

  document.getElementById("send").addEventListener("click", async () => {
    const subject = new signalR.Subject();

    var sendTask = connection.send("SendMessage", subject, "text");
    subject.next("Hello");
    subject.complete();
    await sendTask;
    await connection.stop();
  });

  document.getElementById("stop").addEventListener("click", async () => {
    await connection.stop();
  });


  async function start() {
      await connection.start();
      console.log("SignalR Connected.");
  }
  start();
});
