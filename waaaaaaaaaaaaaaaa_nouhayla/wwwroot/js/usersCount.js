//client side : 



//create connection for our SignalR Hub (server)
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/usersCount").build();

//connect to methods that hub invokes aka recieve notifications from hub

connectionUserCount.on("update", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
})

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
})

//invoke hub methods aka send notification to hub


function newWindowLoadedOnClient() {
    connectionUserCount.invoke("NewWindowLoaded").then((value) => console.log(value));
    //---> by using invoke we can capture whatever is returned by the Hub and use it 
    //connectionUserCount.invoke("NewWindowLoaded") ;
    
}
//start connection
function fulfilled() {
    //do something on start
    console.log("Connection to User Hub Successful");
    //Total views in action, its going to increment whenever a new user loads the window or whenever a user refreches the page
    newWindowLoadedOnClient(); 
}

function rejected() {
    //rejected logs
}

connectionUserCount.start().then(fulfilled, rejected);

