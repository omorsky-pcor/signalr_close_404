document.addEventListener("DOMContentLoaded", () => {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub/chat?x=abc", {
      transport: signalR.HttpTransportType.ServerSentEvents,
      headers: {
        "x-custom-header": "abc"
      }
    })
    .build();

  document.getElementById("stop").addEventListener("click", async () => {
    await connection.stop();
  });
  async function start() {
      await connection.start();
      console.log("SignalR Connected.");
  }
  start();
});
