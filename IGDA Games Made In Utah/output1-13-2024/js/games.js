// Credits to https://www.geeksforgeeks.org/read-json-file-using-javascript/ & https://stackoverflow.com/questions/18238173/javascript-loop-through-json-array
// BIG thanks for the help!

var filters = [""];
var gameData = null;

function stringToHTML(text) {
    let parser = new DOMParser();
    let doc = parser.parseFromString(text, 'text/html');
    return doc.body;
}

function showGames(games) {
    let collection = document.querySelector("#games");
    collection.innerHTML = "";

    for (let i = 0; i < games.length; i++) {
        let game = games[i]

        fetch('/game.html')
            .then((res) => {
                if (!res.ok) {
                    throw new Error
                        (`HTTP error! Status: ${res.status}`);
                }
                return res.text();
            })
            .then((text) => {
                let html = stringToHTML(text);
                html = html.querySelector("div")

                let title = html.querySelector("#title")
                let developer = html.querySelector("#developer")
                let description = html.querySelector("#description")
                let image = html.querySelector("#image")
                let link = html.querySelector("#link")

                title.textContent = game.title;
                developer.textContent = game.developer;
                description.textContent = game.description;
                image.setAttribute("src", game.image);
                image.setAttribute("alt", game.imageAlt);
                link.setAttribute("href", game.link);

                if (filters[0] == "") { collection.append(html); }
                else {
                    var shown = false;

                    for (i in filters) {
                        for (x in game.tags) {
                            if (game.tags[x].toLowerCase() == filters[i].toLowerCase()) {
                                shown = true;
                                break;
                            }
                            else shown = false;
                        }

                        if (shown == false) break;
                    }

                    if (shown == true) collection.append(html);
                }
            })
            .catch((error) =>
                console.error("Unable to show game: ", error));
    }
}

function filterGames(selection) {
    if (selection.value == "") filters = [""];
    else { filters = []; filters.push(selection.value); }
    console.log(filters[0])
    showGames(gameData);
}

function fetchGames() {
    fetch("/data/game_list.json")
        .then((res) => {
            if (!res.ok) {
                throw new Error
                    (`HTTP error! Status: ${res.status}`);
            }
            return res.json();
        })
        .then((data) => {
            gameData = data;
            showGames(gameData);
        })
        .catch((error) =>
            console.error("Unable to fetch data:", error));
}

fetchGames();