// Credits to https://www.geeksforgeeks.org/read-json-file-using-javascript/
// Thanks for the help!

let games = null;

function setGames(data) { games = data; console.log(games); }

function fetchGames() {
    fetch("/data/games.json")
        .then((res) => {
            if (!res.ok) {
                throw new Error
                    (`HTTP error! Status: ${res.status}`);
            }
            return res.json();
        })
        .then((data) => {
            setGames(data);
            console.log(data);
        })
        .catch((error) =>
            console.error("Unable to fetch data:", error));
}

fetchGames();