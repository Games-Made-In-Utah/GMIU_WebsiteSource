// Credits to https://www.geeksforgeeks.org/read-json-file-using-javascript/ & https://stackoverflow.com/questions/18238173/javascript-loop-through-json-array
// BIG thanks for the help!

var filters = ["", "", "", ""];
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

                if (filters[0] == "" && filters[1] == "" && filters[2] == "" && filters[3] == "") { collection.append(html); }
                else {
                    var releaseCheck = (filters[0] == "");
                    var publisherCheck = (filters[1] == "");
                    var priceCheck = (filters[2] == "");
                    var genreCheck = (filters[3] == "");

                    if (releaseCheck == false) for (x in game.tags) if (filters[0].toLowerCase() == game.tags[x].toLowerCase()) { releaseCheck = true; break; }
                    if (publisherCheck == false) for (x in game.tags) if (filters[1].toLowerCase() == game.tags[x].toLowerCase()) { publisherCheck = true; break; }
                    if (priceCheck == false) for (x in game.tags) if (filters[2].toLowerCase() == game.tags[x].toLowerCase()) { priceCheck = true; break; }
                    if (genreCheck == false) {
                        var genres = filters.slice(3);

                        for (g in genres) {
                            genreCheck = false;
                            for (x in game.tags) if (genres[g].toLowerCase() == game.tags[x].toLowerCase()) { genreCheck = true; break; }
                            if (genreCheck == false) break;
                        }
                    }

                    if (releaseCheck == true && publisherCheck == true && priceCheck == true && genreCheck == true) collection.append(html);
                }
            })
            .catch((error) =>
                console.error("Unable to show game: ", error));
    }
}

function filterGames(filter, type) {
    switch (type) {
        case "release":
            filters[0] = filter;
            break;
        case "publisher":
            filters[1] = filter;
            break;
        case "price":
            filters[2] = filter;
            break;
        case "genre":
            filters = filters.slice(0, 3);
            for (g in filter) filters.push(filter[g]);
            if (filter.length == 0) filters.push("");
            break;
        default:
            filters = ["", "", "", ""];
            break;
    }

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