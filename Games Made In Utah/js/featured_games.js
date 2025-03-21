
function stringToHTML(text) {
    let parser = new DOMParser();
    let doc = parser.parseFromString(text, 'text/html');
    return doc.body;
}

function NewFeaturedGames(games) {
    games.sort(() => Math.random() - 0.5)

    for (let i = 0; i < 3; i++) {
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
    
                    let collection = document.querySelector("#featured_games")
                    collection.append(html)
                })
                .catch((error) =>
                    console.error("Unable to show game: ", error));
        }
}

function GrabGames() {
    fetch("/data/game_list.json")
    .then((res) => {
        if (!res.ok) {
            throw new Error
                (`HTTP error! Status: ${res.status}`);
        }
        return res.json();
    })
    .then((data) => {
        NewFeaturedGames(data);
    })
    .catch((error) =>
        console.error("Unable to fetch data:", error));
}

GrabGames()